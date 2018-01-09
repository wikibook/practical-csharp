using CSharpPhrase.DistanceConversion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.DistanceConversion.ConcreteConverter {
    public class MeterConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "meter" || name.ToLower() == "metre" || name == UnitName;
        }

        protected override double Ratio { get { return 1; } }
        public override string UnitName { get { return "メートル"; } }
    }
}
