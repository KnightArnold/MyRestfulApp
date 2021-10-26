using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class ValuesFilters
    {
        public string id { get; set; }
        public string name { get; set; }
        public IEnumerable<PathFromRoot> path_from_root { get; set; }
    }
}
