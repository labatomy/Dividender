using Dividender.Models.Portfolio;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Divendender.Models.Indicators
{
    public class RSI
    {

        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Column(TypeName = "decimal(18,8)")]
        public decimal Value { get; set; }


        // Navigation Property
        public Ticker Ticker { get; set; }
        public int TickerId { get; set; }
    }
}
