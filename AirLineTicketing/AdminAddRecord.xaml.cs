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
    /// Interaction logic for AdminAddRecord.xaml
    /// </summary>
    public partial class AdminAddRecord : Window
    {
        public AdminAddRecord()
        {
            InitializeComponent();
        }

        //SAVE NEW RECORD BUTTON CLICK
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String airline = airlineCombo.Text;
            String departureDate = flightDate.SelectedDate.ToString();
            String departureTime = departureTimeTxt.Text;
            String pilotCode = pilotTxt.Text;
            String crewCode = crewTxt.Text;
            String origin = originTxt.Text;
            String destination = destinationTxt.Text;
            String availableSeats = availSeatsTxt.Text;
            String totalSeats = totalSeatsTxt.Text;
            String layover = layoverTxt.Text;

            //availClasses checkboxes: business economy premium first
            String availableClasses = "";
            if (businessCheck.IsChecked == true)
            {
                availableClasses += "business";
            }
            if (economyCheck.IsChecked == true)
            {
                availableClasses += " economy";
            }
            if(premiumCheck.IsChecked == true)
            {
                availableClasses += " premium";
            }
            if(firstCheck.IsChecked == true)
            {
                availableClasses += " first";
            }

            //passengerTypes checkboxes: adults students youth children toddlers infants
            String allowedPassengerTypes = "";
            if(adultsCheck.IsChecked == true)
            {
                allowedPassengerTypes += "adults";
            }
            if(studentsCheck.IsChecked == true)
            {
                allowedPassengerTypes += " students";
            }
            if(youthCheck.IsChecked == true)
            {
                allowedPassengerTypes += " youth";
            }
            if(childrenCheck.IsChecked == true)
            {
                allowedPassengerTypes += " children";
            }
            if(toddlerCheck.IsChecked == true)
            {
                allowedPassengerTypes += " toddlers";
            }
            if(infantCheck.IsChecked == true)
            {
                allowedPassengerTypes += " infants";
            }

            //baggageTypes checkboxes: check-in, carry-on
            String allowedBaggageTypes = "";
            if(checkInCheck.IsChecked == true)
            {
                allowedBaggageTypes += "check-in";
            }
            if(carryOnCheck.IsChecked == true)
            {
                allowedBaggageTypes += " carry-on";
            }

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
            newFlight.allowedBaggageTypes= allowedBaggageTypes;

            ApiRequest request = new ApiRequest();

            request.postFlightApi(newFlight);
        }

        //ADD ADDITIONAL NEW RECORD - CLEAR ALL CURRENT VALUES
        private void addRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            airlineCombo.Items.Clear();
            flightDate.DisplayDate = DateTime.Now;
            departureTimeTxt.Text = "";
            pilotTxt.Text = "";
            crewTxt.Text = "";
            originTxt.Text = "";
            destinationTxt.Text = "";
            availSeatsTxt.Text = "";
            totalSeatsTxt.Text = "";
            layoverTxt.Text = "";
            //clear all checkboxes
        }

        //NAVIGATE TO EDIT RECORD WINDOW
        private void editRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminEditRecord().Show();
            this.Close();
        }

        //LOG OUT BUTTON - BACK TO SIGN IN WINDOW
        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            new SignInSignUp().Show();
            this.Close();
        }


    }
}