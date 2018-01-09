using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// 16장 '[COLUMN] 데드락을 피한다'에 나온 코드입니다.
// button1_Click、button2_Click은 데드락이 걸립니다.
// 데드락이 걸린 프로그램을 끝내려면
// 디버그를 실행하고 있는 경우 :[디버그]-[디버그 중지]를 선택해서 끝냅니다.
// 직접 실행하고 있는 경우 : 작업 관리자에서 해당 프로그램을 


namespace AsyncDeadLock {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        // Result 속성을 사용해서 동기 처리한다 -> 데드락이 걸린다
        private void button1_Click(object sender, EventArgs e) {
            var result = DoSomethingAsync().Result;
            label1.Text = result.ToString();
        }

        private async Task<long> DoSomethingAsync() {
            var result = await Task.Run(() => {
                long sum = 0;
                for (int i = 1; i <= 10000000; i++) {
                    sum += i;
                }
                return sum;
            });
            return result;
        }


        // 비동기 메서드를 Wait 메서드로 동기 처리한다 -> 데드락이 걸린다
        private void button2_Click(object sender, EventArgs e) {
            RunAsync().Wait();
        }

        public async Task RunAsync() {
            var sw = Stopwatch.StartNew();
            var task1 = Task.Run(() => GetPrimeAt5000());
            var task2 = Task.Run(() => GetPrimeAt6000());
            var prime1 = await task1;
            var prime2 = await task2;
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"실행 시간: {sw.ElapsedMilliseconds}밀리초");
        }

        // 5000번째 소수를 구한다
        private static int GetPrimeAt5000() {
            return GetPrimes().Skip(4999).First();
        }

        // 6000번째 소수를 구한다
        private static int GetPrimeAt6000() {
            return GetPrimes().Skip(5999).First();
        }

        // 위에 있는 두 개의 메서드로부터 호출되는 하위 메서드이다
        // 일부러 효율이 낮은 알고리즘으로 구현했다
        static IEnumerable<int> GetPrimes() {
            for (int i = 2; i < int.MaxValue; i++) {
                bool isPrime = true;
                for (int j = 2; j < i; j++) {
                    if (i % j == 0) {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    yield return i;
            }
        }

        // 완전히 동기처리로 통일
        private void button3_Click(object sender, EventArgs e) {
            var result = DoSomething();
            label1.Text = result.ToString();
        }

        private long DoSomething() {
            long sum = 0;
            for (int i = 1; i <= 10000000; i++) {
                sum += i;
            }
            return sum;
        }

        // 비동기 메서드로 통일
        private async void button4_Click(object sender, EventArgs e) {
            var result = await DoSomethingAsync();
            label1.Text = result.ToString();
        }

        // 비동기 메서드로 통일
        private void button5_Click(object sender, EventArgs e) {
            var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() => {
                return DoSomethingAsync().Result;
            })
            .ContinueWith(task => {
                label1.Text = task.Result.ToString();
            }, currentContext);
        }

        private void button6_Click(object sender, EventArgs e) {
            label1.Text = "";
        }
    }
}
