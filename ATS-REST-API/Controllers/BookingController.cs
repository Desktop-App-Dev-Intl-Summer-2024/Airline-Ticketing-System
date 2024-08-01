using ATS_REST_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ATS_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private static string server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static string local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);

        private readonly IConfiguration _configuration;
        private SqlConnection con;
        private Database db;

        public BookingController(IConfiguration configuration)
        {
            this._configuration = configuration;
            db = new Database();

            if (string.IsNullOrEmpty(local_server_name))
            {
                Console.WriteLine("Please set environment variable: " + server_env_var_name);
            }

            string connectionString = "Data Source=" + local_server_name + ";Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Trust Server Certificate=True";

            con = new SqlConnection(connectionString);
        }

        [HttpPost]
        [Route("PostBookingTicket")]

        public Response PostBookingTicket(BookingDetail detail)
        {
            return db.PostBookingTicket(con, detail);
        }

        [HttpGet]
        [Route("GetBookingHistoryByUserId/{userId}")]

        public Response GetBookingHistoryByUserId(int userId)
        {
            return db.GetBookingHistoryByUserId(con, userId);
        }
    }
}
