using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0407 {
    class SampleClass1 {
        // 中央値を求めるメソッド
        public double Median(params double[] args) {
            var sorted = args.OrderBy(n => n).ToArray();
            int index = sorted.Length / 2;
            if (sorted.Length % 2 == 0)
                return (sorted[index] + sorted[index - 1]) / 2;
            else
                return sorted[index];
        }


        public void WriteLog(string format, params object[] args) {
            var s = String.Format(format, args);
            // ログファイルへ出力する
            WriteLine(s);
        }

        private void WriteLine(string s) {
            Console.WriteLine(s);  // サンプルなのでコンソールへ出力
        }

        public void DoSomething2(int num, string message = "失敗しました", int retryCount = 3) {
            Console.WriteLine("num={0}, message={1}, retryCount={2}", num, message, retryCount);
        }

        public void DoSomething(int num, string message, int retryCount) {  }

        public void DoSomething(int num, string message) {
            DoSomething(num, message, 3);          // 〈←第3引数にデフォルト値を設定し、3つの引数を持つDoSomethingを呼び出す〉
}

        public void DoSomething(int num) {
            DoSomething(num, "DefaultMessage", 3);  //〈←第2、第3引数にデフォルト値を設定し、3つの引数を持つDoSomethingを呼び出す〉
}

    }
}
