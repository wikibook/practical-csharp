using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0406 {
    class ReadonlyProperty {
        public void Do() {
            var obj = new MySample2();
            //obj.MyList.Add(6);          //    〈←List<int> は自由に操作できる〉
            //obj.MyList.RemoveAt(0);
            //obj.MyList[0] = 10;
            foreach (var n in obj.MyList) {
                Console.WriteLine(n);
            }
            //obj.MyList = new List<int>(); 〈←読み取り専用なので、これはビルドエラー〉
            Console.ReadLine();

        }

    }

    class MySample {
        public List<int> MyList { get; private set; }

        public MySample() {
            MyList = new List<int>() { 1, 2, 3, 4, 5 };
        }
    }

    class MySample2 {
        public IReadOnlyList<int> MyList { get; private set; }

        public MySample2() {
            MyList = new List<int>() { 1, 2, 3, 4, 5 };
        }
    }

}
