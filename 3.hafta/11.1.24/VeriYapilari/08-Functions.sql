--select GETDATE()
--select YEAR(getdate())
--select month(getdate())
--select day(getdate())
go
  
--select 
--	e. FirstName + ' ' + e.LastName [Çalýþan],
--	e.BirthDate [Doðum Tarihi]
--from Employees e
--where month('2024-1-8') = month(e.BirthDate)
go
--select 
--	e. FirstName + ' ' + e.LastName [Çalýþan],
--	e.HireDate [Ýþe Baþlama Tarihi]
--from Employees e
----where day(e.HireDate) <= 10
--where day(e.HireDate) between 3 and 10
go

--select 
--	o.OrderDate,
--	dateadd(day,5,o.OrderDate) [Planlanan En geç Kargo Tarihi],
--	o.ShippedDate [Gerçekleþen Kargo Tarihi],
--	DATEDIFF(day,dateadd(day,5,o.OrderDate),o.ShippedDate) as [Geciken Gün]
--	--cast(o.ShippedDate-dateadd(day,5,o.OrderDate)as int) as [Geciken Gün]
--from Orders o
--where dateadd(day,5,o.OrderDate) < o.ShippedDate
--order by [Geciken Gün] desc
go
--select abs(-87)
--select CEILING(4.01)
--select FLOOR(4.99)
--select round(4.5,0)
--select cast(round(4.5,0) as int)
--select cast(round(4.7386,2) as decimal(10,2))
--select power(3,2)

--select len('Infotech')
--select upper('infotech')
--select lower('INFOTECH')
--select SUBSTRING('Infotech',1,4)
--select REPLACE('besiktas bugün ilk macina cikiyor',' ','-')
