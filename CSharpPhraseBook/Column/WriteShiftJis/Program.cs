using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 9장 '[Column] 문자 인코딩을 지정해서 파일에 출력한다'에 나온 코드입니다
//
// C:\Example 폴더를 준비한 후에 실행하기 바랍니다

namespace WriteShiftJis {
    class Program {
        static void Main(string[] args) {
            var filePath = @"C:\Example\Greeting.txt";
            var sjis = Encoding.GetEncoding("shift_jis");
            using (var writer = new StreamWriter(filePath, append: false, encoding: sjis)) {
                writer.WriteLine("동해물과 백두산이");
                writer.WriteLine("마르고 닳도록");
                writer.WriteLine("하느님이 보우하사");
                writer.WriteLine("우리나라 만세");
            }
        }
    }
}
