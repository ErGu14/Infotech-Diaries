-- JOIN : sql de virden fazla tabloyu birleþtirebilmek için kullandýðýmýz yapýya join diyoruz . JOIN, ilgili tablolarýn ilgili alanlarý üzerinden iliþki kurarak gerçekleþir.

-- Join türleri :
-- 1) (Inner) Join: her iki tablodaki EÞLEÞEN DEÐERLERE SAHÝP KAYITLARI döndürür.
--2) left join :
--3) right join :sað taraftaki tüm kayýtlarý, sol tarafýndaki ise eþleþen kayýtlarý döndürür
--4) outher (full) join : her taraftaki tüm kayýtlarý getir
go

--select *
--from Categories c join Products p on c.CategoryID = p.CategoryID
go
--select *
--from Categories c right join Products p on c.CategoryID = p.CategoryID
go
--select *
--from Categories c full join Products p on c.CategoryID = p.CategoryID
go


-- Hangi Sipariþ hangi Çalýþan Tarafýndan Hangi Müþteri için verilmiþti.
--SipariþId      SipariþTarihi      Çalýþan        Müþteri
--10240           2000-5-19         Eray Bey        Engin Niyazi

--select 
--	o.OrderId as [Sipariþ ID],
--	o.OrderDate as [Sipariþ Tarihi],
--	e.FirstName + ' ' + e.LastName as [Personel Adý],
--	c.CompanyName as [Müþteri]
--from Orders o
--	join Employees e on o.EmployeeID= e.EmployeeID
--		join Customers c on o.CustomerID = c.CustomerID
go

-- Bugüne kadar hangi ülkelere kargo gönderdik?

--select 
--	distinct o.ShipCountry
--from Orders o

go

-- Bugüne kadar hangi ülkelere kaç kez kargo gönderimi yaptýk?

--select 
--	o.ShipCountry as [Ülke],
--	COUNT(*) as [Kargo Gönderim Sayýsý],
--	SUM(o.Freight) as [Kargo Masrafý]
--from Orders o
--group by o.ShipCountry
----order by o.ShipCountry desc-- özel durum olmadýkça A-Z ye  sayýlarda ise Büyükten küçüðe sýralar  ama eðer DESC yazarsam durumlar tam tersine çevirir
--order by [Kargo Gönderim Sayýsý] desc, [Kargo Masrafý] desc 
go

--Kategorilere göre toplam stok miktarýný gösterelim

--select 
--	c.CategoryName as [Kategori],
--	sum(p.UnitsInStock) as [Toplam Stok Miktarý]
--from Categories c
--	join Products p on c.CategoryID = p.CategoryID
--group by c.CategoryName
go
-- Bugüne kadar ne kadarlýk satýþ yapmýþýz? ciro (IMMOBÝLEEEEE)

--select 
--	sum(od.Quantity * od.UnitPrice*(1-od.Discount)) as [Ciro]
--from OrderDetails od
go
-- ÖDEV: Sonucu ondalýklý kýsmý 2 basamak gösterecek þekilde nasýl bir sorgu yaparýz?

--select 
--	p.pRO
--	sum(od.Quantity * od.UnitPrice*(1-od.Discount)) as [Ciro]
--from OrderDetails od
--	join Products p on od.ProductID = p.ProductID
--group by Prodcut

--********--

