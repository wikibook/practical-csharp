using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section0102 {
    // List 17-6
    class GreetingMorning : IGreeting {
        public string GetMessage() {
            return "Good morning";
        }
    }

    class GreetingAfternoon : IGreeting {
        public string GetMessage() {
            return "Good afternoon";
        }
    }

    class GreetingEvening : IGreeting {
        public string GetMessage() {
            return "Good night";
        }
    }
}
