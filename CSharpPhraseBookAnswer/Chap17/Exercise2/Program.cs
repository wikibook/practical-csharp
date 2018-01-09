using CSharpPhrase.DistanceConversion.ConcreteConverter;
using CSharpPhrase.DistanceConversion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.DistanceConversion {
    class Program {
        static void Main(string[] args) {
            while (true) {
                var from = GetConverter("변환할 단위를 입력하세요.");
                var to = GetConverter("변환 결과의 단위를 입력하세요.");
                var distance = GetDistance(from);

                var converter = new DistanceConverter(from, to);
                var result = converter.Convert(distance);
                Console.WriteLine($"{distance}{from.UnitName}은(는) {result:0.000}{to.UnitName}입니다.\n");
            }
        }

        static double GetDistance(ConverterBase from) {
            double? value = null;
            do {
                Console.Write($"변환하려는 단위(단위:{from.UnitName})을(를) 입력하세요=> ");
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
