using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {

    [SampleCode("Chapter 16")]
    class Section0602  {

        [ListNo("List 16-21의 비병렬 버전")]
        public void RunSync() {
            var sw = Stopwatch.StartNew();
            var prime1 = GetPrimeAt5000();
            var prime2 = GetPrimeAt6000();
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"실행 시간: {sw.ElapsedMilliseconds}밀리초");
        }


        // List 16-20

        // 5000번째 소수를 구한다
        private static int GetPrimeAt5000() {
            return GetPrimes().Skip(4999).First();
        }

        // 6000번째 소수를 구한다
        private static int GetPrimeAt6000() {
            return GetPrimes().Skip(5999).First();
        }

        // 위의 두 개의 메서드가 호출하는 하위 메서드
        // 일부러 효율이 나쁜 알고리즘으로 구현했습니다
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

        [ListNo("List 16-21")]
        public void Run21() {
            // Wait()를 호출해도 콘솔 응용 프로그램은 데드락을 발생시키지 않는다
            // WindowsForms、ASP.NET MVC 등에서 데드락이 발생할 위험이 있으므로 주의해야 한다
            RunAsync().Wait();
        }



        // List 16-21
        private async Task RunAsync() {
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

        [ListNo("List 16-22")]
        public void Run22() {
            // Wait()를 호출해도 콘솔 응용 프로그램은 데드락을 발생시키지 않는다
            // WindowsForms、ASP.NET MVC 등에서는 데드락이 발생하지 않으므로 주의해야 한다
            WhenAll().Wait();
        }

        // List 16-22
        public async Task WhenAll() {
            var sw = Stopwatch.StartNew();
            var tasks = new Task<int>[] {
                Task.Run(() => GetPrimeAt5000()),
                Task.Run(() => GetPrimeAt6000()),
            };
            var results = await Task.WhenAll(tasks);
            foreach (var prime in results)
                Console.WriteLine(prime);
            Console.WriteLine($"실행 시간: {sw.ElapsedMilliseconds}밀리초");
        }


    }
}
