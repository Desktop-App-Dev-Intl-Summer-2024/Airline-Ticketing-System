CREATE TABLE Flights (
flightNo INT IDENTITY (1000, 1) NOT NULL,
airline varchar(50) not null,
departureDate date not null,
departureTime time not null,
pilotCode int not null,
crewCode int not null,
CONSTRAINT UC_Flight UNIQUE (flightNo)
);