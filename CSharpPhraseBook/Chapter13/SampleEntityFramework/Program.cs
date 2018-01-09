using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {

    // 이 프로그램은 반복해서 실행되지 않는다는 것을 전제로 하고 있습니다.
    // 반복 실행하려면 p.331에 있는 '[칼럼]：데이터베이스를 다시 생성할 때 조작하는 순서'에 따라
    // 데이터베이스를 일단 삭제한 후에 실행하기 바랍니다.
    
    class Program {
        static void Main(string[] args) {
            InsertBooks();
            Console.Write("데이터를 삽입했습니다. 계속하려면 Enter 키를 누르세요.");
            Console.ReadLine();
            Console.WriteLine();

            DisplayAllBooks();
            Console.Write("모든 서적을 표시했습니다. 계속하려면 Enter 키를 누르세요.");
            Console.ReadLine();
            Console.WriteLine();

            AddAuthors();
            Console.Write("서적을 추가했습니다. 계속하려면 Enter 키를 누르세요.");
            Console.ReadLine();
            Console.WriteLine();

            AddBooks();
            Console.WriteLine("서적을 추가했습니다.");
            DisplayAllBooks();
            Console.Write("모든 서적을 표시했습니다. 계속하려면 Enter 키를 누르세요.");
            Console.ReadLine();
        }


        // List 13-5
        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "별의 계승자",
                    PublishedYear = 1977,
                    Author = new Author {
                        Birthday = new DateTime(1941, 06, 27),
                        Gender = "M",
                        Name = "제임스 P. 호건",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "타임머신",
                    PublishedYear = 1895,
                    Author = new Author {
                        Birthday = new DateTime(1866, 09, 21),
                        Gender = "M",
                        Name = "허버트 조지 웰즈",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        // List 13-7
        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(book => book.Author.Name.StartsWith("제임스"))
                         .ToList();
            }
        }

        
        static IEnumerable<Book> GetAllBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books.ToList();
            }
        }

        // List 13-8
        static void DisplayAllBooks() {
            var books = GetAllBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title} {book.PublishedYear}");
            }
        }

        // List 13-9
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1890, 09, 15),
                    Gender = "F",
                    Name = "애거사 크리스티"
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1812, 02, 07),
                    Gender = "M",
                    Name = "찰스 디킨스"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        // List 13-10
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "애거사 크리스티");
                var book1 = new Book {
                    Title = "그리고 아무도 없었다",
                    PublishedYear = 1939,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "찰스 디킨스");
                var book2 = new Book {
                    Title = "두 도시 이야기",
                    PublishedYear = 1859,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

    }
}
