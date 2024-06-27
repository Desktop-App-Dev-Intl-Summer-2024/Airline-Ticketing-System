using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment1_FarmersMarketApp
{
    internal class ApiRequest
    {
        private static String server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static String local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);


        // install sqlclient
        SqlConnection sqlConnection;

        // create command adaptor
        SqlCommand sqlCommand;

        private void Establish_Connection()
        {
            if (String.IsNullOrEmpty(local_server_name))
            {
                throw new Exception("Please set environment variable: " + server_env_var_name);
            }

            // Collect Connection String and Pass it to the connector
            string connectionString = "Data Source=" + local_server_name + ";Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Trust Server Certificate=True";

            // initialize the connection String
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public DataTable getAllProducts() {
            DataTable dt = new DataTable();

            try
            {
                Establish_Connection();

                string query = "select * from A1Products";

                sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return dt;
        }

        public int postProductApi(Product product)
        {
            int status = 0;

            try
            {
                Establish_Connection();

                // step 3: Generate the db query
                string query = "insert into A1Products values(@id, @name, @amount, @price)";

                // step 4: Initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                // step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@name", product.getName());
                sqlCommand.Parameters.AddWithValue("@id", product.getId());
                sqlCommand.Parameters.AddWithValue("@amount", product.getAmount());
                sqlCommand.Parameters.AddWithValue("@price", product.getPrice());

                // step 6: Execute the Query with values
                // ExecuteNonQuery returns 1 if no error happens
                status = sqlCommand.ExecuteNonQuery();

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

            return status;
        }
    }
}
