using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0403 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-18")]
        public void Idiom01() {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (var i = 0; i < 5; i++) {
                Console.WriteLine(items[i]);
            }

            // List 4-19
            //int i = 0;
            //while (i < 5) {
            //    Console.WriteLine(items[i]);
            //    i++;
            //}

        }

        [ListNo("List 4-20")]
        public void Idiom02() {
            var collection = new[] { 1, 2, 3, 4, 5, 6 };
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
        }


        [ListNo("List 4-21")]
        public void Idiom03() {
            var nums = new List<int> { 1, 2, 3, 4, 5 };
            nums.ForEach(n => Console.Write("[{0}] ", n));

            Console.WriteLine();
            nums.ForEach(Console.WriteLine);
        }

        [ListNo("List 4-22")]
        public void Idiom04() {
            Console.WriteLine("빈 행을 입력하면 종료됩니다.");
            bool finish;
            do {
                finish = DoSomething();
            } while (!finish);
        }

        static bool DoSomething() {
            var line = Console.ReadLine();
            var finish = string.IsNullOrEmpty(line);
            Console.WriteLine(line.ToString());
            return finish;
        }

        [ListNo("List 4-23")]
        public void Idiom05() {
            var items = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var line = "";
            foreach (var item in items) {
                if (line.Length + item.Length > 40)
                    break;
                line += item;
            }
            Console.WriteLine(line);
        }


        [ListNo("List 4-24")]
        public void Idiom06() {
            Console.WriteLine(ReturnIdiom());
        }

        // List 4-24
        private int ReturnIdiom() {
            var numbers = new int[] { 123, 98, 4653, 1234, 54, 9854 };
            foreach (var n in numbers) {
                if (n > 1000)
                    return n;
            }
            return -1;
        }

    }

}
