using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineTicketing
{
    internal class Flight
    {
        private string airline;
        private string departureDate;
        private string departureTime;
        private string pilotCode;
        private string crewCode;

        public Flight(string airline, string departureDate, string departureTime, string pilotCode, string crewCode)
        {
            this.airline = airline;
            this.departureDate = departureDate;
            this.departureTime = departureTime;
            this.pilotCode = pilotCode;
            this.crewCode = crewCode;
        }

        public String getAirline() { return airline; }
        public String getDepartureDate() { return departureDate; }
        public String getDepartureTime() { return departureTime; }
        public string getPilotCode() { return pilotCode; }
        public string getCrewCode() { return crewCode; }
        public void setAirline(String airline) { this.airline = airline; }
        public void setDepartureDate(String departureDate) { this.departureDate = departureDate; }
        public void setDepartureTime(String departureTime) { this.departureTime = departureTime; }
        public void setPilotCode(String pilotCode) {  this.pilotCode = pilotCode;}
        public void setCrewCode(String crewCode) { this.crewCode =crewCode;}
    }
}
