using CSharpPhrase.DistanceConversion.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.DistanceConversion.ConcreteConverter {
    public class MileConverter : ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "mile" || name == UnitName;
        }
        protected override double Ratio { get { return 1609.34; } }
        public override string UnitName { get { return "マイル"; } }
    }
}
