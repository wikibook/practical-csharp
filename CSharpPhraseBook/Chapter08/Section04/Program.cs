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
    [SampleCode("Chapter 8")]
    class SampleCode  {
        [ListNo("List 8-16")]
        public  void AddTimeSpan() {
            var now = DateTime.Now;
            var future = now + new TimeSpan(1, 30, 0);
            Console.WriteLine(future);
        }

        [ListNo("List 8-17")]
        public  void SubtractTimeSpan() {
            var now = DateTime.Now;
            var past = now - new TimeSpan(1, 30, 0);
            Console.WriteLine(past);
        }

        [ListNo("List 8-18")]
        public  void AddDays() {
            var today = DateTime.Today;
            var future = today.AddDays(20);
            var past = today.AddDays(-20);
            Console.WriteLine(future);
            Console.WriteLine(past);
        }

        [ListNo("List 8-19")]
        public  void AddYearsMonths() {
            var date = new DateTime(2009, 10, 22);
            var future = date.AddYears(2).AddMonths(5);
            Console.WriteLine(future);
        }

        [ListNo("List 8-20")]
        public  void DiffDatetime() {
            var date1 = new DateTime(2009, 10, 22, 1, 30, 20);
            var date2 = new DateTime(2009, 10, 22, 2, 40, 56);
            TimeSpan diff = date2 - date1;
            Console.WriteLine("두 시각의 차는 {0}일 {1}시간 {2}분 {3}초입니다.",
                              diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            Console.WriteLine("총 {0}초입니다.", diff.TotalSeconds);
        }

        [ListNo("List 8-21")]
        public  void DiffDays() {
            var dt1 = new DateTime(2016, 1, 20, 23, 0, 0);
            var dt2 = new DateTime(2016, 1, 21, 1, 0, 0);
            TimeSpan diff = dt2.Date - dt1.Date;
            Console.WriteLine("{0}일간", diff.Days);
        }

        [ListNo("List 8-22")]
        public  void BadDiffDays() {
            var dt1 = new DateTime(2016, 1, 20, 23, 0, 0);
            var dt2 = new DateTime(2016, 1, 21, 1, 30, 0);
            TimeSpan diff = dt2 - dt1;
            Console.WriteLine("{0}일간", diff.Days);
        }

        [ListNo("List 8-23")]
        public  void GetEndOfMonth() {
            var today = DateTime.Today;
            // 해당 월에 몇일이 있는지를 구한다
            int day = DateTime.DaysInMonth(today.Year, today.Month);
            // 이 day를 사용해서 DateTime 오브젝트를 생성한다. endOfMonth가 해당 월의 말일이다
            var endOfMonth = new DateTime(today.Year, today.Month, day);
            Console.WriteLine(endOfMonth);
        }

        [ListNo("List 8-24")]
        // 
        public  void GetTotalDays() {
            var today = DateTime.Today;
            int dayOfYear = today.DayOfYear;
            Console.WriteLine(dayOfYear);
        }

        [ListNo("List 8-25")]
        public  void BadTotalDays() {
            var today = DateTime.Today;
            var baseDate = new DateTime(today.Year, 1, 1).AddDays(-1);
            TimeSpan ts = today - baseDate;
            Console.WriteLine(ts.Days);
        }

    }
}
