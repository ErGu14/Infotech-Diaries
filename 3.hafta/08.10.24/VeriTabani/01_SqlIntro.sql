USE master
go

drop database if exists OkulDb

create database OkulDb
go

use OkulDb
go

create table B�l�ms(
    Id Int Primary key Identity(1,1),
	Ad NVARCHAR(50) Not null, 
	
)
GO

insert into B�l�ms(Ad)
VALUES
	('Bilgisayar M�hendsli�i'),
	('Elektrik M�hendsli�i'),
	('Makine M�hendsli�i')

go

create table Dersler(
	Id int Primary key Identity(1,1),
	Ad NVARCHAR(50) Not null,
	kredi tinyint not null,
	BolumId int not null,
	foreign key(BolumId) references B�l�ms(Id)
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

	('Makine M�hendisli�ine Giri�',4,3),
	('Termodinamik',6,3),
	('Ak��kanlar Mekani�i',8,3),
	('Malzeme Bilimi',4,3),
	('Mesleki �ngilizce',4,3)
	go

	create table Ogrenciler(
		Id int primary key identity(1,1),
		Ad nvarchar(50) not null,
		Soyad nvarchar(50),
		DogumTarihi date,
		BolumId int,
		foreign key(BolumId) references B�l�ms(Id)
	)
	go

	insert into Ogrenciler(BolumId,Ad,Soyad)
	values
		(1,'Ali' ,'Cabbar'),
		(1,'Sezen' ,'Kara'),
		(1,'Ali' ,'Cabbar'),

		(2,'Cavit' ,'Tutan'),
		(2,'Kemal' ,'Kanatan'),
		(2,'Ceyda' ,'D�men'),
		(2,'Ay�en' ,'Gruda'),

		(3,'Eray' ,'Bey')

		go

-- Sinem Ko�ak Ad�nda 3 numaral� b�l�mde okuyan 19.07.1999 do�umlu ��renci ekleme
insert into Ogrenciler(BolumId,Ad,Soyad,DogumTarihi)
values
		(3,'sinem','Ko�ak','1999-07-19')

		go

create table OgrenciDersler(
	OgrenciId int not null,
	DersId int not null,
	primary key(OgrenciId,DersId),
	foreign key(OgrenciId) references Ogrenciler(Id),
	foreign key(DersId) references Dersler(Id)


	
)
go

-- Bilgisayar b�l�m�ne ��rencilerine ders at�yoruz
-- ��renciler: 1-2-3
--Dersler: 1-2-3

insert into OgrenciDersler(OgrenciId,DersId)
VALUES
	(1,1),(1,3),
	(2,1),(2,2),(2,3),
	(3,1)

	go

--Elektrik b�l�m� ��rencilerine ders at�yoruz
-- ��renciler: 4-5-6-7
--dersler: 4-5-6-7

insert into OgrenciDersler(OgrenciId,DersId)
values
	(4,4),(4,7),
	(5,5),(5,6),(5,7),
	(6,5),(6,6),(6,7),(6,8),
	(7,6),(7,7)

	go

	-- Makine B�l�m� ��rencilerine ders at�yoruz
	--��renciler: 8-9
	--dersler :8-9-10-11-12

insert into OgrenciDersler(OgrenciId,DersId)
values
	(8,8),(8,9),(8,10),(8,11),
	(9,10),(9,12)

	go



use master
go










	



