using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    // List 1-1
    public class Product {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        // 생성자
        public Product(int code, string name, int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        // 소비세를 구한다
        public int GetTax() {
            return (int)(Price * 0.08);
        }

        // 세금을 포함한 가격을 구한다
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }

    }
}
