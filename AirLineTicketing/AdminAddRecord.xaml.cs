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
            String flightNo = flightNoTxt.Text;
            String airline = "";
            String departureDate = "";
            String departureTime = departureTimeTxt.Text;
            String pilotCode = pilotTxt.Text;
            String crewCode = crewTxt.Text;

            Flight newFlight = new Flight(flightNo, airline, departureDate, departureTime, pilotCode, crewCode);

            ApiRequest request = new ApiRequest();

            request.postFlightApi(newFlight);
        }
    }
}
