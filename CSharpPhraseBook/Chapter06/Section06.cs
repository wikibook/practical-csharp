using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    [SampleCode("Chapter 6")]
    class Section06  {

        private IEnumerable<Book> books = Books.GetBooks();

        [ListNo("List 6-33")]
        public void Take() {
            var numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            var results = numbers.Where(n => n > 0)
                                 .Take(5);
            foreach (var item in results)
                Console.WriteLine(item);
        }

        [ListNo("List 6-34")]
        public void TakeWithLoop() {
            List<int> numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            List<int> results = new List<int>();
            foreach (int n in numbers) {
                if (n > 0) {
                    results.Add(n);
                    if (results.Count >= 5)
                        break;
                }
            }
            foreach (int item in results)
                Console.WriteLine(item);
        }


        [ListNo("List 6-35")]
        public void TakeWhile() {
            var selected = books.TakeWhile(x => x.Price < 6000);
            foreach (var book in selected)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
        }

        [ListNo("List 6-36")]
        public void TakeWhileWithLoop() {
            List<Book> selected = new List<Book>();
            foreach (Book book in books) {
                if (book.Price >= 6000)
                    break;
                selected.Add(book);
            }
            foreach (Book book in selected)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
        }

        [ListNo("List 6-37")]
        public void SkipWhile() {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, 7, 0, 4 };
            var selected = numbers.SkipWhile(n => n >= 0)
                                  .ToList();
            selected.ForEach(Console.WriteLine);
        }

        [ListNo("List 6-38")]
        public void SkipWhileWithLoop() {
            List<int> numbers = new List<int> { 9, 7, 5, 4, 2, 4, 0, -4, -1, 0, 4 };
            List<int> selected = new List<int>();
            bool found = false;
            for (int i = 0; i < numbers.Count; i++) {
                if (numbers[i] < 0)
                    found = true;
                if (found)
                    selected.Add(numbers[i]);
            }
            selected.ForEach(Console.WriteLine);
        }

    }
}
