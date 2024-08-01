using AirLineTicketing.Models;
using AirLineTicketing.Network;
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

namespace AirLineTicketing.Views
{
    /// <summary>
    /// Interaction logic for BookingHistory.xaml
    /// </summary>
    public partial class BookingHistory : Window
    {
        Request request;
        List<BookingDetail> bookingDetails;
        int selectedBookingIndex = -1;

        public BookingHistory()
        {
            request = new Request();

            InitializeComponent();
            initializeDisplay();
        }

        private async void initializeDisplay() {
            bookingDetails = await request.getBookingDetailsByUserId(MainWindow.user.getId());
            DisplayGrid.ItemsSource = bookingDetails;

            if (selectedBookingIndex < 0)
            {
                populateDetails(0);
            }
        }

        private void populateDetails(int index) { 
            BookingDetail detail = bookingDetails[index];
            Flight flight = detail.flight;

            BookingIdTxtBx.Text = detail.bookingId.ToString();
            FirstNameTxtBx.Text = detail.firstName;
            LastNameTxtBx.Text = detail.lastName;
            ClassTxtBx.Text = detail.classType;
            NationalityTxtBx.Text = detail.nationality;
            PassportTxtBx.Text = detail.passportNumber;
            AddressTxtBx.Text = detail.address;

            CardNumberTxtBx.Text = detail.cardNumber;
            CardExpiryDateTxtBx.Text = detail.expiryDate;
            CvvTxtBx.Text = detail.cardCvv;
            BookingDateTxtBx.Text = detail.bookingDateTime;
            TicketCostTxtBx.Text = detail.ticketCost.ToString();
            FlightNoTxtBx.Text = detail.flightNo.ToString();
            SeatNoTxtBx.Text = detail.seatNo.ToString();
            AirlineTxtBx.Text = flight.airline;

            DepartureDateTxtBx.Text = flight.departureDate;
            DepartureTimeTxtBx.Text = flight.departureTime;
            OriginTxtBx.Text = flight.origin;
            LayoverTxtBx.Text = flight.layover;
            DestinationTxtBx.Text = flight.destination;
            PassegnersTxtBx.Text = flight.allowedPassengerTypes;
            BaggagesTxtBx.Text = flight.allowedBaggageTypes;
            PilotCodeTxtBx.Text = flight.pilotCode.ToString();
            CrewCodeTxtBx.Text = flight.crewCode.ToString();
        }

        private void DisplayGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedRowIndex = DisplayGrid.SelectedIndex;
            populateDetails(selectedRowIndex);
        }
    }
}
