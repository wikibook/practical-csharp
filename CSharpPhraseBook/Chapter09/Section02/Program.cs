using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            if (!Directory.Exists(@"C:\Example")) {
                Console.WriteLine("실행하려면 C:\\Example 폴더가 존재해야 합니다.");
                return;
            }
            SampleCodeRunner.Run();
        }
    }


    [SampleCode("Chapter 9")]
    class SampleCode  {

        [ListNo("List 9-12")]
        public void WriteTextFile() {
            var filePath = @"C:\Example\고향의봄.txt";
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("나의 살던 고향은");
                writer.WriteLine("꽃피는 산골");
                writer.WriteLine("복숭아꽃 살구꽃");
                writer.WriteLine("아기 진달래");
            }
            DisplayLines(@"C:\Example\고향의봄.txt");
        }

        [ListNo("List 9-13")]
        public void AppendTextFile() {
            var lines = new[] { "====", "울긋불긋 꽃대궐", "차리인 동네", };
            var filePath = @"C:\Example\고향의봄.txt";
            using (var writer = new StreamWriter(filePath, append: true)) {
                foreach (var line in lines)
                    writer.WriteLine(line);
            }
            DisplayLines(@"C:\Example\고향의봄.txt");
        }

        [ListNo("List 9-14")]
        public void WriteAllLinesSample() {
            var lines = new[] { "Seoul", "New Delhi", "Bangkok", "London", "Paris", };
            var filePath = @"C:\Example\Cities.txt";
            File.WriteAllLines(filePath, lines);

            DisplayLines(filePath);
        }

        [ListNo("List 9-15")]
        public void WriteResultOFQuerySample() {
            var names = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var filePath = @"C:\Example\Cities.txt";
            File.WriteAllLines(filePath, names.Where(s => s.Length > 5));

            DisplayLines(filePath);
        }


        [ListNo("List 9-16")]
        public void InsertLines() {
            var originalFilePath = @"C:\Example\고향의봄.txt";
            var filePath = @"C:\Example\고향의봄2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream)) {
                    string texts = reader.ReadToEnd();
                    stream.Position = 0;
                    writer.WriteLine("삽입할 새 행1");
                    writer.WriteLine("삽입할 새 행2");
                    writer.Write(texts);
                }
            }
            DisplayLines(filePath);
        }

        [ListNo("List 9-17")]
        public void InsertLines2() {
            var originalFilePath = @"C:\Example\고향의봄.txt";
            var filePath = @"C:\Example\고향의봄2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            string texts = "";
            // 파일을 모두 읽어들인다
            using (var reader = new StreamReader(filePath)) {
                texts = reader.ReadToEnd();
            }
            // 일단 닫는다

            // 파일을 다시 열어서 출력 처리를 실행한다
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("삽입할 새 행1");
                writer.WriteLine("삽입할 새 행2");
                writer.Write(texts);
            }
            DisplayLines(filePath);
        }

        private static void DisplayLines(string filePath) {
            var xlines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in xlines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }


    }
}
