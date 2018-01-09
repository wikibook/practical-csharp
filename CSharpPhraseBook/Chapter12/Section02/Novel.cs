using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Section02 {

    // List 12-8
    //public class Novel {
    //    public string Title { get; set; }

    //    public string Author { get; set; }

    //    [XmlIgnore]
    //    public int Published { get; set; }

    //    public override string ToString() {
    //        return string.Format("[Title={0}, Author={1}, Published={2}]",
    //                              Title, Author, Published);
    //    }
    //}


    // List 12-9
    [XmlRoot("novel")]
    public class Novel {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "published")]
        public int Published { get; set; }

        public override string ToString() {
            return string.Format("[Title={0}, Author={1}, Published={2}]",
                                  Title, Author, Published);
        }
    }

}
