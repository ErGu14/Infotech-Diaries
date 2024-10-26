--1. T�m �r�nlerin adlar�n� ve birim fiyatlar�n� listeleyin.
--select 
--	p.ProductName as [�r�n],
--	p.UnitPrice as [Fiyat]
--from Products p
go

--2. M��terilerin �irket adlar�n� ve bulunduklar� �ehirleri alfabetik s�rayla listeleyin.

--select 
--	c.CompanyName [�irket Ad�],
--	c.Country [�lke]
	
--from Customers c
--order by c.Country asc
go

--3. �al��anlar�n ad ve soyadlar�n� birle�tirerek tam isimlerini listeleyin.

--select 
--	e.FirstName + ' ' + e.LastName [�al��an]
--from Employees e
go

--4. Stok miktar� 10'dan az olan �r�nleri listeleyin.

--select 
--	*
--from Products p
--where p.UnitsInStock < 10
go

--5. 1998 y�l�nda yap�lan sipari�leri listeleyin.

--select 
--	*

--from Orders o
--where year(o.OrderDate) = 1998
go

--6. Her bir kategorideki �r�n say�s�n� bulun.

--select 
--    c.CategoryID as [ID],
--	c.CategoryName as [Kategori],
--	sum(p.UnitsInStock) [�r�n miktar�]
	

--from Categories c
--	join Products p on p.CategoryID = c.CategoryID
--group by c.CategoryID,c.CategoryName
go
--7. En pahal� 5 �r�n� fiyatlar�yla birlikte listeleyin.

--select top 5 -- s�ralama
--	p.ProductName [�r�n],
--	p.UnitPrice [fiyat]
	
--from Products p
--order by p.UnitPrice desc
go
--8. Her bir �lkedeki m��teri say�s�n� bulun ve m��teri say�s�na g�re azalan s�rayla listeleyin.

--select
--	c.Country,
--	count(*) as [M��teri say�s�]
--from Customers c
--group by c.Country
--order by [M��teri say�s�] asc
go

--9. Nakliye �creti 50'den fazla olan sipari�leri listeleyin.

--select 
--	o.Freight
--from Orders o
--where o.Freight >= 50
--order by o.Freight desc
go

--10. Her bir �al��an�n toplam sipari� say�s�n� bulun.

--select
--	e.EmployeeID,
--	COUNT(*) [haz�rlanan sipari�ler],
--	e.FirstName + ' '+ e.LastName [Sipari�i Haz�rlayan]
--from Orders o
--	join Employees e on e.EmployeeID = o.EmployeeID
--group by e.EmployeeID, e.FirstName + ' '+ e.LastName
--order by [haz�rlanan sipari�ler] desc

go

--11. �r�nleri kategorileriyle birlikte listeleyin.

--select 
--	c.CategoryName [Kategori],
--	p.ProductName [�r�n]
--from Categories c join Products p on c.CategoryID = p.CategoryID
--order by c.CategoryName, p.ProductName
go

--12. Her bir sipari�in toplam tutar�n� hesaplay�n.

--select
--	od.OrderID,
--	sum(od.UnitPrice) [Sipari� Toplam Fiyat]
--from OrderDetails od
--group by od.OrderID

go

--13. En �ok sat�lan 5 �r�n� ve sat�� miktarlar�n� listeleyin.

--select top 5
--	p.ProductName,
--	sum(od.Quantity) [toplam]
	
--from OrderDetails od
--	join Products p on p.ProductID = od.ProductID
--group by p.ProductName
--order by [toplam] desc
go
--14. Her bir m��terinin verdi�i sipari� say�s�n� bulun.

--select 
--	distinct cus.ContactName [Al�c�],
--	count(o.OrderID) [Toplam Sipari�]

--from Orders o
--	join Customers cus on cus.CustomerID = o.CustomerID
--group by cus.ContactName
--order by [Toplam Sipari�] desc

go

--15. Hangi kargo �irketinin ka� sipari� ta��d���n� listeleyin.

--select 
--	s.ShipperID,
--	s.CompanyName,
--	count(o.ShipVia) [Kargo Miktar�]
	

--from Orders o
--	join Shippers s on o.ShipVia = s.ShipperID
--group by s.CompanyName, s.ShipperID
--order by [Kargo Miktar�] desc
go

--16. Her bir �al��an�n toplam sat�� tutar�n� hesaplay�n.

--select 
--	e.EmployeeID,
--	e.FirstName + ' ' + e.LastName [�al��an],
--	sum(od.UnitPrice) [Toplam Sat�� Fiyat�]
	

--from Orders o
--	join Employees e on e.EmployeeID = o.EmployeeID
--		join OrderDetails od on od.OrderID = o.OrderID
--group by e.EmployeeID , e.FirstName + ' ' + e.LastName
--order by [Toplam Sat�� Fiyat�] desc

go

--17. Her bir kategorideki �r�nlerin ortalama fiyat�n� bulun.

--select 
--	c.CategoryName  [Kategori],
--	avg(p.UnitPrice)

--from Categories c
--	join Products p on p.CategoryID = c.CategoryID
--group by c.CategoryName
--order by c.CategoryName 
go

--18. En az 5 sipari� veren m��terileri ve sipari� say�lar�n� listeleyin.

--select top 5
--	c.ContactName,
--	count(od.OrderID) [Sipari� Say�s�]


--from Orders o
--	join Customers c on c.CustomerID = o.CustomerID
--		join OrderDetails od on o.OrderID = od.OrderID
--group by c.ContactName
--order by [Sipari� Say�s�] asc
go

--19. Her bir �lke i�in toplam sat�� tutar�n� hesaplay�n.

--select 
--	c.Country [�lke],
--	sum(od.UnitPrice*od.Quantity*(1-od.Discount))

--from Orders o
--	join OrderDetails od on o.OrderID = od.OrderID
--		join Customers c on o.CustomerID = c.CustomerID
--group by c.Country
--order by c.Country
go
--20. Sipari�leri, sipari� tarihine g�re y�llar ve aylar baz�nda gruplayarak toplam sat�� tutarlar�n� listeleyin. 

--select 
--	YEAR(o.OrderDate) [Y�l],
--	month(o.OrderDate) [Ay],
--	sum(od.Quantity*od.UnitPrice*(1-od.Discount)) [Toplam Sat��]


--from Orders o
--	join OrderDetails od on o.OrderID = od.OrderID
--group by YEAR(o.OrderDate),
--	month(o.OrderDate) 
--order by [Y�l],[Ay]
go














