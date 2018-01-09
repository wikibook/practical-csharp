using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0404 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 4")]
    class SampleCode {


        [ListNo("List 4-25")]
        public void Sample01() {
            var list = new List<int> { 10, 20, 30, 40 };
            var key = 40;
            var num = list.Contains(key) ? 1 : 0;
            Console.WriteLine(num);

        }

        [ListNo("List 4-26")]
        public void Sample02() {
            var list = new List<int> { 10, 20, 30, 40 };
            var key = 40;

            // 인수를 넘겨줄 때도 사용한다
            DoSomething(list.Contains(key) ? 1 : 0);
        }
        private void DoSomething(int n) {
            Console.WriteLine(n);
        }

        [ListNo("List 4-27")]
        public void Sample03() {
            string code = "12345";
            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);
        }

        private static object DefaultMessage() {
            return "Default Message";
        }

        private static object GetMessage(object code) {
            return null;
        }

        // List 4-28
        private static Product GetProductA() {
            Sale sale = new Sale();
            return sale?.Product;
        }


        // List 4-29
        private static Product GetProductB() {
            Sale sale = new Sale();
            return sale == null ? null : sale.Product;
        }
        private static Product GetProduct(int id) {
            return new Product();
        }


        // List 4-30
        [ListNo("List 4-30")]
        public void Sample04() {
            var id = 10;
            var DefaultName = "";
            var product = GetProduct(id);
            var name = product?.Name ?? DefaultName;
            Console.WriteLine(name);
        }
    }

    class Sale {
        // 점포 이름
        public string ShopName { get; set; }

        // 매출액
        public int Amount { get; set; }

        public Product Product { get; set; }
    }
}
