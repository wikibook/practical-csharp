
// List 2-5

namespace DistanceConverter {
    // 피트에서 미터로 단위를 변환하는 클래스
    public class FeetConverter {
        // 미터를 피트로 환산한다
        public double FromMeter(double meter) {
            return meter / 0.3048;
        }

        // 피트를 미터로 환산한다
        public double ToMeter(double feet) {
            return feet * 0.3048;
        }
    }
}
