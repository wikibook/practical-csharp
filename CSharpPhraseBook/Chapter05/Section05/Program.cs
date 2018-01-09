using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 5")]
    class SampleCode  {
        [ListNo("List 5-33 ～ List 5-36")]
        public void Concatenate() {
            {
                var name = "홍" + "길동";
                Console.WriteLine(name);
            }
            {
                var word1 = "Visual";
                var word2 = "Studio";
                var word3 = "Code";
                var text = word1 + word2 + word3;
                Console.WriteLine(text);
            }
            {
                var title = '님';
                var addressee = "손오공" + title;
                Console.WriteLine(addressee);
            }
            {
                var name = "방정환";
                name += "선생님";
                Console.WriteLine(name);
            }
        }

        [ListNo("List 5-38")]
        public void Join() {
            var languages = new[] { "C#", "Java", "VB", "Ruby", };
            var separator = ", ";
            var result = String.Join(separator, languages);
            Console.WriteLine(result);
        }

        [ListNo("List 5-39 ～ List 5-40")]
        public void Split() {
            {
                var text = "The quick brown fox jumps over the lazy dog";
                string[] words = text.Split(' ');
                words.ToList().ForEach(Console.WriteLine);
            }
            Console.WriteLine();

            {
                var text = "The quick brown fox jumps over the lazy dog.";
                var words = text.Split(new[] { ' ', '.' },
                                       StringSplitOptions.RemoveEmptyEntries);
                words.ToList().ForEach(Console.WriteLine);
            }
        }


        [ListNo("List 5-41")]
        public void StringBuilderSample() {
            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);
            }
            var text = sb.ToString();

            Console.WriteLine(text);
        }

        private static IEnumerable<string> GetWords() {
            var text = "The quick brown fox jumps over the lazy dog";
            return text.Split(' ');
        }

    }
}
