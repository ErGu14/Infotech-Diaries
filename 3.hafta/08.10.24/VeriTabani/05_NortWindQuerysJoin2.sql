-- JOIN : sql de virden fazla tabloyu birle�tirebilmek i�in kulland���m�z yap�ya join diyoruz . JOIN, ilgili tablolar�n ilgili alanlar� �zerinden ili�ki kurarak ger�ekle�ir.

-- Join t�rleri :
-- 1) (Inner) Join: her iki tablodaki E�LE�EN DE�ERLERE SAH�P KAYITLARI d�nd�r�r.
--2) left join :
--3) right join :sa� taraftaki t�m kay�tlar�, sol taraf�ndaki ise e�le�en kay�tlar� d�nd�r�r
--4) outher (full) join : her taraftaki t�m kay�tlar� getir
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


-- Hangi Sipari� hangi �al��an Taraf�ndan Hangi M��teri i�in verilmi�ti.
--Sipari�Id      Sipari�Tarihi      �al��an        M��teri
--10240           2000-5-19         Eray Bey        Engin Niyazi

--select 
--	o.OrderId as [Sipari� ID],
--	o.OrderDate as [Sipari� Tarihi],
--	e.FirstName + ' ' + e.LastName as [Personel Ad�],
--	c.CompanyName as [M��teri]
--from Orders o
--	join Employees e on o.EmployeeID= e.EmployeeID
--		join Customers c on o.CustomerID = c.CustomerID
go

-- Bug�ne kadar hangi �lkelere kargo g�nderdik?

--select 
--	distinct o.ShipCountry
--from Orders o

go

-- Bug�ne kadar hangi �lkelere ka� kez kargo g�nderimi yapt�k?

--select 
--	o.ShipCountry as [�lke],
--	COUNT(*) as [Kargo G�nderim Say�s�],
--	SUM(o.Freight) as [Kargo Masraf�]
--from Orders o
--group by o.ShipCountry
----order by o.ShipCountry desc-- �zel durum olmad�k�a A-Z ye  say�larda ise B�y�kten k����e s�ralar  ama e�er DESC yazarsam durumlar tam tersine �evirir
--order by [Kargo G�nderim Say�s�] desc, [Kargo Masraf�] desc 
go

--Kategorilere g�re toplam stok miktar�n� g�sterelim

--select 
--	c.CategoryName as [Kategori],
--	sum(p.UnitsInStock) as [Toplam Stok Miktar�]
--from Categories c
--	join Products p on c.CategoryID = p.CategoryID
--group by c.CategoryName
go
-- Bug�ne kadar ne kadarl�k sat�� yapm���z? ciro (IMMOB�LEEEEE)

--select 
--	sum(od.Quantity * od.UnitPrice*(1-od.Discount)) as [Ciro]
--from OrderDetails od
go
-- �DEV: Sonucu ondal�kl� k�sm� 2 basamak g�sterecek �ekilde nas�l bir sorgu yapar�z?

--select 
--	p.pRO
--	sum(od.Quantity * od.UnitPrice*(1-od.Discount)) as [Ciro]
--from OrderDetails od
--	join Products p on od.ProductID = p.ProductID
--group by Prodcut

--********--

