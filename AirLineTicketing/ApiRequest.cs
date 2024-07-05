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
                string query = "insert into Users values(@username, @password, @firstname, @lastname, @email, @dob)";

                // step 4: Initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                // step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@username", user.getUsername());
                sqlCommand.Parameters.AddWithValue("@password", user.getPassword());
                sqlCommand.Parameters.AddWithValue("@firstname", user.getFirstname());
                sqlCommand.Parameters.AddWithValue("@lastname", user.getLastname());
                sqlCommand.Parameters.AddWithValue("@email", user.getEmail());
                sqlCommand.Parameters.AddWithValue("@dob", user.getDob());

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

        public int userSignInApi(string username, string password) { 
            int status = 0;

            try {
                string query = "select * from Users where username=@username and password=@password";

                Establish_Connection();

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);

                object result = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    status = 1;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return status;
        }

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

        public int agentSignInApi(string username, string password, string license)
        {
            int status = 0;

            try
            {
                string query = "select * from Agents where username=@username and password=@password and @license=license";

                Establish_Connection();

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@license", license);

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
    }
}
