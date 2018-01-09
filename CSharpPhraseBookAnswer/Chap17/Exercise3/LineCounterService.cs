using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.TextFileProcessor.Framework;

namespace CSharpPhrase.TextFileProcessor {
    class LineCounterService : ITextFileService {

        private int _count;

        public void Execute(string line) {
            _count++;
        }

        public void Initialize(string fname) {
            _count = 0;
        }

        public void Terminate() {
            Console.WriteLine("{0} 행", _count);
        }
    }
}
