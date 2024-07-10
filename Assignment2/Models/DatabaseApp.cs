using Microsoft.Data.SqlClient;

namespace Assignment2.Models
{
    public class DatabaseApp
    {
        public Response AddProduct(SqlConnection sqlCon, Product product)
        {
            Response response = new Response();

            try
            {
                string query = "insert into A1Products values(@id, @name, @amount, @price)";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@id", product.id);
                cmd.Parameters.AddWithValue("@amount", product.amount);
                cmd.Parameters.AddWithValue("@price", product.price);

                sqlCon.Open();

                int status = cmd.ExecuteNonQuery();

                if (status == 1)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Product added successfully!";
                    response.product = product;
                    response.products = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Product couldn't be added, Check logs!";
                    response.product = null;
                    response.products = null;
                }

                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.statusMessage = ex.Message;
            }

            return response;
        }

        public Response UpdateProductById(SqlConnection con, int id, Product product)
        {
            Response response = new Response();

            try
            {
                con.Open();

                string query = "update A1Products set name=@name, amount=@amount, price=@price where id=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", product.name);
                cmd.Parameters.AddWithValue("@amount", product.amount);
                cmd.Parameters.AddWithValue("@price", product.price);
                cmd.Parameters.AddWithValue("@id", id);

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Product updated successfully!";
                    response.product = product;
                    response.products = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Product couldn't be updated";
                    response.product = null;
                    response.products = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.statusMessage = ex.Message;
            }

            con.Close();

            return response;
        }
    }
}
