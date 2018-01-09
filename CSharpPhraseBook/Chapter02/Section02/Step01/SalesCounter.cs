// List 2-21

using System;
using System.Collections.Generic;

namespace SalesCalculator {

    // List 2-16
    // 매출 계산 클래스
    public class SalesCounter {

        private List<Sale> _sales;

        // 생성자
        public SalesCounter(List<Sale> sales) {
            _sales = sales;
        }

        // List 2-17
        // 점포별 매출을 구한다
        public Dictionary<string, int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Sale sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount;
                else
                    dict[sale.ShopName] = sale.Amount;
            }
            return dict;
        }

    }
}
