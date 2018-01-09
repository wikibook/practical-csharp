using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15 {
    [SampleCode("Chapter 15")]
    class SampleCodeSection03  {
        [ListNo("List 15-11")]
        public void JoinSample() {
            var books = Library.Books
                               .OrderBy(b => b.CategoryId)
                               .ThenBy(b => b.PublishedYear)
                               .Join(Library.Categories,
                                     book => book.CategoryId,
                                     category => category.Id,
                                     (book, category) => new {
                                         Title = book.Title,
                                         Category = category.Name,
                                         PublishedYear = book.PublishedYear
                                     }
                               );
            foreach (var book in books) {
                Console.WriteLine($"{book.Title}, {book.Category}, {book.PublishedYear}");
            }
        }

        [ListNo("List 15-12")]
        public void JoinSample2() {
            var names = Library.Books
                               .Where(b => b.PublishedYear == 2016)
                               .Join(Library.Categories,
                                     book => book.CategoryId,
                                     category => category.Id,
                                     (book, category) => category.Name)
                               .Distinct();
            foreach (var name in names) {
                Console.WriteLine(name);
            }
        }

        [ListNo("List 15-13")]
        public void GroupJoinSample() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                    c => c.Id,
                                    b => b.CategoryId,
                                    (c, books) => new { Category = c.Name, Books = books });
            foreach (var group in groups) {
                Console.WriteLine(group.Category);
                foreach (var book in group.Books) {
                    Console.WriteLine($"  {book.Title} ({book.PublishedYear}년)");
                }
            }
        }

        [ListNo("List 15-14")]
        public void GroupJoinSample2() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                          c => c.Id,
                                          b => b.CategoryId,
                                          (c, books) => new {
                                              Category = c.Name,
                                              Count = books.Count(),
                                              Average = books.Average(b => b.Price)
                                          });
            foreach (var obj in groups) {
                Console.WriteLine($"{obj.Category} 책 수량:{obj.Count} 평균 가격:{obj.Average:0.0}원");
            }
        }

    }
}
