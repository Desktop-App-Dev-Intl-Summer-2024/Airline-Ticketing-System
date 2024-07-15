using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static String server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static String local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);

        private readonly IConfiguration _configuration;
        private SqlConnection con;
        private DatabaseApp app;

        public ProductController(IConfiguration configuration)
        {
            this._configuration = configuration;
            app = new DatabaseApp();

            if (String.IsNullOrEmpty(local_server_name))
            {
                Console.WriteLine("Please set environment variable: " + server_env_var_name);
            }

            string connectionString = "Data Source=" + local_server_name + ";Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Trust Server Certificate=True";

            con = new SqlConnection(connectionString);
        }

        [HttpPost]
        [Route("AddProduct")]

        public Response AddProduct(Product product)
        {
            return app.AddProduct(con, product);
        }

        [HttpPut]
        [Route("UpdateProductById/{id}")]

        public Response UpdateProductById(int id, Product product)
        {
            return app.UpdateProductById(con, id, product);
        }

        [HttpGet]
        [Route("GetAllProducts")]

        public Response GetAllProducts() {
            return app.GetAllProducts(con);
        }

        [HttpGet]
        [Route("GetProduct")]

        public Response GetProduct(int id, string name)
        {
            return app.GetProduct(con, id, name);
        }
    }
}
