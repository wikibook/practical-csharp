using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0406 {
    public class Person {
        public string GivenName { get; private set; }

        public string FamilyName { get; private set; }

        public string Name {
            get { return FamilyName + " " + GivenName; }
        }
        public string Name2 => FamilyName + " " + GivenName;

        // コンストラクタ
        public Person(string familyName, string givenName) {
            FamilyName = familyName;
            GivenName = givenName;
        }
    }
}
