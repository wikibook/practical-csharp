using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Path.GetFullPath(args[0]));

            var obj = new AsyncWaitSample();
            obj.Execute(args[0]);

            // 두 번째는 파일의 내용이 버퍼에 쌓여 있으므로 필연적으로 속도가 빨라진다
            // 따라서 비동기 버전은 마지막에 한 번 더 호출해서 속도를 공평하게 비교한다
            // 그러나 실행 환경에 따라서는 병렬 버전 쪽이 느려질 때도 있다.

            Console.WriteLine("병렬 버전을 실행합니다. Enter 키를 눌러 주십시오.");
            Console.ReadLine();
            obj.ExecuteAsync(args[0]);

            Console.WriteLine("비병렬 버전을 실행합니다. Enter 키를 눌러 주십시오.");
            Console.ReadLine();
            obj.Execute(args[0]);
        }
    }

    class AsyncWaitSample {
        public async void  ExecuteAsync(string dir) {
            // 동시 실행 수가 많아지면 오히려 느려지는 경우가 있다(실행 환경에 의존한다).
            // 다음과 같은 네 줄로 동시에 실행하는 스레드 수를 제한한다.
            int workMin;
            int ioMin;
            ThreadPool.GetMinThreads(out workMin, out ioMin);
            ThreadPool.SetMinThreads(8, ioMin);
            var start = DateTime.Now;
            var files = Directory.EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories);
            var tasks = new List<Task>();
            foreach (var file in files) {
                var task = Task.Run(() => {
                    if (Find(file))
                        Console.WriteLine(Path.GetFullPath(file));
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
            
            Console.WriteLine("병렬 버전 {0}", (DateTime.Now - start).TotalSeconds);
        }

        public void Execute(string dir) {
            var start = DateTime.Now;
            var files = Directory.EnumerateFiles(dir, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files) {
                if (Find(file))
                    Console.WriteLine(Path.GetFullPath(file));
            }
            Console.WriteLine("비병렬 버전 {0}", (DateTime.Now - start).TotalSeconds);
        }

        private bool Find(string file) {
            bool useAsync = false;
            bool useAwait = false;
            foreach (var line in File.ReadAllLines(file)) {
                if (Regex.IsMatch(line, @"\basync\b"))
                    useAsync = true;
                if (Regex.IsMatch(line, @"\bawait\b"))
                    useAwait = true;
                if (useAsync && useAwait)
                    return true;
            }
            return false;
        }
    }
}
