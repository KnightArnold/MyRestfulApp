
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.CurrenciesModel
{
    public class CurrencyConversion
    {
        public string currency_base { get; set; }
        public string currency_quote { get; set; }
        public Decimal ratio { get; set; }
        public Decimal rate { get; set; }
        public decimal inv_rate { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime valid_until { get; set; }
    }
}
