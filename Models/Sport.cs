using System.Xml.Serialization;

namespace BettingDataProvider.Models
{
    public class Sport
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Event")]
        public List<Event> Event { get; set; }
    }
}