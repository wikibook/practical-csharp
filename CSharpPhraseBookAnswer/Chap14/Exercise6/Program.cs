using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6 {
    class Program {
        static void Main(string[] args) {

            // 지역 시간(한국 시간)을 구한다
            var local = new DateTime(2020, 8, 10, 16, 32, 20, DateTimeKind.Local);
            // DateTimeOffset으로 변환한다
            var date = new DateTimeOffset(local);

            var utc = date.ToUniversalTime();
            Console.WriteLine(utc);
            // "Singapore Standard Time"의 시각으로 변환한다
            DateTimeOffset sst = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date, "Singapore Standard Time");
            Console.WriteLine(sst);
        }
    }
}
