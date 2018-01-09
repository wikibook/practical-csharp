using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 5")]
    class SampleCode  {
        [ListNo("List 5-22")]
        public void IndexOf() {
            var target = "Novelist=김만중;BestWork=구운몽"; ;
            var index = target.IndexOf("BestWork=");
            Console.WriteLine(index);
        }

        [ListNo("List 5-23")]
        public void Substring() {
            var target = "Novelist=김만중;BestWork=구운몽";
            var value = "BestWork=";
            var index = target.IndexOf("BestWork=") + value.Length;
            var bestWork = target.Substring(index);
            Console.WriteLine(bestWork);
        }

        [ListNo("List 5-24")]
        public void Substring2() {
            var target = "Novelist=김만중;BestWork=구운몽;Born=1687";
            var value = "BestWork=";
            var startIndex = target.IndexOf("BestWork=") + value.Length;
            var endIndex = target.IndexOf(";", startIndex);
            var bestWork = target.Substring(startIndex, endIndex - startIndex);
            Console.WriteLine(bestWork);
        }

        [ListNo("List 5-25")]
        // マジックナンバーを使ったコード
        public void Substring3() {
            var target = "Novelist=김만중;BestWork=구운몽";
            var index = target.IndexOf("BestWork=") + 9;
            var bestWork = target.Substring(index);
            Console.WriteLine(bestWork);
        }

    }
}
