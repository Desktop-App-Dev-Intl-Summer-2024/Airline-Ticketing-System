using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineTicketing.Models
{
    public class FlightsQuery
    {
        public string trip {  get; set; }
        public List<string> passenger { get; set; }
        public string seatClass { get; set; }
        public List<string> baggage { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
    }
}
