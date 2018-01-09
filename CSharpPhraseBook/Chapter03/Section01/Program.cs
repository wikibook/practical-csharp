using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    // 범용성이 없는 Count 메서드의 예
    [SampleCode("Chapter 3")]
    class SampleCode {
        [ListNo("List 3-1")]
        public void Do() {
            int count = Count(5);
            Console.WriteLine(count);
        }

        // List 3-1
        public int Count(int num) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            int count = 0;
            foreach (var n in numbers) {
                if (n == num)
                    count++;
            }
            return count;
        }
    }

    // 배열을 인수로 받는 Count 메서드
    [SampleCode("Chapter 3")]
    class Step02 {
        [ListNo("List 3-2")]
        public void Do() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, 5);
            Console.WriteLine(count);
        }

        // List 3-2
        public int Count(int[] numbers, int num) {
            int count = 0;
            foreach (var n in numbers) {
                if (n == num)
                    count++;
            }
            return count;
        }

    }

    // 델리게이트를 받아들이는 Count 메서드
    [SampleCode("Chapter 3")]
    class Step03 {
        // List 3-3
        public delegate bool Judgement(int value);

        public int Count(int[] numbers, Judgement judge) {
            int count = 0;
            foreach (var n in numbers) {
                // 인수로 받은 메서드를 호출한다
                if (judge(n) == true)
                    count++;
            }
            return count;
        }

        [ListNo("List 3-3, 3-4")]
        // List 3-4
        public void Do() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            Judgement judge = IsEven;
            var count = Count(numbers, judge);
            Console.WriteLine(count);
        }

        // n이 짝수인지 조사한다
        public bool IsEven(int n) {
            return n % 2 == 0;
        }


    }

    [SampleCode("Chapter 3")]
    class Step04 {
        public delegate bool Judgement(int value);

        [ListNo("List 3-5")]
        // List 3-5
        // 델리게이트를 받아들이는 Count 메서드를 이용한 예(2)
        public void Do() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, IsEven);
            Console.WriteLine(count);
        }

        // n이 짝수인지 조사한다
        public bool IsEven(int n) {
            return n % 2 == 0;
        }

        public int Count(int[] numbers, Judgement judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }
            return count;
        }

    }

    // 익명 메서드를 이용한 예
    [SampleCode("Chapter 3")]
    class Step05 {
        // List 3-6
        public int Count(int[] numbers, Predicate<int> judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }
            return count;
        }

        [ListNo("List 3-6")]
        public void Do() {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };
            var count = Count(numbers, delegate (int n) { return n % 2 == 0; });
            Console.WriteLine(count);
        }

    }
}
