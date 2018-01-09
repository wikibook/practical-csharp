using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-15
    class Program {
        static void Main(string[] args) {
            // 무한루프를 사용한다
            // 끝내려면 Ctrl+C를 누른다
            while (true) {
                var from = GetConverter("변환할 단위를 입력하세요.");
                var to = GetConverter("변화 결과 단위를 입력하세요.");
                var distance = GetDistance(from);

                var converter = new DistanceConverter(from, to);
                var result = converter.Convert(distance);
                Console.WriteLine($"{distance}{from.UnitName}는 {result:0.000}{to.UnitName}입니다.\n");
            }
        }

        static double GetDistance(ConverterBase from) {
            double? value = null;
            do {
                Console.Write($"변환하려는 거리(단위:{from.UnitName})를 입력하세요 => ");
                var line = Console.ReadLine();
                double temp;
                value = double.TryParse(line, out temp) ? (double?)temp : null;
            } while (value == null);
            return value.Value;
        }

        static ConverterBase GetConverter(string msg) {
            ConverterBase converter = null;
            do {
                Console.Write(msg + " => ");
                var unit = Console.ReadLine();
                converter = ConverterFactory.GetInstance(unit);
            } while (converter == null);
            return converter;
        }
    }
}
