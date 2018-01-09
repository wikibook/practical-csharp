using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine();
            Exercise2_2(names);
            Console.WriteLine();
            Exercise2_3(names);
            Console.WriteLine();
            Exercise2_4(names);
        }

        static void Exercise2_1 (List<string> names) {
            Console.WriteLine("도시 이름을 입력합니다. 빈 행을 입력하면 종료합니다.");
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                var index = names.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);
        }

        static void Exercise2_2(List<string> names) {
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);
        }

        static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o'))
                                .ToArray();
            foreach (var name in selected)
                Console.WriteLine(name);
        }

        static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith("B"))
                                .Select(s => s.Length);
            foreach (var length in selected)
                Console.WriteLine(length);
        }
    }
}
