using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06 {
    [SampleCode("Chapter 6")]
    class Section03  {
        private IEnumerable<Book> books = Books.GetBooks();

        [ListNo("List 6-9")]
        public void Average01() {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            var average = numbers.Average();
            Console.WriteLine(average);
        }

        [ListNo("List 6-10")]
        public void Average02() {
            var average = books.Average(x => x.Price);
            Console.WriteLine(average);
        }

        [ListNo("List 6-11")]
        public void Sum01() {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };

            var sum = numbers.Sum();  
            Console.WriteLine(sum);

            var totalPrice = books.Sum(x => x.Price);
            Console.WriteLine(totalPrice);
        }

        [ListNo("List 6-12")]
        public void Average03() {
            List<int> numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            int sum = 0;
            foreach (int n in numbers) {
                sum += n;
            }
            double average = (double)sum / numbers.Count;
            Console.WriteLine(average);
        }

        [ListNo("List 6-13")]
        public void Min01() {
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4 };
            var min = numbers.Where(n => n > 0)
                             .Min();
            Console.WriteLine(min);
        }

        [ListNo("List 6-14")]
        public void Max01() {
            var pages = books.Max(x => x.Pages);
            Console.WriteLine(pages);
        }

        [ListNo("List 6-15")]
        public void Min02() {
            List<int> numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4 };
            int min = int.MaxValue;
            foreach (int n in numbers) {
                if (n <= 0)
                    continue;   
                if (n < min)
                    min = n;
            }
            Console.WriteLine(min);
        }

        [ListNo("List 6-16")]
        public void Count01() {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            var count = numbers.Count(n => n == 0);
            Console.WriteLine(count);
        }

        [ListNo("List 6-17")]
        public void Count02() {
            var count = books.Count(x => x.Title.Contains("이야기"));
            Console.WriteLine(count);
        }

        [ListNo("List 6-18")]
        public void Count03() {
            List<int> numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            int count = 0;
            foreach (int n in numbers) {
                if (n == 0)
                    count++;
            }
            Console.WriteLine(count);
        }

        [ListNo("List 6-19")]
        public void Count04() {
            int count = 0;
            foreach (Book book in books) {
                if (book.Title.Contains("이야기"))
                    count++;
            }
            Console.WriteLine(count);
        }

    }
}
