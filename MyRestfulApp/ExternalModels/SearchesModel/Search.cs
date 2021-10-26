using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class Search
    {
        public string site_id { get; set; }
        public string country_default_time_zone { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public IEnumerable<Results> results { get; set; }
        public Sort sort { get; set; }
        public IEnumerable<AvailableSorts> available_sorts { get; set; }
        public IEnumerable<Filters> filters { get; set; }
        public IEnumerable<AvailableFilters> available_filters { get; set; }
    }
}
