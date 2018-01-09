using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1)
                return;
            var file1 = args[0];
            var file2 = args[1];
            Concat(file1, file2);

            Display(file1);
        }

        // 이것이 가장 간결한 코드이다
        // 조사하면 분명히 간단한 방법을 찾아낼 수 있다
        private static void Concat(string file1, string file2) {
            File.AppendAllLines(file1, File.ReadLines(file2));
        }

        // 이렇게 구현할 수도 있다
        private static void Concat2(string file1, string file2) {
            using (var dest = new StreamWriter(file1, append:true, encoding:Encoding.UTF8)) {
                var lines = File.ReadLines(file2);
                foreach (var line in lines)
                    dest.WriteLine(line);
            }
        }

        // 확인용 코드
        private static void Display(string outputPath) {
            var text = File.ReadAllText(outputPath);
            Console.WriteLine(text);
        }
    }
}

