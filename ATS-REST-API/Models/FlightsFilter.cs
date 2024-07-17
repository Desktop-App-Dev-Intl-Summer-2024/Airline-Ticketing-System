namespace ATS_REST_API.Models
{
    public class FlightsFilter
    {
        public string trip { get; set; }
        public List<string> passenger { get; set; }
        public string seatClass { get; set; }
        public List<string> baggage { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
    }
}
