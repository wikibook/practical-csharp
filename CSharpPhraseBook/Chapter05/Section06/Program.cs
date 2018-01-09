using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 5")]
    class SampleCode  {
        [ListNo("List 5-42")]
        public void GetChars() {
            var str = "C#프로그래밍";
            foreach (var c in str)
                Console.Write("[{0}]", c);
            Console.WriteLine();
        }

        [ListNo("List 5-43")]
        public void BadGetChars() {
            string str = "구문으로 배우는 C#";
            for (int i = 0; i < str.Length; i++) {
                char c = str[i];
                Console.Write("[{0}]", c);     // 편의상 두 행으로 나눴다
            }
            Console.WriteLine();
        }

        [ListNo("List 5-44")]
        public void CreateFromCharArray() {
            var chars = new char[] { 'P', 'r', 'o', 'g', 'r', 'a', 'm' };
            var str = new string(chars);  
            Console.WriteLine(str);
        }


        [ListNo("List 5-45")]
        public void CreateFromCharArray2() {
            var target = "Novelist\t=\t김만중";
            var chars = target.SkipWhile(c => c != '=')
                              .Skip(1)
                              .Where(c => !char.IsWhiteSpace(c))
                              .ToArray();　
            var str = new string(chars);

        }

        [ListNo("List 5-46")]
        public void ToStringSample() {
            int number = 12345;
            //int number = 0;
            var s1 = number.ToString();             //  "12345"
            var s2 = number.ToString("#");          //  "12345"
            var s3 = number.ToString("0000000");    //  "0012345"
            var s4 = number.ToString("#,0");        //  "12,345"

            decimal distance = 9876.123m;
            //decimal distance = 0m;
            var s5 = distance.ToString();           //  "9876.123"
            var s6 = distance.ToString("#");        //  "9876"
            var s7 = distance.ToString("#,0.0");    //  "9,876.1"
            var s8 = distance.ToString("#,0.0000"); //  "9,876.1230"

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
        }

        [ListNo("List 5-47")]
        public void FormatSample() {
            int number = 12345;
            var s1 = string.Format("{0,10}", number);       // "     12345"
            var s2 = string.Format("{0,10:#,0}", number);   // "    12,345"

            decimal distance = 9876.543m;
            var s3 = string.Format("{0,10}", distance);     // "  9876.543"
            var s4 = string.Format("{0,10:0.0}", distance); // "    9876.5"

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
        }

        [ListNo("List 5-48")]
        public void FormatSample2() {
            var number = 12345;
            var s1 = $"{number:#,0}";      // "12,345"
            var s2 = $"{number:0000000}";  // "0012345"
            var s3 = $"{number,8}";        // "   12345"
            var s4 = $"{number,8:#,0}";    // "  12,345"

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
        }

        [ListNo("List 5-49")]
        public void FormatSample3() {
            var novelist = "김만중";
            var bestWork = "구운몽";
            var bookline = String.Format("Novelist={0};BestWork={1}", novelist, bestWork);

            //var bookline = "Novelist=" + novelist + ";BestWork=" + bestWork;
            Console.WriteLine(bookline);
        }

        [ListNo("List 5-51")]
        public void FormatSample4() {
            var article = 12;
            var clause = 5;
            var header = String.Format("제{0,2}조{1,2}항", article, clause);
            Console.WriteLine("[{0}]", header);
        }


        [ListNo("List 5-52")]

        public void FormatSample5() {
            var novelist = "김만중";
            var bestWork = "구운몽";
            var bookline = $"Novelist={novelist};BestWork={bestWork}";
            Console.WriteLine(bookline);

            var article = 12;
            var clause = 5;
            var header = $"제{article,2}조{clause,2}항";
            Console.WriteLine("[{0}]", header);
        }


    }
}
