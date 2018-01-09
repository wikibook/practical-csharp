using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Section02 {

    // List 12-12
    [XmlRoot("novelist")]

    public class Novelist {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlArray("masterpieces")]
        [XmlArrayItem("title", typeof(string))]
        public string[] Masterpieces { get; set; }
    }
}
