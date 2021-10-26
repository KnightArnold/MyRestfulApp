using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class AvailableFilters
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public IEnumerable<ValuesAvailableFilters> values { get; set; }
    }
}
