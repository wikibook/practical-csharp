using System;
using System.Collections.Generic;
using System.Linq;

namespace Section02 {

    // List 7-15
    class WordsExtractor {
        private string[] _lines;

        // 생성자
        // 파일 이외의 것으로부터도 추출할 수 있도록 string[]을 인수로 받는다
        public WordsExtractor(string[] lines) {
            _lines = lines;
        }

        // 10 문자 이상인 단어를 중복없이 알파벳 순으로 열거한다
        public IEnumerable<string> Extract() {
            var hash = new HashSet<string>();    
            foreach (var line in _lines) {
                var words = GetWords(line);
                foreach (var word in words) {
                    if (word.Length >= 10)
                        hash.Add(word.ToLower());
                }
            }
            return hash.OrderBy(s => s); 
        }

        // 단어로 분할할 때 사용되는 분리자
        // 문자 배열을 초기화하기 보다는 ToCharArray 메서드를 사용하는 것이 편하다
        private char[] _separators = @" !?"",.".ToCharArray();

        // １행부터 단어를 꺼내서 열거한다
        private IEnumerable<string> GetWords(string line) {
            var items = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                // you're, it's, don't 에서 아포스트로피 이후에 나오는 부분을 삭제한다
                var index = item.IndexOf("'");
                var word = index <= 0 ? item : item.Substring(0, index);
                // 모두 알파벳만을 대상으로 한다
                if (word.ToLower().All(c => 'a' <= c && c <= 'z'))
                    yield return word;
            }
        }
    }
}