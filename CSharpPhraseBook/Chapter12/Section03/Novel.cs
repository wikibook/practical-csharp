using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Section03 {
    // List 12-14
    [DataContract(Name = "novel")]
    [Serializable]
    public class Novel {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "published")]
        public int Published { get; set; }

        public override string ToString() {
            return string.Format("[Title={0}, Author={1}, Published={2}]",
                                  Title, Author, Published);
        }
    }

    [XmlRoot("novels")]
    public class NovelCollection {
        [XmlElement(Type = typeof(Novel), ElementName = "novel")]
        public Novel[] Novels { get; set; }
    }

}
