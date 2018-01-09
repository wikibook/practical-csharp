using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {

    // List 1-2
    class Program {
        static void Main(string[] args) {
            // 같은 방식으로 사용할 수 있다

            MyClass myClass = new MyClass { X = 1, Y = 2 };

            MyStruct myStruct = new MyStruct { X = 1, Y = 2 };

            Console.WriteLine("X={0} Y={1}", myClass.X, myClass.Y);
            Console.WriteLine("X={0} Y={1}", myStruct.X, myStruct.Y);
        }
    }


    // 클래스
    class MyClass {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 구조체
    struct MyStruct {
        public int X { get; set; }
        public int Y { get; set; }
    }



}
