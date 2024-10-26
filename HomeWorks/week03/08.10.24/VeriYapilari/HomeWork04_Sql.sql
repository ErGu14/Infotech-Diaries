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
--	('Tiyatro Kulübü','2018-04-14'),
--	('Müzik Kulübü','2019-05-20'),
--	('Spor Kulübü','2016-01-11'),
--	('Satranç Kulübü','2023-02-18'),
--	('Fotoðrafçýlýk Kulübü','2024-03-19')

--go

--insert into OgrenciKulup(KulupID,FirstName,LastName,Rol,KatilimTarihi)
--values
	
--	(1,'Aylin','Demir','Baþkan','2018-05-10'),
--	(1,'Berk','Arslan','Sekreter','2019-05-10'),
--	(1,'Cemre','Kaya','Üye','2018-05-10'),
--	(1,'Furkan','Yýlmaz','Üye','2018-05-30'),

--	(2,'Deniz','Yýldýz','Baþkan','2019-10-13'),
--	(2,'Elif','Çetin','Sekreter','2020-01-10'),
--	(2,'Furkan','Yýlmaz','Üye','2021-08-30'),
--	(2,'Nihal','Öztürk','Üye','2022-04-27'),

--	(3,'Gizem','Kýlýç','Baþkan','2016-03-02'),
--	(3,'Hakan','Aksu','Sekreter','2017-11-28'),
--	(3,'Ýrem','Soylu','Üye','2019-06-03'),
--	(3,'Aylin','Demir','Üye','2020-12-11'),

--	(4,'Kerem','Kerem','Baþkan','2023-03-04'),
--	(4,'Leyla','Koç','Sekreter','2024-05-16'),
--	(4,'Mert','Aydoðan','Üye','2023-02-24'),
--	(4,'Onur','Çakýr','Üye','2024-08-01'),

--	(5,'Nihal','Öztürk','Baþkan','2024-03-25'),
--	(5,'Onur','Çakýr','Sekreter','2024-04-11'), 
--	(5,'Pelin','Çelik','Üye','2024-09-29'),
--	(5,'Deniz','Yýldýz','Üye','2024-07-05')
	
--	go
go
-- Tüm kulüp üyelerinin adlarýný, soyadlarýný ve hangi kulüpte yer aldýklarýný listeleyin. (`JOIN`)
--select 
--	ok.FirstName + ' ' + ok.LastName [Öðrenci],
--	k.KulupAdi
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
go
---  "Tiyatro Kulübü" üyelerini ve rollerini listeleyin. (`WHERE` ve `JOIN`)

--select 
--	ok.FirstName + ' ' + ok.LastName [Öðrenci],
--	ok.Rol,
--    k.KulupAdi [Kulüpler]
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--where k.KulupAdi  =  'Tiyatro Kulübü'

go

--  Tüm kulüplerde baþkan olarak görev yapan öðrencileri listeleyin. (`WHERE`)

--select 
--ok.FirstName,
--ok.Rol
--from OgrenciKulup ok
--where ok.Rol = 'Baþkan'
go

 --  Her kulübün kaç üyesi olduðunu listeleyin. (`GROUP BY` ve `COUNT`)
-- select 
--	k.KulupAdi,
--	COUNT(k.KulupID)
-- from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--group by k.KulupAdi
go
--Kuruluþ yýlý en eski olan kulübün üyelerini listeleyin. (`ORDER BY` ve `JOIN`)
--select 
--	ok.FirstName + ' ' + ok.LastName [Öðrenci],
--	min (ok.KatilimTarihi) [Tarih]
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--group by ok.FirstName + ' ' + ok.LastName
--order by [Tarih] asc
go
--öðrencilerin hangi tarihte hangi kulübe katýldýklarýný listeleyin. (`SELECT` ve `JOIN`)

--select 
--	ok.FirstName + ' ' + ok.LastName [Öðrenci],
--	ok.KatilimTarihi [Tarih]
	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
go
--"Müzik Kulübü"nde bulunan tüm rollerin bir listesini çýkarýn. (`WHERE` ve `DISTINCT`)

--select distinct
--     k.KulupAdi,
--	 ok.FirstName,
--	 ok.Rol
	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--where k.KulupAdi = 'Müzik Kulübü'
go
-- Her kulüpte kaç baþkan olduðunu gruplandýrarak listeleyin. (`GROUP BY` ve `COUNT`)

--select distinct

--    k.KulupAdi,
--	count(ok.Rol)

	
--from OgrenciKulup ok
--	join Kulups k on k.KulupID = ok.KulupID
--	where ok.Rol = 'Baþkan'
--	group by k.KulupAdigo
go
--****************--
--ALTTAKÝ ÖRNEKLER ANLAÞILMADI--
--****************--
go
-- Hangi öðrenci en son hangi kulübe katýlmýþ, bu bilgiyi listeleyin. (`JOIN` ve `ORDER BY`)

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
--  Birden fazla kulüpte yer alan öðrencileri ve katýldýklarý kulüpleri listeleyin.  (`GROUP BY` ve `HAVING`)

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