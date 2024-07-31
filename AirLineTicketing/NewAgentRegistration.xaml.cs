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
            String username = agentUsernameTxt.Text;
            String password = agentPasswordTxt.Text;
            String firstname = agentFirstNameTxt.Text;
            String lastname = agentLastNameTxt.Text;
            String email = agentEmailTxt.Text;
            String dob = agentDobTxt.Text;
            String license = agentLicenseTxt.Text;

            Agent newAgent = new Agent(username, password, firstname, lastname, email, dob, license);

            ApiRequest request = new ApiRequest();

            request.postAgentApi(newAgent);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FAQ().Show();

        private void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            new AgentSignIn().Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
