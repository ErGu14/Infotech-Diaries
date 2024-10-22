-- hangi bölgede ne kadarlık satış olmuş
--select 
--	r.RegionDescription,
--	sum(od.quantity*od.UnitPrice*(1-od.Discount))
--from OrderDetails od
--	join Orders o on od.OrderID = o.OrderID
--		join Employees e on e.EmployeeID = o.EmployeeID
--			join EmployeeTerritories et on et.EmployeeID = e.EmployeeID
--				join Territories t on t.TerritoryID = et.TerritoryID
--					join Region r on r.RegionID = t.RegionID
--group by r.RegionDescription

go

-- En çok satışı yapılan ilk 3 ürünü listeleyin

--select top 3
--	p.ProductName [Ürün],
--	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Satış Tutarı]
--from OrderDetails od
--	join Products p on p.ProductID = od.ProductID
--group by p.ProductName
--order by [Satış Tutarı] desc
go
-- en son satılan 5 ürünü listeleyin ve sipariş tarihide olsun

--select top 5
--	p.ProductName,
--	o.OrderDate
	
--from Products p
--	join OrderDetails od on od.ProductID = p.ProductID
--		join Orders o on o.OrderID = od.OrderID

--order by o.OrderDate desc

go
-- hangi bölgede hangi bölgede ne kadarlık satış olmuş

--select 
--	r.RegionDescription,
--	p.ProductName [ürün],
--	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Satış Tutarı]
--	from OrderDetails od
--join Orders o on od.OrderID = o.OrderID
--		join Employees e on e.EmployeeID = o.EmployeeID
--			join EmployeeTerritories et on et.EmployeeID = e.EmployeeID
--				join Territories t on t.TerritoryID = et.TerritoryID
--					join Region r on r.RegionID = t.RegionID
--						join Products p on od.ProductID = p.ProductID
--group by r.RegionDescription,p.ProductName
--order by [Satış Tutarı] desc
go
-- ürünlere göre toplam ciro
select 
	p.ProductName,
	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Satış Tutarı]

from OrderDetails od
	join Products p on p.ProductID = od.ProductID
Group by p.ProductName
	having cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) >= 70000
order by [Satış Tutarı] desc