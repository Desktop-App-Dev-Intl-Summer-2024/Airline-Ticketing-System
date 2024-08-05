using AirLineTicketing.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirLineTicketing
{
    class ApiRequest
    {
        private static String server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static String local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);


        // install sqlclient
        SqlConnection sqlConnection;

        // create command adaptor
        SqlCommand sqlCommand;

        private void Establish_Connection()
        {
            if (String.IsNullOrEmpty(local_server_name)) {
                throw new Exception("Please set environment variable: " + server_env_var_name);
            }

            // Collect Connection String and Pass it to the connector
            string connectionString = "Data Source=" + local_server_name + ";Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Trust Server Certificate=True";

            // initialize the connection String
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public void postUserApi(User user) {
            try
            {
                Establish_Connection();

                // step 3: Generate the db query
                string query = "insert into Users values(@username, @password, @firstname, @lastname, @email, @dob, @userType)";

                // step 4: Initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                // step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@username", user.getUsername());
                sqlCommand.Parameters.AddWithValue("@password", user.getPassword());
                sqlCommand.Parameters.AddWithValue("@firstname", user.getFirstname());
                sqlCommand.Parameters.AddWithValue("@lastname", user.getLastname());
                sqlCommand.Parameters.AddWithValue("@email", user.getEmail());
                sqlCommand.Parameters.AddWithValue("@dob", user.getDob());
                sqlCommand.Parameters.AddWithValue("@userType", user.getUserType());

                // step 6: Execute the Query with values
                // ExecuteNonQuery returns 1 if no error happens
                int status = sqlCommand.ExecuteNonQuery();

                if (status == 1)
                {
                    MessageBox.Show("Data Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // step 7: Close the connection
            sqlConnection.Close();
        }

        public User? userSignInApi(string username, string password) {
            try {
                string query = "select * from Users where username=@username and password=@password";

                Establish_Connection();

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    int id = (int)reader["id"];
                    string firstname = (string)reader["firstname"];
                    string lastname = (string)reader["lastname"];
                    string email = (string)reader["email"];
                    string dob = Convert.ToString(reader["dob"]);
                    string userType = Convert.ToString(reader["userType"]);

                    User user = new User(username, "", firstname, lastname, email, dob);
                    user.setUserType(userType);

                    user.setId(id);

                    return user;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        //AGENT REGISTRATION 
        public void postAgentApi(Agent agent)
        {
            try
            {
                //Call EstablishConnection method (to create and open connection)
                Establish_Connection();

                //Step 3: generate the database query
                string query = "insert into Agents values (@username, @password, @firstname, @lastname, @email, @dob, @license)";

                //Step 4: initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                //Step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@username", agent.getUsername());
                sqlCommand.Parameters.AddWithValue("@password", agent.getPassword());
                sqlCommand.Parameters.AddWithValue("@firstname", agent.getFirstname());
                sqlCommand.Parameters.AddWithValue("@lastname", agent.getLastname());
                sqlCommand.Parameters.AddWithValue("@email", agent.getEmail());
                sqlCommand.Parameters.AddWithValue("@dob", agent.getDob());
                sqlCommand.Parameters.AddWithValue("@license", agent.getLicense());

                //Step 6: execute the query with values
                //ExecuteNonQuery returns 1 if no error occurs
                int status = sqlCommand.ExecuteNonQuery();
                if (status == 1)
                {
                    System.Windows.MessageBox.Show("Agent registered successfully!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Something went wrong - please try again!");
                }

                //Step 7: Close the connection
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //AGENT SIGN IN
        public int agentSignInApi(string username, string password, string agentLicense)
        {
            int status = 0;

            try
            {
                string query = "select * from Agents where username=@username and password=@password and agentLicense=@agentLicense";

                Establish_Connection();

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@agentLicense", agentLicense);

                object result = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return status;
        }
        //NEW FLIGHT RECORD
        public void postFlightApi(Flight flight)
        {
            try
            {
                //Call EstablishConnection method (to create and open connection)
                Establish_Connection();

                //Step 3: generate the database query
                string query = "insert into Flights values (@airline, @departureDate, @departureTime, @pilotCode, @crewCode," +
                    "                                       @origin, @destination, @availableClasses, @availableSeats, @totalSeats," +
                    "                                       @layover, @allowedPassengerTypes, @allowedBaggageTypes)";

                //Step 4: initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                //Step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@airline", flight.airline);
                sqlCommand.Parameters.AddWithValue("@departureDate", flight.departureDate);
                sqlCommand.Parameters.AddWithValue("@departureTime", flight.departureTime);
                sqlCommand.Parameters.AddWithValue("@pilotCode", flight.pilotCode);
                sqlCommand.Parameters.AddWithValue("@crewCode", flight.crewCode);
                sqlCommand.Parameters.AddWithValue("@origin", flight.origin);
                sqlCommand.Parameters.AddWithValue("@destination", flight.destination);
                sqlCommand.Parameters.AddWithValue("@availableClasses", flight.availableClasses);
                sqlCommand.Parameters.AddWithValue("@availableSeats", flight.availableSeats);
                sqlCommand.Parameters.AddWithValue("@totalSeats", flight.totalSeats);
                sqlCommand.Parameters.AddWithValue("@layover", flight.layover);
                sqlCommand.Parameters.AddWithValue("@allowedPassengerTypes", flight.allowedPassengerTypes);
                sqlCommand.Parameters.AddWithValue("@allowedBaggageTypes", flight.allowedBaggageTypes);

                //Step 6: execute the query with values
                //ExecuteNonQuery returns 1 if no error occurs
                int status = sqlCommand.ExecuteNonQuery();
                if (status == 1)
                {
                    System.Windows.MessageBox.Show("New flight record saved successfully!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Something went wrong - please try again!");
                }

                //Step 7: Close the connection
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //EDITING CURRENT FLIGHT RECORD
        public Flight? searchFlightApi(string flightNo)
        {
            try
            {
                string query = "select * from Flights where flightNo=@flightNo";

                Establish_Connection();

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@flightNo", flightNo);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    string airline = (string)reader["airline"];
                    string departureDate = Convert.ToString(reader["departureDate"]);
                    string departureTime = Convert.ToString(reader["departureTime"]);
                    string pilotCode = Convert.ToString(reader["pilotCode"]);
                    string crewCode = Convert.ToString(reader["crewCode"]);
                    string origin = (string)reader["origin"];
                    string destination = (string)reader["destination"];
                    string availableClasses = (string)reader["availableClasses"];
                    string availableSeats = Convert.ToString(reader["availableSeats"]);
                    string totalSeats = Convert.ToString(reader["totalSeats"]);
                    string layover = (string)reader["layover"];
                    string allowedPassengerTypes = (string)reader["allowedPassengerTypes"];
                    string allowedBaggageTypes = (string)reader["allowedBaggageTypes"];

                    Flight newFlight = new Flight();

                    newFlight.airline = airline;
                    newFlight.departureDate = departureDate;
                    newFlight.departureTime = departureTime;
                    newFlight.pilotCode = int.Parse(pilotCode);
                    newFlight.crewCode = int.Parse(crewCode);
                    newFlight.origin = origin;
                    newFlight.destination = destination;
                    newFlight.availableSeats = int.Parse(availableSeats);
                    newFlight.totalSeats = int.Parse(totalSeats);
                    newFlight.layover = layover;
                    newFlight.availableClasses = availableClasses;
                    newFlight.allowedPassengerTypes = allowedPassengerTypes;
                    newFlight.allowedBaggageTypes = allowedBaggageTypes;

                    return newFlight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}