using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DormitoryApp
{
    // Атрибут XmlType вказує, як цей клас буде називатись в XML
    // при серіалізації (це нам знадобиться для HTML-генератора).
    [XmlType("Resident")]
    public class Resident
    {
        // XmlAttribute означає, що поле буде збережено як атрибут тегу <Resident>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Faculty")]
        public string Faculty { get; set; }

        [XmlAttribute("Department")]
        public string Department { get; set; }

        [XmlAttribute("Course")]
        public int Course { get; set; }

        [XmlAttribute("Room")]
        public string Room { get; set; }

        [XmlAttribute("ResidenceStart")]
        public DateTime ResidenceStart { get; set; }

        [XmlAttribute("ResidenceEnd")]
        public DateTime ResidenceEnd { get; set; }

        [XmlAttribute("ContractNumber")]
        public string? ContractNumber { get; set; }

        public Resident() { }
    }
}
