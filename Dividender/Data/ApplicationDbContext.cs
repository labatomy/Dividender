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
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticker>().HasData(
                new Ticker { Id = 1, Name = "", Symbol = "VYM" },
                new Ticker { Id = 2, Name = "", Symbol = "BTI" },
                new Ticker { Id = 3, Name = "", Symbol = "ALB" },
                new Ticker { Id = 4, Name = "", Symbol = "LAZ" },
                new Ticker { Id = 5, Name = "", Symbol = "MMLP" },
                new Ticker { Id = 6, Name = "", Symbol = "HAL" },
                new Ticker { Id = 7, Name = "", Symbol = "DOW" },
                new Ticker { Id = 8, Name = "", Symbol = "CC" },
                new Ticker { Id = 9, Name = "", Symbol = "OXY" },
                new Ticker { Id = 10, Name = "", Symbol = "AUY" },
                new Ticker { Id = 11, Name = "", Symbol = "PFF" },
                new Ticker { Id = 12, Name = "", Symbol = "FDP" },
                new Ticker { Id = 13, Name = "", Symbol = "PAAS" },
                new Ticker { Id = 14, Name = "", Symbol = "HTGC" },
                new Ticker { Id = 15, Name = "", Symbol = "ANDE" },
                new Ticker { Id = 16, Name = "", Symbol = "BK" },
                new Ticker { Id = 17, Name = "", Symbol = "TAP" },
                new Ticker { Id = 18, Name = "", Symbol = "BMY" },
                new Ticker { Id = 19, Name = "", Symbol = "VST" },
                new Ticker { Id = 20, Name = "", Symbol = "AGNC" },
                new Ticker { Id = 21, Name = "", Symbol = "IVZ" },
                new Ticker { Id = 22, Name = "", Symbol = "BHGE" },
                new Ticker { Id = 23, Name = "", Symbol = "AAL" },
                new Ticker { Id = 24, Name = "", Symbol = "PRU" },
                new Ticker { Id = 25, Name = "", Symbol = "SLB" },
                new Ticker { Id = 26, Name = "", Symbol = "MPC" },
                new Ticker { Id = 27, Name = "", Symbol = "BECN" },
                new Ticker { Id = 28, Name = "", Symbol = "THO" },
                new Ticker { Id = 29, Name = "", Symbol = "BTU" },
                new Ticker { Id = 30, Name = "", Symbol = "WY" }
            );

            builder.Entity<Watchlist>().HasData(
                new Watchlist { Id = 1, Name = "Panda", Description = "Pandas List", TickerId = 1 }
            );




        }
    }
}

