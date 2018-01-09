using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPhrase.CustomSection {

	// List 14-12
    public class MyAppSettings : ConfigurationSection {
        [ConfigurationProperty("traceOption")]
        public TraceOption TraceOption {
            get { return (TraceOption)this["traceOption"]; }
            set { this["traceOption"] = value; }
        }
    }

	// List 14-11
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
}
