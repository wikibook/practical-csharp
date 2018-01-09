using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise6 {
    class Program {
        static void Main(string[] args) {
            var text = "기러기 국제경제국 다들잠들다 너구리 시집간집시 토마토 건조할조건";
            var pattern = @"\b(\w)(\w)\w\2\1\b";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }
    }
}
