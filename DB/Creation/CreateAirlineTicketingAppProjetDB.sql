USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'AirlineTicketingAppProjet'
)
CREATE DATABASE [AirlineTicketingAppProjet]
GO

