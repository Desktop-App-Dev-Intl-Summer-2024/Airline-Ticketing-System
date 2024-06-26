# Airline-Ticketing-System

## Trello Board Link
https://trello.com/b/W1MN71TW/airline-ticketing-app-projet

## Description
This project aims to implement an Airline Ticketing System that runs as a Desktop application which helps with browsing, filtering, and reserving airline tickets based on user preference. The major users of this project are the airline employees who acts as the admin who is capable of loading the flight information, and then comes the consumers and travel agents who are both capable of reserving the tickets on the flights of their choice. This app uses C# .NET Framework for its front-end implementation, and Microsoft SQL for its backend.

## Scope

### Features
- Flight info loading: users with admin privileges will be able to load into the system flight information, including time of flight, destination, plane model, price, and available amenities. They will be able to edit the information as well.
- Registration: users (consumers that are not admin) will be able to register a profile with which to reserve tickets. Required info: name, dob, email address (which will be used as both contact and username), and password. Users will need to confirm their email address to complete their registration.
- Ticket Browsing: users will be able to browse available plane tickets based on their selected filters for destination, dates, number of seats needed, and pricing.
- Ticket selection: users will be able to select their desired flight(s), confirm their selection, and reserve the flight for purchase. Users will also be able to add baggage, meals, and insurance details in the ticket selection screen.
- Billing: users will receive billing to their email address on file for their selected flights, to be paid within a specified time frame (or tickets will be un-reserved).
- Notification: users will be able to set preferences to be notified by the application via email if flights meeting their desired parameters become available.
- Questions/Comments: users will be able to reach out to the airline via the application with questions or comments. The airline’s customer service will contact the user via their email address on file.
- Booking for third party: Travel agents will be able to register with the application (required to confirm licensing) to access the ability to book tickets for third parties (their clients).

### End Users
Primary users of the Airline Ticketing System: Airline Admin, consumers, travel agents.
- Airline Admin: loading flight data. 
- Consumers: data filtering and selection. 
- Travel agents: data filtering and selection on behalf of third party.

### User story
- As an airline admin, I can load all the relevant flight information into the system so that other users can browse, and book tickets.
- As an airline admin, I should be able to edit the flight information.
- As an airline admin, I should be able to approve registration of new travel agents.
- As a user, I should be able to create and register an account with the airline so that I can book tickets.
- As a user, I should be able to browse available flights, so that I can choose the best option from this list
- As a user, I should be able to reserve a flight of my choice.
- As a user, I should receive billing information on my email address, so that I can pay and confirm my ticket
- As a user, I should be able to set my notification preferences, so that I’m notified of availability of desired flights, or change of flight statuses
- As a user, I should be able to contact the airline customer service, so that I can let them know about any questions and comments.
- As a travel agent, I should be able to register with the airline.
- As a travel agent, I should be able to book tickets for my clients.

### Areas Covered
1. **User registration:** The users must be able to register with the airline with their email address.  
2. **Agent registration:** The travel agents must be able to register their account with the airline.  
3. **Admin module:** Admin must be able to create and maintain flight details in the system.  
4. **Browsing module:** All users must be able to view available flights based on specific filter criteria.  
5. **Reservation module:** All users must be able to reserve tickets.  
6. **Billing module:** To calculate and display the total amount to be paid by the user to confirm a ticket.  

### Project Users, Actors, Vendors, and Actuators
**Users**
- Consumers
- Travel Agents
**Actors**
- Airline Admins
**Vendors**
- Any major airline company that offers flight services. This includes airlines like Delta, United, Emirates, etc. The vendor provides the flight schedules, seat availability, pricing, and other related services that users (travelers) book through the system.
- Additionally, third-party services such as online travel agencies (OTAs) like Expedia, Booking.com, or Kayak, which aggregate flight options from multiple airlines and facilitate bookings.
**Actuators**
- Airline Ticketing System: A software application that is at the core of this project that works as the actuator. It is responsible for the registration of users, loading of flight details, browsing, booking and billing of airline tickets.

### Properties
- Programming languages used: C# and SQL
- .NETFramework 8.0
- Microsoft Server Management Studio 19.3
- Git and GitHub

### Project Plan
- Create views for various functionalities: Week 1-2 (3 June – 16 June) 
- Database design: Week 2 (10 June – 16 June)
- Stored procedure creation: Week 3 (17 June – 23 June)
- Create REST APIs and bridge between front and back ends: Week 4 (24 June – 30 June)
- NUnit testing: Week 5 (1 July – 7 July)
- UI optimization: Week 6 (8 July – 14 July)
- Final Edits: Week 7 (15 July – 21 July)
- Project Presentation: 29 July

