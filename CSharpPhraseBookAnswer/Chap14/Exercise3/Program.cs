using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    class Program {
        static void Main(string[] args) {
            var cs = ConfigurationManager.GetSection("myAppSettings") as MyAppSettings;

            var option = cs.TraceOption;
            Console.WriteLine("#TraceOption");
            Console.WriteLine(option.BufferSize);
            Console.WriteLine(option.Enabled);
            Console.WriteLine(option.FilePath);
            Console.WriteLine();

            var calendarOption = cs.CalendarOption;
            Console.WriteLine("#CalendarOption");
            Console.WriteLine(calendarOption.StringFormat);
            Console.WriteLine(calendarOption.Maximum);
            Console.WriteLine(calendarOption.Minimum);
            Console.WriteLine(calendarOption.MondayIsFirstDay);

            Console.ReadLine();
        }
    }
}
