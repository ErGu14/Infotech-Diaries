create database OkulYonetimiDB
go

--use OkulYonetimiDB
--go
--CREATE TABLE Bolumler (
--    BolumID INT PRIMARY KEY,
--    BolumAdi VARCHAR(100)
--)
--GO

--CREATE TABLE Ogrenciler (
--    OgrenciID INT PRIMARY KEY,
--    Ad VARCHAR(50),
--    Soyad VARCHAR(50),
--    BolumID INT,
--    FOREIGN KEY (BolumID) REFERENCES Bolumler(BolumID)
--)
--GO

--CREATE TABLE Dersler (
--    DersID INT PRIMARY KEY,
--    DersAdi VARCHAR(100)
--) 
--GO

--CREATE TABLE Notlar (
--    NotID INT PRIMARY KEY,
--    OgrenciID INT,
--    DersID INT,
--    NotDegeri DECIMAL(5, 2),
--    FOREIGN KEY (OgrenciID) REFERENCES Ogrenciler(OgrenciID),
--    FOREIGN KEY (DersID) REFERENCES Dersler(DersID)
--)
--GO

--CREATE TABLE Ogretmenler (
--    OgretmenID INT PRIMARY KEY,
--    Ad VARCHAR(50),
--    Soyad VARCHAR(50),
--    BolumID INT,
--    FOREIGN KEY (BolumID) REFERENCES Bolumler(BolumID)
--)
--GO

--CREATE TABLE OgretmenDersler (
--    OgretmenID INT,
--    DersID INT,
--    PRIMARY KEY (OgretmenID, DersID),
--    FOREIGN KEY (OgretmenID) REFERENCES Ogretmenler(OgretmenID),
--    FOREIGN KEY (DersID) REFERENCES Dersler(DersID)
--)
--GO

--INSERT INTO Bolumler (BolumID, BolumAdi) VALUES
--(1, 'Bilgisayar Mühendisliði'),
--(2, 'Elektrik Mühendisliði'),
--(3, 'Makine Mühendisliði')
--GO

--INSERT INTO Ogrenciler (OgrenciID, Ad, Soyad, BolumID) VALUES
--(1, 'Ali', 'Þahin', 1),
--(2, 'Ayþe', 'Yýlmaz', 1),
--(3, 'Mehmet', 'Demir', 2),
--(4, 'Fatma', 'Kara', 3),
--(5, 'Zeynep', 'Koç', 2)
--GO

--INSERT INTO Dersler (DersID, DersAdi) VALUES
--(1, 'Veritabaný Yönetimi'),
--(2, 'Algoritmalar'),
--(3, 'Devre Teorisi'),
--(4, 'Mekanik')
--GO

--INSERT INTO Notlar (NotID, OgrenciID, DersID, NotDegeri) VALUES
--(1, 1, 1, 85.00),
--(2, 1, 2, 90.00),
--(3, 2, 1, 75.00),
--(4, 3, 3, 45.00),
--(5, 4, 4, 60.00),
--(6, 5, 2, 50.00)
--GO

--INSERT INTO Ogretmenler (OgretmenID, Ad, Soyad, BolumID) VALUES
--(1, 'Dr. Ali', 'Yýlmaz', 1),
--(2, 'Prof. Mehmet', 'Demir', 2),
--(3, 'Doç. Fatma', 'Kara', 1),
--(4, 'Dr. Zeynep', 'Koç', 3),
--(5, 'Prof. Ahmet', 'Çelik', 2)
--GO

--INSERT INTO OgretmenDersler (OgretmenID, DersID) VALUES
--(1, 1),
--(1, 2),
--(2, 3),
--(3, 1),
--(4, 4),
--(5, 2),
--(5, 3)
--GO

go

--   **Bölüm Bazýnda Not Ortalamasý:** Her bölümdeki tüm öðrencilerin aldýklarý derslerden elde ettikleri notlarýn ortalamasýný bulun. Her bir bölüm için ortalama notu listeleyin.

--select
--	o.Ad + ' ' + o.Soyad [Öðrenci],
--	b.BolumAdi,
--	avg(n.NotDegeri)
	
	
--from Ogrenciler o
--	join Bolumler b on b.BolumID = o.BolumID
--		join Notlar n on n.OgrenciID = o.OgrenciID
--group by o.Ad + ' ' + o.Soyad,b.BolumAdi
go
--**En Yüksek Notu Alan Öðrenciyi Bulma:** Tüm bölümler arasýndan en yüksek notu alan öðrenciyi ve hangi dersten bu notu aldýðýný listeleyin. Öðrencinin adýný, soyadýný, bölümünü, dersi ve notunu sonuç olarak getirin.
--select top 1
--	o.Ad,
--	o.Soyad,
--	b.BolumAdi,
--	d.DersAdi,
--	n.NotDegeri,
--	max(n.NotDegeri) [MAX]
--from Ogrenciler o
--	join notlar n on n.OgrenciID = o.OgrenciID
--		join Bolumler b on  b.BolumID = o.BolumID
--			join Dersler d on d.DersID = n.DersID
--group by o.Ad,o.Soyad,b.BolumAdi,d.DersAdi,n.NotDegeri
--order by n.NotDegeri DESC

go
--   **Baþarýsýz Öðrencilerin Listesi:** Notu 50'nin altýnda olan tüm öðrencilerin listesini oluþturun. Öðrencinin adý, soyadý, bölümü, dersi ve aldýðý notu gösteren bir sorgu yazýn.
--select 
--	o.Ad,
--	o.Soyad,
--	b.BolumAdi,
--	d.DersAdi,
--	n.NotDegeri

--from Ogrenciler o
--	join notlar n on n.OgrenciID = o.OgrenciID
--		join Bolumler b on  b.BolumID = o.BolumID
--			join Dersler d on d.DersID = n.DersID
--where n.NotDegeri < 50
--group by o.Ad,o.Soyad,b.BolumAdi,d.DersAdi,n.NotDegeri
--order by n.NotDegeri DESC
go
--Her öðretmenin verdiði dersleri ve bu derslere kayýtlý olan öðrencilerin listesini getiren bir sorgu yazýn. Sorgu sonuçlarý, öðretmen adý, ders adý ve öðrenci adýný içermelidir.
--SELECT 
--    og.Ad AS OgretmenAdi, 
--    og.Soyad AS OgretmenSoyadi, 
--    d.DersAdi AS DersAdi, 
--    o.Ad AS OgrenciAdi, 
--    o.Soyad AS OgrenciSoyadi
--FROM 
--    Ogretmenler og
--JOIN 
--    OgretmenDersler od ON og.OgretmenID = od.OgretmenID
--JOIN 
--    Dersler d ON od.DersID = d.DersID
--JOIN 
--    Notlar n ON d.DersID = n.DersID
--JOIN 
--    Ogrenciler o ON n.OgrenciID = o.OgrenciID
--ORDER BY 
--    og.Ad, d.DersAdi, o.Ad;
go
