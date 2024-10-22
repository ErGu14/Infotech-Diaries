-- Yeni Ürün Ekleme

CREATE PROCEDURE AddNewProduct
	@Name NVARCHAR(100),
	@CategoryId INT,
	@SupplierId INT,
	@QuantityPerUnit VARCHAR(50),
	@UnitPrice DECIMAL(18,2),
	@UnitsInStock INT,
	@Discounted BIT,
	@ReorderLevel INT
AS
BEGIN
	INSERT INTO Products(Name,CategoryId,SupplierId,QuantityPerUnit,UnitPrice,UnitsInStock,ReorderLevel,Discounted)
	VALUES
	(@Name,@CategoryId,@SupplierId,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@ReorderLevel,@Discounted)
END
GO