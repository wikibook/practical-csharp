using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 8")]
    class SampleCode  {

        [ListNo("List 8-9")]
        public void VariousToString() {
            var date = new DateTime(2017, 10, 22, 21, 6, 47);
            var s1 = date.ToString("d");                           // 2017-10-22
            var s2 = date.ToString("D");                           // 2017년 10월 22일 일요일
            var s3 = date.ToString("yyyy-MM-dd");                  // 2017-10-22
            var s4 = date.ToString("yyyy년M월d일(ddd)");           // 2017년10월22일(일)
            var s5 = date.ToString("yyyy년MM월dd일 HH시mm분ss초"); // 2017년10월22일 21시06분47초
            var s6 = date.ToString("f");                           // 2017년 10월 22일 일요일 오후 9:06
            var s7 = date.ToString("F");                           // 2017년 10월 22일 일요일 오후 9:06:47
            var s8 = date.ToString("t");                           // 오후 9:06
            var s9 = date.ToString("T");                           // 오후 9:06:47
            var s10 = date.ToString("tt hh:mm");                   // 오후 09:06
            var s11 = date.ToString("HH시mm분ss초");               // 21시06분47초


            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine(s9);
            Console.WriteLine(s10);
            Console.WriteLine(s11);
        }

        [ListNo("List 8-10")]
        public void Format() {
            var today = DateTime.Today;
            var str = string.Format("{0}년{1,2}월{2,2}일",
                                    today.Year, today.Month, today.Day);
            Console.WriteLine(str);
        }

        [ListNo("List 8-11")]
        public void JapaneseCalendar() {
            var date = new DateTime(2016, 8, 15);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = date.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str);
            var str2 = date.ToString("gg", culture);
            Console.WriteLine(str2);
            var str3 = date.ToString("ddd", culture);
            Console.WriteLine(str3);
        }

        [ListNo("List 8-12")]
        public void GetEraName() {
            var date = new DateTime(1995, 8, 24);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            Console.WriteLine(eraName);
        }

        [ListNo("List 8-13")]
        public void KoreanDayOfWeek() {
            var date = new DateTime(1998, 6, 25);
            var culture = new CultureInfo("ko-KR");
            culture.DateTimeFormat.Calendar = new KoreanCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            Console.WriteLine(dayOfWeek);

            var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(date.DayOfWeek);
            Console.WriteLine(shortDayOfWeek);
        }

    }
}
