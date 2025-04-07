-- Drop existing EventEaseDB if it exists
USE master;
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventEaseDB')
    DROP DATABASE EventEaseDB;
GO

-- Create a fresh database
CREATE DATABASE EventEaseDB;
GO

USE EventEaseDB;
GO

-- Create Venues table
CREATE TABLE Venues (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(255) NULL
);
GO

-- Create Events table
CREATE TABLE Events (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Date DATE NOT NULL,
    Description NVARCHAR(500) NULL,
	ImageUrl NVARCHAR(255) NULL
);
GO

-- Create Bookings table with foreign key relationships
CREATE TABLE Bookings (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    BookingDate DATE NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(Id),
    FOREIGN KEY (VenueId) REFERENCES Venues(Id)
);
GO

-- Insert sample data into Venues
INSERT INTO Venues (Name, Location, Capacity, ImageUrl)
VALUES 
('Conference Hall A', 'Cape Town Convention Center', 300, 'https://example.com/hallA.jpg'),
('Open Air Grounds', 'Joburg Park', 800, 'https://example.com/park.jpg');
GO

-- Insert sample data into Events
INSERT INTO Events (Name, Date, Description)
VALUES 
('Tech Summit 2025', '2025-09-15', 'A premier gathering of tech leaders.'),
('Startup Pitch Night', '2025-10-05', 'An evening of startup innovation and networking.');
GO

-- Insert sample data into Bookings
INSERT INTO Bookings (EventId, VenueId, BookingDate)
VALUES 
(1, 1, '2025-08-01'),
(2, 2, '2025-09-20');
GO

-- View the tables
SELECT * FROM Venues;
SELECT * FROM Events;
SELECT * FROM Bookings;
