using System.IO;
using System.Net;
using System.Net.Http;

namespace Assignment1_FarmersMarketApp.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Product product { get; set; }
        public List<Product> products { get; set; }
    }
}
