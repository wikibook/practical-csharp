// List 1-7
using System;
// using SampleApp;

namespace SampleApp {
    class Program {
        static void Main(string[] args) {
            Product yakkwa = new Product(123, "약과", 180); 
            int taxIncluded = yakkwa.GetPriceIncludingTax();
            Console.WriteLine(taxIncluded);
        }
    }
}
