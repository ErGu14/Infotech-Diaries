--create function GetFullName(@employeeId int)
--returns nvarchar(100) as
--	begin 
--		declare @Fullname nvarchar(100)
--				select @Fullname =
--				e.TitleOfCourtesy + ' ' + e.FirstName + ' '+e.LastName
--				from Employees e
--				where e.EmployeeID = @employeeId
--		return @fullname
					
--			End
go

--select
--	dbo.GetFullName(e.EmployeeID) [�al��an],
--	e.City [�ehir]
--from Employees e
