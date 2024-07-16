namespace ATS_REST_API.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Flight flight { get; set; }
        public List<Flight> flights { get; set; }
    }
}
