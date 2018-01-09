using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-10 / List 17-13 (ConverterBase)
    public abstract class ConverterBase {

        public abstract bool IsMyUnit(string name);


        // 미터와의 비율(이 비율을 곱하면 미터로 변환된다)
        protected abstract double Ratio { get; }

        // 거리의 단위 이름(예를 들어 미터 , 피트 등)
        public abstract string UnitName { get; }

        // 미터로부터 변환
        public double FromMeter(double meter) {
            return meter / Ratio;
        }

        // 미터로 변환
        public double ToMeter(double feet) {
            return feet * Ratio;
        }
    }
}
