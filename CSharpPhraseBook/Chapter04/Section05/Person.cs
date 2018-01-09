
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0405 {

    // List 4-33
    public class Person {
        public string GivenName { get; private set; }

        public string FamilyName { get; private set; }

        public string Name {
            get { return FamilyName + " " + GivenName; }
        }

        // List 3-34
        public string Name2 => FamilyName + " " + GivenName;

        // 생성자
        public Person(string familyName, string givenName) {
            FamilyName = familyName;
            GivenName = givenName;
        }
    }
}
