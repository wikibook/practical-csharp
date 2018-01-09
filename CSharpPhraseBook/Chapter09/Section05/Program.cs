using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 9")]
    class SampleCode  {
        [ListNo("List 9-54")]
        public void SplitPath() {
            var path = @"C:\Program Files\Microsoft Office\Office16\EXCEL.EXE";
            var directoryName = Path.GetDirectoryName(path);
            var fileName = Path.GetFileName(path);
            var extension = Path.GetExtension(path);
            var filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            var pathRoot = Path.GetPathRoot(path);

            Console.WriteLine("DirectoryName : {0}", directoryName);
            Console.WriteLine("FileName : {0}", fileName);
            Console.WriteLine("Extension : {0}", extension);
            Console.WriteLine("FilenameWithoutExtension : {0}", filenameWithoutExtension);
            Console.WriteLine("PathRoot : {0}", pathRoot);
        }

        [ListNo("List 9-55")]
        public void GetFullPath() {
            var fullPath = Path.GetFullPath(@"..\Greeting.txt");
            Console.WriteLine(fullPath);
        }


        [ListNo("List 9-56")]
        public void BuildPath() {
            var dir = @"C:\Example\Temp";
            var fname = "Greeting.txt";
            var path = Path.Combine(dir, fname);
            Console.WriteLine(path);
        }

        [ListNo("List 9-58")]
        public void BuildPath2() {
            var topdir = @"C:\Example\";
            var subdir = @"Temp";
            var fname = "Greeting.txt";
            var path = Path.Combine(topdir, subdir, fname);
            Console.WriteLine(path);
        }
    }
}
