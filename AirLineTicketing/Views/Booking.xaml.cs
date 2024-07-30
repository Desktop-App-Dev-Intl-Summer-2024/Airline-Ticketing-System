using AirLineTicketing.Models;
using AirLineTicketing.Network;
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
        Flight selectedFlight;
        Request request;

        public Booking()
        {
            InitializeComponent();

            selectedFlight = MainWindow.selectedFlight;
            request = new Request();

            setHeading();
            initializeGrid();
            initializeComboBoxes();
            initializePrice();
        }

        private void initializeComboBoxes() {
            ClassCmbBx.ItemsSource = selectedFlight.availableClasses.Split(' ');
        }

        private void initializePrice() { 
            // Using Pseudo random numbers to price for the purpose of this Demo Project

            Random random = new Random();
            double price = random.NextDouble() * (10.0) + 130;

            TicketPriceDisplayLbl.Content = "$" + Math.Round(price, 2).ToString();
        }

        private void initializeGrid() {
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

        private void FirstnameTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstnameTxtBx.Text = "";
        }

        private void LastNameTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            LastNameTxtBx.Text = "";
        }

        private void NationalityTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            NationalityTxtBx.Text = "";
        }

        private void PassportNoTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            PassportNoTxtBx.Text = "";
        }

        private void AddressTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            AddressTxtBx.Text = "";
        }

        private void CvvTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            CvvTxtBx.Text = "";
        }

        private void CardExpDatePckr_GotFocus(object sender, RoutedEventArgs e)
        {
            CardExpDatePckr.Text = "";
        }

        private void CardNoTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            CardNoTxtBx.Text = "";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = FirstnameTxtBx.Text.Trim();
                string lastName = LastNameTxtBx.Text.Trim();
                string? classType = ClassCmbBx.SelectedItem.ToString();
                string nationality = NationalityTxtBx.Text.Trim();
                string passportNumber = PassportNoTxtBx.Text.Trim();
                string address = AddressTxtBx.Text.Trim();
                string cardNumber = CardNoTxtBx.Text.Trim();
                string? expiryDate = CardExpDatePckr.Text;
                string cardCvv = CvvTxtBx.Text.Trim();
                string bookingDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                double ticketCost = Convert.ToDouble(TicketPriceDisplayLbl.Content.ToString().Substring(1));


                int flightNo = selectedFlight.flightNo;

                BookingDetail detail = new BookingDetail();

                detail.bookingUserId = MainWindow.user.getId();
                detail.firstName = firstName;
                detail.lastName = lastName;
                detail.classType = classType;
                detail.nationality = nationality;
                detail.passportNumber = passportNumber;
                detail.address = address;
                detail.cardNumber = cardNumber;
                detail.expiryDate = expiryDate;
                detail.cardCvv = cardCvv;
                detail.bookingDateTime = bookingDateTime;
                detail.ticketCost = ticketCost;
                detail.flightNo = flightNo;

                BookingDetail confirmedDetail = await request.postTicketBooking(detail);

                if(confirmedDetail != null)
                {
                    MessageBox.Show($"Booking confirmed! " +
                        $"\nID: {confirmedDetail.bookingId} and " +
                        $"\nSeat No: {confirmedDetail.seatNo}" +
                        $"\n\nPlease Check Booking History for more information");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User? user = MainWindow.user;

            FirstnameTxtBx.Text = user?.getFirstname();
            LastNameTxtBx.Text = user?.getLastname();
        }
    }
}
