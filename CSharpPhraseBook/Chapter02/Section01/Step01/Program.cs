// List 2-1

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            // 피트에서 미터로의 환산표표를 출력한다
            for (int feet = 1; feet <= 10; feet++) {
                double meter = feet * 0.3048;
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }
    }
}
