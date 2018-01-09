using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 12")]
    class SampleCode  {
        [ListNo("List 12-2")]
        public void Serialize() {
            var novel = new Novel {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };
            var settings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = "  ",
            };
            using (var writer = XmlWriter.Create("novel.xml", settings)) {
                var serializer = new DataContractSerializer(novel.GetType());
                serializer.WriteObject(writer, novel);
            }

            Display("novel.xml");
        }

        [ListNo("List 12-3")]
        public void Deserialize() {
            using (var reader = XmlReader.Create("novel.xml")) {
                var serializer = new DataContractSerializer(typeof(Novel));
                var novel = serializer.ReadObject(reader) as Novel;
                Console.WriteLine(novel);
            }
        }

        [ListNo("List 12-4")]
        public void SerializeCollection() {
            var novels = new Novel[] {
               new Novel {
                  Author = "제임스 P. 호건",
                  Title = "별의 계승자",
                  Published = 1977,
               },
               new Novel {
                  Author = "허버트 조지 웰즈",
                  Title = "타임머신",
                  Published = 1895,
               },
            };
            using (var writer = XmlWriter.Create("novels.xml")) {
                var serializer = new DataContractSerializer(novels.GetType());
                serializer.WriteObject(writer, novels);
            }

            Display("novels.xml");
        }

        [ListNo("List 12-5")]
        public void DeserializeCollection() {
            using (XmlReader reader = XmlReader.Create("novels.xml")) {
                var serializer = new DataContractSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(reader) as Novel[];
                foreach (var novel in novels) {
                    Console.WriteLine(novel);
                }
            }
        }

        private void Display(string filename) {
            var lines = File.ReadLines(filename);
            foreach (var line in lines)
                Console.WriteLine(line);

        }
    }
}
