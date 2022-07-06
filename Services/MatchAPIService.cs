using BettingDataProvider.Context;
using BettingDataProvider.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BettingDataProvider.Services
{
    public class MatchResult
    {
        public string? MatchName { get; set; }

        public DateTime? StartDate { get; set; }

        public List<Bet>? Markets { get; set; }
    }
    public class MatchAPIService
    {
        private readonly ApplicationDbContext _context;

        public MatchAPIService(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public async Task<MatchResult> GetMatch(int id)
        {
            var match =  await _context.Matches.FirstOrDefaultAsync(m => m.Id.Equals(id));

            var result = new MatchResult
            {
                MatchName = match?.Name,
                StartDate = match?.StartDate,
                Markets = match?.Bet.Where(x => x.IsLive == true).ToList()
            };

            return result ;
        }

        public async Task<IEnumerable<MatchResult>> GetUpcomingMatches()
        {
            var matches = await _context.Matches
                .Where(x => x.StartDate > DateTime.Now.AddHours(-24) && x.StartDate <= DateTime.Now)
                .ToListAsync();

            return matches.Select(m => new MatchResult
            {
                MatchName = m.Name,
                StartDate = m.StartDate,
                Markets = m.Bet.Where(x => 
                x.Name.Equals("Match Winner") || 
                x.Name.Equals("Map Advantage") || 
                x.Name.Equals("Total Maps Played"))
                .ToList()
            });
        }
    }
}