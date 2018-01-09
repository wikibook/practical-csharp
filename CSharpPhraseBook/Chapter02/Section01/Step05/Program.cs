// List 2-6

using System;

namespace DistanceConverter {
    class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom")
                PrintFeetToMeterList(1, 10);
            else
                PrintMeterToFeetList(1, 10);
        }

        // 피트에서 미터로의 환산표를 출력
        static void PrintFeetToMeterList(int start, int stop) {
            FeetConverter converter = new FeetConverter();
            for (int feet = start; feet <= stop; feet++) {
                double meter = converter.ToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        // 미터에서 피트로의 환산표를 출력
        static void PrintMeterToFeetList(int start, int stop) {
            FeetConverter converter = new FeetConverter();
            for (int meter = start; meter <= stop; meter++) {
                double feet = converter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
            }
        }

    }
}
