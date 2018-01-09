using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }
    [SampleCode("Chapter 8")]
    class SampleCode  {
        [ListNo("List 8-26")]
        public void SampleNextDay() {
            Console.WriteLine(NextDay(DateTime.Now, DayOfWeek.Friday));
            Console.WriteLine(NextDay(DateTime.Now, DayOfWeek.Monday));
        }

        // List 8-26
        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }

        [ListNo("List 8-27")]
        public void SampleGetAge() {
            var birthday = new DateTime(1992, 4, 5);
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            Console.WriteLine(age);
        }

        // List 8-27
        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        [ListNo("List 8-28")]
        public void SampleNthWeek() {
            var date = DateTime.Today;
            var nth = NthWeek(date);  
            Console.WriteLine("{0}주째", nth);
        }

        // List 8-28
        public static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

        [ListNo("List 8-29")]
        public void SampleDayOfNthWeek() {
            DateTime day = DayOfNthWeek(2016, 9, DayOfWeek.Sunday, 3);
            Console.WriteLine(day);
            DateTime day1 = DayOfNthWeek(2017, 1, DayOfWeek.Sunday, 5);
            Console.WriteLine(day1);
            // 해당 날이 존재하지 않으면 예외가 발생한다
            // DateTime day2 = DayOfNthWeek(2017, 1, DayOfWeek.Wednesday, 5);
            // Console.WriteLine(day2);
        }

        // List 8-29
        public static DateTime DayOfNthWeek(int year, int month, DayOfWeek dayOfWeek, int nth) {
            // LINQ를 사용해서 첫 번째 X요일이 몇일인지를 구한다
            var firstDay = Enumerable.Range(1, 7)
                                     .Select(d => new DateTime(year, month, d))
                                     .First(d => d.DayOfWeek == dayOfWeek)
                                     .Day;
            // 첫 번째 X요일의 날짜에 7의 배수를 더하면 n번째 X요일을 구할 수 있다
            var day = firstDay + (nth - 1) * 7;
            return new DateTime(year, month, day);
        }


        [ListNo("List 8-30")]
        public void SampleDayOfNthWeek2() {
            DateTime day = DayOfNthWeek2(2016, 9, DayOfWeek.Sunday, 3);
            Console.WriteLine(day);
            DateTime day1 = DayOfNthWeek(2017, 1, DayOfWeek.Sunday, 5);
            Console.WriteLine(day1);
        }

        // List 8-30
        public static DateTime DayOfNthWeek2(int year, int month, DayOfWeek dayOfWeek, int nth) {
            // 해당 월의 1일이 무슨 요일인지를 구한다
            var firstDayOfWeek = (int)(new DateTime(year, month, 1)).DayOfWeek;
            // 이렇게 구한 firstDayOfWeek를 사용해서 첫 번째 X요일의 날짜를 구한다
            var firstDay = 1 + ((int)dayOfWeek - firstDayOfWeek);
            // 0보다 작으면 7을 더해서 첫 번째 X요일의 날짜를 알 수 있다
            if (firstDay <= 0)
                firstDay += 7;
            // 첫 번째 X요일의 날짜에 7의 배수를 더하면 n번째 X요일을 구할 수 있다
            var day = firstDay + (nth - 1) * 7;
            return new DateTime(year, month, day);
        }
    }
}
