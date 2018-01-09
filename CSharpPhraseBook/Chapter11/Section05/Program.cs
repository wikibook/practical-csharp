using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section05 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 11")]
    class SampleCode {
        [ListNo("List 11-22")]
        public void CrearePairData() {
            var option = new XElement("option");
            option.SetElementValue("enabled", true);
            option.SetElementValue("min", 0);
            option.SetElementValue("max", 100);
            option.SetElementValue("step", 10);
            var root = new XElement("settings", option);
            root.Save("sample.xml");

            Display("sample.xml");
        }

        // 실행되는 순서는 List 11-22, List 11-24
        [ListNo("List 11-24")]
        public void ReadPairData() {
            var xdoc = XDocument.Load("sample.xml");
            var option = xdoc.Root.Element("option");
            Console.WriteLine((bool)option.Element("enabled"));
            Console.WriteLine((int)option.Element("min"));
            Console.WriteLine((int)option.Element("max"));
            Console.WriteLine((int)option.Element("step"));
        }

        // 실행되는 순서는 List 11-23, List 11-25
        [ListNo("List 11-23")]
        public void CreatePairData2() {
            var option = new XElement("option");
            option.SetAttributeValue("enabled", true);
            option.SetAttributeValue("min", 0);
            option.SetAttributeValue("max", 100);
            option.SetAttributeValue("step", 10);
            var root = new XElement("settings", option);
            root.Save("sample.xml");
            Display("sample.xml");
        }

        [ListNo("List 11-25")]
        public void ReadPairDat2() {
            var xdoc = XDocument.Load("sample.xml");
            var option = xdoc.Root.Element("option");
            Console.WriteLine((bool)option.Attribute("enabled"));
            Console.WriteLine((int)option.Attribute("min"));
            Console.WriteLine((int)option.Attribute("max"));
            Console.WriteLine((int)option.Attribute("step"));
        }

        [ListNo("List 11-26")]
        public void DictionaryToXml() {
            var dict = new Dictionary<string, string> {
                ["IAEA"] = "국제 원자력 기구",
                ["IMF"] = "국제통화기금",
                ["ISO"] = "국제 표준화 기구",
            };
            var query = dict.Select(x => new XElement("word",
                                           new XAttribute("abbr", x.Key),
                                           new XAttribute("korean", x.Value)));
            var root = new XElement("abbreviations", query);
            root.Save("abbreviations.xml");

            Display("abbreviations.xml");
        }

        [ListNo("List 11-27")]
        public void DictionaryFromXml() {
            var xdoc = XDocument.Load("abbreviations.xml");
            var pairs = xdoc.Root.Elements()
                            .Select(x => new {
                                Key = x.Attribute("abbr").Value,
                                Value = x.Attribute("korean").Value
                            });
            var dict = pairs.ToDictionary(x => x.Key, x => x.Value);
            foreach (var d in dict) {
                Console.WriteLine(d.Key + "=" + d.Value);
            }
        }

        [ListNo("List 11-28")]
        public void DictionaryFromXml2() {
            var xmlstring = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <abbreviations>
                  <IAEA>국제 원자력 기구</IAEA>
                  <IMF>국제통화기금</IMF>
                  <ISO>국제 표준화 기구</ISO>
                </abbreviations>";
            var xwork = XDocument.Parse(xmlstring);
            xwork.Save("abbreviations2.xml");

            // List 11-28
            var xdoc = XDocument.Load("abbreviations2.xml");
            var pairs = xdoc.Root.Elements()
                            .Select(x => new {
                                Key = x.Name.LocalName,
                                Value = x.Value
                            });
            var dict = pairs.ToDictionary(x => x.Key, x => x.Value);
            foreach (var d in dict) {
                Console.WriteLine(d.Key + "=" + d.Value);
            }
        }


        public void Display(string filename) {
            var lines = File.ReadLines(filename);

            // 이 아래에 있는 코드는 확인용이다
            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

    }
}
