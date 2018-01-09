using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class InchConverter {
        private static readonly double ratio = 0.0254;

        // 미터를 피트로 환산한다
        public static double FromMeter(double meter) {
            return meter / ratio;
        }

        // 피트를 미터로 환산한다
        public static double ToMeter(double feet) {
            return feet * ratio;
        }
    }
}
