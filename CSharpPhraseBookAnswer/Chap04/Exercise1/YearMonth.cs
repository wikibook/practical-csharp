using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 연습문제이므로 의미없는 네임스페이스를 지정했지만 본래는 적절한 이름을 지정해야 한다
//  Exercise2에서 이 프로젝트를 참조로 추가해서 이용한다
namespace Chapter04 {

    // 4.1.1
    public class YearMonth {
        public int Year { get; private set; }

        public int Month { get; private set; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        // 4.1.2
        public bool Is21Century {
            get {
                return 2001 <= Year && Year <= 2100;
            }
        }

        // 4.1.3
        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(this.Year + 1, 1);
            } else {
                return new YearMonth(this.Year, this.Month + 1);
            }
        }

        // 4.1.4
        public override string ToString() {
            return $"{Year}年{Month}月";
        }
    }
}
