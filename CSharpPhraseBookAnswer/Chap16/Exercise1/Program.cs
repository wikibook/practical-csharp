using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 콘솔 응용 프로그램의 형태로 작성했습니다

namespace Exercise1 {
    class Program {
        static  void Main(string[] args) {
            RunAsync();
            // 비동기로 동작하므로 여기서 사용자의 키 입력을 기다리게 해서 프로그램이 끝나지 않게 한다
            // Main 메서드에는 async를 사용하지 않는다
            Console.ReadLine();
        }

        private static async void RunAsync() {
            var text = await TextReaderSample.ReadTextAsync("oop.md");
            Console.WriteLine(text);
        }
    }

    static class TextReaderSample {
        public static async Task<string> ReadTextAsync(string filePath) {
            var sb = new StringBuilder();
            var sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                var line = await sr.ReadLineAsync();
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
    }
}
