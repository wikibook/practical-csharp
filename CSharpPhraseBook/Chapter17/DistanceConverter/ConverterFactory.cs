using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-14
    static class ConverterFactory {
        // 미리 인스턴스를 생성하고 배열에 넣어둔다
        private static ConverterBase[] _converters = new ConverterBase[] {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
        };

        public static ConverterBase GetInstance(string name) {
            return _converters.FirstOrDefault(s => s.IsMyUnit(name));
        }
    }
}
