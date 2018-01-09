using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpPhrase.TextFileProcessor {
    class ToHankakuProcessor : TextProcessor {

        private static Dictionary<char, char> _dictionary =
            new Dictionary<char, char>() {
                {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
                {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'}
            };

        // 본문에서는 다루지 않았던 Regex 클래스에 있는 Replace 오버로드 메서드를 이용했다
        // 람다식에서 변환 규칙을 지정한다
        protected override void Execute(string line) {
            var s = Regex.Replace(line, "[０-９]", c => _dictionary[c.Value[0]].ToString());
            Console.WriteLine(s);
        }
    }
}
