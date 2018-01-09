using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 4장 '[Column] 전위++과 후위++의 차이'에서 나온 코드입니다

namespace IncrementOperator {

    class Program {
        static void Main(string[] args) {
            int num = 5;
            Console.WriteLine(num++);
            num = 5;
            Console.WriteLine(++num);

            Console.ReadLine();
        }
    }
}
