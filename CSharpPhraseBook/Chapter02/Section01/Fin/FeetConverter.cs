// List 2-10
// List 2-12

using System;

namespace DistanceConverter {
    public static class FeetConverter {
        private const double ratio = 0.3048;

        // 미터로 피트를 구한다
        public static double FromMeter(double meter) {
            return meter / ratio;
        }

        // 피트로 미터를 구한다
        public static double ToMeter(double feet) {
            return feet * ratio;
        }
    }
}