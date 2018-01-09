using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-12
    public class DistanceConverter {
        public ConverterBase From { get; private set; }
        public ConverterBase To { get; private set; }

        public DistanceConverter(ConverterBase from, ConverterBase to) {
            From = from;
            To = to;
        }

        public double Convert(double value) {
            var meter = From.ToMeter(value);
            return To.FromMeter(meter);
        }
    }
}
