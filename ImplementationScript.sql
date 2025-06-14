
CREATE DATABASE StoreDb;
GO

USE StoreDb;
GO


CREATE TABLE ProductType (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);


CREATE TABLE ProductStatus (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL 
);


CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(300),
    Price DECIMAL(18, 2) NOT NULL,
	QuantityStock INT NOT NULL,
    ProductTypeId INT NOT NULL,
    ProductStatusId INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id),
    FOREIGN KEY (ProductStatusId) REFERENCES ProductStatus(Id)
);


CREATE TABLE Invoice (
    Id INT PRIMARY KEY IDENTITY(1,1),
	clientFullName VARCHAR(200),
	clientDirection VARCHAR(300),
	clientDocumentNumber VARCHAR(100),
    InvoiceNumber NVARCHAR(50) NOT NULL,
    IssueDate DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(18,2) NOT NULL
);


CREATE TABLE InvoiceProduct (
    Id INT PRIMARY KEY IDENTITY(1,1),
    InvoiceId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,

    FOREIGN KEY (InvoiceId) REFERENCES Invoice(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);


INSERT INTO ProductStatus (Name) VALUES ('Activo'), ('Inactivo');


INSERT INTO ProductType (Name) VALUES ('Electronicos'), ('Ropa'), ('Comida'), ('Miselanea');

go
CREATE TRIGGER TRG_UpdateProductStock
ON InvoiceProduct
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE p
    SET p.QuantityStock = p.QuantityStock - i.Quantity
    FROM Product p
    INNER JOIN inserted i ON p.Id = i.ProductId;
END;
