using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15 {
	// List 15-11
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return $"Id:{Id}, 분야 이름:{Name}";
        }
    }

    public class Book {

        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }

        public override string ToString() {
            return $"발행연도:{PublishedYear}, 분야:{CategoryId}, 가격:{Price}, 제목:{Title}";
        }
    }

    public static class Library {
        // Categories 속성을 통해 나온 분야의 목록을 구할 수 있다
        public static IEnumerable<Category> Categories { get; private set; }

        // Books 속성을 통해 위에 나온 서적 정보를 구할 수 있다
        public static IEnumerable<Book> Books { get; private set; }

        static Library() {
            Categories = new List<Category> {
                new Category { Id = 1, Name = "Development"  },
                new Category { Id = 2, Name = "Server"  },
                new Category { Id = 3, Name = "Web Design"  },
                new Category { Id = 4, Name = "Windows"  },
                new Category { Id = 5, Name = "Application"  },
            };

            Books = new List<Book> {
                new Book { Title = "Writing C# Solid Code", CategoryId = 1, Price = 25000, PublishedYear = 2016 },
                new Book { Title = "C# 개발지침", CategoryId = 1, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "Visual C# 다시 입문", CategoryId = 1, Price = 27800, PublishedYear = 2016 },
                new Book { Title = "구문으로 배우는 C# Book", CategoryId = 1, Price = 24000, PublishedYear = 2016 },
                new Book { Title = "TypeScript 초급 강좌", CategoryId = 1, Price = 25000, PublishedYear = 2015 },
                new Book { Title = "PowerShell 실전 레시피", CategoryId = 2, Price = 42000, PublishedYear = 2013 },
                new Book { Title = "SQL Server 완전 입문", CategoryId = 2, Price = 38000, PublishedYear = 2014 },
                new Book { Title = "IIS 웹 서버 운용 가이드", CategoryId = 2, Price = 31800, PublishedYear = 2015 },
                new Book { Title = "마이크로소프트 Azure 서버 구축", CategoryId = 2, Price = 48000, PublishedYear = 2016 },
                new Book { Title = "웹 디자인 강좌 HTML5 & CSS", CategoryId = 3, Price = 28000, PublishedYear = 2013 },
                new Book { Title = "HTML5 웹 대백과", CategoryId = 3, Price = 38000, PublishedYear = 2015 },
                new Book { Title = "CSS 디자인 사전", CategoryId = 3, Price = 35500, PublishedYear = 2015 },
                new Book { Title = "Windows10으로 즐겁게 일하기", CategoryId = 4, Price = 22800, PublishedYear = 2016 },
                new Book { Title = "Windows10의 고수가 되는 법", CategoryId = 4, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Windows10의 고수가 되는 법2", CategoryId = 4, Price = 20800, PublishedYear = 2016 },
                new Book { Title = "Windows10 쉽게 다루자 입문편", CategoryId = 4, Price = 23000, PublishedYear = 2015 },
                new Book { Title = "너무 쉬운 Windows10 입문", CategoryId = 5, Price = 18900, PublishedYear = 2015 },
                new Book { Title = "Word Excel 실전 템플레이트 모음집", CategoryId = 5, Price = 26000, PublishedYear = 2016 },
                new Book { Title = "즐겁게 배우는 Excel 초급편", CategoryId = 5, Price = 28000, PublishedYear = 2015 },
            };
        }
    }
}
