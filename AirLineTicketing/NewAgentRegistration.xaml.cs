using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace AirLineTicketing
{
    /// <summary>
    /// Interaction logic for NewAgentRegistration.xaml
    /// </summary>
    public partial class NewAgentRegistration : Window
    {
        public NewAgentRegistration()
        {
            InitializeComponent();
        }


        private void EstablishConnection()
        {
            //Collect connection string and pass it to the connector
            //Right click on data connection name, properties, copy and paste connection string
            // string connectionString = "Data Source=desktop-aiq6j2v;Initial Catalog=AirlineTicketingAppProjet;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string connectionString = "Data Source=LAPTOP_DE_MARIE\\MSSQLSERVER01;Initial Catalog=AirlineTicketingAppProject;Integrated Security=True;Encrypt=True;;Trust Server Certificate=True";
            //initialize the connection string
            sqlConnection = new SqlConnection(connectionString);
            //open the connection
            sqlConnection.Open();
        }

        //Step 2: create the connector: create them as global so accesible

        //install SQL client
        SqlConnection sqlConnection;

        //create command adapter
        SqlCommand sqlCommand;

        private void agentUsernameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentUsernameTxt.Text = "";
        }

        private void agentPasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentPasswordTxt.Text = "";
        }

        private void agentFirstNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentFirstNameTxt.Text = "";
        }

        private void agentLastNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentLastNameTxt.Text = "";
        }

        private void agentEmailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentEmailTxt.Text = "";
        }

        private void agentDobTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentDobTxt.Text = "";
        }

        private void agentLicenseTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            agentLicenseTxt.Text = "";
        }

        private void submitAgentRegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Call EstablishConnection method (to create and open connection)
                EstablishConnection();

                //Step 3: generate the database query
                string query = "insert into AgentRegistration values (@username, @password, @firstname, @lastname, @email, @dob, @license)";

                //Step 4: initialize the sql command
                sqlCommand = new SqlCommand(query, sqlConnection);

                //Step 5: initialize the variables of the query
                sqlCommand.Parameters.AddWithValue("@username", agentUsernameTxt.Text);
                sqlCommand.Parameters.AddWithValue("@password", agentPasswordTxt.Text);
                sqlCommand.Parameters.AddWithValue("@firstname", agentFirstNameTxt.Text);
                sqlCommand.Parameters.AddWithValue("@lastname", agentLastNameTxt.Text);
                sqlCommand.Parameters.AddWithValue("@email", agentEmailTxt.Text);
                sqlCommand.Parameters.AddWithValue("@dob", DateTime.Parse(agentDobTxt.Text));
                sqlCommand.Parameters.AddWithValue("@license", agentLicenseTxt.Text);

                //Step 6: execute the query with values
                //ExecuteNonQuery returns 1 if no error occurs
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    System.Windows.MessageBox.Show("Agent registered successfully!");
                }

                //Step 7: Close the connection
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Step 2: Establish connection
                EstablishConnection();

                //Step 3: Create the query
                string query = "select * from Student";

                //Step 4: Initialize command adapter
                sqlCommand = new SqlCommand(query, sqlConnection);

                //Step 5.1: Create data adapter to read the data from DB
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                //Step 5.2: Create table adapter to formulate the data from data adapter
                DataTable dataTable = new DataTable();
                //Fill the dataTable with retrieved info from adapter
                adapter.Fill(dataTable);

                //Step 6: Add the table to the data grid
                testGrid.ItemsSource = dataTable.AsDataView();

                //Step 7: Reinitialize WPF with the content we just pulled from the DB
                DataContext = adapter;

            }
            catch (SqlException ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
