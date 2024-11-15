﻿using AirLineTicketing.Models;
using AirLineTicketing.Network;
using AirLineTicketing.Views;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirLineTicketing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isloggedIn = false;
        public static User? user = null;
        public static Flight? selectedFlight = null;

        public FlightsFilter flightsFilter;
        public List<CheckboxItem> passangerComboBoxItems;
        public List<CheckboxItem> baggageComboBoxtems;
        public Places places;

        private Request request;

        public MainWindow()
        {
            InitializeComponent();

            flightsFilter = new FlightsFilter();
            request = new Request();

            InitializeBaggageComboBox();
            InitializePassangerComboBox();
            InitializeOriginDestinationComboBox();

            setLogButtonText();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FAQ().Show();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isloggedIn)
            {
                System.Windows.MessageBox.Show("Logout success!");

                isloggedIn = false;
                user = null;

                setLogButtonText();
            }
            else {
                new SignInSignUp().Show();
                this.Close();
            }
        }

        private void setLogButtonText() {
            if (isloggedIn)
            {
                logBtn.Content = "Log out";
            }
            else {
                logBtn.Content = "Sign In/Sign Up";
            }
        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string trip = tripCmbx.Text.ToLower();
            List<string> passenger = GetSelectedItemsList(passangerComboBoxItems);
            string seatClass = classCmbx.Text.ToLower();
            List<string> baggage = GetSelectedItemsList(baggageComboBoxtems);
            string origin = originCmbx.Text.ToLower();
            string destination = destinationCmbx.Text.ToLower();
            string date = flightDatePckr.Text;

            FlightsFilter filter = new FlightsFilter();

            filter.trip = trip;
            filter.passenger = passenger;
            filter.seatClass = seatClass;
            filter.baggage = baggage;
            filter.origin = origin;
            filter.destination = destination;
            filter.date = date;

            List<Flight> availableFlights = await request.getFlightsByFilter(filter);
            DisplayGrid.ItemsSource = availableFlights;
        }

        private void InitializeBaggageComboBox()
        {
            baggageComboBoxtems = new List<CheckboxItem>
            {
                new CheckboxItem { Name = "Baggage", IsSelected = true },
                new CheckboxItem { Name = "Carry-on", IsSelected = true },
                new CheckboxItem { Name = "Check-in", IsSelected = false },
            };

            baggageCmbx.ItemsSource = baggageComboBoxtems;
        }

        private List<string> GetSelectedItemsList(List<CheckboxItem> list) { 
            List<string> selected = new List<string>();

            for (int i = 1; i < list.Count; i++) {
                if (list[i].IsSelected) {
                    selected.Add(list[i].Name.ToLower());
                }
            }

            return selected;
        }

        private void InitializePassangerComboBox()
        {
            passangerComboBoxItems = new List<CheckboxItem>
            {
                new CheckboxItem { Name = "Passengers", IsSelected = true },
                new CheckboxItem { Name = "Adults", IsSelected = true },
                new CheckboxItem { Name = "Students", IsSelected = false },
                new CheckboxItem { Name = "Youths", IsSelected = false },
                new CheckboxItem { Name = "Children", IsSelected = false },
                new CheckboxItem { Name = "Toddler", IsSelected = false },
                new CheckboxItem { Name = "Infants", IsSelected = false },
            };

            passengerTypeCmbx.ItemsSource = passangerComboBoxItems;
        }

        private async void InitializeOriginDestinationComboBox() {
            Places places = await request.getAllPlaces();

            originCmbx.ItemsSource = places.origins;
            destinationCmbx.ItemsSource = places.destinations;
        }

        private void passengerTypeCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            passengerTypeCmbx.SelectedIndex = 0;
        }

        private void baggageCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            baggageCmbx.SelectedIndex = 0;
        }

        private void ShowAllFlightsBtn_Click(object sender, RoutedEventArgs e)
        {
            refreshDisplayGrid();
        }

        public async void refreshDisplayGrid() {
            List<Flight> allFlights = await request.getAllFlights();
            DisplayGrid.ItemsSource = allFlights;
        }


        private void DisplayGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedFlight = DisplayGrid.SelectedItem as Flight;

                if (selectedFlight == null) return;

                string message = "Do you want to proceed with: "
                    + "\n 1. Flight No: " + selectedFlight.flightNo
                    + "\n 2. Airlines: " + selectedFlight.airline
                    + "\n 3. Date: " + selectedFlight.departureDate
                    + "\n 4. Time: " + selectedFlight.departureTime
                    + "\n 5. Origin: " + selectedFlight.origin
                    + "\n 6. Destination: " + selectedFlight.destination;

                DialogResult result = System.Windows.Forms.MessageBox.Show(
                    message,
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!isloggedIn) {
                        System.Windows.MessageBox.Show("Please log in to continue...");
                        return;
                    }

                    new Booking(this).Show();
                }
                
                DisplayGrid.SelectedItem = null;
            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void BookingHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isloggedIn)
            {
                System.Windows.MessageBox.Show("Please log in to continue...");
                return;
            }

            new BookingHistory().Show();
        }
    }
}