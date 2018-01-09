using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            Product yakkwa = new Product(123, "약과", 180);
            Product chapssal = new Product(235, "찹쌀떡", 160);
            int yakkwaTax = yakkwa.GetTax();
            int chapssalTax = chapssal.GetTax();

            Console.WriteLine("{0} {1} {2}", yakkwa.Name, yakkwa.Price, yakkwaTax);
            Console.WriteLine("{0} {1} {2}", chapssal.Name, chapssal.Price, chapssalTax);

        }
    }
}
