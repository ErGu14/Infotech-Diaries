--declare @adSoyad nvarchar(50)

--set @adSoyad = 'Eray Gülüçmen'

--select @adSoyad [ad]
go


declare @categoryName nvarchar(50)
set @categoryName = 'Beverages'
select 
	p.ProductName,
	p.UnitPrice,
	c.CategoryName
from Products p
	join Categories c on c.CategoryID = p.CategoryID
where c.CategoryName = @categoryName