namespace Section02 {
    internal class Employee {
        public string Name { get; set; }
        public int Code { get; set; }

        public Employee(int id, string name) {
            Code = id;
            Name = name;

        }


    }
}