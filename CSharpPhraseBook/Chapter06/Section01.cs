using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    class Section01 : SampleCodeRunner {
        [ListNoAttribute("List-12-123")]
        void Sample01() {
            var numbers = Enumerable.Repeat(-1, 20)
                        .ToList();
            foreach (var num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }
        [ListNoAttribute("List-12-123")]
        void Sample02() {
            var strings = Enumerable.Repeat("(unknown)", 12) 
                        .ToArray();
            foreach (var s in strings)
                Console.Write("{0} ", s);
            Console.WriteLine();

        }

        [ListNoAttribute("List-12-123")]
        void Sample03() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = -1;
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        void Sample04() {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++) {
                numbers.Add(-1);
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        void Sample05() {
            var array = Enumerable.Range(1, 20)
                                  .ToArray();
            foreach (var num in array)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }
        void Sample06() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = i + 1;
            }
            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        void Sample07() {
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
