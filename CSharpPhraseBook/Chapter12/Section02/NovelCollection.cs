using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Section02 {
    // List 12-10
    [XmlRoot("novels")]
    public class NovelCollection {
        [XmlElement(Type = typeof(Novel), ElementName = "novel")]
        public Novel[] Novels { get; set; }
    }


}
