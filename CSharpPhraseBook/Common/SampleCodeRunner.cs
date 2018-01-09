using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gushwell.CsBook {
    // 프로젝트에 정의된 메서드를 차례로 호출하는 클래스이다.
    // 각 프로젝트에 추가(링크)해서 이용한다.
    // 이 책에서 설명하지 않은 리플렉션이나 속성이라는 기능을 사용했다.
    // 자세한 내용을 알고 싶다면 리플렉션이나 속성에 대해 쓰여진 자료를 참고하기 바람.
    public class SampleCodeRunner {
        public static void Run() {
            var asm = Assembly.GetEntryAssembly();
            var types = asm.GetTypes()
                           .OrderBy(x => x.Name);
            foreach (var type in types) {
                var attr = type.GetCustomAttribute(typeof(SampleCodeAttribute)) as SampleCodeAttribute;
                if (attr == null)
                    continue;
                Console.WriteLine("\n{0}",attr.Chapter);
                var obj = Activator.CreateInstance(type);
                CallMethods(obj);
            }
            Console.ReadLine();
        }

        // obj의 인스턴스 메서드 중에 public void 메서드(인수 없음)를 차례로 호출한다
        public static void CallMethods(Object obj) {
            var type = obj.GetType();

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var mi in methods) {
                if (mi.Name == "Finalize" || mi.Name == "MemberwiseClone" ||
                    mi.Name.StartsWith("set_") || mi.Name.StartsWith("get_"))
                    continue;
                if (mi.GetParameters().Length > 0 || mi.ReturnParameter.ParameterType.Name != "Void")
                    continue;
                var listNoAttr = mi.GetCustomAttribute(typeof(ListNoAttribute)) as ListNoAttribute;
                var listNo = listNoAttr?.ListNumber;

                if (listNo == null)
                    Console.WriteLine($"\n- {mi.Name} method");
                else
                    Console.WriteLine($"\n- {mi.Name} method ({listNo})");
                mi.Invoke(obj, new object[] { });
                Thread.Sleep(10);
            }
        }
    }

    // 메서드에 부가하는 속성. 리스트 번호를 지정한다
    [AttributeUsage(AttributeTargets.Method)]
    public class ListNoAttribute : Attribute {
        public string ListNumber { get; private set; }

        public ListNoAttribute(string listNumber) {
            ListNumber = listNumber;
        }
    }

    // public void 메서드를 실행하기 위한 마커 속
    // 실행하려는 클래스에 이 속성을 부가한다
    [AttributeUsage(AttributeTargets.Class)]
    public class SampleCodeAttribute : Attribute {
        public string Chapter { get; private set; }

        public SampleCodeAttribute(string chapter) {
            Chapter = chapter;
        }
    }

}
