/*
	C-reate  (Ürün oluþtur)
	R-ead (ürün detayý getirme, ürün listeleme)
	U-pdate (ürün üzeri deðiþiklik yapma)
	D-elete (ürün silme)

	CRUD Ýþlemleri
*/

-- INSERT
/*
insert into TabloAdý(Kolon1,Kolon2,...)
values
	(v1,v2,...),
	(v1,v2,...),
	(v1,v2,...),
	...


*/

--insert into Categories(CategoryName,Description)
--values ('Bilgisayar','Aman Amna Nereye geldik')

go

--UPDATE

/*
	UPDATE TabloAdý SET kolon1=value1, kolon2=v2,...
	where koþul 
*/
go

--update Categories set Description = 'Aman Aman Nereye Geldik'
--where CategoryID =11
go
--DELETE

/*
	DELETE FROM TabloAdý
	where koþul
*/

--delete from Categories
--where CategoryID = 11

go

select 
	*
from Categories c
where c.IsDeleted = 0
