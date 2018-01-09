using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15 {
    [SampleCode("Chapter 15")]
    class SampleCodeSection02 {
        [ListNo("List 15-2")]
        public void MaximumPrice() {
            var price = Library.Books
                               .Where(b => b.CategoryId == 1)
                               .Max(b => b.Price);
            Console.WriteLine(price);

        }

        [ListNo("List 15-3")]
        public void MostShortTitleBook() {
            var min = Library.Books
                             .Min(x => x.Title.Length);
            var book = Library.Books
                              .First(b => b.Title.Length == min);
            Console.WriteLine(book);
        }

        public void MostShortTitleBook2() {
            var book = Library.Books
                              .First(b => b.Title.Length == 
                                          Library.Books.Min(x => x.Title.Length));
            Console.WriteLine(book);
        }

        [ListNo("List 15-4")]
        public void AboveAverage() {
            var average = Library.Books
                                 .Average(x => x.Price);
            var aboves = Library.Books
                                .Where(b => b.Price > average);
            foreach (var book in aboves) {
                Console.WriteLine(book);
            }
        }

        [ListNo("List 15-5")]
        public void Distinct() {
            var query = Library.Books
                               .Select(b => b.PublishedYear)
                               .Distinct()
                               .OrderBy(y => y);
            foreach (var n in query)
                Console.WriteLine(n);
        }

        [ListNo("List 15-6")]
        public void SortByMultipleKeys() {
            var books = Library.Books
                               .OrderBy(b => b.CategoryId)
                               .ThenByDescending(b => b.PublishedYear);
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        [ListNo("List 15-7")]
        public void ContainsSample() {
            var years = new int[] { 2013, 2016 };
            var books = Library.Books
                               .Where(b => years.Contains(b.PublishedYear));
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }


        [ListNo("List 15-8")]
        public void GroupBySample() {
            var groups = Library.Books
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(g => g.Key);
            foreach (var g in groups) {
                Console.WriteLine($"{g.Key}년");
                foreach (var book in g) {
                    Console.WriteLine($"  {book}");
                }
            }
        }

        [ListNo("List 15-9")]
        public void GroupBySample2() {
            var selected = Library.Books
                                  .GroupBy(b => b.PublishedYear)
                                  .Select(group => group.OrderByDescending(b => b.Price)
                                                        .First())
                                  .OrderBy(o => o.PublishedYear);
            foreach (var book in selected) {
                Console.WriteLine($"{book.PublishedYear}년 {book.Title} ({book.Price})");
            }
        }


        [ListNo("List 15-10")]
        public void ToLookupSample() {
            var lookup = Library.Books
                                .ToLookup(b => b.PublishedYear);
            var books = lookup[2014];
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }
    }
}
