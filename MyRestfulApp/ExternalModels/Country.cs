using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels
{
    public class Country
    {
        public string id { get; set; }

        public string name { get; set; }

        public string locale { get; set; }

        public string currency_id { get; set; }

        public string decimal_separator { get; set; }

        public string thousands_separator { get; set; }

        public string time_zone { get; set; }

        public Dictionary<string,Location> geo_information { get; set; }

        public IEnumerable<States> states { get; set; }

    }
}
