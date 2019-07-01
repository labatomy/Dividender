using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dividender.Models.Portfolio
{
    public class Dividend
    {
        public int Id { get; set; }

        [DisplayName("Shares Held")]
        public int Shares { get; set; }


        [DisplayName("Return Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Navigation Property
        public Ticker Ticker { get; set; }
        public int TickerId { get; set; }

    }
}