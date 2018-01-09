using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();
            if (string.Compare(s1, s2, ignoreCase: true) == 0)
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");
        }
    }
}
