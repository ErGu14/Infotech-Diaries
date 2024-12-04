--veri tabaný yaratma operasyonu baþlýyor
use master
go

if DB_ID('PortfolioDb') is not null
begin
	alter database PortfolioDb set single_user with rollback immediate --database ile güncelleme  yapma     bu db yi tek kullanýcý halne getir
	drop database PortfolioDb
end
go

create database PortfolioDb collate Turkish_CI_As  -- türkçe karakterlerin destekleneceði þekilde db oluþtur
go

Use PortfolioDb
go
-- veri tabaný yaratma operasyonu sona erdi
go
-- Uygulamanýn genel ayarlarý için settings tablosu oluþturuluyor

create table Settings(
	Id int default 1,

	SiteName nvarchar(MAX) not null,
	FooterText nvarchar(MAX) not null,


	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go



--Contacts Tablosu oluþutuluyor

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


--abouts talosu oluþturuluyor
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
--homeBanners tablosu oluþturuluyor
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

	
	IsDeleted bit not null default  0, -- varsayýlan olarak silinmemiþ yapýyoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)



)
go



create table Categories(
	Id int primary key identity,

	
	Name nvarchar(max)not null,
	Description nvarchar(max) null default 'Kategori Açýklamasý',

	
	IsDeleted bit not null default  0, -- varsayýlan olarak silinmemiþ yapýyoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)

)
go



create table Projects(
	Id int primary key identity,

	
	Title nvarchar(max)not null,
	SubTitle nvarchar(max) not null,
	Description nvarchar(max) null default 'Proje Açýklamasý',
	ImageUrl nvarchar(max) not null,
	Team nvarchar(max) not null,
	Url nvarchar(max),
	GitHubUrl nvarchar(max),
	ZipFileUrl nvarchar(max),
	CatgorieId int not null foreign key references Categories(Id),

	



	
	IsDeleted bit not null default  0, -- varsayýlan olarak silinmemiþ yapýyoruz
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
	

	
	IsDeleted bit not null default  0, -- varsayýlan olarak silinmemiþ yapýyoruz
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)

)
go

