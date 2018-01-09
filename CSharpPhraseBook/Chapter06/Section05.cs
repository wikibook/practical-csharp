using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    [SampleCode("Chapter 6")]
    class Section05  {

        [ListNo("List 6-28")]
        public void FindFirst() {
            var text = "The quick brown fox jumps over the lazy dog";
            var words = text.Split(' ');
            var word = words.FirstOrDefault(x => x.Length == 4);
            Console.WriteLine(word);
        }

        [ListNo("List 6-29")]
        public void FindFirstWithLoop() {
            string text = "The quick brown fox jumps over the lazy dog";
            string[] words = text.Split(' ');
            string word = null;
            foreach (string w in words) {
                if (w.Length == 4) {
                    word = w;
                    break;
                }
            }
            Console.WriteLine(word);
        }

        [ListNo("List 6-30")]
        public void FindIndexWithLinq() {
            var numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            var item = numbers.Select((n, ix) => new { Value = n, Index = ix })
                              .FirstOrDefault(o => o.Value < 0);
            var index = item == null ? -1 : item.Index;
            Console.WriteLine(index);
        }

        [ListNo("List 6-31")]
        public void FindIndexWithLoop() {
            List<int> numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            int index = -1;
            for (int i = 0; i < numbers.Count; i++) {
                if (numbers[i] < 0) {
                    index = i;
                    break;
                }
            }
            Console.WriteLine(index);
        }

        [ListNo("List 6-32")]
        public void Sample05() {
            var numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            var index = numbers.FindIndex(n => n < 0);
            Console.WriteLine(index);
        }
    }
}
