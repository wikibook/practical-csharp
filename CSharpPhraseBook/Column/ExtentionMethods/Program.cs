using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.Extensions;

// 3장 '[Column] 확장 메서드'에 나온 코드입니다
// StringExtensions.cs가 해당 소스 파일입니다

namespace ExtensionMethods {
    class Program {
        static void Main(string[] args) {
            var word = "gateman";
            var result = word.Reverse();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
