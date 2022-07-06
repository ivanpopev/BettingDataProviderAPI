using BettingDataProvider.Models;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using BettingDataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Polly;
using Newtonsoft.Json;

namespace BettingDataProvider.Services
{
    [XmlRoot("XmlSports")]
    public class Data
    {
        [XmlElement("Sport")]
        public List<Sport> Sport { get; set; }
        [XmlAttribute("CreateDate")]
        public string CreateDate { get; set; }
    }

    public class JsonRootElement
    {
        public Data XmlSports { get; set; }
    }
    public class SportsEventsDataRetriever
    {
        private  HttpClient httpClient;
        private static readonly string SPORTS_DATA_URL = "https://sports.ultraplay.net/sportsxml?clientKey=9C5E796D-4D54-42FD-A535-D7E77906541A&sportId=2357&days=7";
        private readonly ApplicationDbContext _context;

        public SportsEventsDataRetriever(ApplicationDbContext context)
        {
            _context = context;
            httpClient = new HttpClient();  
        }

        public void PollSportsData()
        {
            var policy = Policy.HandleResult<Task>(_ => true)
                .WaitAndRetryForever(_ => TimeSpan.FromSeconds(60))
                .Execute(()=>FetchData());
        }

        private async Task FetchData()
        {
            try
            {
                var result = await httpClient.GetAsync(SPORTS_DATA_URL);
                var stream = await result.Content.ReadAsStringAsync();

                var itemXml = XElement.Parse(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(Data));
                var data = (Data)serializer.Deserialize(itemXml.CreateReader());

                if (data != null)
                {
                    data.Sport.ForEach(s => _context.Add(s));
                    await _context.SaveChangesAsync();
                    Console.Write("FETCHEEED");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                throw;
            }
            
        }      
    }
}