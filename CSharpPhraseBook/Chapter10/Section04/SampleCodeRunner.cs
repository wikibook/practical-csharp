using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gushwell.CsBook {
    // プロジェクトに定義されたメソッドを順に呼び出していくクラス。
    // 各プロジェクトから参照追加して利用する。
    // 本書では説明していないリフレクションおよび属性という機能を使っている。
    // 詳しく知りたい場合には、リフレクションおよび属性について書かれた資料を参照してほしい。
    public class SampleCodeRunner {
        public static void Run() {
            var asm = Assembly.GetEntryAssembly();
            var types = asm.GetTypes()
                           .Where(x => x.BaseType == typeof(SampleCodeRunner))
                           .OrderBy(x => x.Name);
            foreach (var type in types) {
                if (!type.IsClass || type.IsNested)
                    continue;
                if (type.Name.EndsWith("Attribute"))
                    continue;
                if (type.Name.Contains("SampleCodeRunner"))
                    continue;
                var mi = type.GetMethod("Do");
                if (mi != null) {
                    var obj = Activator.CreateInstance(type);
                    Console.WriteLine($"\n# {type.Name} class");
                    mi.Invoke(obj, new object[] { });
                    Console.Write("PRESS Enter Key");
                    Console.ReadLine();
                }
            }
        }

        public virtual void Do() {
            var type = this.GetType();

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            // .OrderBy(x => x.Name);
            foreach (var mi in methods) {
                if (mi.Name == "Finalize" || mi.Name == "MemberwiseClone" || mi.Name == "Do" ||
                    mi.Name.StartsWith("set_") || mi.Name.StartsWith("get_"))
                    continue;
                if (mi.GetParameters().Length > 0 || mi.ReturnParameter.ParameterType.Name != "Void")
                    continue;
                var listnoAttr = mi.GetCustomAttribute(typeof(ListNoAttribute)) as ListNoAttribute;
                var listno = listnoAttr?.ListNumber;

                if (listno == null)
                    Console.WriteLine($"\n- {mi.Name} method");
                else
                    Console.WriteLine($"\n- {mi.Name} method ({listno})");
                mi.Invoke(this, new object[] { });
                Thread.Sleep(10);
            }
        }
    }

    // メソッドに付加する属性。リスト番号を指定する。
    [AttributeUsage(AttributeTargets.Method)]
    public class ListNoAttribute : Attribute {
        public string ListNumber { get; set; }

        public ListNoAttribute(string listNumber) {
            ListNumber = listNumber;
        }
    }
}
