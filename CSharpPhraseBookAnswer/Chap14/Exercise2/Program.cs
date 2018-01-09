using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            PrintAssembkyVersion();
            PrintFileversion();
            Console.ReadLine();
        }

        private static void PrintAssembkyVersion() {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            Console.WriteLine("Assembly Version: {0}.{1}.{2}.{3}",
               ver.Major, ver.Minor, ver.Build, ver.Revision);
        }

        private static void PrintFileversion() {
            var location = Assembly.GetExecutingAssembly().Location;
            var ver = FileVersionInfo.GetVersionInfo(location);
            Console.WriteLine("File Version: {0}.{1}.{2}.{3}",
                              ver.FileMajorPart, ver.FileMinorPart,
                              ver.FileBuildPart, ver.FilePrivatePart);
        }
    }
}
