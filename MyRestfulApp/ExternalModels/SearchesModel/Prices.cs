using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class Prices
    {
        public int id { get; set; }
        public IEnumerable<SubPrices> prices { get; set; }
    }
}
