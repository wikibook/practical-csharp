using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 11")]
    class SampleCode  {
        [ListNo("List 11-11")]
        public void CreateXDocumentFromString() {
            string xmlstring =
                  @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                    <novelists>
                      <novelist>
                        <name eng=""Agatha Christie"">아가사 크리스티</name>
                        <birth>1890-09-15</birth>
                        <death>1976-01-12</death>
                        <masterpieces>
                          <title>그리고 아무도 없었다</title>
                          <title>오리엔트 특급 살인</title>
                        </masterpieces>
                      </novelist>
                    </novelists>";
            var xdoc = XDocument.Parse(xmlstring);

            // 내용을 확인한다
            Display(xdoc);

        }

        [ListNo("List 11-12")]
        public void CreateXElementFromString() {
            string elmstring =
              @"<novelist>
                  <name kana=""O. Henry"">오 헨리</name>
                  <birth>1862-10-11</birth>
                  <death>1910-06-05</death>
                  <masterpieces>
                    <title>현자의 선물</title>
                    <title>마지막 잎새</title>
                  </masterpieces>
                </novelist>";
            XElement element = XElement.Parse(elmstring);

            var xdoc = XDocument.Load("novelists.xml");
            xdoc.Root.Add(element);

            // 내용을 확인한다
            Display(xdoc);
        }


        [ListNo("List 11-13")]
        public void CreateXDocumentManually() {
            var novelists = new XElement("novelists",
              new XElement("novelist",
                new XElement("name", ">마크 트웨인", new XAttribute("eng", "Mark Twain")),
                new XElement("birth", "1835-11-30"),
                new XElement("death", "1910-03-21"),
                new XElement("masterpieces",
                    new XElement("title", "톰 소여의 모험"),
                    new XElement("title", "허클베리 핀의 모험"),
                    new XElement("title", "왕자와 거지")
                )
              ),
              new XElement("novelist",
                  new XElement("name", "어니스트 헤밍웨이", new XAttribute("eng", "Ernest Hemingway")),
                  new XElement("birth", "1899-07-21"),
                  new XElement("death", "1961-07-02"),
                  new XElement("masterpieces",
                     new XElement("title", "무기여 잘 있거라"),
                     new XElement("title", "노인과 바다")
                  )
              )
            );
            var xdoc = new XDocument(novelists);

            // 내용을 확인한다  ToString()로 XML형식 문자열을 구할 수 있다
            Console.WriteLine(xdoc.ToString());
        }

        [ListNo("List 11-14")]
        public void CreateXDocumentFromCollection() {
            // Novelist의 목록을 준비한다
            var novelists = new List<Novelist> {
              new Novelist {
                Name = "마크 트웨인",
                EngName = "Mark Twain",
                Birth = DateTime.Parse("1835-11-30"),
                Death = DateTime.Parse("1910-03-21"),
                Masterpieces = new string[] { "톰 소여의 모험", "허클베리 핀의 모험", },
              },
              new Novelist {
                  Name = "어니스트 헤밍웨이",
                  EngName = "Ernest Hemingway",
                  Birth = DateTime.Parse("1899-07-21"),
                  Death = DateTime.Parse("1961-07-02"),
                  Masterpieces = new string[] { "무기여 잘 있거라", "노인과 바다", },
              },

            };

            // Linq to Objects를 사용해서 목록의 내용을 XElement 시퀀스로 변환한다
            var elements = novelists.Select(x =>
              new XElement("novelist",
                new XElement("name", x.Name, new XAttribute("eng", x.EngName)),
                new XElement("birth", x.Birth),
                new XElement("death", x.Death),
                new XElement("masterpieces", x.Masterpieces.Select(t => new XElement("title", t)))
              )
            );

            // 가장 위에 있는 novelists 요소를 생성한다
            var root = new XElement("novelists", elements);

            // root 요소를 지정해서 XDocument 오브젝트를 생성한다
            var xdoc = new XDocument(root);

            // 내용을 확인한다
            Display(xdoc);

        }

        private void Display(XDocument xdoc) {
            // 이 아래에 있는 코드는 확인용이다
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                var death = (DateTime)xnovelist.Element("death");
                var masterpieces = xnovelist.Element("masterpieces").Elements().Select(x => x.Value);

                Console.WriteLine("{0}({1}-{2}) - {3}", xname.Value, birth.ToShortDateString(), death.ToShortDateString(),
                    string.Join(", ", masterpieces));
            }
            Console.WriteLine();
        }

    }


}
