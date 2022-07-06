using System.Xml.Serialization;

namespace BettingDataProvider.Models
{
    public enum MatchTypes
    {
        PreMatch,
        Live,
        OutRight
    }

    public class Match
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute("MatchType")]
        public MatchTypes MatchType { get; set; }

        [XmlElement("Bet")]
        public List<Bet> Bet { get; set; }         
    }
}
