--Product tablosundaki kayýtlarý getir
--select 
--	p.ProductID as [ID],
--	p.ProductName as [ürün],
--	p.UnitPrice as [fiyat],
--	p.UnitsInStock as [stok miktarý]
	
--from Products p
go
-- Maksimum , minimum,ortalama fiyatlarý ve ürün sayýsýný gösterelim


--select 
--	MAX(p.UnitPrice) as [Maksikum fiyat],
--	MIN(p.UnitPrice) as [Minimum fiyat],
--	AVG(p.UnitPrice) as [Ortalama Fiyat],
--	COUNT(*) as [Ürün Sayýsý]
--from Products p
go
--select 
--	sum(p.UnitPrice * p.UnitsInStock) as [Toplam Stok Deðeri],
--	AVG(p.UnitPrice * p.UnitsInStock) as [Ortalama Stok Deðeri]

--from Products p
go
--select 
--	p.ProductName,
--	UPPER(p.ProductName) as [Büyük Harf],
--	LOWER(p.ProductName) as [Küçük Harf]
--from Products p
go
--select 
--	c.ContactName,
--	replace(Replace(LOWER(c.ContactName),' ','_'),'é','e') as [User Name] 
--from Customers c

