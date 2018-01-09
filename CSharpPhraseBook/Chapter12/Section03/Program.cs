using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 12")]
    class SampleCode  {

        [ListNo("List 12-15")]
        public void Serialize() {
            var novels = new Novel[] {
              new Novel {
                Author = "아이작 아시모프",
                Title = "나는 로봇이야",
                Published = 1950,
              },
              new Novel {
                Author = "조지 오웰",
                Title = "1984",
                Published = 1949,
              },
            };
            using (var stream = new FileStream("novels.json", FileMode.Create,
                                                FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
            }

            Display("novels.json");
        }
        private static string SerializeToString() {
            var novels = new Novel[] {
              new Novel {
                Author = "아이작 아시모프",
                Title = "나는 로봇이야",
                Published = 1950,
              },
              new Novel {
                Author = "조지 오웰",
                Title = "1984",
                Published = 1949,
              },
            };
            using (var stream = new MemoryStream()) {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
                stream.Close();
                var jsonText = Encoding.UTF8.GetString(stream.ToArray());
                return jsonText;
            }
        }

        [ListNo("List 12-16")]
        public void Deserialize() {
            using (var stream = new FileStream("novels.json", FileMode.Open, FileAccess.Read)) {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                foreach (var novel in novels)
                    Console.WriteLine(novel);
            }
        }

        public void DeserializeFromString() {
            var jsonText = SerializeToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonText);
            using (var stream = new MemoryStream(byteArray)) {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                foreach (var novel in novels)
                    Console.WriteLine(novel);
            }
        }


        [ListNo("List 12-17")]
        public void SerializeDict() {
            var abbreviationDict = new AbbreviationDict {
                Abbreviations = new Dictionary<string, string> {
                    ["ODA"] = "정부개발원조",
                    ["OECD"] = "경제 협력 개발 기구",
                    ["OPEC"] = "석유 수출국 기구",
                }
            };
            var settings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
            };
            using (var stream = new FileStream("abbreviations.json", FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(abbreviationDict.GetType(), settings);
                serializer.WriteObject(stream, abbreviationDict);
            }

            Display("abbreviations.json");
        }


        [ListNo("List 12-18")]
        public void DeserializeDict() {
            var settings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
            };
            using (var stream = new FileStream("abbreviations.json", FileMode.Open, FileAccess.Read)) {
                var serializer = new DataContractJsonSerializer(typeof(AbbreviationDict), settings);
                var dict = serializer.ReadObject(stream) as AbbreviationDict;
                foreach (var item in dict.Abbreviations) {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
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
