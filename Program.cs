using COM3D2_ExportUtility;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

internal class Program
{
    static bool configKS;
    static bool configNEI;
    static bool configTEX;
    static bool configOGG;
    static bool configOther;

    static void Main(string[] args)
    {
        NativeLoader.EnsureNativeLoaded();

        // 解析命令行参数
        while (true)
        {
            Console.WriteLine("按下数字键导出选定的文件类型，按下回车键开始导出: ");
            Console.WriteLine("1. 导出 .ks  文件: 已" + (configKS ? "启用" : "禁用"));
            Console.WriteLine("2. 导出 .csv 文件: 已" + (configNEI ? "启用" : "禁用"));
            Console.WriteLine("3. 导出 .png 文件: 已" + (configTEX ? "启用" : "禁用"));
            Console.WriteLine("4. 导出 .ogg 文件: 已" + (configOGG ? "启用" : "禁用"));
            Console.WriteLine("5. 导出 其它 文件: 已" + (configOther ? "启用" : "禁用"));
            Console.WriteLine("6. 导出 所有 文件");

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
            {
                configKS = !configKS;
                Console.WriteLine("\n导出 .ks 文件: " + (configKS ? "启用" : "禁用") + "\n");
            }
            else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
            {
                configNEI = !configNEI;
                Console.WriteLine("\n导出 .csv 文件: " + (configNEI ? "启用" : "禁用") + "\n");
            }
            else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
            {
                configTEX = !configTEX;
                Console.WriteLine("\n导出 .png 文件: " + (configTEX ? "启用" : "禁用") + "\n");
            }
            else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)
            {
                configOGG = !configOGG;
                Console.WriteLine("\n导出 .ogg 文件: " + (configOGG ? "启用" : "禁用") + "\n");
            }
            else if (key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.NumPad5)
            {
                configOther = !configOther;
                Console.WriteLine("\n导出 其它 文件: " + (configOther ? "启用" : "禁用") + "\n");
            }
            else if (key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.NumPad6)
            {
                configKS = true;
                configNEI = true;
                configTEX = true;
                configOGG = true;
                configOther = true;
                Console.WriteLine("\n导出 所有 文件: 已设置\n");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
        }

        string baseDirectory = ".";
        string outputDirectory = Path.Combine(baseDirectory, "OutputDirectory");

        Console.WriteLine("搜索目录: " + baseDirectory);
        Console.WriteLine("输出目录: " + outputDirectory);

        foreach (var arc in Directory.GetFiles(baseDirectory, "*.arc", SearchOption.AllDirectories))
        {
            if (!arc.StartsWith(baseDirectory, StringComparison.OrdinalIgnoreCase))
                continue;
            var outputRel = outputDirectory + arc.Substring(baseDirectory.Length, arc.Length - 4 - baseDirectory.Length);

            Console.WriteLine("\n加载档案: " + arc);

            var fs = new FileSystemArchive();
            fs.AddArchive(arc);
            var list = fs.GetFileListAtExtension("*");

            Console.WriteLine($"发现 {list.Count()} 项结果");

            foreach (var item in list)
            {
                var outputAbs = Path.Combine(outputRel, item);
                var arcItemName = Encoding.Default.GetString(Encoding.UTF8.GetBytes(item));

                if (configKS && outputAbs.EndsWith(".ks", StringComparison.OrdinalIgnoreCase))
                {
                    Directory.CreateDirectory(Directory.GetParent(outputAbs)!.FullName);
                    OutputKs(fs, arcItemName, outputAbs);
                }
                else if (configNEI && outputAbs.EndsWith(".nei", StringComparison.OrdinalIgnoreCase))
                {
                    Directory.CreateDirectory(Directory.GetParent(outputAbs)!.FullName);
                    outputAbs = outputAbs.Substring(0, outputAbs.Length - 4) + ".csv";
                    OutputNei(fs, arcItemName, outputAbs);
                }
                else if (configTEX && outputAbs.EndsWith(".tex", StringComparison.OrdinalIgnoreCase))
                {
                    Directory.CreateDirectory(Directory.GetParent(outputAbs)!.FullName);
                    outputAbs = outputAbs.Substring(0, outputAbs.Length - 4) + ".png";
                    OutputTex(fs, arcItemName, outputAbs);
                }
                else if (configOGG && outputAbs.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase))
                {
                    Directory.CreateDirectory(Directory.GetParent(outputAbs)!.FullName);
                    OutputNei(fs, arcItemName, outputAbs);
                }
                else if (configOther)
                {
                    Directory.CreateDirectory(Directory.GetParent(outputAbs)!.FullName);
                    OutputOther(fs, arcItemName, outputAbs);
                }
                else
                {
                    continue;
                }

                Console.WriteLine("导出文件: " + outputAbs);
            }

            fs.Dispose();
        }
    }

    static void OutputKs(FileSystemArchive fs, string filename, string outputAbs)
    {
        using (var fd = fs.FileOpen(filename))
        {
            using (var output = new StreamWriter(File.Open(outputAbs, FileMode.Create), Encoding.UTF8))
            {
                if (fd.IsValid())
                    output.Write(NUty.SjisToUnicode(fd.ReadAll()));
            }
        }
    }

    static void OutputNei(FileSystemArchive fs, string filename, string outputAbs)
    {
        using (var fd = fs.FileOpen(filename))
        {
            CSVUtils.SaveArray2CSVFile(outputAbs, CSVUtils.LoadFromFileNei(fd));
        }
    }

    static void OutputTex(FileSystemArchive fs, string filename, string outputAbs)
    {
        using (var fd = fs.FileOpen(filename))
        {
            using (var output = File.Open(outputAbs, FileMode.Create))
            {
                if (!fd.IsValid())
                    return;
                using var image = ImportCM.LoadTextureFile(fd, true).CreateTexture2D();
                image?.SaveAsPng(output);
            }
        }
    }

    static void OutputOther(FileSystemArchive fs, string filename, string outputAbs)
    {
        using (var fd = fs.FileOpen(filename))
        {
            using (var output = File.Open(outputAbs, FileMode.Create))
            {
                if (!fd.IsValid())
                    return;
                var buffer = fd.ReadAll();
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
