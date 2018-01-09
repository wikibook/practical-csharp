using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// 10장 '[Column] 대문자/소문자를 구별하지 않고 매칭시킨다'
// '[Column] 행의 시작 지점과 행의 끝 지점의 의미를 변경해서 여러 행 모드로 바꾼다'에 나온 코드입니다

namespace RegexOptionsSample {
    class Program {
        static void Main(string[] args) {
            IgnoreCase();
            Multiline();
            Console.ReadLine();
        }

        // List 10-13
        private static void IgnoreCase() {
            var text = "kor, KOR, Kor";
            var mc = Regex.Matches(text, @"\bjpn\b", RegexOptions.IgnoreCase);
            foreach (Match m in mc) {
                Console.WriteLine(m.Value);
            }
        }

        // List 10-14
        private static void Multiline() {
            var text = "Word\nExcel\nPowerPoint\nOutlook\nOneNote\n";
            var pattern = @"^[a-zA-Z]{5,7}$";
            var matches = Regex.Matches(text, pattern, RegexOptions.Multiline);
            foreach (Match m in matches) {
                Console.WriteLine("{0} {1}", m.Index, m.Value);
            }
        }

    }
}
