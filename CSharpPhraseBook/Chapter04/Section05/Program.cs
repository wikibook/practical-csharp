using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0405 {
    class Program {
        static void Main(string[] args) {
            // 이 프로젝트에 포함된 코드는 모두 책에 게재돼 있는 코드이지만
            // 실행 가능한 완성된 코드는 아닙니다.
        }
    }

    class SampleCode {
        // List 4-31
        public int MinimumLength { get; set; } = 6;


        // List 4-32
        public string DefaultUrl { get; set; } = GetDefaultUrl();


        private static string GetDefaultUrl() {
            return "http://www.msn.com/ja-jp/news/";
        }

    }

}
