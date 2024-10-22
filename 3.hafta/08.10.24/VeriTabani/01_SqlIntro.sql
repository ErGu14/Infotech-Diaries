USE master
go

drop database if exists OkulDb

create database OkulDb
go

use OkulDb
go

create table Bölüms(
    Id Int Primary key Identity(1,1),
	Ad NVARCHAR(50) Not null, 
	
)
GO

insert into Bölüms(Ad)
VALUES
	('Bilgisayar Mühendsliði'),
	('Elektrik Mühendsliði'),
	('Makine Mühendsliði')

go

create table Dersler(
	Id int Primary key Identity(1,1),
	Ad NVARCHAR(50) Not null,
	kredi tinyint not null,
	BolumId int not null,
	foreign key(BolumId) references Bölüms(Id)
)
go

insert into dersler(Ad,kredi,BolumId)
values
	('Matematik',6,1),
	('Algoritma',4,1),
	('Programlama Dilleri',3,1),

	('Devre Teorisi',8,2),
	('Elektronik Devreleri',6,2),
	('Otomatik Kumanda',3,2),
	('Temel Elektronik',4,2),

	('Makine Mühendisliðine Giriþ',4,3),
	('Termodinamik',6,3),
	('Akýþkanlar Mekaniði',8,3),
	('Malzeme Bilimi',4,3),
	('Mesleki Ýngilizce',4,3)
	go

	create table Ogrenciler(
		Id int primary key identity(1,1),
		Ad nvarchar(50) not null,
		Soyad nvarchar(50),
		DogumTarihi date,
		BolumId int,
		foreign key(BolumId) references Bölüms(Id)
	)
	go

	insert into Ogrenciler(BolumId,Ad,Soyad)
	values
		(1,'Ali' ,'Cabbar'),
		(1,'Sezen' ,'Kara'),
		(1,'Ali' ,'Cabbar'),

		(2,'Cavit' ,'Tutan'),
		(2,'Kemal' ,'Kanatan'),
		(2,'Ceyda' ,'Dümen'),
		(2,'Ayþen' ,'Gruda'),

		(3,'Eray' ,'Bey')

		go

-- Sinem Koçak Adýnda 3 numaralý bölümde okuyan 19.07.1999 doðumlu öðrenci ekleme
insert into Ogrenciler(BolumId,Ad,Soyad,DogumTarihi)
values
		(3,'sinem','Koçak','1999-07-19')

		go

create table OgrenciDersler(
	OgrenciId int not null,
	DersId int not null,
	primary key(OgrenciId,DersId),
	foreign key(OgrenciId) references Ogrenciler(Id),
	foreign key(DersId) references Dersler(Id)


	
)
go

-- Bilgisayar bölümüne öðrencilerine ders atýyoruz
-- öðrenciler: 1-2-3
--Dersler: 1-2-3

insert into OgrenciDersler(OgrenciId,DersId)
VALUES
	(1,1),(1,3),
	(2,1),(2,2),(2,3),
	(3,1)

	go

--Elektrik bölümü öðrencilerine ders atýyoruz
-- Öðrenciler: 4-5-6-7
--dersler: 4-5-6-7

insert into OgrenciDersler(OgrenciId,DersId)
values
	(4,4),(4,7),
	(5,5),(5,6),(5,7),
	(6,5),(6,6),(6,7),(6,8),
	(7,6),(7,7)

	go

	-- Makine Bölümü öðrencilerine ders atýyoruz
	--öðrenciler: 8-9
	--dersler :8-9-10-11-12

insert into OgrenciDersler(OgrenciId,DersId)
values
	(8,8),(8,9),(8,10),(8,11),
	(9,10),(9,12)

	go



use master
go










	



