using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    [SampleCode("Chapter 6")]
    class Section07  {

        private List<Book> books = Books.GetBooks();

        [ListNo("List 6-39")]
        public void Select01() {
            var words = new List<string> { "Microsoft", "Apple", "Google", "Oracle", "Facebook", };
            var lowers = words.Select(name => name.ToLower())
                              .ToArray();
            lowers.ToList().ForEach(Console.WriteLine);

            var books = new List<Book> {
               new Book { Title = "태평천하", Price = 400, Pages = 378 },
               new Book { Title = "운수 좋은 날", Price = 281, Pages = 212 },
               new Book { Title = "만세전", Price = 389, Pages = 201 },
               new Book { Title = "삼대", Price = 637, Pages = 464 },
               new Book { Title = "상록수", Price = 411, Pages = 276 },
               new Book { Title = "혈의 누", Price = 961, Pages = 666 },
               new Book { Title = "금수회의록", Price = 514, Pages = 268 },
            };

        }

        [ListNo("List 6-40")]
        public void Select02() {
            var titles = books.Select(x => x.Title);
            titles.ToList().ForEach(Console.WriteLine);
        }

        [ListNo("List 6-41")]
        public void SelectWithLoop() {
            List<string> words = new List<string> { "Microsoft", "Apple", "Google", "Oracle", "Facebook", };
            List<string> lowers = new List<string>();
            foreach (string name in words) {
                lowers.Add(name.ToLower());
            }
            lowers.ForEach(Console.WriteLine);
        }

        [ListNo("List 6-42")]
        public void Distinct() {
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };
            var results = numbers.Distinct();
            results.ToList().ForEach(Console.WriteLine);
        }


        [ListNo("List 6-43")]
        public void DistinctWithLoop() {
            List<int> numbers = new List<int> { 19, 17, 15, 24, 12, 17, 14, 20, 12, 28, 19, 30, 24 };
            List<int> results = new List<int>();
            foreach (int n in numbers) {
                if (!results.Contains(n))
                    results.Add(n);
            }
            foreach (int n in results)
                Console.WriteLine(n);
        }

        [ListNo("List 6-44")]
        public void OrderBy() {
            var sortedBooks = books.OrderBy(x => x.Price);
            foreach (var book in sortedBooks)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
        }

        [ListNo("List 6-45")]
        public void OrderByDescending() {
            var sortedBooks = books.OrderByDescending(x => x.Price);
            foreach (var book in sortedBooks)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
        }

        [ListNo("List 6-46")]
        public void Sort() {
            books.Sort(BookCompare);
            foreach (var book in books)
                Console.WriteLine("{0} {1}", book.Title, book.Price);
        }

        private int BookCompare(Book a, Book b) {
            return a.Price - b.Price;
        }

        [ListNo("List 6-47")]
        public void Concat01() {
            var files1 = Directory.GetFiles(@"C:\Program Files\Common Files\System");
            var files2 = Directory.GetFiles(@"C:\Program Files (x86)\Common Files\System");
            var allfiles = files1.Concat(files2); 
                                                  
            allfiles.ToList().ForEach(Console.WriteLine);
        }

        [ListNo("List 6-48")]
        public void Concat02() {
            string[] files1 = Directory.GetFiles(@"C:\Program Files\Common Files\System");
            string[] files2 = Directory.GetFiles(@"C:\Program Files (x86)\Common Files\System");
            List<string> allfiles = new List<string>(files1);
            allfiles.AddRange(files2);
                                      
            allfiles.ForEach(Console.WriteLine);
        }
    }
}
