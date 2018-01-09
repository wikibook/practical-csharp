using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    // List 7-19
    // 줄임말과 그에 대응되는 한국어를 관리하는 클래스
    class Abbreviations {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        // 생성자
        public Abbreviations() {
            var lines = File.ReadAllLines("Abbreviations.txt");
            _dict = lines.Select(line => line.Split('='))
                         .ToDictionary(x => x[0], x => x[1]);
        }

        // 요소를 추가한다
        public void Add(string abbr, string japanese) {
            _dict[abbr] = japanese;
        }

        // 인덱서: 줄임말을 키로 사용한다
        public string this[string abbr] {
            get {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }

        // 한국어로부터 그에 대응되는 줄임말을 구한다
        public string ToAbbreviation(string japanese) {
            return _dict.FirstOrDefault(x => x.Value == japanese).Key;
        }

        // 한국어의 위치를 인수에 넘겨주고 그것이 포함되는 요소(Key,Value)를 모두 구한다
        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring) {
            foreach (var item in _dict) {
                if (item.Value.Contains(substring))
                    yield return item;
            }
        }
    }
}
