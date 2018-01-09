using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0402 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-10")]
        public void Idiom01() { 
            var age = 10;
            if (age <= 10) {
                Console.WriteLine("10세 이하입니다.");
            }
        }

        [ListNo("List 4-11, 4-12")]
        public void Idiom02() { 
            var num = 55;
            if (50 <= num && num <= 100) {
                Console.WriteLine("범위 안에 있습니다.");
            }

            // List 4-12
            if (num >= 50 && num <= 100) {
                Console.WriteLine("범위 안에 있습니다.");
            }

        }

        [ListNo("List 4-13")]
        public void Idiom03() {
            Console.Write("수치를 입력해주세 =>");
            var line = Console.ReadLine();
            int num = int.Parse(line);
            if (num > 80) {
                Console.WriteLine("A급입니다.");
            } else if (num > 60) {
                Console.WriteLine("B급입니다.");
            } else if (num > 40) {
                Console.WriteLine("C급입니다.");
            } else {
                Console.WriteLine("D급입니다.");
            }

            // List 4-14 
            //if (num > 80) 
            //    Console.WriteLine("A급입니다.");
            //else 
            //    if (num > 60) 
            //        Console.WriteLine("B급입니다.");
            //    else 
            //        if (num > 40) 
            //            Console.WriteLine("C급입니다.");
            //        else 
            //            Console.WriteLine("D급입니다.");
            

        }

        [ListNo("List 4-16")]
        public void Idiom04() {
            int? num = 10;
            if (num.HasValue)
                Console.WriteLine("값을 기다립니다.");
        }

        [ListNo("List 4-17")]
        public void Idiom05() {
            var b = ReturnBoolSample();
            Console.WriteLine(b);
        }
        
        private bool ReturnBoolSample() {
            Console.Write("Hello 라고 입력해주세요 =>");
            var line = Console.ReadLine();
            // List 4-17
            return line == "Hello";
        }
    }
}
