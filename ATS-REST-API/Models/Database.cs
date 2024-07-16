using Microsoft.Data.SqlClient;

namespace ATS_REST_API.Models
{
    public class Database
    {
        public Response GetAllFlights(SqlConnection con)
        {
            Response response = new Response();
            List<Flight> flights = new List<Flight>();

            try
            {
                con.Open();

                string query = "SELECT * FROM Flights";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int flightNo = (int)reader["flightNo"];
                    string airline = (string)reader["airline"];
                    string departureDate = Convert.ToString(reader["departureDate"]);
                    string departureTime = Convert.ToString(reader["departureTime"]);
                    int pilotCode = (int)reader["pilotCode"];
                    int crewCode = (int)reader["crewCode"];
                    string origin = (string)reader["origin"];
                    string destination = (string)reader["destination"];
                    string availableClasses = (string)reader["availableClasses"];
                    int availableSeats = (int)reader["availableSeats"];
                    int totalSeats = (int)reader["totalSeats"];
                    string layover = (string)reader["layover"];
                    string allowedPassengerTypes = (string)reader["allowedPassengerTypes"];
                    string allowedBaggageTypes = (string)reader["allowedBaggageTypes"];

                    Flight flight = new Flight();

                    flight.flightNo = flightNo;
                    flight.airline = airline;
                    flight.departureDate = departureDate;
                    flight.departureTime = departureTime;
                    flight.pilotCode = pilotCode;
                    flight.crewCode = crewCode;
                    flight.origin = origin;
                    flight.destination = destination;
                    flight.availableClasses = availableClasses;
                    flight.availableSeats = availableSeats;
                    flight.totalSeats = totalSeats;
                    flight.layover = layover;
                    flight.allowedPassengerTypes = allowedPassengerTypes;
                    flight.allowedBaggageTypes = allowedBaggageTypes;

                    flights.Add(flight);
                }

                if (flights.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Flights retrieved successfully!";
                    response.flights = flights;
                    response.flight = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "No flights found!";
                    response.flights = flights;
                    response.flight = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                response.statusCode = 100;
                response.statusMessage = ex.Message;
            }

            con.Close();

            return response;
        }
    }
}
