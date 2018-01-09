using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 7")]
    class SampleCode {
        [ListNo("List 7-11")]
        public void ListToDictionary() {
            var employees = new List<Employee>() {
                 new Employee(100, "이몽룡"),
                 new Employee(112, "변학도"),
                 new Employee(125, "성춘향"),
            };

            var employeeDict = employees.ToDictionary(emp => emp.Code);

            Console.WriteLine(employeeDict[100].Name);
            Console.WriteLine(employeeDict[112].Name);
            Console.WriteLine(employeeDict[125].Name);
        }

        [ListNo("List 7-12")]
        public void DictionrayToDictionary() {
            var flowerDict = new Dictionary<string, int>() {
               { "sunflower", 400 },
               { "pansy", 300 },
               { "tulip", 200 },
               { "rose", 500 },
               { "dahlia", 400 },
            };
            var newDict = flowerDict.Where(x => x.Value >= 400)
                                    .ToDictionary(flower => flower.Key, flower => flower.Value);
            foreach (var item in newDict.Keys) {
                Console.WriteLine(item);
            }
        }

        [ListNo("List 7-13")]
        public void CustomClassSample() {
            var dict = new Dictionary<MonthDay, string> {
               { new MonthDay(6, 6), "현충일" },
               { new MonthDay(8, 15), "광복절" },
               { new MonthDay(10, 3), "개천절" },
            };
            var md = new MonthDay(8, 15);
            var s = dict[md];
            Console.WriteLine(s);
        }

        [ListNo("List 7-16")]
        public void WordsExtractorSample() {
            var lines = File.ReadAllLines("sample.txt");
            var we = new WordsExtractor(lines);
            foreach (var word in we.Extract()) {
                Console.WriteLine(word);
            }
        }

        [ListNo("List 7-17")]
        public void DuplicateKeySample() {
            // 딕셔너리를 초기화한다
            var dict = new Dictionary<string, List<string>>() {
               { "PC", new List<string> { "퍼스널 컴퓨터", "프로그램 카운터", } },
               { "CD", new List<string> { "컴팩트 디스크", "캐시 디스펜서", } },
            };

            // 딕셔너리에 추가한다
            var key = "EC";
            var value = "전자상거래";
            if (dict.ContainsKey(key)) {
                dict[key].Add(value);
            } else {
                dict[key] = new List<string> { value };
            }

            // 딕셔너리의 내용을 열거한다
            foreach (var item in dict) {
                foreach (var term in item.Value) {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
        }


    }
}