-- Categories tablosuna 4 yeni kategori ekleme
INSERT INTO Categories (Name, Description, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Web Geliþtirme', 'Web uygulamalarý ve sitelerinin geliþtirilmesi için kullanýlan teknolojiler ve araçlar.', 0, GETDATE(), GETDATE()),
('Mobil Uygulama Geliþtirme', 'Mobil cihazlar için uygulama geliþtirme teknolojileri ve araçlarý.', 0, GETDATE(), GETDATE()),
('Bulut Biliþim', 'Veri depolama, yönetim ve analiz için bulut tabanlý çözümler ve teknolojiler.', 0, GETDATE(), GETDATE()),
('Yapay Zeka ve Makine Öðrenimi', 'AI ve ML teknikleri, araçlarý ve uygulamalarý ile ilgili bilgiler.', 0, GETDATE(), GETDATE());
go
-- Messages tablosuna 25 örnek mesaj ekleme
INSERT INTO Messages (Name, Email, Subject, Content, IsDeleted, IsRead, SendingDate, ReadingDate)
VALUES 
('Ali Veli', 'ali.veli@example.com', 'Merhaba', 'Bu bir test mesajýdýr.', 0, 0, GETDATE(), GETDATE()),
('Ayþe Yýlmaz', 'ayse.yilmaz@example.com', 'Proje Hakkýnda', 'Proje ile ilgili bazý sorularým var.', 0, 0, GETDATE(), GETDATE()),
('Mehmet Demir', 'mehmet.demir@example.com', 'Teklif Talebi', 'Yeni proje için teklif talep ediyorum.', 0, 0, GETDATE(), GETDATE()),
('Ahmet Kaya', 'ahmet.kaya@example.com', 'Destek Talebi', 'Yardýmýnýza ihtiyacým var.', 0, 0, GETDATE(), GETDATE()),
('Fatma Kara', 'fatma.kara@example.com', 'Toplantý Talebi', 'Yeni bir toplantý planlamak istiyorum.', 0, 0, GETDATE(), GETDATE()),
('Hüseyin Yýldýrým', 'huseyin.yildirim@example.com', 'Ýþbirliði Teklifi', 'Sizinle iþbirliði yapmak istiyorum.', 0, 0, GETDATE(), GETDATE()),
('Elif Can', 'elif.can@example.com', 'Geri Bildirim', 'Uygulamanýz hakkýnda geri bildirim vermek istiyorum.', 0, 0, GETDATE(), GETDATE()),
('Cemre Toprak', 'cemre.toprak@example.com', 'Ýçerik Önerisi', 'Blog için yeni bir içerik önerim var.', 0, 0, GETDATE(), GETDATE()),
('Burak Güneþ', 'burak.gunes@example.com', 'Yeni Fikir', 'Yeni bir proje fikrim var.', 0, 0, GETDATE(), GETDATE()), ('Ceren Yýldýz', 'ceren.yildiz@example.com', 'Feedback', 'Sitenizi çok beðendim, teþekkürler!', 0, 0, GETDATE(), GETDATE()), ('Deniz Aksoy', 'deniz.aksoy@example.com', 'Destek Talebi', 'Hesabýmla ilgili sorun yaþýyorum.', 0, 0, GETDATE(), GETDATE()), ('Ege Çýnar', 'ege.cinar@example.com', 'Ýþbirliði', 'Projemizde sizinle çalýþmak istiyoruz.', 0, 0, GETDATE(), GETDATE()), ('Furkan Demir', 'furkan.demir@example.com', 'Geri Bildirim', 'Mobil uygulamanýz hakkýnda bazý önerilerim var.', 0, 0, GETDATE(), GETDATE()), ('Gizem Aydýn', 'gizem.aydin@example.com', 'Soru', 'Kurs hakkýnda daha fazla bilgi alabilir miyim?', 0, 0, GETDATE(), GETDATE()), ('Hakan Koç', 'hakan.koc@example.com', 'Öneri', 'Web sitenizin ana sayfasý için bir önerim var.', 0, 0, GETDATE(), GETDATE()), ('Iþýl Yýlmaz', 'isil.yilmaz@example.com', 'Teþekkür', 'Destek ekibinize teþekkür etmek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Jale Çelik', 'jale.celik@example.com', 'Toplantý Talebi', 'Yeni bir toplantý düzenlemek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Kadir Taþ', 'kadir.tas@example.com', 'Proje Destek', 'Projem için desteðinize ihtiyacým var.', 0, 0, GETDATE(), GETDATE()), ('Lale Gök', 'lale.gok@example.com', 'Bilgi Talebi', 'Yeni ürünleriniz hakkýnda bilgi almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Mert Yýlmaz', 'mert.yilmaz@example.com', 'Yardým', 'Hizmetleriniz hakkýnda yardým almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Nazan Çýnar', 'nazan.cinar@example.com', 'Geri Bildirim', 'Sitenizin kullanýmý hakkýnda geri bildirim vermek istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Onur Kara', 'onur.kara@example.com', 'Teklif Talebi', 'Yeni bir proje için teklif almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Pelin Deniz', 'pelin.deniz@example.com', 'Destek', 'Uygulamanýz hakkýnda bazý sorunlar yaþýyorum.', 0, 0, GETDATE(), GETDATE()), ('Rýza Güneþ', 'riza.gunes@example.com', 'Yeni Ürün', 'Yeni ürünleriniz hakkýnda bilgi almak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Sevil Demir', 'sevil.demir@example.com', 'Þikayet', 'Hizmetiniz hakkýnda þikayette bulunmak istiyorum.', 0, 0, GETDATE(), GETDATE()), ('Tuna Yýldýz', 'tuna.yildiz@example.com', 'Öneri', 'Uygulamanýz hakkýnda bazý önerilerim var.', 0, 0, GETDATE(), GETDATE())
go
-- SocialsMediaAccount tablosuna sosyal medya hesaplarý ekleme
INSERT INTO SocialsMediaAccount (Title, AccountUrl, Icon, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Instagram', 'http://instagram.com/hesap', 'fa-instagram', 0, GETDATE(), GETDATE()),
('Facebook', 'http://facebook.com/hesap', 'fa-facebook', 0, GETDATE(), GETDATE()),
('LinkedIn', 'http://linkedin.com/hesap', 'fa-linkedin', 0, GETDATE(), GETDATE()),
('Medium', 'http://medium.com/hesap', 'fa-medium', 0, GETDATE(), GETDATE());
go
-- Projects tablosuna örnek projeler ekleme
INSERT INTO Projects (Title, SubTitle, Description, ImageUrl, Team, Url, GitHubUrl, ZipFileUrl, CatgorieId, IsDeleted, CreatedAt, UpdatedAt)
VALUES 
('Proje 1', 'Web Geliþtirme Projesi', 'Bu proje bir web geliþtirme projesidir.', 'http://example.com/project1.jpg', 'Takým A', 'http://example.com/project1', 'http://github.com/project1', 'http://example.com/project1.zip', 1, 0, GETDATE(), GETDATE()),
('Proje 2', 'Mobil Uygulama Geliþtirme', 'Bu proje bir mobil uygulama geliþtirme projesidir.', 'http://example.com/project2.jpg', 'Takým B', 'http://example.com/project2', 'http://github.com/project2', 'http://example.com/project2.zip', 2, 0, GETDATE(), GETDATE()),
('Proje 3', 'Bulut Biliþim Çözümü', 'Bu proje bir bulut biliþim çözümü sunar.', 'http://example.com/project3.jpg', 'Takým C', 'http://example.com/project3', 'http://github.com/project3', 'http://example.com/project3.zip', 3, 0, GETDATE(), GETDATE()),
('Proje 4', 'Yapay Zeka ve Makine Öðrenimi', 'Bu proje bir yapay zeka ve makine öðrenimi projesidir.', 'http://example.com/project4.jpg', 'Takým D', 'http://example.com/project4', 'http://github.com/project4', 'http://example.com/project4.zip', 4, 0, GETDATE(), GETDATE());
go
-- Settings tablosuna veri ekleme
INSERT INTO Settings (Id, SiteName, FooterText, CreatedAt, UpdatedAt)
VALUES (1, 'Eray Gülüçmen', '© 2024 Tüm Haklarý Saklýdýr.', GETDATE(), GETDATE());
go
-- Contacts tablosuna veri ekleme
INSERT INTO Contacts (Id, Adress, PhoneNumber, Email, GoogleMap, CreatedAt, UpdatedAt)
VALUES (1, 'Ýstanbul, Türkiye', '+90 555 5555', 'info@example.com', '<iframe src="https://www.google.com/maps"></iframe>', GETDATE(), GETDATE());
go
-- Abouts tablosuna veri ekleme
INSERT INTO Abouts (Id, AboutTitle, AboutText, AboutCvUrl, AboutImageUrl, CreatedAt, UpdatedAt)
VALUES (1, 'Hakkýmýzda', 'Biz yenilikçi çözümler sunan bir ekibiz.', 'http://example.com/cv.pdf', 'http://example.com/image.jpg', GETDATE(), GETDATE());
go
-- HomeBanners tablosuna veri ekleme
INSERT INTO HomeBanners (Id, HomeBannerTitle, HomeBannerSubtitle, HomeBannerText, HomeBannerImageUrl, CreatedAt, UpdatedAt)
VALUES (1, 'Hoþ Geldiniz', 'En Ýyi Çözümler', 'Bizimle çalýþmaya hazýr mýsýnýz?', 'http://example.com/banner.jpg', GETDATE(), GETDATE());
go
-- ServiceInfos tablosuna veri ekleme
INSERT INTO ServiceInfos (Id, ServiceTitle, ServiceText, CreatedAt, UpdatedAt)
VALUES (1, 'Web Geliþtirme', 'Profesyonel web geliþtirme hizmetleri sunuyoruz.', GETDATE(), GETDATE());
go
-- Services tablosuna veri ekleme
INSERT INTO Services (Icon, Title, SubTitle, Description, IsDeleted, CreatedAt, UpdatedAt)
VALUES ('~/ui/img/services/s1.png', 'Web Geliþtirme', 'Profesyonel Hizmetler', 'Kapsamlý web geliþtirme çözümleri.', 0, GETDATE(), GETDATE());
go

