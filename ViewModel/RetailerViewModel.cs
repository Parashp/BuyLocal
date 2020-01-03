using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RetailerViewModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string LatLang { get; set; }
        public string Contact { get; set; }
    }
}
