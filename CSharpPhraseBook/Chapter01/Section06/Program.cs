using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            Employee employee = new Employee {
                Id = 100,
                Name = "홍길동",
                Birthday = new DateTime(1992, 4, 5),
                DivisionName = "제1영업부",
            }; 
            Console.WriteLine("{0}({1})은 {2}에 소속돼 있습니다.", 
                employee.Name, employee.GetAge(), employee.DivisionName);

        }
    }


    public class Person {

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age))
                age--;
            return age;
        }
    }

    public class Employee : Person {
        public int Id { get; set; }

        public string DivisionName { get; set; }
    }



}
