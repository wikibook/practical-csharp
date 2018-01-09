using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5 {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 2)
                return;
            UnzipTxt(args[0], args[1]);
        }

        private static void UnzipTxt(string archiveFile, string outputFolder) {
            using (var zip = ZipFile.OpenRead(archiveFile)) {
                var entries = zip.Entries.Where(x => Path.GetExtension(x.Name) == ".txt");
                if (entries.Any() && !Directory.Exists(outputFolder)) {
                    Directory.CreateDirectory(outputFolder);
                }
                foreach (var entry in entries) {
                    var destPath = Path.Combine(outputFolder, entry.FullName);
                    var destfolder = Path.GetDirectoryName(destPath);
                    if (!Directory.Exists(destfolder)) {
                        Directory.CreateDirectory(destfolder);
                    }
                    entry.ExtractToFile(destPath, overwrite: true);
                }
            }
        }
    }
}
