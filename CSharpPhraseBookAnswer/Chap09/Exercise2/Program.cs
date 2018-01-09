using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0)
                return;
            var file = args[0];
            var outputPath = Numbering(file);

            Display(outputPath);
        }

        private static string Numbering(string file) {
            var lines = File.ReadLines(file)
                            .Select((s, n) => string.Format("{0,4}: {1}", n+1, s));
            var path = Path.ChangeExtension(file, ".txt");
            File.WriteAllLines(path, lines);
            return path;
        }

        // 확인용 코드
        private static void Display(string outputPath) {
            var text = File.ReadAllText(outputPath);
            Console.WriteLine(text);
        }
    }
}
