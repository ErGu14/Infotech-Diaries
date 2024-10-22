/*
	C-reate  (�r�n olu�tur)
	R-ead (�r�n detay� getirme, �r�n listeleme)
	U-pdate (�r�n �zeri de�i�iklik yapma)
	D-elete (�r�n silme)

	CRUD ��lemleri
*/

-- INSERT
/*
insert into TabloAd�(Kolon1,Kolon2,...)
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
	UPDATE TabloAd� SET kolon1=value1, kolon2=v2,...
	where ko�ul 
*/
go

--update Categories set Description = 'Aman Aman Nereye Geldik'
--where CategoryID =11
go
--DELETE

/*
	DELETE FROM TabloAd�
	where ko�ul
*/

--delete from Categories
--where CategoryID = 11

go

select 
	*
from Categories c
where c.IsDeleted = 0
