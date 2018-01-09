using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 7")]
    class SampleCode  {

        [ListNo("List 7-1")]
        public void InitializeDictionary() {
            var flowerDict = new Dictionary<string, int>() {
                { "sunflower", 400 },
                { "pansy", 300 },
                { "tulip", 350 },
                { "rose", 500 },
                { "dahlia", 450 },
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);
        }

        [ListNo("List 7-2")]
        public void InitializeDictionary2() {
            var flowerDict = new Dictionary<string, int>() {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);
        }

        [ListNo("List 7-3")]
        public void InitializeDictionary3() {
            var employeeDict = new Dictionary<int, Employee> {
               { 100, new Employee(100, "이몽룡") },
               { 112, new Employee(112, "변학도") },
               { 125, new Employee(125, "성춘향") },
            };

            // 아래는 확인용 코드이다
            var emp0 = employeeDict[100];
            Console.WriteLine($"{emp0.Id} {emp0.Name}");
            var emp1 = employeeDict[112];
            Console.WriteLine($"{emp1.Id} {emp1.Name}");
            var emp2 = employeeDict[125];
            Console.WriteLine($"{emp2.Id} {emp2.Name}");

        }

        private Dictionary<string, int> flowerDict = new Dictionary<string, int>()  {
            { "sunflower", 400 },
            { "pansy", 300 },
            { "tulip", 350 },
            { "rose", 500 },
            { "dahlia", 450 },
        };

        private Dictionary<int, Employee> employeeDict = new Dictionary<int, Employee> {
            { 100, new Employee(100, "이몽룡") },
            { 112, new Employee(112, "변학도") },
            { 125, new Employee(125, "성춘향") },
        };

        // AddItem 뒤에 AddItem2를 호출하면 예외가 발생하므로 이것을 먼저 실행한다
        [ListNo("List 7-5")]
        public void AddItem1() {
            flowerDict.Add("violet", 600);
            employeeDict.Add(126, new Employee(126, "김향단"));

            Console.WriteLine(flowerDict["violet"]);
            Console.WriteLine(employeeDict[126].Name);
        }

        [ListNo("List 7-4")]
        public void AddItem2() {
            flowerDict["violet"] = 600;

            employeeDict[126] = new Employee(126, "김향단");

            Console.WriteLine(flowerDict["violet"]);
            Console.WriteLine(employeeDict[126].Name);
        }


        [ListNo("List 7-6")]
        public void GetItem() {

            int price = flowerDict["rose"];

            var employee = employeeDict[125];

            Console.WriteLine($"price={price}");
            Console.WriteLine($"employee={employee.Id} {employee.Name}");
        }

        [ListNo("List 7-7")]
        public void ContainsKey() {
            var key = "pansy";
            if (flowerDict.ContainsKey(key)) {
                var price = flowerDict[key];
                Console.WriteLine(price);
            }
        }

        [ListNo("List 7-8")]
        public void RemoveItem() {
            var result = flowerDict.Remove("pansy");
            Console.WriteLine(result);
        }

        [ListNo("List 7-9")]
        public void GetAllItems() {
            foreach (var item in flowerDict)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            Console.WriteLine();

            var average = flowerDict.Average(x => x.Value);
            Console.WriteLine(average);

            int total = flowerDict.Sum(x => x.Value);
            Console.WriteLine(total);

            var items = flowerDict.Where(x => x.Key.Length <= 5);
            foreach (var item in items)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);

        }


        [ListNo("List 7-10")]
        public void GetAllKeys() {
            foreach (var key in flowerDict.Keys)
                Console.WriteLine(key);
        }
        
    }
}
