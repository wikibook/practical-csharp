using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 11")]
    class SampleCode  {
        [ListNo("List 11-15")]
        public void AddElement() {
            var element = new XElement("novelist",
                new XElement("name", "찰스 디킨스", new XAttribute("eng", "Charles Dickens")),
                new XElement("birth", "1812-02-07"),
                new XElement("death", "1870-06-09"),
                new XElement("masterpieces",
                  new XElement("title", "올리버 트위스트"),
                  new XElement("title", "크리스마스 캐럴")
                )
              );
            var xdoc = XDocument.Load("novelists.xml");
            xdoc.Root.Add(element);

            // 이후는 확인용 코드이다
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            } 
            //Display(xdoc);
        }

        [ListNo("List 11-16")]
        public void RemoveElement() {
            var xdoc = XDocument.Load("novelists.xml");
            var elements = xdoc.Root.Elements()
                               .Where(x => x.Element("name").Value == "마크 트웨인");
            elements.Remove();
            Display(xdoc);
        }

        [ListNo("List 11-17")]
        public void ReplaceElement1() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                                   .Single(x => x.Element("name").Value == "마크 트웨인");
            string elmstring =
              @"<novelist>
                <name eng=""Mark Twain"">마크 트웨인</name>
                <birth>1835-11-30</birth>
                <death>1910-03-21</death>
                <masterpieces>
                  <title>도금시대</title>
                  <title>아서 왕 궁정의 코네티컷 양키</title>
                </masterpieces>
              </novelist>";
            var newElement = XElement.Parse(elmstring);
            element.ReplaceWith(newElement);
            Display(xdoc);
        }

        [ListNo("List 11-18")]
        public void ReplaceElement2() {
            var xdoc = XDocument.Load("novelists.xml");
            Display(xdoc);
            var element = xdoc.Root.Elements()
                              .Single(x => x.Element("name").Value == "마크 트웨인")
                              .Element("masterpieces");
            var newElement = new XElement("masterpieces",
                new XElement("title", "도금시대"),
                new XElement("title", "아서 왕 궁정의 코네티컷 양키")
            );
            element.ReplaceWith(newElement);
            Display(xdoc);
        }

        [ListNo("List 11-19")]
        public void ReplaceElement3() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                              .Select(x => x.Element("name"))
                              .Single(x => x.Value == "마크 트웨인");
            element.Value = "마크 트웨인";
            Display(xdoc);
        }

        // 책에서는 로드한 XML을 그대로 저장하는 코드를 게재했지만
        // 이 코드는 요소를 수정하고나서 저정한다
        [ListNo("List 11-20")]
        public void SaveXMLDocument() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                              .Select(x => x.Element("name"))
                              .Single(x => x.Value == "마크 트웨인");
            element.Value = "마크 트웨인";
            xdoc.Save("newNovelists.xml", SaveOptions.DisableFormatting);

            var xnewdoc = XDocument.Load("newNovelists.xml");
            Display(xnewdoc);
        }

        private void Display(XDocument xdoc) {
            // 이 아래에 있는 코드는 확인용이다
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var xeng = xname.Attribute("eng");
                var birth = (DateTime)xnovelist.Element("birth");
                var masterpieces = xnovelist.Element("masterpieces").Elements().Select(x => x.Value);
                
                Console.WriteLine("{0}({1}) {2} - {3}", xname.Value, xeng.Value, birth.ToShortDateString(),
                    string.Join(", ", masterpieces));
            }
            Console.WriteLine();
        }
    }
}
