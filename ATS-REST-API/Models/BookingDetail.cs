using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_REST_API.Models
{
    public class BookingDetail
    {
        public int bookingId {  get; set; }
        public int bookingUserId { get; set; }
        public string firstName { get; set; }
        public string lastName {  get; set; }
        public string classType { get; set; }
        public string nationality { get; set; }
        public string passportNumber { get; set; }
        public string address { get; set; }
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string cardCvv { get; set; }
        public string bookingDateTime { get; set; }
        public double ticketCost { get; set; }
        public int flightNo { get; set; }
        public int seatNo { get; set; }
        public Flight? flight { get; set; }
    }
}
