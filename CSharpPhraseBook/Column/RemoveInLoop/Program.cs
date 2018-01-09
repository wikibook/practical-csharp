using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 6장 '[Column] foreach나 for 루프 안에서 리스트에 있는 요소를 삭제하면 안된다'에 나온 코드입니다

namespace RemoveInLoop {
    class Program {
        static void Main(string[] args) {
          //  BadRemoveInForeach();
            BadRemoveInFor();
            RemoveInFor();
            RemoveWithLinq();
            Console.ReadLine();
        }

        // 이 메서드에서는 예외가 발생한다
        private static void BadRemoveInForeach() {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int n in list) {
                if (n % 4 == 0)
                    list.Remove(n);
            }
            Console.WriteLine(list.Count);

        }

        private static void BadRemoveInFor() {
            var list = new List<int> { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };
            for (int i = 0; i < list.Count; i++) {
                if (list[i] == 5)
                    list.Remove(list[i]);  
            }
            Console.WriteLine(list.Count);
        }

        private static void RemoveInFor() {
            var list = new List<int> { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };
            for (int i = list.Count - 1; i >= 0; i--) {
                if (list[i] == 5)
                    list.Remove(list[i]);  
            }
            Console.WriteLine(list.Count);
        }

        private static void RemoveWithLinq() {
            var list = new List<int> { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };
            list.RemoveAll(x => x == 5);
            Console.WriteLine(list.Count);
        }


    }
}
