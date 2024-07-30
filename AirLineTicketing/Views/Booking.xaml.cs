using AirLineTicketing.Models;
using System;
using System.Collections;
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

namespace AirLineTicketing.Views
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();

            setHeading();
            initializeGrid();
            initializePrice();
        }

        private void initializePrice() { 
            // Using Pseudo random numbers to price for the purpose of this Demo Project

            Random random = new Random();
            double price = random.NextDouble() * (10) + 130;

            TicketPriceDisplayLbl.Content = Math.Round(price, 2).ToString();
        }

        private void initializeGrid() {
            Flight? selectedFlight = MainWindow.selectedFlight;

            List<Flight> list = [selectedFlight];

            if (selectedFlight != null)
            {
                DisplayGrid.ItemsSource = list;

                ClassDisplayLabel.Content = selectedFlight.availableClasses;
                PassengersDisplayLabel.Content = selectedFlight.allowedPassengerTypes;
                BaggagesDisplayLabel.Content = selectedFlight.allowedBaggageTypes;
            }
        }

        private void setHeading() {
            User user = MainWindow.user;

            HeadingLabel.Content = "Welcome, " + user.getFirstname() + " " + user.getLastname();
        }
    }
}
