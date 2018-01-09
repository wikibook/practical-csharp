using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1)
                return;

            // 이것은 확인용 코드이다
            Console.WriteLine($"source: {Path.GetFullPath(args[0])}");
            Console.WriteLine($"dest:   {Path.GetFullPath(args[1])}\n");
            // 여기까지

            var sourceDir = args[0];
            var destDir = args[1];
            CopyFiles(sourceDir, destDir);
        }

        private static void CopyFiles(string sourceDir, string destDir) {
            var files = Directory.EnumerateFiles(sourceDir, "*.*");
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);
            foreach (var file in files) {
                var dest = GetBakFilePath(destDir, file);
                Console.WriteLine(dest);
                File.Copy(file, dest, overwrite:true);
            }
        }

        private static string GetBakFilePath(string destDir, string file) {
            var name = Path.GetFileNameWithoutExtension(file) + "_bak";
            var ext = Path.GetExtension(file);
            // 확장자가 없는 파일인 경우 ext는 ""이므로 무조건 ext를 추가해도 괜찮다
            return Path.Combine(destDir, name + ext);
        }
    }
}
