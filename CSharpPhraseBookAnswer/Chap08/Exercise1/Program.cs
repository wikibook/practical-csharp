using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var dateTime = new DateTime(2019, 1, 15, 19, 48, 32);
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            // 2019/1/15 19:48 
            var str = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            Console.WriteLine(str);
        }
        private static void DisplayDatePattern2(DateTime dateTime) {
            // 2019년01월15일 19시48분32초 
            var str = dateTime.ToString("yyyy년MM월dd일 HH시mm분ss초");
            Console.WriteLine(str);
        }
        private static void DisplayDatePattern3(DateTime dateTime) {
            // 평성31년 1월15일(화요일)
            // 연도도 두 자리수 고정으로 하고 0을 추가할 경우에는 조금 더 연구해야 한다
            // DisplayDatePattern3_2에서 그 일례를 보여준다
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str = string.Format("{0}年{1,2}月{2,2}日({3})", datestr, dateTime.Month, dateTime.Day, dayOfWeek);
            Console.WriteLine(str);
        }

        // 10장에서 설명하는 Regex 클래스를 이용해서 0을 추가하면 목적한 결과를 얻을 수 있다
        // 연도도 두 자리수 고정으로 하고 0을 추가할 수 있다
        private static void DisplayDatePattern3_2(DateTime dateTime) {
            // 다음과 같이 구현했을 경우에는 결과가 달라진다
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            // dddd로 '일요일'과 같은 문자열을 얻을 수 있다
            var dateStr = dateTime.ToString("ggyy年MM月dd日(dddd)", culture); 
            var str = Regex.Replace(dateStr, @"0(\d)", " $1");
            Console.WriteLine(str);
        }
    }
}

