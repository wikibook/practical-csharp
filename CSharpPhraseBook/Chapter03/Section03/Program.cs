using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 3")]
    class SampleCode  { 

        public void ExistsSample() { 
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var exists = list.Exists(s => s[0] == 'A');
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        public void FindSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var name = list.Find(s => s.Length == 6);
            Console.WriteLine(name);
            Console.WriteLine();
        }

        public void FindIndexSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            int index = list.FindIndex(s => s == "Berlin");
            Console.WriteLine(index);
            Console.WriteLine();
        }

        public void FindAllSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var names = list.FindAll(s => s.Length <= 5);
            foreach (var s in names)
                Console.WriteLine(s);
            Console.WriteLine();
        }
        public void RemoveAllSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var removedCount = list.RemoveAll(s => s.Contains("on"));
            Console.WriteLine("{0} {1}", removedCount, list.Count);
            Console.WriteLine();
        }

        public void ForEachSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            list.ForEach(s => Console.WriteLine(s));
            foreach (var s in list)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        public void ConvertAllSample() {
            var list = new List<string> {
               "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var lowerList = list.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));
        }
    }
}
