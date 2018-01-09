using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {

    [SampleCode("Chapter 6")]
    class Section02  {
        [ListNo("List-6-2")]
        public void InitializeList01() {
            var numbers = Enumerable.Repeat(-1, 20)
                        .ToList();
            foreach (var num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        [ListNo("List-6-3")]
        public void InitializeList02() {
            var strings = Enumerable.Repeat("(unknown)", 12) 
                        .ToArray();
            foreach (var s in strings)
                Console.Write("{0} ", s);
            Console.WriteLine();

        }

        [ListNo("List-6-4")]
        public void InitializeList03() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = -1;
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        [ListNo("List-6-5")]
        public void InitializeList04() {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++) {
                numbers.Add(-1);
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        [ListNo("List-6-6")]
        public void InitializeList05() {
            var array = Enumerable.Range(1, 20)
                                  .ToArray();
            foreach (var num in array)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        [ListNo("List-6-7")]
        public void InitializeList06() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = i + 1;
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        [ListNo("List-6-8")]
        public void SaInitializeList07() {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++) {
                numbers.Add(i + 1);
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }
    }
}
