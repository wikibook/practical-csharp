using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            // Today는 static 속성
            DateTime today = DateTime.Today;

            // Console은 static클래스, WriteLine은 static메서드
            Console.WriteLine("오늘은 {0}월{1}일입니다.", today.Month, today.Day);

        }
    }
}
