using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

            // 이 코드는 확인용이다
            var text = File.ReadAllText(newfile);
            Console.WriteLine(text);
        }

        static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             });
            foreach (var sport in sports) {
                Console.WriteLine("{0} {1}", sport.Name, sport.Teammembers);
            }
        }
        static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                             .Select(x => new {
                                 Firstplayed = x.Element("firstplayed").Value,
                                 Name = x.Element("name").Attribute("chinese").Value
                             })
                             .OrderBy(x => int.Parse(x.Firstplayed));
            foreach (var sport in sports) {
                Console.WriteLine("{0}", sport.Name);
            }
        }

        static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var sport = xdoc.Root.Elements()
                             .Select(x => new {
                                 Name = x.Element("name").Value,
                                 Teammembers = x.Element("teammembers").Value
                             })
                             .OrderByDescending(x => int.Parse(x.Teammembers))
                             .First();
            Console.WriteLine("{0}", sport.Name);
        }

        static void Exercise1_4(string file, string newfile) {
            var xdoc = XDocument.Load(file);
            var element = new XElement("ballsport",
                 new XElement("name", "축구", new XAttribute("chinese", "蹴球")),
                 new XElement("teammembers", "11"),
                 new XElement("firstplayed", "1863")
              );
            xdoc.Root.Add(element);
            xdoc.Save(newfile);
        }

    }
}
