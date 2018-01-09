using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.2.2
            MyClass myClass = new MyClass { X = 1, Y = 2 };
            MyStruct myStruct = new MyStruct { X = 3, Y = 4 };
            PrintObjects(myClass, myStruct);
            Console.WriteLine();

            // 1.2.3
            PrintObjectsTwice(myClass, myStruct);
            Console.WriteLine();
            Console.WriteLine("MyClass  : ({0},{1})", myClass.X, myClass.Y);
            Console.WriteLine("MyStruct : ({0},{1})", myStruct.X, myStruct.Y);
        }

        // 1.2.1

        static void PrintObjects(MyClass obj1, MyStruct obj2)
        {
            Console.WriteLine("MyClass  : ({0},{1})", obj1.X, obj1.Y);
            Console.WriteLine("MyStruct : ({0},{1})", obj2.X, obj2.Y);
        }

        /* 1.2.4
          Main 메서드에 있는 myClass 변수에는 오브젝트를 가리키는 참조가 저장돼 있다.
          따라서 인수 obj1에는 Main 메서드에 있는 MyClass 오브젝트를 가리키는 참조가 전달되므로
          obj1의 속성값을 변경하면 변수 myClass가 가리키고 있는 MyClass 오브젝트가 변경된다.
          그러나 obj2에는 Main 메서드에 있는 myStruct 오브젝트의 복사본이 전달되므로
          obj2의 속성값을 변경해도 myStruct 오브젝트에는 영향을 주지 않는다.

          문제에서 PrintObjects라고 지정했는데
          동일한 클래스 안에 코드를 썼기 때문에 PrintObjectsTwice로 구현했다.
        */
        // 1.2.3
        static void PrintObjectsTwice(MyClass obj1, MyStruct obj2)
        {
            obj1.X *= 2;
            obj1.Y *= 2;
            obj2.X *= 2;
            obj2.Y *= 2;
            Console.WriteLine("MyClass  : ({0},{1})", obj1.X, obj1.Y);
            Console.WriteLine("MyStruct : ({0},{1})", obj2.X, obj2.Y);
        }
    }

    // 클래스
    class MyClass
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 구조체
    struct MyStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
