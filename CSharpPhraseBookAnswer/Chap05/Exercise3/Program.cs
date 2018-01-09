using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        // 5.3.1
        private static void Exercise3_1(string text) {
            int spaces = text.Count(c => c == ' ');
            Console.WriteLine("공백 수:{0}", spaces);
        }

        // 5.3.2
        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        // 5.3.3
        private static void Exercise3_3(string text) {
            int count = text.Split(' ').Length;
            Console.WriteLine("단어 수:{0}", count);
        }

        // 5.3.4
        private static void Exercise3_4(string text) {
            var words = text.Split(' ')
                            .Where(s => s.Length <= 4);
            foreach (var word in words)
                Console.WriteLine(word);
        }

        // 5.3.5
        private static void Exercise3_5(string text) {
            var array = text.Split(' ')
                            .ToArray();
            if (array.Length > 0) {
                var sb = new StringBuilder(array[0]);
                foreach (var word in array.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(word);
                }
                var clone = sb.ToString();
                Console.WriteLine(clone);
            }
        }
    }
}
