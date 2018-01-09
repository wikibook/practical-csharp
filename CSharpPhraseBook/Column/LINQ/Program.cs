using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 15장 '[Column] Zip 메서드 사용법'과
// '[Column] LINQ에 있는 집합 연산자'에서 나온 코드입니다

namespace LINQ {
    class Program {
        static void Main(string[] args) { 
            ZipSample();
            Console.WriteLine();

            UnionSample();
            IntersectSample();
            ExceptSample();

            Console.ReadLine();
        }

        static void ZipSample() {
            var jWeeks = new List<string> {
               "월", "화", "수", "목", "금", "토", "일"
            };
                        var eWeeks = new List<string> {
               "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"
            };
            var weeks = jWeeks.Zip(eWeeks,
                                       (s1, s2) => string.Format("{0}({1})", s1, s2));
            weeks.ToList().ForEach(Console.WriteLine);
        }

        static void UnionSample() {
            var animals1 = new[] { "기린", "사자", "코끼리", "얼룩말", "팬더", };
            var animals2 = new[] { "사자", "코알라", "기린", "고릴라", };
            var union = animals1.Union(animals2);
            foreach (var name in union)
                Console.Write($"{name} ");
            Console.WriteLine();
        }

        static void IntersectSample() {
            var animals1 = new[] { "기린", "사자", "코끼리", "얼룩말", "팬더", };
            var animals2 = new[] { "사자", "코알라", "기린", "고릴라", };
            var intersect = animals1.Intersect(animals2);
            foreach (var name in intersect)
                Console.Write($"{name} ");
            Console.WriteLine();
        }

        static void ExceptSample() {
            var animals1 = new[] { "기린", "사자", "코끼리", "얼룩말", "팬더", };
            var animals2 = new[] { "사자", "코알라", "기린", "고릴라", };
            var expect = animals1.Except(animals2);
            foreach (var name in expect)
                Console.Write($"{name} ");
            Console.WriteLine();
        }



    }
}
