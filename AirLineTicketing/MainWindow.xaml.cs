using AirLineTicketing.Models;
using AirLineTicketing.Network;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isloggedIn)
            {
                MessageBox.Show("Logout success!");
                isloggedIn = false;
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

        private async void ShowAllFlightsBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Flight> allFlights = await request.getAllFlights();
            DisplayGrid.ItemsSource = allFlights;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FAQ().Show();
        }
    }
}