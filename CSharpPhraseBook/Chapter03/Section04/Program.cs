using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 3")]
    class SampleCode  { 

        [ListNo("List 3-7")]
        public  void SimpleQuery() {
            var names = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            IEnumerable<string> query = names.Where(s => s.Length <= 5);
            foreach (string s in query)
                Console.WriteLine(s);
        }

        public void SimpleQuery2() {
            var names = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var query = names.Where(s => s.Length <= 5)
                             .Select(s => s.ToLower());
            foreach (string s in query)
                Console.WriteLine(s);
        }

        public void SimpleQuery3() {
            var names = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var query = names.Select(s => s.Length);
            foreach (var n in query)
                Console.Write("{0} ", n);
            Console.WriteLine();
        }


        [ListNo("List 3-8")]
        public void DeferredSample() {
            string[] names = {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra"  };
            var query = names.Where(s => s.Length <= 5);
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("------");

            names[0] = "Osaka";
            foreach (var item in query)
                Console.WriteLine(item);
        }

        [ListNo("List 3-9")]
        public void ImmediateQuery() {
            string[] names = {
              "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra"  };
            var query = names.Where(s => s.Length <= 5)
                             .ToArray();
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("------");

            names[0] = "Osaka";
            foreach (var item in query)
                Console.WriteLine(item);
        }
    }
}
