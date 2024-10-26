--use master
--go

--create DATABASE OgrenciKulupsDB
--go

--use OgrenciKulupsDB

--create table Kulups(
--	KulupID int primary key identity(1,1) not null,
--	KulupAdi nvarchar(50) ,
--	KurulusYili date not null,

--)
--go

--create table OgrenciKulup(
--	OgrenciID int identity(1,1)not null,
--	FirstName nvarchar(50)not null,
--	LastName nvarchar(50) not null,
--	KulupID int  not null,
--	Rol nvarchar(50) not null,
--	KatilimTarihi date 

--	foreign key (KulupID) references Kulups(KulupID),
--)
--go

--insert into Kulups(KulupAdi,KurulusYili)
--values
--	('Tiyatro Kul�b�','2018-04-14'),
--	('M�zik Kul�b�','2019-05-20'),
--	('Spor Kul�b�','2016-01-11'),
--	('Satran� Kul�b�','2023-02-18'),
--	('Foto�raf��l�k Kul�b�','2024-03-19')

--go

--insert into OgrenciKulup(KulupID,FirstName,LastName,Rol,KatilimTarihi)
--values
	
--	(1,'Aylin','Demir','Ba�kan','2018-05-10'),
--	(1,'Berk','Arslan','Sekreter','2019-05-10'),
--	(1,'Cemre','Kaya','�ye','2018-05-10'),
--	(1,'Furkan','Y�lmaz','�ye','2018-05-30'),

--	(2,'Deniz','Y�ld�z','Ba�kan','2019-10-13'),
--	(2,'Elif','�etin','Sekreter','2020-01-10'),
--	(2,'Furkan','Y�lmaz','�ye','2021-08-30'),
--	(2,'Nihal','�zt�rk','�ye','2022-04-27'),

--	(3,'Gizem','K�l��','Ba�kan','2016-03-02'),
--	(3,'Hakan','Aksu','Sekreter','2017-11-28'),
--	(3,'�rem','Soylu','�ye','2019-06-03'),
--	(3,'Aylin','Demir','�ye','2020-12-11'),

--	(4,'Kerem','Kerem','Ba�kan','2023-03-04'),
--	(4,'Leyla','Ko�','Sekreter','2024-05-16'),
--	(4,'Mert','Aydo�an','�ye','2023-02-24'),
--	(4,'Onur','�ak�r','�ye','2024-08-01'),

--	(5,'Nihal','�zt�rk','Ba�kan','2024-03-25'),
--	(5,'Onur','�ak�r','Sekreter','2024-04-11'), 
--	(5,'Pelin','�elik','�ye','2024-09-29'),
--	(5,'Deniz','Y�ld�z','�ye','2024-07-05')
	
--	go
go
-- T�m kul�p �yelerinin adlar�n�, soyadlar�n� ve hangi kul�pte yer ald�klar�n� listeleyin. (`JOIN`)
--select 
--	ok.FirstName + ' ' + ok.LastName [��renci],
--	k.KulupAdi
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
go
---  "Tiyatro Kul�b�" �yelerini ve rollerini listeleyin. (`WHERE` ve `JOIN`)

--select 
--	ok.FirstName + ' ' + ok.LastName [��renci],
--	ok.Rol,
--    k.KulupAdi [Kul�pler]
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--where k.KulupAdi  =  'Tiyatro Kul�b�'

go

--  T�m kul�plerde ba�kan olarak g�rev yapan ��rencileri listeleyin. (`WHERE`)

--select 
--ok.FirstName,
--ok.Rol
--from OgrenciKulup ok
--where ok.Rol = 'Ba�kan'
go

 --  Her kul�b�n ka� �yesi oldu�unu listeleyin. (`GROUP BY` ve `COUNT`)
-- select 
--	k.KulupAdi,
--	COUNT(k.KulupID)
-- from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--group by k.KulupAdi
go
--Kurulu� y�l� en eski olan kul�b�n �yelerini listeleyin. (`ORDER BY` ve `JOIN`)
--select 
--	ok.FirstName + ' ' + ok.LastName [��renci],
--	min (ok.KatilimTarihi) [Tarih]
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--group by ok.FirstName + ' ' + ok.LastName
--order by [Tarih] asc
go
--��rencilerin hangi tarihte hangi kul�be kat�ld�klar�n� listeleyin. (`SELECT` ve `JOIN`)

--select 
--	ok.FirstName + ' ' + ok.LastName [��renci],
--	ok.KatilimTarihi [Tarih]
	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
go
--"M�zik Kul�b�"nde bulunan t�m rollerin bir listesini ��kar�n. (`WHERE` ve `DISTINCT`)

--select distinct
--     k.KulupAdi,
--	 ok.FirstName,
--	 ok.Rol
	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--where k.KulupAdi = 'M�zik Kul�b�'
go
-- Her kul�pte ka� ba�kan oldu�unu grupland�rarak listeleyin. (`GROUP BY` ve `COUNT`)

--select distinct

--    k.KulupAdi,
--	count(ok.Rol)

	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--	where ok.Rol = 'Ba�kan'
--	group by k.KulupAdigo
go
--****************--
--ALTTAK� �RNEKLER ANLA�ILMADI--
--****************--
go
-- Hangi ��renci en son hangi kul�be kat�lm��, bu bilgiyi listeleyin. (`JOIN` ve `ORDER BY`)

--select 
--    ok.FirstName,
--    ok.LastName,
--    k.KulupAdi,
--    ok.KatilimTarihi
--from OgrenciKulup ok
--    join Kulups k on k.KulupID = ok.KulupID
--    where ok.KatilimTarihi in (
--        select max(ok2.KatilimTarihi)
--        from OgrenciKulup ok2
--        where ok2.KulupID = ok.KulupID
--        group by ok2.KulupID
--    )
--order by ok.KulupID, ok.KatilimTarihi desc 
go
--  Birden fazla kul�pte yer alan ��rencileri ve kat�ld�klar� kul�pleri listeleyin.  (`GROUP BY` ve `HAVING`)

--select 
--    ok.FirstName,
--    ok.LastName,
--    k.KulupAdi
--from 
--    OgrenciKulup ok
--join 
--    Kulups k on ok.KulupID = k.KulupID
--where 
--    ok.FirstName in (
--        select ok2.FirstName
--        from OgrenciKulup ok2
--        group by ok2.FirstName, ok2.LastName
--        having count(distinct ok2.KulupID) > 1
--    )