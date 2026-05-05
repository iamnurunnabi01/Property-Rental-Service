-- ============================================================
--  PropertyRentalDB - Full SQL Setup Script
--  Run this entire script in SSMS against your SQL Server
-- ============================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PropertyRentalDB')
BEGIN
    ALTER DATABASE PropertyRentalDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PropertyRentalDB;
END
GO

CREATE DATABASE PropertyRentalDB;
GO

USE PropertyRentalDB;
GO

-- ===================== TABLES =====================

CREATE TABLE Users (
    UserId      INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100)  NOT NULL,
    Email       NVARCHAR(150)  NOT NULL UNIQUE,
    Password    NVARCHAR(255)  NOT NULL,
    Role        NVARCHAR(20)   NOT NULL CHECK (Role IN ('SuperAdmin','Owner','Customer')),
    CreatedAt   DATETIME       DEFAULT GETDATE()
);

CREATE TABLE Property (
    PropertyId  INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId     INT            NOT NULL REFERENCES Users(UserId) ON DELETE CASCADE,
    Title       NVARCHAR(200)  NOT NULL,
    Location    NVARCHAR(200)  NOT NULL,
    Price       DECIMAL(10,2)  NOT NULL,
    Bedrooms    INT            NOT NULL,
    Status      NVARCHAR(20)   DEFAULT 'Available' CHECK (Status IN ('Available','Booked','Unavailable')),
    Description NVARCHAR(MAX),
    CreatedAt   DATETIME       DEFAULT GETDATE()
);

CREATE TABLE Booking (
    BookingId   INT IDENTITY(1,1) PRIMARY KEY,
    PropertyId  INT            NOT NULL REFERENCES Property(PropertyId),
    CustomerId  INT            NOT NULL REFERENCES Users(UserId),
    StartDate   DATE           NOT NULL,
    EndDate     DATE           NOT NULL,
    TotalPrice  DECIMAL(10,2)  NOT NULL,
    Status      NVARCHAR(20)   DEFAULT 'Pending' CHECK (Status IN ('Pending','Confirmed','Cancelled')),
    BookedAt    DATETIME       DEFAULT GETDATE()
);

CREATE TABLE Payment (
    PaymentId   INT IDENTITY(1,1) PRIMARY KEY,
    BookingId   INT            NOT NULL REFERENCES Booking(BookingId),
    Amount      DECIMAL(10,2)  NOT NULL,
    PaymentDate DATETIME       DEFAULT GETDATE(),
    Method      NVARCHAR(50)   DEFAULT 'Online'
);

CREATE TABLE Review (
    ReviewId    INT IDENTITY(1,1) PRIMARY KEY,
    PropertyId  INT            NOT NULL REFERENCES Property(PropertyId),
    UserId      INT            NOT NULL REFERENCES Users(UserId),
    Rating      INT            NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    Comment     NVARCHAR(MAX),
    ReviewDate  DATETIME       DEFAULT GETDATE()
);

CREATE TABLE Offer (
    OfferId         INT IDENTITY(1,1) PRIMARY KEY,
    PropertyId      INT            NOT NULL REFERENCES Property(PropertyId) ON DELETE CASCADE,
    DiscountPercent DECIMAL(5,2)   NOT NULL CHECK (DiscountPercent BETWEEN 0 AND 100),
    StartDate       DATE           NOT NULL,
    EndDate         DATE           NOT NULL,
    Description     NVARCHAR(200)
);

-- ===================== SEED DATA =====================

-- SuperAdmin (password: admin123)
INSERT INTO Users (Name, Email, Password, Role) VALUES
('Super Admin', 'admin@rental.com', 'admin123', 'SuperAdmin');

-- Sample Owner (password: owner123)
INSERT INTO Users (Name, Email, Password, Role) VALUES
('John Owner', 'john@owner.com', 'owner123', 'Owner');

-- Sample Customer (password: cust123)
INSERT INTO Users (Name, Email, Password, Role) VALUES
('Alice Customer', 'alice@customer.com', 'cust123', 'Customer');

-- Sample Properties
INSERT INTO Property (OwnerId, Title, Location, Price, Bedrooms, Status, Description) VALUES
(2, 'Cozy Downtown Apartment', 'Dhaka, Gulshan', 5000.00, 2, 'Available', 'Modern apartment in the heart of Gulshan'),
(2, 'Spacious Family House', 'Dhaka, Dhanmondi', 8500.00, 4, 'Available', 'Large family home with garden'),
(2, 'Studio Near University', 'Dhaka, Mirpur', 2500.00, 1, 'Available', 'Perfect for students'),
(2, 'Luxury Penthouse', 'Dhaka, Banani', 15000.00, 3, 'Available', 'Top floor luxury living');

-- Sample Offers
INSERT INTO Offer (PropertyId, DiscountPercent, StartDate, EndDate, Description) VALUES
(1, 10.00, GETDATE(), DATEADD(day, 30, GETDATE()), 'Summer Special - 10% OFF'),
(3, 15.00, GETDATE(), DATEADD(day, 15, GETDATE()), 'Student Discount - 15% OFF');

-- ===================== USEFUL VIEWS =====================
GO
-- Property with avg rating
CREATE VIEW vw_PropertyWithRating AS
SELECT 
    p.*,
    u.Name AS OwnerName,
    ISNULL(AVG(CAST(r.Rating AS FLOAT)), 0) AS AvgRating,
    COUNT(r.ReviewId) AS ReviewCount
FROM Property p
JOIN Users u ON p.OwnerId = u.UserId
LEFT JOIN Review r ON p.PropertyId = r.PropertyId
GROUP BY p.PropertyId, p.OwnerId, p.Title, p.Location, p.Price,
         p.Bedrooms, p.Status, p.Description, p.CreatedAt, u.Name;
GO
-- Owner earnings view
CREATE VIEW vw_OwnerEarnings AS
SELECT 
    p.OwnerId,
    p.Title,
    p.PropertyId,
    b.BookingId,
    u.Name AS CustomerName,
    b.StartDate,
    b.EndDate,
    b.TotalPrice,
    b.Status AS BookingStatus,
    b.BookedAt
FROM Booking b
JOIN Property p ON b.PropertyId = p.PropertyId
JOIN Users u ON b.CustomerId = u.UserId
WHERE b.Status = 'Confirmed';
GO

PRINT 'PropertyRentalDB created successfully!';
GO
