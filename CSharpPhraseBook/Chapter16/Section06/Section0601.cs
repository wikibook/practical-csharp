using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {

    [SampleCode("Chapter 16")]
    class Section0601  {
        private  List<Book> books;

        public Section0601() {
            books = new List<Book> {
               new Book { Title = "こころ", Price = 541, Pages = 543 },
               new Book { Title = "二都物語", Price = 842, Pages = 1232 },
               new Book { Title = "人間失格", Price = 643, Pages = 334 },
               new Book { Title = "伊豆の踊子", Price = 432, Pages = 286 },
               new Book { Title = "銀河鉄道の夜", Price = 543, Pages = 385 },
               new Book { Title = "遠野物語", Price = 666, Pages = 381 },
            };
        }

        [ListNo("List 16-16")]
        public void AsParallel() {
            var selected = books.AsParallel()
                                .Where(b => b.Price > 500 && b.Pages > 400)
                                .Select(b => new { b.Title });
            foreach (var book in selected) {
                Console.WriteLine(book.Title);
            }
        }

        [ListNo("List 16-17")]
        public void AsParallelAsOrdered() {
            var selected = books.AsParallel()
                                .AsOrdered()
                                .Where(b => b.Price > 500 && b.Pages > 400)
                                .Select(b => new { b.Title });
            foreach (var book in selected) {
                Console.WriteLine(book.Title);
            }
        }

        [ListNo("List 16-18")]
        public void WithDegreeOfParallelism() {
            var selected = books.AsParallel()
                                .WithDegreeOfParallelism(8)
                                .Where(b => b.Price > 500 && b.Pages > 400)
                                .Select(b => new { b.Title });
            foreach (var book in selected) {
                Console.WriteLine(book.Title);
            }
        }

        [ListNo("List 16-19")]
        public void ForAll() {
            var selected = books.AsParallel()
                                .Where(b => b.Price > 500);
            selected.AsParallel().ForAll(book => {
                Console.WriteLine(book.Title);
            });
        }

    }
}
