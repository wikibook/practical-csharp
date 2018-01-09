using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }
    [SampleCode("Chapter 5")]
    class SampleCode  {

        [ListNo("List 5-1")]
        public void ComparisonStrings() {
            var str1 = "Windows";
            var str2 = "Windows";
            if (str1 == str2)
                Console.WriteLine("일치합니다.");
        }

        [ListNo("List 5-2")]
        public void ComparisonIgnoreCase() {
            var str1 = "Windows";
            var str2 = "WINDOWS";
            if (String.Compare(str1, str2, true) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");
        }

        [ListNo("List 5-3")]
        public void ComparisonIgnoreCase2() {
            var str1 = "Windows";
            var str2 = "WINDOWS";
            if (String.Compare(str1, str2, ignoreCase: true) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");
        }

        [ListNo("List 5-4")]
        public void ComparisonIgnoreKanaType() {
            var str1 = "カステラ";
            var str2 = "かすてら";
            var cultureInfo = new CultureInfo("ja-JP");
            if (String.Compare(str1, str2, cultureInfo, CompareOptions.IgnoreKanaType) == 0)
                Console.WriteLine("일치합니다.");
        }

        [ListNo("List 5-5")]
        public void ComparisonIgnoreWidth() {
            var str1 = "HTML5";
            var str2 = "ＨＴＭＬ５";
            var cultureInfo = new CultureInfo("ja-JP");
            if (String.Compare(str1, str2, cultureInfo, CompareOptions.IgnoreWidth) == 0)
                Console.WriteLine("일치합니다.");
        }

        [ListNo("List 5-6")]
        public void ComparisonIgnoreCaseAndWidth() {
            var str1 = "Ｃｏｍｐｕｔｅｒ";
            var str2 = "COMPUTER";
            var cultureInfo = new CultureInfo("ja-JP");
            if (String.Compare(str1, str2, cultureInfo,
                               CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0)
                Console.WriteLine("일치합니다.");
        }

    }

}
