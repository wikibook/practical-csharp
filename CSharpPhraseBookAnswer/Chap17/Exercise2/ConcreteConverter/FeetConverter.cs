using CSharpPhrase.DistanceConversion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.DistanceConversion.ConcreteConverter {
    public class FeetConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "feet" || name == UnitName;
        }
        protected override double Ratio { get { return 0.3048; } }
        public override string UnitName { get { return "フィート"; } }
    }
}
