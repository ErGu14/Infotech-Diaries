-- hangi b�lgede ne kadarl�k sat�� olmu�
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

-- En �ok sat��� yap�lan ilk 3 �r�n� listeleyin

--select top 3
--	p.ProductName [�r�n],
--	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Sat�� Tutar�]
--from OrderDetails od
--	join Products p on p.ProductID = od.ProductID
--group by p.ProductName
--order by [Sat�� Tutar�] desc
go
-- en son sat�lan 5 �r�n� listeleyin ve sipari� tarihide olsun

--select top 5
--	p.ProductName,
--	o.OrderDate
	
--from Products p
--	join OrderDetails od on od.ProductID = p.ProductID
--		join Orders o on o.OrderID = od.OrderID

--order by o.OrderDate desc

go
-- hangi b�lgede hangi b�lgede ne kadarl�k sat�� olmu�

--select 
--	r.RegionDescription,
--	p.ProductName [�r�n],
--	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Sat�� Tutar�]
--	from OrderDetails od
--join Orders o on od.OrderID = o.OrderID
--		join Employees e on e.EmployeeID = o.EmployeeID
--			join EmployeeTerritories et on et.EmployeeID = e.EmployeeID
--				join Territories t on t.TerritoryID = et.TerritoryID
--					join Region r on r.RegionID = t.RegionID
--						join Products p on od.ProductID = p.ProductID
--group by r.RegionDescription,p.ProductName
--order by [Sat�� Tutar�] desc
go
-- �r�nlere g�re toplam ciro
select 
	p.ProductName,
	cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) [Sat�� Tutar�]

from OrderDetails od
	join Products p on p.ProductID = od.ProductID
Group by p.ProductName
	having cast(sum(od.quantity*od.UnitPrice*(1-od.Discount)) AS decimal(10,2)) >= 70000
order by [Sat�� Tutar�] desc