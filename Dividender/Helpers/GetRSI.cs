using CsvHelper;
using CsvHelper.Configuration;
using Divendender.Models.Indicators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dividender.Helpers
{
    public class Indicator
    {
        private string url = "https://www.alphavantage.co/query?function=RSI&symbol=V&interval=60min&time_period=60&series_type=close&apikey=OD3IMFWZFKS4HG8O&datatype=csv";

        public async Task<string> GetSymbolAsync(string symbol)
        {
            using (var client = new HttpClient())
            {
                using (var stream = await client.GetStreamAsync(url).ConfigureAwait(continueOnCapturedContext: false))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.RegisterClassMap<RSIMap>();
                    var records = csv.GetRecords<RsiIndicator>();
                    var row = records.ToList().Skip(1).First();

                    return row.RSI.ToString();
                }
            }
        }

        public class RsiIndicator
        {
            public DateTime time { get; set; }
            public string RSI { get; set; }

        }

        public sealed class RSIMap : ClassMap<RsiIndicator>
        {
            public RSIMap()
            {
                Map(m => m.time);
                Map(m => m.RSI);
            }
        }


    }
}
