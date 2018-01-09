using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0406 {
    class PasswordPolicy {
        public int MinimumLength { get; set; } = 6;

        public bool RequireUppercase { get; set; } = GetRequireUppercase();

        private static bool GetRequireUppercase() {
            return true;
        }

        public PasswordPolicy() {
            MinimumLength = 6;
        }

        private string _name = null;  //〈- 初期値はnullが保証されているので本来は不要 〉

        public string Name {
            get {
                if (_name == null)
                    _name = GetNameFromFile();
                return _name;
            }
            set { _name = value; }
        }

        private string GetNameFromFile() {
            throw new NotImplementedException();
        }
    }
}
