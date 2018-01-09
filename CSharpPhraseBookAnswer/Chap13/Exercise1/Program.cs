using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            // 아래에 있는 세 줄의 코드를 통해 책에 나온 데이터를 삽입한다
            // 실행하면 다음과 같은 두 개의 파일이 생성된다
            // "C:\Users\<사용자 이름>\Exercise1.Models.BooksDbContext.mdf"
            // "C:\Users\<사용자 이름>\Exercise1.Models.BooksDbContext.ldf"
            
            InsertBooks();
            AddAuthors();
            AddBooks();
           

            // 여기부터 문제의 해답이다
            Console.WriteLine("# 1.1");
            Exercise1_1();

            Console.WriteLine("# 1.2");
            Exercise1_2();

            Console.WriteLine("# 1.3");
            Exercise1_3();

            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine();
        }

        private static void Exercise1_1() {
            using (var db = new BooksDbContext()) {
                var king = db.Authors.Single(a => a.Name == "찰스 디킨스");
                var book1 = new Book {
                    Title = "크리스마스 캐럴",
                    PublishedYear = 1843,
                    Author = king,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "애거사 크리스티");
                var book2 = new Book {
                    Title = "밀물을 타고",
                    PublishedYear = 1948,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
            using (var db = new BooksDbContext()) {
                var king = new Author {
                    Birthday = new DateTime(1947, 9, 21),
                    Gender = "M",
                    Name = "스티븐 킹"
                };
                var book1 = new Book {
                    Title = "샤이닝",
                    PublishedYear = 1977,
                    Author = king
                };
                db.Books.Add(book1);

                var golding = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "윌리엄 골딩"
                };
                var book2 = new Book {
                    Title = "파리대왕",
                    PublishedYear = 1954,
                    Author = golding
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        private static void Exercise1_2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.OrderBy(b => b.Author.Id)) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_3() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));
                foreach (var book in books) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .OrderBy(b => b.PublishedYear)
                              .Take(3);
                foreach (var book in books) {
                    Console.WriteLine("{0} {1} {2}({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name, book.Author.Birthday
                    );
                }
            }
        }

        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors
                              .OrderByDescending(a => a.Birthday);
                foreach (var author in authors) {
                    Console.WriteLine("{0} {1:yyyy/MM}", author.Name, author.Birthday);
                    foreach (var book in author.Books)
                        Console.WriteLine("  {0} {1}",
                            book.Title, book.PublishedYear,
                            book.Author.Name, book.Author.Birthday
                    );
                    Console.WriteLine();
                }
            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(book => book.Author.Name.StartsWith("호건"))
                         .ToList();
            }
        }

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
