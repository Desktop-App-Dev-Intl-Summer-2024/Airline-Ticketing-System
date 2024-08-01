using AirLineTicketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AirLineTicketing
{
    /// <summary>
    /// Interaction logic for AdminEditRecord.xaml
    /// </summary>
    public partial class AdminEditRecord : Window
    {
        ApiRequest apiRequest;

        public AdminEditRecord()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();

        }



        //NAVIGATE TO ADD RECORD WINDOW
        private void addRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminAddRecord().Show();
            this.Close();
        }

        //LOG OUT BUTTON - BACK TO SIGN IN WINDOW
        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            new SignInSignUp().Show();
            this.Close();
        }

        //SEARCH RECORD BUTTON CLICK - SEARCH DB BY FLIGHT NO
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string flightNo = flightNoSearchTxt.Text;

            Flight? flight = apiRequest.searchFlightApi(flightNo);

            if (flight != null)
            {
                MessageBox.Show("Record retrieved succesfully!");
                
                departureTimeTxt.Text = flight.departureTime;
                pilotTxt.Text = flight.pilotCode.ToString();
                crewTxt.Text = flight.crewCode.ToString();
                originTxt.Text = flight.origin;
                destinationTxt.Text = flight.destination;
                availSeatsTxt.Text = flight.availableSeats.ToString();
                totalSeatsTxt.Text = flight.totalSeats.ToString();
                layoverTxt.Text = flight.layover;
            }
            else
            {
                MessageBox.Show("No record found  - check flight no!");
            }
        }

        private void flightNoSearchTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            flightNoSearchTxt.Text = "";
        }
    }
}