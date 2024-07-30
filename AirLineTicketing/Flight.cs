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
        private string origin;
        private string destination;
        private string availableClasses;
        private string availableSeats;
        private string totalSeats;
        private string layover;
        private string allowedPassengerTypes;
        private string allowedBaggageTypes;

        public Flight(string airline, string departureDate, string departureTime, string pilotCode, 
                        string crewCode, string origin, string destination, string availableClasses, 
                        string availableSeats, string totalSeats, string layover, string passengerTypes, string baggageTypes)
        {
            this.airline = airline;
            this.departureDate = departureDate;
            this.departureTime = departureTime;
            this.pilotCode = pilotCode;
            this.crewCode = crewCode;
            this.origin = origin;
            this.destination = destination;
            this.availableClasses = availableClasses;

            this.availableSeats = availableSeats;
            this.totalSeats = totalSeats;
            this.layover = layover;
            this.allowedPassengerTypes = allowedPassengerTypes;
            this.allowedBaggageTypes = allowedBaggageTypes;
        }

        public String getAirline() { return airline; }
        public String getDepartureDate() { return departureDate; }
        public String getDepartureTime() { return departureTime; }
        public string getPilotCode() { return pilotCode; }
        public string getCrewCode() { return crewCode; }
        public string getOrigin() { return origin; }
        public String getDestination() { return destination; }
        public String getAvailableClasses() { return availableClasses; }
        public String getAvailableSeats() { return availableSeats; }
        public String getTotalSeats() {return totalSeats; }
        public String getLayover() { return layover; }
        public String getAllowedPassengerTypes() { return allowedPassengerTypes; }
        public String getAllowedBaggageTypes() { return allowedBaggageTypes; }
        public void setAirline(String airline) { this.airline = airline; }
        public void setDepartureDate(String departureDate) { this.departureDate = departureDate; }
        public void setDepartureTime(String departureTime) { this.departureTime = departureTime; }
        public void setPilotCode(String pilotCode) {  this.pilotCode = pilotCode;}
        public void setCrewCode(String crewCode) { this.crewCode =crewCode;}
        public void setOrigin(String origin) { this.origin = origin; }
        public void setDestination(String destination) { this.destination = destination; }
        public void setAvailableClasses(String availableClasses) { this.availableClasses = availableClasses; }
        public void setAvailableSeats(String availSeats) {  this.availableSeats = availSeats;}
        public void setTotalSeats(String totalSeats) { this.totalSeats = totalSeats;}
        public void setLayover(String layover) { this.layover = layover; }  
        public void setAllowedPassengerTypes(String allowedPassengerTypes) {  this.allowedPassengerTypes = allowedPassengerTypes;}
        public void setAllowedBaggageTypes(String allowedBaggageTypes) { this.allowedBaggageTypes = allowedBaggageTypes;}
    }
}
