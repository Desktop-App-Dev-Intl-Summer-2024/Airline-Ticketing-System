using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineTicketing.Models
{
    public class Places
    {
        public Places() {
            origins = new List<string>();
            destinations = new List<string>();
        }

        public List<string> origins { get; set; }
        public List<string> destinations { get; set; }
    }
}
