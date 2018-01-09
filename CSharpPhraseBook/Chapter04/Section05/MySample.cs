using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0405 {

    // List 4-35
    class MySample {
        public IReadOnlyList<int>  MyList { get; private set; }

        public MySample() {
            MyList = new List<int>() { 1, 2, 3, 4, 5 };
        }
    }
 
}
