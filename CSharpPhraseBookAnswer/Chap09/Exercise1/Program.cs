using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0)
                return;
            var file = args[0];

            Console.WriteLine($"{Path.GetFullPath(file)}에 관해서 조사합니다.");
            Excrcice1_1(file);
            Excrcice1_2(file);
            Excrcice1_3(file);
        }

        private static void Excrcice1_1(string file) {
            var count = 0;
            using (var sr = new StreamReader(file)) {
                while (!sr.EndOfStream) {
                    var line = sr.ReadLine();
                    if (line.Contains(" class "))
                        count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void Excrcice1_2(string file) {
            var count = File.ReadAllLines(file)
                            .Count(s => s.Contains(" class "));
            Console.WriteLine(count);
        }
        private static void Excrcice1_3(string file) {
            var count = File.ReadLines(file)
                            .Count(s => s.Contains(" class "));
            Console.WriteLine(count);
        }
    }
}
