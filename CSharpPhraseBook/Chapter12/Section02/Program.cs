using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 12")]
    class SampleCode  {


        [ListNo("List 12-6")]
        public void SerializeToFile() {
            var novel = new Novel {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };
            using (var writer = XmlWriter.Create("novel.xml")) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }

            Display("novel.xml");

        }

        public void SerializeToString() {
            var novel = new Novel {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb)) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }
            var xmlText = sb.ToString();
            Console.WriteLine(xmlText);
        }

        public void SerializeToStream() {
            var novel = new Novel {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };
            var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream)) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }
            // 버퍼에 있는 데이터를 모두 스트림에 라이트한다
            stream.Flush();
            
            // Position을 0으로 지정해서 리와인드한다
            stream.Position = 0;
            // StreamReader를 사용해서 MemoryStream의 내용을 읽어들인다
            var reader = new StreamReader(stream);
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                Console.WriteLine(line);
            }
        }


        [ListNo("List 12-7")]
        public void Deserialize() {
            using (var reader = XmlReader.Create("novel.xml")) {
                var serializer = new XmlSerializer(typeof(Novel));
                var novel = serializer.Deserialize(reader) as Novel;
                // 아래는 내용을 확인하기 위한 코드이다
                Console.WriteLine(novel);
            }
        }

        public void DeserializeFromString() {
            string xmlText = GetXmlString();

            using (var reader = XmlReader.Create(new StringReader(xmlText))) {
                var serializer = new XmlSerializer(typeof(Novel));
                var novel = serializer.Deserialize(reader) as Novel;
                Console.WriteLine(novel);
            }
        }


        private static string GetXmlString() {
            var novel = new Novel {
                Author = "제임스 P. 호건",
                Title = "별의 계승자",
                Published = 1977,
            };
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb)) {
                var serializer = new XmlSerializer(typeof(Novel));
                serializer.Serialize(writer, novel);
            }
            var xmlText = sb.ToString();
            return xmlText;
        }

        // 코드12,12에 있는 클래스 정의를 시리얼화한다
        [ListNo("List 12-11")]
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
            var novelCollection = new NovelCollection {
                Novels = novels
            };

            using (var writer = XmlWriter.Create("novels.xml")) {
                var serializer = new XmlSerializer(novelCollection.GetType());
                serializer.Serialize(writer, novelCollection);
            }

            Display("novels.xml");


            // 다음은 p.310 아래쪽에 나온 코드입니다.
            // 이 코드를 실행했을 때 책에 나온 설명과 일치되도록 하려면 Novelist 클래스(Novelist.cs)에 추가한
            // 속성 네 개를 모두 주석 처리하고 단독으로 실행하기 바랍니다.
            //
            //var novelist = new Novelist {
            //    Name = "아서 C. 클라크",
            //    Masterpieces = new string[] {
            //        " 2001 스페이스 오디세이",
            //        " 유년기의 끝",
            //    }
            //};
            //using (var writer = XmlWriter.Create("novelist.xml")) {
            //    var serializer = new XmlSerializer(novelist.GetType());
            //    serializer.Serialize(writer, novelist);
            //}
            //
            //Display("novelist.xml");
        }


        [ListNo("List 12-13")]
        public void SerializeArrayMember() {
            using (var reader = XmlReader.Create("novels.xml")) {
                var serializer = new XmlSerializer(typeof(NovelCollection));
                var novels = serializer.Deserialize(reader) as NovelCollection;
                foreach (var novel in novels.Novels) {
                    Console.WriteLine(novel);
                }
            }


            Display("novels.xml");

        }

        private void Display(string filename) {
            var lines = File.ReadLines(filename);
            foreach (var line in lines)
                Console.WriteLine(line);

        }

    }
}
