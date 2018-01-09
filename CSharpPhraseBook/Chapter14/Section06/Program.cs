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
    [SampleCode("Chapter 14")]
    class SampleCode {
        [ListNo("List 14-25")]
        public void LocalTimeAndUniversalTime() {
            // 현지 시각을 구한다
            var now = DateTimeOffset.Now;
            Console.WriteLine("Now = {0}", now);
            // UTC(협정세계시)로 변환한다
            var utc = now.ToUniversalTime();
            Console.WriteLine("UTC = {0}", utc);
            // UTC(협정세계시)를 현지 시각으로 변환한다
            var localTime = utc.ToLocalTime();
            Console.WriteLine("LocalTime = {0}", localTime);
        }


        [ListNo("List 14-26")]
        public void LocalTimeAndUniversalTime2() {
            // 현지 시각을 구한다
            var now = DateTimeOffset.Now;
            // UTC(협정 세계시)로 변환한다
            var utc = now.ToUniversalTime();
            // 현재 시각과 이것을 변환한 UTC를 비교한다
            if (now == utc)
                Console.WriteLine("'{0}' == '{1}'", now, utc);
            else
                Console.WriteLine("'{0}' != '{1}'", now, utc);
        }


        [ListNo("List 14-27")]
        public void StringToDateTimeOffset() {
            DateTimeOffset time;
            if (DateTimeOffset.TryParse("2016/03/26 1:07:21 +09:00", out time)) {
                Console.WriteLine("{0} | {1}", time, time.ToUniversalTime());
            }
        }

        [ListNo("List 14-28")]
        public void FindSystemTimeZoneById() {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            Console.WriteLine("Utc와의 차             {0}", tz.BaseUtcOffset);
            Console.WriteLine("시간대 ID              {0}", tz.Id);
            Console.WriteLine("정식 이름              {0}", tz.DisplayName);
            Console.WriteLine("표준시의 정식 이름     {0}", tz.StandardName);
            Console.WriteLine("썸머타임 정식 이름     {0}", tz.DaylightName);
            Console.WriteLine("썸머타임을 실시하는가? {0}", tz.SupportsDaylightSavingTime);
        }

        [ListNo("List 14-29")]
        public void GetSystemTimeZones() {
            // 시간대 Id의 목록을 구한다
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timeZones)
                Console.WriteLine("'{0}' - '{1}'", timezone.Id, timezone.DisplayName);
        }


        [ListNo("List 14-30")]
        public void ConvertTime() {
            DateTimeOffset utc = DateTimeOffset.UtcNow;
            var timezone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            // 예를 들어 위와 같은 코드로 TimeZoneInfo가 얻어진다
            //……
            DateTimeOffset time = TimeZoneInfo.ConvertTime(utc, timezone);
            Console.WriteLine("India Standard Time {0} {1}", time, time.Offset);
        }

        [ListNo("List 14-31")]
        public void ConvertTime2() {
            DateTimeOffset utc = DateTimeOffset.UtcNow;
            var ist = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utc, "India Standard Time");
            Console.WriteLine("India Standard Time {0} {1}", ist, ist.Offset);
        }

        [ListNo("List 14-32")]
        public void ConvertTimeBySystemTimeZoneId() {
            // 지역 시각(한국 시간)을 구한다
            var local = new DateTime(2017, 10, 12, 11, 20, 0);
            // DateTimeOffset으로 변환한다
            var date = new DateTimeOffset(local);
            // "Pacific Standard Time" 시각으로 변환한다
            DateTimeOffset pst = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, "Pacific Standard Time");
            Console.WriteLine(pst);
        }

        [ListNo("List 14-33")]
        public void ConvertTimeBySystemTimeZoneId2() {
            var chinatz = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            var chinaTime = new DateTimeOffset(2017, 4, 6, 9, 0, 0, chinatz.BaseUtcOffset);
            // chinaTime에 베이징 시각(DateTimeOffset)이 들어 있다
            // 이 시각을 "Hawaiian Standard Time" 시각으로 변환한다
            var hawaiiTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(chinaTime, "Hawaiian Standard Time");
            Console.WriteLine(chinaTime);
            Console.WriteLine(hawaiiTime);
        }

    }
}
