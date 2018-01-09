using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {

    // List 7-20
    class Program {
        static void Main(string[] args) {
            // 생성자를 호출한다
            var abbrs = new Abbreviations();

            // Add 메서드를 호출한 예
            abbrs.Add("IOC", "국제 올림픽 위원회");
            abbrs.Add("NPT", "핵확산방지조약");

            // 인덱서를 사용한 예
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}을(를) 찾을 수 없습니다.", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }
            Console.WriteLine();

            // ToAbbreviation 메서드를 이용한 예
            var japanese = "동남아시아 국가 연합";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0}을(를) 찾을 수 없습니다.", japanese);
            else
                Console.WriteLine("「{0}」의 줄임말은 {1}입니다.", japanese, abbreviation);
            Console.WriteLine();

            // FindAll 메서드를 이용한 예
            foreach (var item in abbrs.FindAll("국제")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
    }
}
