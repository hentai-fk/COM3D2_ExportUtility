using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace COM3D2_ExportUtility
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SetDllDirectory("Libs");

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

                    Directory.CreateDirectory(Directory.GetParent(outputAbs).FullName);

                    if (outputAbs.EndsWith(".nei", StringComparison.OrdinalIgnoreCase))
                    {
                        outputAbs = outputAbs.Substring(0, outputAbs.Length - 4) + ".csv";
                        OutputNei(fs, arcItemName, outputAbs);
                    }
                    else
                    {
                        using (var fd = fs.FileOpen(arcItemName))
                        {
                            if (fd.IsValid())
                            {
                                if (outputAbs.EndsWith(".ks", StringComparison.OrdinalIgnoreCase))
                                {
                                    using (var output = new StreamWriter(File.OpenWrite(outputAbs), Encoding.UTF8))
                                    {
                                        output.Write(NUty.SjisToUnicode(fd.ReadAll()));
                                    }
                                }
                                else
                                {
                                    using (var output = File.OpenWrite(outputAbs))
                                    {
                                        var buffer = fd.ReadAll();
                                        output.Write(buffer, 0, buffer.Length);
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine("导出文件: " + outputAbs);
                }

                fs.Dispose();
            }
        }

        static void OutputNei(FileSystemArchive fs, string filename, string outputAbs)
        {
            using (var fd = fs.FileOpen(filename))
            {
                CSVUtils.SaveArray2CSVFile(outputAbs, CSVUtils.LoadFromFileNei(fd));
            }
        }

        [DllImport("kernel32", SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);
    }
}
