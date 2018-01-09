using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    // List 17-2
    class GreetingMorning : GreetingBase {
        public override string GetMessage() {
            return "Good morning";
        }
    }

    class GreetingAfternoon : GreetingBase {
        public override string GetMessage() {
            return "Good afternoon";
        }
    }

    class GreetingEvening : GreetingBase {
        public override string GetMessage() {
            return "Good night";
        }
    }
}
