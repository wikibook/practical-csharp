using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            {
                var dt = new DateTime(2017, 1, 1);
                foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                    Console.Write("{0:yy/MM/dd}의 다음 주의 {1}: ", dt, (DayOfWeek)dayofweek);
                    Console.WriteLine("{0:yy/MM/dd(ddd)}", NextWeek(dt, (DayOfWeek)dayofweek));
                }
            }
            Console.WriteLine();
            {
                var dt = new DateTime(2017, 4, 30);
                foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                    Console.Write("{0:yy/MM/dd}의 다음 주의{1}: ", dt, (DayOfWeek)dayofweek);
                    Console.WriteLine("{0:yy/MM/dd(ddd)}", NextWeek(dt, (DayOfWeek)dayofweek));
                }
            }
        }

        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            return nextweek.AddDays(days);
        }
    }
}
