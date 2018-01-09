// Lust 2-26

using System;
using System.Collections.Generic;
using System.IO;

namespace SalesCalculator {
    class Program {

        // List 2-25
        static void Main(string[] args) {
            var sales = new SalesCounter("sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }
    }
}
