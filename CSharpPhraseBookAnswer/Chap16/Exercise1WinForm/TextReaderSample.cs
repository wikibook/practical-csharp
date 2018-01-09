using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1WinForm {
    static class TextReaderSample {

        // 읽어들인 행을 IProgress 인터페이스를 사용해서 한 행씩 호출한 곳에 알린다
        // ReadTextAsync를 호출했을 때와 표시하는 방식이 다르다는 점에 주목하기 바랍니다
        public static async Task ReadLinesAsync(string filePath, IProgress<string> progress) {
            var sr = new StreamReader(filePath);
            while (!sr.EndOfStream) {
                var line = await sr.ReadLineAsync();
                progress.Report(line);
            }
        }

        // 읽어들인 행을 StringBuilder를 사용해서 모아두고 마지막에 텍스트 전체를 반환한다
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
