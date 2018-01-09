using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4 {
    class Program {
        static void Main(string[] args) {
            var line = "Novelist=김만중;BestWork=구운몽;Born=1886";
            foreach (var pair in line.Split(';')) {
                var array = pair.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(array[0]), array[1]);
            }
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "작가　";
                case "BestWork":
                    return "대표작";
                case "Born":
                    return "탄생년";
            }
            throw new ArgumentException("인수 key는 정확한 값이 아닙니다.");
        }
    }    
}
