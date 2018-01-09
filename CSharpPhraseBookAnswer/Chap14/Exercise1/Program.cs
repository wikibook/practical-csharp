using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// 이 프로그램을 실행하면 commands.txt에 기록된 notepad.exe가 시작됩니다.
// 이 때 sample.txt가 존재하지 않으면 notepad.exe가
// 'sample.txt를 찾을 수 없습니다. 새로 작성하겠습니까?'라고 질문하는데
// 여기에 '예'를 선택하기 바랍니다.
// notepad.exe에서 텍스트를 편집하고 저장하면 sample.txt의 각각의 행이 정렬되고
// 그 후에 다시 notepad.exe가 시작되어 sample.txt를 읽어들입니다

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("commands.txt");

            ExecuteCommands(lines);
        }

        static ProcessStartInfo CreateStartupInfo(string line) {
            var items = line.Split('|');
            var startInfo = new ProcessStartInfo {
                FileName = items[0],
                Arguments = items.Length >= 2 ? items[1] : null
            };
            return startInfo;
        }
         
        static void ExecuteCommands(string[] lines) {
            foreach (var line in lines) {
                var info = CreateStartupInfo(line);
                if (string.IsNullOrWhiteSpace(info.FileName))
                    continue;
                using (var process = Process.Start(info)) {
                    process.WaitForExit();
                }
            }
        }
    }
}
