-- StockMaster --

-- Varsa StockMaster veritabanýný sil
IF EXISTS (SELECT * FROM sys.databases WHERE name='StockMaster')
BEGIN
	DROP DATABASE StockMaster
END
GO

-- StockMaster veritabanýný oluþtur
CREATE DATABASE StockMaster
GO

-- StockMaster veritabanýný seç, kullanýma al
USE StockMaster
GO

-- Kategori tablosunu oluþtur
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(MAX)
)
GO

-- Tedarikçi tablosunu oluþtur
CREATE TABLE Suppliers(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	ContactName NVARCHAR(100) NOT NULL,
	Phone VARCHAR(20),
	Address VARCHAR(250)
)
GO

-- Ürün tablosunu oluþtur
CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	QuantityPerUnit VARCHAR(50),
	UnitPrice DECIMAL(18,2),
	UnitsInStock INT,
	Discounted BIT,
	ReorderLevel INT,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	SupplierId INT FOREIGN KEY REFERENCES Suppliers(Id)
)
GO

-- Stok Hareketleri Tablosunu oluþturuyoruz
CREATE TABLE StockTransactions(
	Id INT PRIMARY KEY IDENTITY,
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	TransactionType VARCHAR(3) CHECK(TransactionType IN ('IN','OUT')),
	Quantity INT NOT NULL,
	TransactionDate DATETIME NOT NULL DEFAULT GETDATE()
)
GO

-- Kullanýcý tablosunu oluþturuyoruz
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	UserName VARCHAR(50) NOT NULL,
	Password VARCHAR(100) NOT NULL,
	Role VARCHAR(50)
)
GO

