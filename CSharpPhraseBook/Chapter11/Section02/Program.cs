using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 11")]
    class SampleCode  {

        [ListNo("List 11-2")]
        public void GetAllElements1() {
            var xdoc = XDocument.Load("novelists.xml");
            var xelements = xdoc.Root.Elements();
            foreach (var xnovelist in xelements) {
                XElement xname = xnovelist.Element("name");
                Console.WriteLine(xname.Value);
            }
        }


        [ListNo("List 11-3")]
        public void GetAllElements2() {
            var xdoc = XDocument.Load("novelists.xml");
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }
        }


        [ListNo("List 11-4")]
        public void GetAttribute() {
            var xdoc = XDocument.Load("novelists.xml");
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                XAttribute xeng = xname.Attribute("eng");
                Console.WriteLine("{0} {1}", xname.Value, xeng?.Value);
            }
        }


        [ListNo("List 11-5")]
        public void ExtractElements() {
            var xdoc = XDocument.Load("novelists.xml");
            var xnovelists = xdoc.Root.Elements()
                                 .Where(x => ((DateTime)x.Element("birth")).Year >= 1900);
            foreach (var xnovelist in xnovelists) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }
        }

        [ListNo("List 11-6")]
        public void SortElements() {
            var xdoc = XDocument.Load("novelists.xml");
            var xnovelists = xdoc.Root.Elements()
                                 .OrderBy(x => (string)(x.Element("name").Attribute("eng")));
            foreach (var xnovelist in xnovelists) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            }
        }

        [ListNo("List 11-7")]
        public void GetNestingElements() {
            var xdoc = XDocument.Load("novelists.xml");
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var works = xnovelist.Element("masterpieces")
                                     .Elements("title")
                                     .Select(x => x.Value);
                Console.WriteLine("{0} - {1}", xname.Value, string.Join(", ", works));
            }
        }

        [ListNo("List 11-8")]
        public void GetDescendants() {
            var xdoc = XDocument.Load("novelists.xml");
            var xtitles = xdoc.Root.Descendants("title");
            foreach (var xtitle in xtitles) {
                Console.WriteLine(xtitle.Value);
            }
        }

        [ListNo("List 11-9")]
        public void Projection() {
            var xdoc = XDocument.Load("novelists.xml");
            var novelists = xdoc.Root.Elements()
                                .Select(x => new {
                                    Name = (string)x.Element("name"),
                                    Birth = (DateTime)x.Element("birth"),
                                    Death = (DateTime)x.Element("death")
                                });
            foreach (var novelist in novelists) {
                Console.WriteLine("{0} ({1}-{2})",
                                   novelist.Name, novelist.Birth.Year, novelist.Death.Year);
            }
        }

        [ListNo("List 11-10")]
        public void Projection3() {
            var novelists = ReadNovelists();
            foreach (var novelist in novelists) {
                Console.WriteLine("{0} ({1}-{2}) - {3}",
                    novelist.Name, novelist.Birth.Year, novelist.Death.Year,
                    string.Join(", ", novelist.Masterpieces));
            }
        }

        // List 11-10
        public IEnumerable<Novelist> ReadNovelists() {
            var xdoc = XDocument.Load("novelists.xml");
            var novelists = xdoc.Root.Elements()
                                .Select(x => new Novelist {
                                    Name = (string)x.Element("name"),
                                    KanaName = (string)(x.Element("name").Attribute("eng")),
                                    Birth = (DateTime)x.Element("birth"),
                                    Death = (DateTime)x.Element("death"),
                                    Masterpieces = x.Element("masterpieces")
                                                     .Elements("title")
                                                     .Select(title => title.Value)
                                                     .ToArray()
                                });
            return novelists.ToArray();
        }

    }
}
