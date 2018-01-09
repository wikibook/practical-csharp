using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-toi")
                PrintMeterToInchList(1, 10);
            else
                PrintInchToMeterList(1, 10);
        }

        // 피트에서 미터로의 환산표를 출력
        static void PrintInchToMeterList(int start, int stop) {
            for (int feet = start; feet <= stop; feet++) {
                double meter = InchConverter.ToMeter(feet);
                Console.WriteLine("{0} inch = {1:0.0000} m", feet, meter);
            }
        }

        // 미터에서 피트로의 환산표를 출력
        static void PrintMeterToInchList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double feet = InchConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} inch", meter, feet);
            }
        }
    }
}
