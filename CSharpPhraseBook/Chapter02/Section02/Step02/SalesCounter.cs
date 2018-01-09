﻿// List 2-22

using System;
using System.Collections.Generic;
using System.IO;

namespace SalesCalculator {
    // 매출 계산 클래스
    public class SalesCounter {

        private List<Sale> _sales;


        // 생성자
        public SalesCounter(string filePath) { 
            _sales = ReadSales(filePath);
        }

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

        // 매출 데이터를 읽어들이고 Sale 오브젝트의 리스트를 반환한다
        private static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            return sales;
        }


    }
}
