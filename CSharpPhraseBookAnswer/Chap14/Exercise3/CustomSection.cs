using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3 {
    public class TraceOption : ConfigurationElement {
        [ConfigurationProperty("enabled")]
        public bool Enabled {
            get { return (bool)this["enabled"]; }
        }

        [ConfigurationProperty("filePath")]
        public string FilePath {
            get { return (string)this["filePath"]; }
        }

        [ConfigurationProperty("bufferSize")]
        public int BufferSize {
            get { return (int)this["bufferSize"]; }
        }
    }

    public class CalendarOption : ConfigurationElement {
        [ConfigurationProperty("StringFormat")]
        public string StringFormat {
            get { return (string)this["StringFormat"]; }
        }
        [ConfigurationProperty("Minimum")]
        public DateTime Minimum {
            get { return (DateTime)this["Minimum"]; }
        }
        [ConfigurationProperty("Maximum")]
        public DateTime Maximum {
            get { return (DateTime)this["Maximum"]; }
        }

        [ConfigurationProperty("MondayIsFirstDay")]
        public bool MondayIsFirstDay {
            get { return (bool)this["MondayIsFirstDay"]; }
        }
    }

    public class MyAppSettings : ConfigurationSection {
        [ConfigurationProperty("traceOption")]
        public TraceOption TraceOption {
            get { return (TraceOption)this["traceOption"]; }
            set { this["traceOption"] = value; }
        }

        [ConfigurationProperty("CalendarOption")]
        public CalendarOption CalendarOption {
            get { return (CalendarOption)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }

}
