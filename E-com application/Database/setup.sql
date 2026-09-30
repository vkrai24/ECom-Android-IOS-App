-- E-Commerce Database Setup Script
-- Run this script in SQL Server Management Studio (SSMS)

-- Create Database
CREATE DATABASE ECommerceDB;
GO

USE ECommerceDB;
GO

-- Create Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(20),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2
);
GO

-- Create Products Table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(2000),
    Price DECIMAL(18,2) NOT NULL,
    OriginalPrice DECIMAL(18,2),
    Category NVARCHAR(50) NOT NULL,
    ImageUrl NVARCHAR(500),
    Stock INT NOT NULL,
    Rating DECIMAL(2,1),
    ReviewCount INT,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2
);
GO

-- Create Orders Table
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    OrderNumber NVARCHAR(50) NOT NULL UNIQUE,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Processing',
    ShippingAddress NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    State NVARCHAR(50) NOT NULL,
    ZipCode NVARCHAR(20) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100),
    OrderDate DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ShippedDate DATETIME2,
    DeliveredDate DATETIME2,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Create OrderItems Table
CREATE TABLE OrderItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Discount DECIMAL(18,2),
    Total DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO

-- Create Payments Table
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    TransactionId NVARCHAR(200),
    PaymentDate DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);
GO

-- Insert Sample Products
INSERT INTO Products (Name, Description, Price, OriginalPrice, Category, ImageUrl, Stock, Rating, ReviewCount)
VALUES
('Wireless Bluetooth Headphones', 'Premium wireless headphones with noise cancellation and 30-hour battery life.', 79.99, 99.99, 'Electronics', 'https://via.placeholder.com/400', 50, 4.5, 128),
('Smart Fitness Watch', 'Track your fitness goals with this advanced smartwatch featuring heart rate monitoring.', 129.99, NULL, 'Electronics', 'https://via.placeholder.com/400', 30, 4.7, 256),
('Premium Leather Wallet', 'Handcrafted genuine leather wallet with RFID protection.', 49.99, 69.99, 'Fashion', 'https://via.placeholder.com/400', 100, 4.3, 89),
('Portable Power Bank', '20000mAh high-capacity power bank with fast charging support.', 34.99, NULL, 'Electronics', 'https://via.placeholder.com/400', 75, 4.6, 312),
('Yoga Mat Pro', 'Extra thick exercise yoga mat with carrying strap.', 29.99, NULL, 'Sports', 'https://via.placeholder.com/400', 60, 4.8, 167),
('Coffee Maker Deluxe', 'Programmable coffee maker with thermal carafe.', 89.99, NULL, 'Home & Garden', 'https://via.placeholder.com/400', 25, 4.4, 94),
('Running Shoes Elite', 'Professional running shoes with advanced cushioning technology.', 119.99, 149.99, 'Sports', 'https://via.placeholder.com/400', 45, 4.7, 203),
('Desk Lamp LED', 'Adjustable LED desk lamp with USB charging port.', 39.99, NULL, 'Home & Garden', 'https://via.placeholder.com/400', 80, 4.5, 145);
GO

-- Create Indexes for Performance
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Products_Category ON Products(Category);
CREATE INDEX IX_Orders_UserId ON Orders(UserId);
CREATE INDEX IX_Orders_OrderNumber ON Orders(OrderNumber);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_OrderItems_ProductId ON OrderItems(ProductId);
CREATE INDEX IX_Payments_OrderId ON Payments(OrderId);
GO

PRINT 'Database setup completed successfully!';
PRINT 'Sample products have been inserted.';
PRINT 'You can now run the .NET Core API application.';
GO
