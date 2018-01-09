using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            var outfile = "output.xml";
            ChangeXmlFormat(file, outfile);

            // 이 코드는 확인용이다
            var text = File.ReadAllText(outfile);
            Console.WriteLine(text);
        }

        private static void ChangeXmlFormat(string file, string outfile) {
            var xdoc = XDocument.Load(file);
            var words = xdoc.Root.Elements()
                             .Select(x =>
                                new XElement("word",
                                    new XAttribute("chinese", x.Element("chinese").Value),
                                    new XAttribute("korean", x.Element("korean").Value)
                                )
                             );
            var root = new XElement("seoulku", words);
            root.Save(outfile);
        }
    }
}
