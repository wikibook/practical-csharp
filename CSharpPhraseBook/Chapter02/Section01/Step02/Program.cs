// List 2-2

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            // 피트에서 미터로의 환산표를 출력한
            for (int feet = 1; feet <= 10; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0} f = {1:0.0000} m", feet, meter);
            }
        }

        // 피트를 미터로 환산한다
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }
    }
}
