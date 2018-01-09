using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {

    // List 17-1
    abstract class GreetingBase {
        public virtual string GetMessage() {
            return "";
        }
    }

    // List 17-4
    //abstract class GreetingBase {
    //    public abstract string GetMessage();
    //}
}
