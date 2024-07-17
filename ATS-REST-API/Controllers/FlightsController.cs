using ATS_REST_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ATS_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private static string server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static string local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);

        private readonly IConfiguration _configuration;
        private SqlConnection con;
        private Database db;

        public FlightsController(IConfiguration configuration)
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

        [HttpGet]
        [Route("GetAllFlights")]

        public Response GetAllFlights()
        {
            return db.GetAllFlights(con);
        }

        [HttpPost]
        [Route("GetFlightsByFilter")]

        public Response GetFlightsByFilter(FlightsFilter filter) {
            return db.GetFlightsByFilter(con, filter);
        }

        [HttpGet]
        [Route("GetOriginAndDestination")]

        public Response GetOriginAndDestination()
        {
            return db.GetOriginAndDestination(con);
        }
    }
}
