using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-13 (ConverterBase의 추상 클래스)

    public class MeterConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "meter" || name.ToLower() == "meter" || name == UnitName;
        }
        protected override double Ratio { get { return 1; } }
        public override string UnitName { get { return "미터"; } }
    }

    public class FeetConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "feet" || name == UnitName;
        }
        protected override double Ratio { get { return 0.3048; } }
        public override string UnitName { get { return "피트"; } }
    }

    public class InchConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "inch" || name == UnitName;
        }
        protected override double Ratio { get { return 0.0254; } }
        public override string UnitName { get { return "인치"; } }
    }

    public class YardConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "yard" || name == UnitName;
        }
        protected override double Ratio { get { return 0.9144; } }
        public override string UnitName { get { return "야드"; } }
    }
}
