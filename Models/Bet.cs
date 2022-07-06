using System.Xml.Serialization;

namespace BettingDataProvider.Models
{
    public class Bet
    {        
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlElement("Odd")]
        public List<Odd> Odd { get; set; }
    }
}
