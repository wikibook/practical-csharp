using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0406 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-36")]
        public void Sample01() {
            var median1 = Median(1.0, 2.0, 3.0);
            var median2 = Median(1.0, 2.0, 3.0, 4.0, 5.0);
            Console.WriteLine(median1);
            Console.WriteLine(median2);

        }

        // List 4-36
        // 중간값을 구하는 메서드
        private double Median(params double[] args) {
            var sorted = args.OrderBy(n => n).ToArray();
            int index = sorted.Length / 2;
            if (sorted.Length % 2 == 0)
                return (sorted[index] + sorted[index - 1]) / 2;
            else
                return sorted[index];
        }

        [ListNo("List 4-37")]
        public void Sample02() {
            var time = DateTime.Now;
            var user = "idei";
            var message = "테스트입니다.";             
            WriteLog("Time:{0:f} User:{1} Message:{2}", time, user, message);
        }
        // List 4-37
        private void WriteLog(string format, params object[] args) {
            var s = String.Format(format, args);   
            // 로그 파일을 출력한다
            WriteLine(s);
        }

        private void WriteLine(string line) {
            // 더미 코드
            Console.WriteLine(line);
        }

        [ListNo("List 4-38")]
        public void Sample03() {
            DoSomething(100);
            DoSomething(100, "오류입니다.");
            DoSomething(100, "오류입니다.", 5);

        }

        // List 4-38
        private void DoSomething(int num, string message = "실패했습니다.", int retryCount = 3) {
            // 더미 코드
            Console.WriteLine("{0} {1} {2}",num, message, retryCount);
        }

    }
}
