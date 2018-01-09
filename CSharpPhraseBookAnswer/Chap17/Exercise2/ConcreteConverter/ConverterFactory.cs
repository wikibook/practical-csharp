using CSharpPhrase.DistanceConversion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.DistanceConversion.ConcreteConverter {
    static class ConverterFactory {
        // あらかじめインスタンスを生成し、配列に入れておく。
        private static ConverterBase[] _converters = new ConverterBase[] {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
            new KilometerConverter(),
            new MileConverter(),
        };

        public static ConverterBase GetInstance(string name) {
            return _converters.FirstOrDefault(x => x.IsMyUnit(name));
        }
    }
}
