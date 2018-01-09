using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();

        }
    }

    [SampleCode("Chapter 9")]
    class SampleCode  {

        [ListNo("List 9-59")]
        public void GetTempFileName() {
            var tempFileName = Path.GetTempFileName();
            Console.WriteLine(tempFileName);
        }

        [ListNo("List 9-60")]
        public void GetTempPath() {
            var tempPath = Path.GetTempPath();
            Console.WriteLine(tempPath);
        }

        [ListNo("List 9-61")]
        public void SpecialFolders() {  
            // "바탕 화면" 폴더를 구한다
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(desktopPath);
            // "내 문서" 폴더를 구한다
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(myDocumentsPath);
            // 프로그램 파일 폴더를 구한다
            var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            Console.WriteLine(programFilesPath);
            // Windows 폴더를 구한다
            var windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            Console.WriteLine(windowsPath);
            // 시스템 폴더를 구한다
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Console.WriteLine(systemPath);
        }

    }
}
