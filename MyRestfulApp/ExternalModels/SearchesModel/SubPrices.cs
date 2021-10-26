using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class SubPrices
    {
        public int id { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public int regular_amount { get; set; }
        public string currency_id { get; set; }
        public DateTime last_update { get; set; }
        public IEnumerable<Conditions> conditions { get; set; }
        public string exchange_rate_context { get; set; }
        public object metada { get; set; }
    }   
}
