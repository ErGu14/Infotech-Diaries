--1. Tüm ürünlerin adlarýný ve birim fiyatlarýný listeleyin.
--select 
--	p.ProductName as [Ürün],
--	p.UnitPrice as [Fiyat]
--from Products p
go

--2. Müþterilerin þirket adlarýný ve bulunduklarý þehirleri alfabetik sýrayla listeleyin.

--select 
--	c.CompanyName [Þirket Adý],
--	c.Country [Ülke]
	
--from Customers c
--order by c.Country asc
go

--3. Çalýþanlarýn ad ve soyadlarýný birleþtirerek tam isimlerini listeleyin.

--select 
--	e.FirstName + ' ' + e.LastName [Çalýþan]
--from Employees e
go

--4. Stok miktarý 10'dan az olan ürünleri listeleyin.

--select 
--	*
--from Products p
--where p.UnitsInStock < 10
go

--5. 1998 yýlýnda yapýlan sipariþleri listeleyin.

--select 
--	*

--from Orders o
--where year(o.OrderDate) = 1998
go

--6. Her bir kategorideki ürün sayýsýný bulun.

--select 
--    c.CategoryID as [ID],
--	c.CategoryName as [Kategori],
--	sum(p.UnitsInStock) [ürün miktarý]
	

--from Categories c
--	join Products p on p.CategoryID = c.CategoryID
--group by c.CategoryID,c.CategoryName
go
--7. En pahalý 5 ürünü fiyatlarýyla birlikte listeleyin.

--select top 5 -- sýralama
--	p.ProductName [Ürün],
--	p.UnitPrice [fiyat]
	
--from Products p
--order by p.UnitPrice desc
go
--8. Her bir ülkedeki müþteri sayýsýný bulun ve müþteri sayýsýna göre azalan sýrayla listeleyin.

--select
--	c.Country,
--	count(*) as [Müþteri sayýsý]
--from Customers c
--group by c.Country
--order by [Müþteri sayýsý] asc
go

--9. Nakliye ücreti 50'den fazla olan sipariþleri listeleyin.

--select 
--	o.Freight
--from Orders o
--where o.Freight >= 50
--order by o.Freight desc
go

--10. Her bir çalýþanýn toplam sipariþ sayýsýný bulun.

--select
--	e.EmployeeID,
--	COUNT(*) [hazýrlanan sipariþler],
--	e.FirstName + ' '+ e.LastName [Sipariþi Hazýrlayan]
--from Orders o
--	join Employees e on e.EmployeeID = o.EmployeeID
--group by e.EmployeeID, e.FirstName + ' '+ e.LastName
--order by [hazýrlanan sipariþler] desc

go

--11. Ürünleri kategorileriyle birlikte listeleyin.

--select 
--	c.CategoryName [Kategori],
--	p.ProductName [Ürün]
--from Categories c join Products p on c.CategoryID = p.CategoryID
--order by c.CategoryName, p.ProductName
go

--12. Her bir sipariþin toplam tutarýný hesaplayýn.

--select
--	od.OrderID,
--	sum(od.UnitPrice) [Sipariþ Toplam Fiyat]
--from OrderDetails od
--group by od.OrderID

go

--13. En çok satýlan 5 ürünü ve satýþ miktarlarýný listeleyin.

--select top 5
--	p.ProductName,
--	sum(od.Quantity) [toplam]
	
--from OrderDetails od
--	join Products p on p.ProductID = od.ProductID
--group by p.ProductName
--order by [toplam] desc
go
--14. Her bir müþterinin verdiði sipariþ sayýsýný bulun.

--select 
--	distinct cus.ContactName [Alýcý],
--	count(o.OrderID) [Toplam Sipariþ]

--from Orders o
--	join Customers cus on cus.CustomerID = o.CustomerID
--group by cus.ContactName
--order by [Toplam Sipariþ] desc

go

--15. Hangi kargo þirketinin kaç sipariþ taþýdýðýný listeleyin.

--select 
--	s.ShipperID,
--	s.CompanyName,
--	count(o.ShipVia) [Kargo Miktarý]
	

--from Orders o
--	join Shippers s on o.ShipVia = s.ShipperID
--group by s.CompanyName, s.ShipperID
--order by [Kargo Miktarý] desc
go

--16. Her bir çalýþanýn toplam satýþ tutarýný hesaplayýn.

--select 
--	e.EmployeeID,
--	e.FirstName + ' ' + e.LastName [Çalýþan],
--	sum(od.UnitPrice) [Toplam Satýþ Fiyatý]
	

--from Orders o
--	join Employees e on e.EmployeeID = o.EmployeeID
--		join OrderDetails od on od.OrderID = o.OrderID
--group by e.EmployeeID , e.FirstName + ' ' + e.LastName
--order by [Toplam Satýþ Fiyatý] desc

go

--17. Her bir kategorideki ürünlerin ortalama fiyatýný bulun.

--select 
--	c.CategoryName  [Kategori],
--	avg(p.UnitPrice)

--from Categories c
--	join Products p on p.CategoryID = c.CategoryID
--group by c.CategoryName
--order by c.CategoryName 
go

--18. En az 5 sipariþ veren müþterileri ve sipariþ sayýlarýný listeleyin.

--select top 5
--	c.ContactName,
--	count(od.OrderID) [Sipariþ Sayýsý]


--from Orders o
--	join Customers c on c.CustomerID = o.CustomerID
--		join OrderDetails od on o.OrderID = od.OrderID
--group by c.ContactName
--order by [Sipariþ Sayýsý] asc
go

--19. Her bir ülke için toplam satýþ tutarýný hesaplayýn.

--select 
--	c.Country [Ülke],
--	sum(od.UnitPrice*od.Quantity*(1-od.Discount))

--from Orders o
--	join OrderDetails od on o.OrderID = od.OrderID
--		join Customers c on o.CustomerID = c.CustomerID
--group by c.Country
--order by c.Country
go
--20. Sipariþleri, sipariþ tarihine göre yýllar ve aylar bazýnda gruplayarak toplam satýþ tutarlarýný listeleyin. 

--select 
--	YEAR(o.OrderDate) [Yýl],
--	month(o.OrderDate) [Ay],
--	sum(od.Quantity*od.UnitPrice*(1-od.Discount)) [Toplam Satýþ]


--from Orders o
--	join OrderDetails od on o.OrderID = od.OrderID
--group by YEAR(o.OrderDate),
--	month(o.OrderDate) 
--order by [Yýl],[Ay]
go














