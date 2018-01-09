using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 10")]
    class SampleCode  {

        [ListNo("List 10-1")]
        public void IsMatch01() {
            var text = "private List<string> results = new List<string>();";
            bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            if (isMatch)
                Console.WriteLine("찾았습니다.");
            else
                Console.WriteLine("찾지 못했습니다.");
        }

        [ListNo("List 10-2")]
        public void IsMatch02() {
            var text = "private List<string> results = new List<string>();";
            var regex = new Regex(@"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            if (isMatch)
                Console.WriteLine("찾았습니다.");
            else
                Console.WriteLine("찾지 못했습니다.");
        }

        [ListNo("List 10-3")]
        public void StartWith() {
            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch(text, @"^using");
            if (isMatch)
                Console.WriteLine("'using'으로 시작됩니다.");
            else
                Console.WriteLine("'using'으로 시작되지 않습니다.");
        }

        [ListNo("List 10-4")]
        public void EndWith() {
            var text = "Regex 클래스를 사용해서 문자열을 처리하는 방법을 설명합니다.";
            bool isMatch = Regex.IsMatch(text, @"합니다.$");
            if (isMatch)
                Console.WriteLine("'합니다.'로 끝납니다.");
            else
                Console.WriteLine("'합니다.'로 끝나지 않습니다.");
        }


        [ListNo("List 10-5")]
        public void PerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            var regex = new Regex(@"^(W|w)indows$");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}행과 일치", count);
        }

        [ListNo("List 10-6")]
        public void BadPerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            var regex = new Regex(@"(W|w)indows");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}행과 일치", count);
        }

        [ListNo("List 10-7")]
        public void PerfectMatch02() {
            var strings = new[] { "13000", "-50.6", "0.123",  "+180.00",
                "10.2.5", "320-0851", " 123", "$1200", "500원", };
            var regex = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
            foreach (var s in strings) {
                var isMatch = regex.IsMatch(s);
                if (isMatch)
                    Console.WriteLine(s);
            }
        }
    }
}
