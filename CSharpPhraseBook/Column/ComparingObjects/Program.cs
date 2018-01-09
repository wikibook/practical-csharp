using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 5장 '[Column] 오브젝트끼리 비교할 때'에서 나온 코드입니다.

namespace ComparingObjects {

    class Program {
        static void Main(string[] args) {
            Compare01();
            Compare02();
            Compare03();
            Console.ReadLine();
        }

        private static void Compare01() {
            int a = GetCurrentValue();
            int b = GetNextValue();
            if (a == b) {
                // a와 b는 같다 
                Console.WriteLine("a와 b는 같다(1)");
            }
            DateTime d1 = GetMyBirthday();
            DateTime d2 = GetYourBirthday();
            if (d1 == d2) {
                // d1와 d2는 같은 날짜, 같은 시각이다 
                Console.WriteLine("a와 b는 같다(2)");
            }
        }

        private static DateTime GetYourBirthday() {
            return new DateTime(1995,8,5);
        }

        private static DateTime GetMyBirthday() {
            return new DateTime(1995, 8, 5);
        }

        private static int GetNextValue() {
            return 12345;
        }

        private static int GetCurrentValue() {
            return 12345;
        }

        private static void Compare02() {
            {
                Sample a = new Sample { Num = 1, Str = "C#" };
                Sample b = new Sample { Num = 1, Str = "C#" };
                if (a == b) {
                    // a와 b는 메모리 상에서 각각 별도로 확보된 오브젝트이므로
                    // 이 부분에 작성된 코드는 실행되지 않는다
                    Console.WriteLine("a와 b는 같다(3)");
                }
            }
            {
                Sample a = new Sample { Num = 1, Str = "C#" };
                Sample b = a;
                if (a == b) {
                    // a와 b는 메모리 상에서 동일한 오브젝트를 참조하므로
                    // 이 부분에 작성된 코드가 실행된다
                    Console.WriteLine("a와 b는 같다(4)");
                }
            }
        }


        private static void Compare03() {
            var str1 = GetCurrentWord();
            // "Hello"가 반환된다 
            var str2 = GetNextWord();
            // 다른 영역에 확보된 "Hello"가 반환된다 
            if (str1 == str2) {
                // 참조형을 비교하는 것이 아니고 값을 비교하는 것이므로 메모리 상의 서로 다른 곳에 있는 "Hello"이지만   
                // 같다고 판정되어 이 부분에 있는 코드가 실행된다 
                Console.WriteLine("str1과 str2는 같다.");
            }
        }

        private static string GetNextWord() {
            return "Hello";
        }

        private static string GetCurrentWord() {
            return new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
        }


    }


    class Sample {
        public int Num { get; set; }

        public string Str { get; set; }

    }
}
