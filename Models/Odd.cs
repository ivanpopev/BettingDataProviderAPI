using System.Xml.Serialization;

namespace BettingDataProvider.Models
{
    public class Odd
    {
        [XmlAttribute("Id")]
        public int Id {  get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public float Value { get; set;  }
    }
}