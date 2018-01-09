using Chapter15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        public static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        static void Exercise1_2() {
            var max = Library.Books.Max(b => b.Price);
            var book = Library.Books.First(b => b.Price == max);
            Console.WriteLine(book);
        }

        static void Exercise1_3() {
            var query = Library.Books.GroupBy(b => b.PublishedYear)
                               .Select(g => new { PublishedYear = g.Key, Count = g.Count() })
                               .OrderBy(x => x.PublishedYear);
            foreach (var item in query) {
                Console.WriteLine("{0}년 {1}권", item.PublishedYear, item.Count);
            }
        }

        static void Exercise1_4() {
            var query = Library.Books
                               .Join(Library.Categories,
                                    book => book.CategoryId,
                                    category => category.Id,
                                     (book, category) => new {
                                         book.Title,
                                         book.PublishedYear,
                                         book.Price,
                                         CategoryName = category.Name
                                     })
                               .OrderByDescending(x => x.PublishedYear)
                               .ThenByDescending(x => x.Price);
            foreach (var item in query)
                Console.WriteLine("{0}년 {1}원 {2} ({3})",
                                  item.PublishedYear,
                                  item.Price,
                                  item.Title,
                                  item.CategoryName
                                 );
        }

        static void Exercise1_5() {
            var query = Library.Books
                               .Where(b => b.PublishedYear == 2016)
                               .Join(
                                   Library.Categories, book => book.CategoryId,
                                   category => category.Id,
                                   (book, category) => category.Name)
                               .Distinct();
            foreach (var name in query)
                Console.WriteLine(name);
        }

        static void Exercise1_6() {
            var query = Library.Books
                               .Join(Library.Categories,
                                    book => book.CategoryId,
                                    category => category.Id,
                                     (book, category) => new {
                                         book.Title,
                                         book.PublishedYear,
                                         book.Price,
                                         CategoryName = category.Name
                                     })
                               .GroupBy(x => x.CategoryName)
                               .OrderBy(x => x.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}", group.Key);
                foreach (var item in group) {
                    Console.WriteLine(" {0}",
                                  item.Title,
                                  item.PublishedYear,
                                  item.Price
                                 );
                }
            }
        }

        private static void Exercise1_7() {
            var catid = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books
                                .Where(b => b.CategoryId == catid)
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(b => b.Key);
            foreach (var group in groups) {
                Console.WriteLine("#{0}년", group.Key);
                foreach (var book in group) {
                    Console.WriteLine(" {0}", book.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var query = Library.Categories
                               .GroupJoin(
                                    Library.Books,
                                    c => c.Id,
                                    b => b.CategoryId,
                                    (c, b) => new {
                                        CategoryName = c.Name,
                                        Count = b.Count()
                                    })
                                .Where(x => x.Count >= 4);
            foreach (var category in query)
                Console.WriteLine(category.CategoryName);
        }
    }
}
