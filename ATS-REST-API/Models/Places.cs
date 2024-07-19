namespace ATS_REST_API.Models
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
