using Divendender.Models.Indicators;
using Dividender.Models.Portfolio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dividender.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Dividend> Dividends { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<RSI> RSIs { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

