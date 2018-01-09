using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            StructTest test1 = new StructTest();
            test1.Run();
            Console.WriteLine();
            ClassTest test2 = new ClassTest();
            test2.Run();
            Console.ReadLine();
        }
    }


    class StructTest {

        // List 1-4
        public void Run() {
            MyPoint a = new MyPoint(10, 20);
            MyPoint b = a;
            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);
            a.X = 80;
            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);
            

        }

        // List 1-3
        struct MyPoint {
            public int X { get; set; }
            public int Y { get; set; }

            // 생성자
            public MyPoint(int x, int y) {
                this.X = x;
                this.Y = y;
            }
        }
    }

    class ClassTest {

        // List 1-6
        public void Run() {
            MyPoint a = new MyPoint(10, 20);
            MyPoint b = a;
            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);
            a.X = 80;
            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);

        }

        // List 1-5
        class MyPoint {
            public int X { get; set; }
            public int Y { get; set; }

            // 생성자
            public MyPoint(int x, int y) {
                this.X = x;
                this.Y = y;
            }
        }
    }

}
