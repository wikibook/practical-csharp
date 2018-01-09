using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter04;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Exercise2_2(ymCollection);
            Console.WriteLine("----");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("----");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        // 4.2.3
        static YearMonth FindFirst21C(YearMonth[] yms) {
            foreach (var ym in yms) {
                if (ym.Is21Century)
                    return ym;
            }
            return null;
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            var yearmonth = FindFirst21C(ymCollection);
            if (yearmonth == null)
                Console.WriteLine("21세기 데이터는 없습니다.");
            else
                Console.WriteLine(yearmonth);


            // 또는 다음과 같이 쓸 수도 있다
            Console.WriteLine("----");
            var yearmonth2 = FindFirst21C(ymCollection);
            var s = yearmonth2 == null ? "21세기 데이터가 없습니다." : yearmonth2.ToString();
            Console.WriteLine(s);
        }


        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(ym => ym.AddOneMonth())
                                    .ToArray();
            foreach (var ym in array) {
                Console.WriteLine(ym);
            }
        }
    }

}
