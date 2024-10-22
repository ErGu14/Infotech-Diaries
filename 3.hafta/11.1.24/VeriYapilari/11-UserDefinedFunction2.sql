--create function GetTotal(@price MONEY, @quantity SMALLINT, @discount real)
--returns decimal(10,2) as
--begin
--	declare @total decimal(10,2) = cast(@price * @quantity*(1-@discount) as decimal(10,2))
--	return @total
	
--end
select 
	sum(dbo.GetTotal(od.UnitPrice,od.quantity,od.discount))
from OrderDetails od