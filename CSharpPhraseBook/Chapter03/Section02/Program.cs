using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 3")]
    class SampleCode  { 
        public  int Count(int[] numbers, Predicate<int> judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }
            return count;
        }

        public  void Step0() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            Predicate<int> judge =
                  (int n) => {
                      if (n % 2 == 0)
                          return true;
                      else
                          return false;
                  };
            var count = Count(numbers, judge);
            Console.WriteLine(count);

        }

        public void Step1() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers,
              (int n) => {
                  if (n % 2 == 0)
                      return true;
                  else
                      return false;
              }
            );
            Console.WriteLine(count);

        }

        public void Step2() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, (int n) => { return n % 2 == 0; });
            Console.WriteLine(count);

        }

        public void Step3() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, (int n) => n % 2 == 0);
            Console.WriteLine(count);

        }

        public void Step4() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, (n) => n % 2 == 0);
            Console.WriteLine(count);

        }

        public void Step5() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, n => n % 2 == 0);
            Console.WriteLine(count);
        }

        public void Sample() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count1 = Count(numbers, n => n % 2 == 1);
            Console.WriteLine(count1);

            var count2 = Count(numbers, n => n >= 5);
            Console.WriteLine(count2);

            var count3 = Count(numbers, n => 5 <= n && n < 10);
            Console.WriteLine(count3);

            var count4 = Count(numbers, n => n.ToString().Contains('1'));
            Console.WriteLine(count4);

        }
    }
}
