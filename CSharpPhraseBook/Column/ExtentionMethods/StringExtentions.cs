using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.Extensions {

    public static class StringExtentions {    
        public static string Reverse(this string str) {   
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}
