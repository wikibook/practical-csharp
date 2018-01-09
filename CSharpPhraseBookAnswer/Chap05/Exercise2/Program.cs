using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var line = Console.ReadLine();
            int num;
            if (int.TryParse(line, out num)) {
                Console.WriteLine("{0:#,#}", num);
            } else {
                Console.WriteLine("숫자값 문자열이 아닙니다.");
            }
        }
    }
}
