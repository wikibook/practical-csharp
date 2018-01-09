using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 5")]
    class SampleCode  {
        [ListNo("List 5-26")]
        public void Trim1() {
            var target = "   non-whitespace characters   ";
            var replaced = target.Trim();
            Console.WriteLine("[{0}]", replaced);
        }

        [ListNo("List 5-28")]
        public void Trim2() {
            var target = "   non-whitespace characters   ";
            var replaced1 = target.TrimStart();
            var replaced2 = target.TrimEnd();
            Console.WriteLine("[{0}]\n[{1}]", replaced1, replaced2);
        }

        [ListNo("List 5-29")]
        public void Remove() {
            var target = "01234ABC567";
            var result = target.Remove(5, 3);
            Console.WriteLine(result);
        }


        [ListNo("List 5-30")]
        public void Insert() {
            var target = "01234";
            var result = target.Insert(2, "abc");
            Console.WriteLine(result);
        }

        [ListNo("List 5-31")]
        public void Replace() {
            var target = "I hope you could come with us.";
            var replaced = target.Replace("hope", "wish");
            Console.WriteLine(replaced);
        }


        [ListNo("List 5-32")]
        public void ToUpper() {
            var target = "The quick brown fox jumps over the lazy dog.";
            var replaced = target.ToUpper();
            Console.WriteLine(replaced);
        }



    }
}
