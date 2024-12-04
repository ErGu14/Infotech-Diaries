--veri taban� yaratma operasyonu ba�l�yor
use master
go

if DB_ID('PortfolioDb') is not null
begin
	alter database PortfolioDb set single_user with rollback immediate --database ile g�ncelleme  yapma     bu db yi tek kullan�c� halne getir
	drop database PortfolioDb
end
go

create database PortfolioDb collate Turkish_CI_As  -- t�rk�e karakterlerin desteklenece�i �ekilde db olu�tur
go

Use PortfolioDb
go
-- veri taban� yaratma operasyonu sona erdi
go
-- Uygulaman�n genel ayarlar� i�in settings tablosu olu�turuluyor

create table Settings(
	Id int default 1,

	SiteName nvarchar(MAX) not null,
	FooterText nvarchar(MAX) not null,


	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go



--Contacts Tablosu olu�utuluyor

create table Contacts(
	Id int default 1,
	Adress nvarchar(max)not null,
	PhoneNumber nvarchar(max) not null,
	Email nvarchar(max)not null,
	GoogleMap nvarchar(max)not null,
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go

go


--abouts talosu olu�turuluyor
create table Abouts(
	Id int default 1,
	AboutTitle nvarchar(max) not null,
	AboutText nvarchar(max) not null,
	AboutCvUrl nvarchar(max) not null,
	AboutImageUrl nvarchar(max) not null,
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go




go
--homeBanners tablosu olu�turuluyor
create table HomeBanners(
	Id int default 1,
	HomeBannerTitle nvarchar(max)not null,
	HomeBannerSubtitle nvarchar(max)not null,
	HomeBannerText nvarchar(max)not null,
	HomeBannerImageUrl nvarchar(max)not null,
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go

go

create table ServiceInfos(
	Id int default 1,

	ServiceTitle nvarchar(MAX) not null,
	ServiceText nvarchar(MAX) not null,

	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go
b


create table Services(
	Id int primary key identity,

	Icon nvarchar(max) not null default '~/ui/img/services/s1.png',
	Title nvarchar(max) not null,
	SubTitle nvarchar(max) not null,
	Description nvarchar(max) not null,

	
	IsDeleted bit not null default  0, -- varsay�lan olarak silinmemi� yap�yoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)



)
go



create table Categories(
	Id int primary key identity,

	
	Name nvarchar(max)not null,
	Description nvarchar(max) null default 'Kategori A��klamas�',

	
	IsDeleted bit not null default  0, -- varsay�lan olarak silinmemi� yap�yoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)

)
go



create table Projects(
	Id int primary key identity,

	
	Title nvarchar(max)not null,
	SubTitle nvarchar(max) not null,
	Description nvarchar(max) null default 'Proje A��klamas�',
	ImageUrl nvarchar(max) not null,
	Team nvarchar(max) not null,
	Url nvarchar(max),
	GitHubUrl nvarchar(max),
	ZipFileUrl nvarchar(max),
	CatgorieId int not null foreign key references Categories(Id),

	



	
	IsDeleted bit not null default  0, -- varsay�lan olarak silinmemi� yap�yoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)

)
go

Create table Messages(
	Id int primary key identity,

	Name nvarchar(max)not null,
	Email nvarchar(max)not null,
	Subject nvarchar(max)not null,
	Content nvarchar(max)not null,


	IsDeleted bit not null default 0,
	IsRead bit not null default 0,
	SendingDate datetime2(3) default getdate(),
	ReadingDate datetime2(3)

)
go

create table SocialsMediaAccount(
	Id int primary key identity,

	
	Title nvarchar(max)not null,
	AccountUrl nvarchar(max)not null,
	Icon nvarchar(max)not null default 'fa-facebook',
	

	
	IsDeleted bit not null default  0, -- varsay�lan olarak silinmemi� yap�yoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)

)
go

-- Categories tablosuna 4 yeni kategori ekleme
INSERT INTO Categories (Name, Description, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Web Geli�tirme', 'Web uygulamalar� ve sitelerinin geli�tirilmesi i�in kullan�lan teknolojiler ve ara�lar.', 0, GETDATE(), GETDATE()),
('Mobil Uygulama Geli�tirme', 'Mobil cihazlar i�in uygulama geli�tirme teknolojileri ve ara�lar�.', 0, GETDATE(), GETDATE()),
('Bulut Bili�im', 'Veri depolama, y�netim ve analiz i�in bulut tabanl� ��z�mler ve teknolojiler.', 0, GETDATE(), GETDATE()),
('Yapay Zeka ve Makine ��renimi', 'AI ve ML teknikleri, ara�lar� ve uygulamalar� ile ilgili bilgiler.', 0, GETDATE(), GETDATE());
go
-- Messages tablosuna 25 �rnek mesaj ekleme
INSERT INTO Messages (Name, Email, Subject, Content, IsDeleted, IsRead, SendingDate, ReadingDate)
VALUES 
('Ali Veli', 'ali.veli@example.com', 'Merhaba', 'Bu bir test mesaj�d�r.', 0, 0, GETDATE(), GETDATE()),
('Ay�e Y�lmaz', 'ayse.yilmaz@example.com', 'Proje Hakk�nda', 'Proje ile ilgili baz� sorular�m var.', 0, 0, GETDATE(), GETDATE()),
('Mehmet Demir', 'mehmet.demir@example.com', 'Teklif Talebi', 'Yeni proje i�in teklif talep ediyorum.', 0, 0, GETDATE(), GETDATE()),
('Ahmet Kaya', 'ahmet.kaya@example.com', 'Destek Talebi', 'Yard�m�n�za ihtiyac�m var.', 0, 0, GETDATE(), GETDATE()),
('Fatma Kara', 'fatma.kara@example.com', 'Toplant� Talebi', 'Yeni bir toplant� planlamak istiyorum.', 0, 0, GETDATE(), GETDATE()),
('H�seyin Y�ld�r�m', 'huseyin.yildirim@example.com', '��birli�i Teklifi', 'Sizinle i�birli�i yapmak istiyorum.', 0, 0, GETDATE(), GETDATE()),
('Elif Can', 'elif.can@example.com', 'Geri Bildirim', 'Uygulaman�z hakk�nda geri bildirim vermek istiyorum.', 0, 0, GETDATE(), GETDATE()),
('Cemre Toprak', 'cemre.toprak@example.com', '��erik �nerisi', 'Blog i�in yeni bir i�erik �nerim var.', 0, 0, GETDATE(), GETDATE()),
('Burak G�ne�', 'burak.gunes@example.com', 'Yeni Fikir', 'Yeni bir proje fikrim var.', 0, 0, GETDATE(), GETDATE()), ('Ceren Y�ld�z', 'ceren.yildiz@example.com', 'Feedback', 'Sitenizi �ok be�endim, te�ekk�rler!', 0, 0, GETDATE(), GETDATE()), ('Deniz Aksoy', 'deniz.aksoy@example.com', 'Destek Talebi', 'Hesab�mla ilgili sorun ya��yorum.', 0, 0, GETDATE(), GETDATE()), ('Ege ��nar', 'ege.cinar@example.com', '��birli�i', 'Projemizde sizinle �al��mak istiyoruz.', 0, 0, GETDATE(), GETDATE()), ('Furkan Demir', 'furkan.demir@example.com', 'Geri Bildirim', 'Mobil uygulaman�z hakk�nda baz� �nerilerim var.', 0, 0, GETDATE(), GETDATE()), ('Gizem Ayd�n', 'gizem.aydin@example.com', 'Soru', 'Kurs hakk�nda daha fazla bilgi alabilir miyim?', 0, 0, GETDATE(), GETDATE()), ('Hakan Ko�', 'hakan.koc@example.com', '�neri', 'Web sitenizin ana sayfas� i�in bir �nerim var.', 0, 0, GETDATE(), GETDATE()), ('I��l Y�lmaz', 'isil.yilmaz@example.com', 'Te�ekk�r', 'Destek ekibinize te�ekk�r etmek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Jale �elik', 'jale.celik@example.com', 'Toplant� Talebi', 'Yeni bir toplant� d�zenlemek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Kadir Ta�', 'kadir.tas@example.com', 'Proje Destek', 'Projem i�in deste�inize ihtiyac�m var.', 0, 0, GETDATE(), GETDATE()), ('Lale G�k', 'lale.gok@example.com', 'Bilgi Talebi', 'Yeni �r�nleriniz hakk�nda bilgi almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Mert Y�lmaz', 'mert.yilmaz@example.com', 'Yard�m', 'Hizmetleriniz hakk�nda yard�m almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Nazan ��nar', 'nazan.cinar@example.com', 'Geri Bildirim', 'Sitenizin kullan�m� hakk�nda geri bildirim vermek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Onur Kara', 'onur.kara@example.com', 'Teklif Talebi', 'Yeni bir proje i�in teklif almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Pelin Deniz', 'pelin.deniz@example.com', 'Destek', 'Uygulaman�z hakk�nda baz� sorunlar ya��yorum.', 0, 0, GETDATE(), GETDATE()), ('R�za G�ne�', 'riza.gunes@example.com', 'Yeni �r�n', 'Yeni �r�nleriniz hakk�nda bilgi almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Sevil Demir', 'sevil.demir@example.com', '�ikayet', 'Hizmetiniz hakk�nda �ikayette bulunmak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Tuna Y�ld�z', 'tuna.yildiz@example.com', '�neri', 'Uygulaman�z hakk�nda baz� �nerilerim var.', 0, 0, GETDATE(), GETDATE())
go
-- SocialsMediaAccount tablosuna sosyal medya hesaplar� ekleme
INSERT INTO SocialsMediaAccount (Title, AccountUrl, Icon, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Instagram', 'http://instagram.com/hesap', 'fa-instagram', 0, GETDATE(), GETDATE()),
('Facebook', 'http://facebook.com/hesap', 'fa-facebook', 0, GETDATE(), GETDATE()),
('LinkedIn', 'http://linkedin.com/hesap', 'fa-linkedin', 0, GETDATE(), GETDATE()),
('Medium', 'http://medium.com/hesap', 'fa-medium', 0, GETDATE(), GETDATE());
go
-- Projects tablosuna �rnek projeler ekleme
INSERT INTO Projects (Title, SubTitle, Description, ImageUrl, Team, Url, GitHubUrl, ZipFileUrl, CatgorieId, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Proje 1', 'Web Geli�tirme Projesi', 'Bu proje bir web geli�tirme projesidir.', 'http://example.com/project1.jpg', 'Tak�m A', 'http://example.com/project1', 'http://github.com/project1', 'http://example.com/project1.zip', 1, 0, GETDATE(), GETDATE()),
('Proje 2', 'Mobil Uygulama Geli�tirme', 'Bu proje bir mobil uygulama geli�tirme projesidir.', 'http://example.com/project2.jpg', 'Tak�m B', 'http://example.com/project2', 'http://github.com/project2', 'http://example.com/project2.zip', 2, 0, GETDATE(), GETDATE()),
('Proje 3', 'Bulut Bili�im ��z�m�', 'Bu proje bir bulut bili�im ��z�m� sunar.', 'http://example.com/project3.jpg', 'Tak�m C', 'http://example.com/project3', 'http://github.com/project3', 'http://example.com/project3.zip', 3, 0, GETDATE(), GETDATE()),
('Proje 4', 'Yapay Zeka ve Makine ��renimi', 'Bu proje bir yapay zeka ve makine ��renimi projesidir.', 'http://example.com/project4.jpg', 'Tak�m D', 'http://example.com/project4', 'http://github.com/project4', 'http://example.com/project4.zip', 4, 0, GETDATE(), GETDATE());
go
-- Settings tablosuna veri ekleme
INSERT INTO Settings (Id, SiteName, FooterText, CreatedAt, UpdatedAt)
VALUES (1, 'Eray G�l��men', '� 2024 T�m Haklar� Sakl�d�r.', GETDATE(), GETDATE());
go
-- Contacts tablosuna veri ekleme
INSERT INTO Contacts (Id, Adress, PhoneNumber, Email, GoogleMap, CreatedAt, UpdatedAt)
VALUES (1, '�stanbul, T�rkiye', '+90 555 5555', 'info@example.com', '<iframe src="https://www.google.com/maps"></iframe>', GETDATE(), GETDATE());
go
-- Abouts tablosuna veri ekleme
INSERT INTO Abouts (Id, AboutTitle, AboutText, AboutCvUrl, AboutImageUrl, CreatedAt, UpdatedAt)
VALUES (1, 'Hakk�m�zda', 'Biz yenilik�i ��z�mler sunan bir ekibiz.', 'http://example.com/cv.pdf', 'http://example.com/image.jpg', GETDATE(), GETDATE());
go
-- HomeBanners tablosuna veri ekleme
INSERT INTO HomeBanners (Id, HomeBannerTitle, HomeBannerSubtitle, HomeBannerText, HomeBannerImageUrl, CreatedAt, UpdatedAt)
VALUES (1, 'Ho� Geldiniz', 'En �yi ��z�mler', 'Bizimle �al��maya haz�r m�s�n�z?', 'http://example.com/banner.jpg', GETDATE(), GETDATE());
go
-- ServiceInfos tablosuna veri ekleme
INSERT INTO ServiceInfos (Id, ServiceTitle, ServiceText, CreatedAt, UpdatedAt)
VALUES (1, 'Web Geli�tirme', 'Profesyonel web geli�tirme hizmetleri sunuyoruz.', GETDATE(), GETDATE());
go
-- Services tablosuna veri ekleme
INSERT INTO Services (Icon, Title, SubTitle, Description, IsDeleted, CreatedAt, UpdatedAt)
VALUES ('~/ui/img/services/s1.png', 'Web Geli�tirme', 'Profesyonel Hizmetler', 'Kapsaml� web geli�tirme ��z�mleri.', 0, GETDATE(), GETDATE());
go

