using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  19장 '[Column] 부동소수점형끼리 비교한다'에서 나온 코드입니다

namespace FloatingPointArithmetic { 

    class Program {
        static void Main(string[] args) {
            FloatingPointTest();

            DecimalTest();

            Console.ReadLine();

        }
        private static void FloatingPointTest() {
            double sum = 0.0;
            for (int i = 0; i < 10; i++)
                sum += 0.1;
            if (sum == 1.0)
                Console.WriteLine("sum == 1.0");
            else
                Console.WriteLine("sum != 1.0");

            if (Math.Abs(sum - 1.0) < 0.000001) {
                Console.WriteLine("1.0이라고 간주한다.");

            }
        }

        private static void DecimalTest() {
            decimal sum = 0m;
            // 1/3을 세 번 더한다
            for (int i = 0; i < 3; i++) {
                sum += GetDecimal();  
            }
            Console.WriteLine(sum == 1m);
        }


        static decimal GetDecimal() {
            return 1m / 3m;
        }

    }

}