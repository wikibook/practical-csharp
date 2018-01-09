using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    class Program {
        static void Main(string[] args) {
            // 1.3.2
            Student student = new Student {
                Name = "홍길동",
                Birthday = new DateTime(2006, 11, 6),
                ClassNumber = 2,
                Grade = 5,
            };

            // 1.3.3
            Console.WriteLine("{0} - {1}학년 {2}반 생년월일:{3:yyyy/M/d}",
                student.Name, student.Grade, student.ClassNumber, student.Birthday);

            // 1.3.4
            Person person = student;
            if (person is Student)
                Console.WriteLine("person is Student");

            object obj = student;
            if (obj is Student)
                Console.WriteLine("obj is Student");
        }
    }

}
