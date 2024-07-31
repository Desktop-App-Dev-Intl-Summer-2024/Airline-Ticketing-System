using Microsoft.AspNetCore.Http.Extensions;
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
                    string departureDate = Convert.ToDateTime(reader["departureDate"]).ToString("yyyy-MM-dd");
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

        public Response GetFlightsByFilter(SqlConnection con, FlightsFilter filter) {
            Response response = new Response();
            List<Flight> flights = new List<Flight>();

            try
            {
                con.Open();

                string query = "SELECT * FROM Flights WHERE 1=1 ";

                if (filter.passenger != null && filter.passenger.Any())
                {
                    for (int i = 0; i < filter.passenger.Count; i++)
                    {
                        query += $" AND allowedPassengerTypes LIKE '%{filter.passenger[i]}%'";
                    }
                }

                if (!string.IsNullOrEmpty(filter.seatClass))
                {
                    query += $" AND availableClasses LIKE '%{filter.seatClass}%'";
                }

                if (filter.baggage != null && filter.baggage.Any())
                {
                    for (int i = 0; i < filter.baggage.Count; i++)
                    {
                        query += $" AND allowedBaggageTypes LIKE '%{filter.baggage[i]}%'";
                    }
                }

                if (!string.IsNullOrEmpty(filter.origin))
                {
                    query += $" AND origin = '{filter.origin}'";
                }

                if (!string.IsNullOrEmpty(filter.destination))
                {
                    query += $" AND destination = '{filter.destination}'";
                }

                if (!string.IsNullOrEmpty(filter.date))
                {
                    query += $" AND CONVERT(date, departureDate) = '{filter.date}'";
                }

                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int flightNo = (int)reader["flightNo"];
                    string airline = (string)reader["airline"];
                    string departureDate = Convert.ToDateTime(reader["departureDate"]).ToString("yyyy-MM-dd");
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

        public Response GetOriginAndDestination(SqlConnection con)
        {
            Response response = new Response();
            Places places = new Places();

            try
            {
                con.Open();

                string queryOrigin = "SELECT DISTINCT origin FROM Flights";
                SqlCommand sqlCommand = new SqlCommand(queryOrigin, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string origin = (string)reader["origin"];

                    places.origins.Add(origin);
                }

                reader.Close();

                string queryDestination = "SELECT DISTINCT destination FROM Flights";
                sqlCommand = new SqlCommand(queryDestination, con);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string destination = (string)reader["destination"];

                    places.destinations.Add(destination);
                }

                

                if (places.origins.Count + places.destinations.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Places retrieved successfully!";
                    response.places = places;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "No Places found!";
                    response.places = null;
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

        public Response PostBookingTicket(SqlConnection con, BookingDetail detail) {
            Response response = new Response();

            try
            {
                con.Open();
                // check if seats are available in the flight
                string queryFlight = $"select * from Flights where flightNo={detail.flightNo}";

                SqlCommand cmd = new SqlCommand(queryFlight, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    int availableSeats = (int)reader["availableSeats"];
                    int totalSeats = (int)reader["totalSeats"];

                    reader.Close();

                    if (availableSeats > 0)
                    {
                        detail.seatNo = totalSeats - availableSeats + 1;

                        // Insert into booking table
                        string insertBookingQuery = $"INSERT INTO Bookings " +
                            $"(bookingUserId, firstName, lastName, classType," +
                            $" nationality, passportNumber, address, cardNumber," +
                            $" expiryDate, cardCvv, bookingDateTime, ticketCost," +
                            $" flightNo, seatNo)" +
                            $" VALUES ({detail.bookingUserId},'{detail.firstName}', '{detail.lastName}'," +
                            $" '{detail.classType}', '{detail.nationality}', '{detail.passportNumber}'," +
                            $" '{detail.address}', '{detail.cardNumber}', '{detail.expiryDate}', '{detail.cardCvv}'," +
                            $" '{detail.bookingDateTime}', {detail.ticketCost}, {detail.flightNo}, {detail.seatNo})";


                        cmd = new SqlCommand(insertBookingQuery, con);
                        cmd.ExecuteNonQuery();

                        string getBookingIDQuery = $"select top 1 bookingId from Bookings where bookingUserId={detail.bookingUserId} order by bookingId desc";
                        cmd = new SqlCommand(getBookingIDQuery, con);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            detail.bookingId = (int)reader["bookingId"];
                        }

                        reader.Close();

                        // Update Flights table with new Available Seats
                        string updateFlightsQuery = $"update Flights set availableSeats={availableSeats - 1} where flightNo={detail.flightNo}";
                        cmd = new SqlCommand(updateFlightsQuery, con);
                        cmd.ExecuteNonQuery();

                        response.bookingDetail = detail;
                        response.statusCode = 200;
                    }
                    else {
                        response.statusCode = 100;
                        response.statusMessage = "No Seats Available, Désolée!";
                    }
                }

            } catch(Exception ex)
            {
                response.statusCode = 100;
                response.statusMessage = ex.Message;
            }

            con.Close();

            return response;
        }
    }
}
