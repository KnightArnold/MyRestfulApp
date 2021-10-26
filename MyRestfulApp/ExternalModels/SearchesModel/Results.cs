using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulApp.ExternalModels
{
    public class Results
    {        
        public string id { get; set; }
        public string site_id { get; set; }
        public string title { get; set; }       
        public decimal price { get; set; }
        public Seller seller { get; set; }
        public string permalink { get; set; }
    }
}
