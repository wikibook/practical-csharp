using System;

namespace Section02 {

    // List 7-14
    class MonthDay {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public MonthDay(int month, int day) {
            this.Month = month;
            this.Day = day;
        }

        // MonthDay끼리 비교한다
        public override bool Equals(object obj) {
            var other = obj as MonthDay;
            if (other == null)
                throw new ArgumentException();
            return this.Day == other.Day && this.Month == other.Month;
        }

        // 해시 코드를 구한다
        public override int GetHashCode() {
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }

    }
}