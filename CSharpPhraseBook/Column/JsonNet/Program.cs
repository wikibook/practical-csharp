using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

// '[Column] JSON.NET을 이용한다'에 나온 코드입니다

namespace JsonNet {

    class Program {
        static void Main(string[] args) {
            SerializeJson();
            DeserializeJson();
            SerializeJson2();
            Console.ReadLine();
        }

        private static void SerializeJson() {
            var novel = new Novel {
                Author = "로버트 A. 하인라인",
                Title = "여름으로 가는 문",
                Published = 1956,
            };

            using (var stream = new StreamWriter(@"sample.json"))
            using (var writer = new JsonTextWriter(stream)) {
                JsonSerializer serializer = new JsonSerializer {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
                serializer.Serialize(writer, novel);
            }
        }

        private static void DeserializeJson() {
            using (var stream = new StreamReader(@"sample.json"))
            using (var writer = new JsonTextReader(stream)) {
                JsonSerializer serializer = new JsonSerializer {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                };
                var novel = serializer.Deserialize<Novel>(writer);
                Console.WriteLine(novel);
            }
        }


        // 이 부분은 책에 나오지 않았습니다
        private static void SerializeJson2() {
            var novel = new Novelist {
                Name = "아서 C. 클라크",
                Birth = new DateTime(1917, 12, 16),
                Masterpieces = new[] { "2001 스페이스 오디세이", "유년기의 끝", },
            };
            {
                using (var stream = new StreamWriter(@"sample2.json"))
                using (var writer = new JsonTextWriter(stream)) {
                    JsonSerializer serializer = new JsonSerializer {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    };
                    serializer.Serialize(writer, novel);
                }
            }
            {
                using (var stream = new MemoryStream()) {
                    var serializer = new DataContractJsonSerializer(novel.GetType(),
                                      new DataContractJsonSerializerSettings {
                                          DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss")
                                      });
                    serializer.WriteObject(stream, novel);
                    stream.Close();
                    var jsonText = Encoding.UTF8.GetString(stream.ToArray());
                    Console.WriteLine(jsonText);
                }
            }
        }
    }
    [DataContract(Name = "novelist")]

    class Novelist {
        [DataMember(Name ="name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "birth", Order = 2)]
        public DateTime Birth { get; set; }

        [DataMember(Name = "masterpieces", Order = 3)]
        public string[] Masterpieces { get; set; }
    }

}
