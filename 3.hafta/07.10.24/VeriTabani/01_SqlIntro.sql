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



	



