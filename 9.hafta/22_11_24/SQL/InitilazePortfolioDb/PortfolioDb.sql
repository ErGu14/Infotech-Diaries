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

create table Setting(
	Id int default 1,
	
	CreatedAt datetime2(3) not null default getdate(),
	UpdatedAt datetime2(3)
)
go

insert into Setting()
values
	('Eray G�l��men','Copyright &copy; 2024 T�m Haklar� Sakl�d�r| Bu Site SATNER �ablonu �le Haz�rlanm��t�r.',
	'Menek�e sokak Nuri Caddesi No 90 Daire 8',
	'555-555-55-55',
	'eray@bey.com',
	'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12032.381187572828!2d28.979224562644948!3d41.06690953010336!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab7913b7b9b3f%3A0x154c9d69c759851e!2zSW5mb3RlY2ggQWNhZGVteSBZYXrEsWzEsW0gS3Vyc3UgKMWeacWfbGkvTWVjaWRpeWVrw7Z5IMWedWJlKQ!5e0!3m2!1str!2str!4v1732276131664!5m2!1str!2str" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>',
	'HAKKIMDA',
	'Ben InfoAcademy Yaz�l�m Uzmanl��� E�itimini tamamlad�m. �e�itli projelerde yer ald�m.Halihaz�rda dotnet ekosisteminde uygulama geli�tiriyorum. Ve bal�k tutmay� severim.',
	'files/eraygulucmencv.pdf',
	'/ui/img/about-us.png'



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
insert into Contacts(Adress,PhoneNumber,Email,GoogleMap)
values
	(
	'Menek�e sokak Nuri Caddesi No 90 Daire 8',
	'555-555-55-55',
	'eray@bey.com',
	'<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12032.381187572828!2d28.979224562644948!3d41.06690953010336!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab7913b7b9b3f%3A0x154c9d69c759851e!2zSW5mb3RlY2ggQWNhZGVteSBZYXrEsWzEsW0gS3Vyc3UgKMWeacWfbGkvTWVjaWRpeWVrw7Z5IMWedWJlKQ!5e0!3m2!1str!2str!4v1732276131664!5m2!1str!2str" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>'

	)
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
insert into Abouts(AboutTitle,AboutText,AboutCvUrl,AboutImageUrl)
values
	(
	'HAKKIMDA',
	'Ben InfoAcademy Yaz�l�m Uzmanl��� E�itimini tamamlad�m. �e�itli projelerde yer ald�m.Halihaz�rda dotnet ekosisteminde uygulama geli�tiriyorum. Ve bal�k tutmay� severim.',
	'files/eraygulucmencv.pdf',
	'/ui/img/about-us.png'



	)



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
insert into HomeBanners(HomeBannerTitle,HomeBannerSubtitle,HomeBannerText,HomeBannerImageUrl)
values
	(
		'Merhaba',
		'Ben Eray G�l��men',
		'Senior Dotnet Developer',
		'/ui/img/banner/home-right.png'


	)

go