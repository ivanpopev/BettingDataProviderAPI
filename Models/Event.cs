using System.Xml.Serialization;

namespace BettingDataProvider.Models
{
    public class Event
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlElement("Match")]
        public List<Match> Match { get; set; }
    }
}