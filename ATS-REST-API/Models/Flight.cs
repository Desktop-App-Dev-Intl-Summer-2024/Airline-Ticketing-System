namespace ATS_REST_API.Models
{
    public class Flight
    {
        public int flightNo { get; set; }
        public string airline { get; set; }
        public string departureDate {  get; set; }
        public string departureTime { get; set; }
        public int pilotCode { get; set; }
        public int crewCode { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string availableClasses { get; set; }
        public int availableSeats { get; set; }
        public int totalSeats { get; set; }
        public string layover { get; set; }
        public string allowedPassengerTypes { get; set; }
        public string allowedBaggageTypes { get; set; }
    }
}
