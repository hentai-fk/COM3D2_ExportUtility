using COM3D2_ExportUtility.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace COM3D2_ExportUtility
{
    internal class NativeLoader
    {
        private static string ExtractAndLoad(string name, byte[] source)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), name);
            File.WriteAllBytes(tempPath, source);

            // 手动加载这个 DLL
            IntPtr handle = LoadLibrary(tempPath);
            if (handle == IntPtr.Zero)
                throw new Exception("无法加载本机 DLL：" + tempPath);

            return tempPath;
        }

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public static void EnsureNativeLoaded()
        {
            ExtractAndLoad("cm3d2.dll", Resources.cm3d2);
        }
    }
}
