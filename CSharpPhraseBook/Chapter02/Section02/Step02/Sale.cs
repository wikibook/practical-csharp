using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    // 매출 클래스
    public class Sale {
        // 점포 이름
        public string ShopName { get; set; }

        // 상품 종류
        public string ProductCategory { get; set; }

        // 매출액
        public int Amount { get; set; }
    }
}
