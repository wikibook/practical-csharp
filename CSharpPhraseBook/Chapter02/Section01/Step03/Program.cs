// List 2-3

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                // 피트에서 미터로의 환산표를 출력
                for (int feet = 1; feet <= 10; feet++) {
                    double meter = FeetToMeter(feet);
                    Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
                }
            } else {
                // 미터에서 피트로의 환산표를 출력
                for (int meter = 1; meter <= 10; meter++) {
                    double feet = MeterToFeet(meter);
                    Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
                }
            }
        }

        // 피트를 미터로 환산한다
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        // 미터를 피트로 환산한다
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }
}
