using BettingDataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingDataProvider.Context
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
        {
        }
        public DbSet<Match> Matches { get; set; }
 
        public DbSet<Event> Events { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }

        public DbSet<Sport> Sports { get; set; }       
    }
}
