using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dividender.Models.Portfolio
{
    public class Watchlist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,8)")]
        public decimal RSI { get; set; }


        // Navigation Property
        public Ticker Ticker { get; set; }
        public int TickerId { get; set; }
    }
}
