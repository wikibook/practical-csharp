using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpPhrase.TextFileProcessor;
using System.Text.RegularExpressions;

namespace CSharpPhrase.TextFileProcessor {
    class Program {
        static void Main(string[] args) {
            TextProcessor.Run<ToHankakuProcessor>(args[0]);
        }
    }

}