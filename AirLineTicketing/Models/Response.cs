namespace AirLineTicketing.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Flight flight { get; set; }
        public List<Flight> flights { get; set; }
        public Places places { get; set; }
        public BookingDetail bookingDetail { get; set; }
        public List<BookingDetail> bookingDetails { get; set; }
    }
}
