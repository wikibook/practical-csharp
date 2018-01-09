using System;

namespace Ch0405 {
    internal class Product {
        //public string Name { get; set; }

        private string _name;

        //public string Name {
        //    get { return _name; }
        //    set { _name = value; }

        //}

        public string Name {
            get {
                if (_name == null)
                    _name = GetNameFromFile();
                return _name;
            }
            set { _name = value; }
        }

        private string GetNameFromFile() {
            return "田中";
        }
    }
}