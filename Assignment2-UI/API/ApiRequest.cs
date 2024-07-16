using Assignment1_FarmersMarketApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment1_FarmersMarketApp.API
{
    internal class ApiRequest
    {
        private static string server_env_var_name = "DEV_AIRLINE_TICKETING_APP_SERVER";
        private static string local_server_name = Environment.GetEnvironmentVariable(server_env_var_name);


        // install sqlclient
        SqlConnection sqlConnection;

        // create command adaptor
        SqlCommand sqlCommand;

        //CONNECTION
        private void Establish_Connection()
        {
            if (string.IsNullOrEmpty(local_server_name))
            {
                throw new Exception("Please set environment variable: " + server_env_var_name);
            }

            // Collect Connection String and Pass it to the connector
            string connectionString = "Data Source=" + local_server_name + ";Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Trust Server Certificate=True";

            // initialize the connection String
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        //GET ALL PRODUCTS
        public DataTable getAllProducts()
        {
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

        //GET INDIVIDUAL PRODUCT
        public Product getProductApi(int id, string name)
        {
            Product product = null;

            try
            {
                Establish_Connection();

                string query;

                if (id > 0)
                {
                    query = "select * from A1Products where id=@id";
                }
                else if (name != string.Empty)
                {
                    query = "select * from A1Products where name like @name";
                }
                else
                {
                    throw new Exception("Both Id and Name can't empty");
                }


                sqlCommand = new SqlCommand(query, sqlConnection);


                if (id > 0)
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@name", "%" + name + "%");
                }

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    int productId = (int)reader["id"];
                    string productName = (string)reader["name"];
                    double amount = Convert.ToDouble(reader["amount"]);
                    double price = Convert.ToDouble(reader["price"]);

                    product = new Product(productName, productId, amount, price);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return product;
        }

        //POST NEW PRODUCT: INSERT INTO DB
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
                    MessageBox.Show("Product Added Successfully");
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

        //PUT PRODUCT: UPDATE DB
        public int putProductApi(Product product)
        {
            int status = 0;

            try
            {
                Establish_Connection();

                // step 3: Generate the db query
                string query = "update A1Products set name=@name, amount=@amount, price=@price where id=@id";

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
                    MessageBox.Show("Product Updated Successfully");
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

        //DELETE PRODUCT
        public int deleteProductApi(int id)
        {
            int status = 0;

            try
            {
                Establish_Connection();

                string query = "delete from A1Products where id=@id";

                sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", id);

                int i = sqlCommand.ExecuteNonQuery();

                if (i == 1)
                {
                    MessageBox.Show("Product Deleted Successfully");
                    status = 1;
                }
                else
                {
                    MessageBox.Show("Product Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sqlConnection.Close();

            return status;
        }

        //RETRIEVE AVAILABLE PRODUCTS FROM DB 
        public ArrayList getAvailableProductsAPI()
        {
            ArrayList availableProduct = new ArrayList();

            try
            {
                Establish_Connection();

                string query = "SELECT * FROM A1Products";
                sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int productId = (int)reader["id"];
                    string productName = (string)reader["name"];
                    double amount = Convert.ToDouble(reader["amount"]);
                    double price = Convert.ToDouble(reader["price"]);

                    Product product = new Product(productName, productId, amount, price);
                    availableProduct.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sqlConnection.Close();
            return availableProduct;
        }

        //UPDATING DB AFTER CONFIRMATION OF PURCHASE
        public int UpdateDatabaseWithPurchaseAPI(ArrayList selectedProducts)
        {
            int status = 0;

            try
            {
                Establish_Connection();

                string query = "update A1Products set amount= (case ";

                for (int i = 0; i < selectedProducts.Count; i++)
                {
                    SelectedProduct product = selectedProducts[i] as SelectedProduct;

                    query += "when id=" + product.getId() + " then " + product.getRemaingAmount() + " ";
                }

                query += "else amount end);";

                sqlCommand = new SqlCommand(query, sqlConnection);
                status = sqlCommand.ExecuteNonQuery();

                if (status > 0)
                {
                    MessageBox.Show("Purchase confirmed! See email for billing.");
                }
                else
                {
                    MessageBox.Show("Purchase couldn't be complete please retry!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sqlConnection.Close();

            return status;
        }
    }
}
