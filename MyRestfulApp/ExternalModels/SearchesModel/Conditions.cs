using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels.SearchesModel
{
    public class Conditions
    {
        public string[] context_restrictions { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public bool eligible { get; set; }
    }
}
