using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 14")]
    class SampleCode  {

        [ListNo("List 14-6")]
        public void AssemblyVersion() {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            Console.WriteLine("{0}.{1}.{2}.{3}",
               ver.Major, ver.Minor, ver.Build, ver.Revision);
        }

        [ListNo("List 14-7")]
        public void FileVersion() {
            var location = Assembly.GetExecutingAssembly().Location;
            var ver = FileVersionInfo.GetVersionInfo(location);
            Console.WriteLine("{0} {1} {2} {3}",
                              ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart, ver.FilePrivatePart);
        }


    }
}
