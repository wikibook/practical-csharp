using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var file = args[0];
            Pickup3DigitNumber(file);
        }

        private static void Pickup3DigitNumber(string file) {
            foreach (var line in File.ReadLines(file)) {
                var matches = Regex.Matches(line, @"\b\d{3,}\b");
                foreach (Match m in matches) {
                    Console.WriteLine(m.Value);
                }
            }
        }
    }
}
