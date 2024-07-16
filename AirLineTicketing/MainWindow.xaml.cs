using AirLineTicketing.Models;
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
        public FlightsQuery flightsQuery;
        public List<CheckboxItem> passangerComboBoxItems;
        public List<CheckboxItem> baggageComboBoxtems;
        public Places places;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBaggageComboBox();
            InitializePassangerComboBox();
            InitializeOriginDestinationComboBox();

            flightsQuery = new FlightsQuery();

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

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string trip = tripCmbx.Text.ToLower();
            List<string> passenger = GetSelectedItemsList(passangerComboBoxItems);
            string seatClass = classCmbx.Text.ToLower();
            List<string> baggage = GetSelectedItemsList(baggageComboBoxtems);
            string origin = originCmbx.Text.ToLower();
            string destination = destinationCmbx.Text.ToLower();
            string date = flightDatePckr.Text;

            FlightsQuery queryObject = new FlightsQuery();

            queryObject.trip = trip;
            queryObject.passenger = passenger;
            queryObject.seatClass = seatClass;
            queryObject.baggage = baggage;
            queryObject.origin = origin;
            queryObject.destination = destination;
            queryObject.date = date;

            // query the database for eligible flights
            // Display flights from DB after quering
        }

        private void InitializeBaggageComboBox()
        {
            baggageComboBoxtems = new List<CheckboxItem>
            {
                new CheckboxItem { Name = "Baggage", IsSelected = true },
                new CheckboxItem { Name = "Carry-on bag", IsSelected = true },
                new CheckboxItem { Name = "Check-in bag", IsSelected = false },
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
                new CheckboxItem { Name = "Students(18+)", IsSelected = false },
                new CheckboxItem { Name = "Youths(12-17)", IsSelected = false },
                new CheckboxItem { Name = "Children", IsSelected = false },
                new CheckboxItem { Name = "Toddler with own seat", IsSelected = false },
                new CheckboxItem { Name = "Infants on lap", IsSelected = false },
            };

            passengerTypeCmbx.ItemsSource = passangerComboBoxItems;
        }

        private void InitializeOriginDestinationComboBox() { 
            // to be done through API calls
            List<string> origins = new List<string> { "Montreal", "Trivandrum", "Interlaken"};
            List<string> destinations = new List<string> { "California", "New Delhi", "Paris", "Stockholm", "Trivandrum", "Montreal" };

            originCmbx.ItemsSource = origins;
            destinationCmbx.ItemsSource = destinations;
        }

        private void passengerTypeCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            passengerTypeCmbx.SelectedIndex = 0;
        }

        private void baggageCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            baggageCmbx.SelectedIndex = 0;
        }
    }
}