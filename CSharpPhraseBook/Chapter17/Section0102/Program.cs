using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section0102 {
    class Program {

        // List 17-17
        static void Main(string[] args) {
            var greetings = new List<IGreeting>() {
               new GreetingMorning(),
               new GreetingAfternoon(),
               new GreetingEvening(),
            };
            foreach (var obj in greetings) {
                string msg = obj.GetMessage();
                Console.WriteLine(msg);
            }
            Console.ReadLine();
        }
    }
}
