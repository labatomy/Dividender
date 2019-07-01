using Dividender.Models.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dividender.Models.Portfolio
{
    public class Trade
    {
        public int Id { get; set; }

        public int Shares { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Purchased On")]
        public DateTime PurchaseDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Sold On")]
        public DateTime SellDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Sell Price")]
        public decimal SellPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayName("Target Price")]
        public decimal Target { get; set; }

        public string Reason { get; set; }


        // Navigation Property
        public Transaction Transaction { get; set; }

        public Ticker Ticker { get; set; }
        public int TickerId { get; set; }

    }
}
