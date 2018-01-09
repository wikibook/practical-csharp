using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            // 생성자를 호출한다
            var abbrs = new Abbreviations();

            // Add 메서드를 호출한 예
            abbrs.Add("IOC", "국제 올림픽 위원회");
            abbrs.Add("NPT", "핵확산방지조약");

            // 7.2.3 (Count를 호출한 예)
            // 위에 나온 Add 메서드에서 두 개의 오브젝트를 추가했으므로 읽어들인 단어 수+2가 Count의 값이 된다
            var count = abbrs.Count;
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();

            // 7.2.3 (Remove를 호출한 예)
            if (abbrs.Remove("NPT"))
                Console.WriteLine(abbrs.Count);
            if (!abbrs.Remove("NPT"))
                Console.WriteLine("삭제할 수 없습니다.");
            Console.WriteLine();

            // 7.2.4
            // IEnumerable<>를 구현했으므로 LINQ를 사용할 수 있다
            foreach (var item in abbrs.Where(x => x.Key.Length == 3))
                Console.WriteLine("{0}={1}", item.Key, item.Value);
        }
    }
}
