--Product tablosundaki kay�tlar� getir
--select 
--	p.ProductID as [ID],
--	p.ProductName as [�r�n],
--	p.UnitPrice as [fiyat],
--	p.UnitsInStock as [stok miktar�]
	
--from Products p
go
-- Maksimum , minimum,ortalama fiyatlar� ve �r�n say�s�n� g�sterelim


--select 
--	MAX(p.UnitPrice) as [Maksikum fiyat],
--	MIN(p.UnitPrice) as [Minimum fiyat],
--	AVG(p.UnitPrice) as [Ortalama Fiyat],
--	COUNT(*) as [�r�n Say�s�]
--from Products p
go
--select 
--	sum(p.UnitPrice * p.UnitsInStock) as [Toplam Stok De�eri],
--	AVG(p.UnitPrice * p.UnitsInStock) as [Ortalama Stok De�eri]

--from Products p
go
--select 
--	p.ProductName,
--	UPPER(p.ProductName) as [B�y�k Harf],
--	LOWER(p.ProductName) as [K���k Harf]
--from Products p
go
--select 
--	c.ContactName,
--	replace(Replace(LOWER(c.ContactName),' ','_'),'�','e') as [User Name] 
--from Customers c

