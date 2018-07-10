using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    [SampleCode("Chapter 6")]
    class Section04 {
        private IEnumerable<Book> books = Books.GetBooks();

        [ListNo("List 6-20")]
        public void Any01WithLinq() {
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 11, 30, 24 };
            bool exists = numbers.Any(n => n % 7 == 0);
            Console.WriteLine(exists);

        }

        [ListNo("List 6-21")]
        public void Any02WithLinq() {
            bool exists = books.Any(x => x.Price >= 10000);
            Console.WriteLine(exists);
        }

        [ListNo("List 6-22")]
        public void AnyWithLoop() {
            List<int> numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 11, 30, 24 };
            bool exists = false;
            foreach (int n in numbers) {
                if (n % 7 == 0) {
                    exists = true;
                    break;
                }
            }
            Console.WriteLine(exists);
        }

        [ListNo("List 6-23")]
        public void All01WithLinq() {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            bool isAllPositive = numbers.All(n => n > 0);
            Console.WriteLine(isAllPositive);
        }

        [ListNo("List 6-24")]
        public void All02WithLinq() {
            bool is10000OrLess = books.All(x => x.Price <= 10000);
            Console.WriteLine(is10000OrLess);
        }

        [ListNo("List 6-25")]
        public void AllWithLoop() {
            List<int> numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            bool isAllPositive = true;
            foreach (int n in numbers) {
                if (n < 0) {
                    isAllPositive = false;
                    break;
                }
            }
            Console.WriteLine(isAllPositive);
        }

        [ListNo("List 6-26")]
        public void SequenceEqual() {
            var numbers1 = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, -1, 0, 4 };
            var numbers2 = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, -1, 0, 4 };
            bool equal = numbers1.SequenceEqual(numbers2);
            Console.WriteLine(equal);
        }

        [ListNo("List 6-27")]
        public void SequenceEqualWithLoop() {
            List<int> numbers1 = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, -1, 0, 4 };
            List<int> numbers2 = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, -1, 0, 4 };
            bool equal = true;
            if (numbers1.Count != numbers2.Count) {
                equal = false;     
            } else {
                for (int i = 0; i < numbers1.Count; i++) {
                    if (numbers1[i] != numbers2[i]) {
                        equal = false; 
                        break;
                    }
                }
            }
            Console.WriteLine(equal);
        }
    }
}
