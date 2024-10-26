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
--(1, 'Bilgisayar M�hendisli�i'),
--(2, 'Elektrik M�hendisli�i'),
--(3, 'Makine M�hendisli�i')
--GO

--INSERT INTO Ogrenciler (OgrenciID, Ad, Soyad, BolumID) VALUES
--(1, 'Ali', '�ahin', 1),
--(2, 'Ay�e', 'Y�lmaz', 1),
--(3, 'Mehmet', 'Demir', 2),
--(4, 'Fatma', 'Kara', 3),
--(5, 'Zeynep', 'Ko�', 2)
--GO

--INSERT INTO Dersler (DersID, DersAdi) VALUES
--(1, 'Veritaban� Y�netimi'),
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
--(1, 'Dr. Ali', 'Y�lmaz', 1),
--(2, 'Prof. Mehmet', 'Demir', 2),
--(3, 'Do�. Fatma', 'Kara', 1),
--(4, 'Dr. Zeynep', 'Ko�', 3),
--(5, 'Prof. Ahmet', '�elik', 2)
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

--   **B�l�m Baz�nda Not Ortalamas�:** Her b�l�mdeki t�m ��rencilerin ald�klar� derslerden elde ettikleri notlar�n ortalamas�n� bulun. Her bir b�l�m i�in ortalama notu listeleyin.

--select
--	o.Ad + ' ' + o.Soyad [��renci],
--	b.BolumAdi,
--	avg(n.NotDegeri)
	
	
--from Ogrenciler o
--	join Bolumler b on b.BolumID = o.BolumID
--		join Notlar n on n.OgrenciID = o.OgrenciID
--group by o.Ad + ' ' + o.Soyad,b.BolumAdi
go
--**En Y�ksek Notu Alan ��renciyi Bulma:** T�m b�l�mler aras�ndan en y�ksek notu alan ��renciyi ve hangi dersten bu notu ald���n� listeleyin. ��rencinin ad�n�, soyad�n�, b�l�m�n�, dersi ve notunu sonu� olarak getirin.
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
--   **Ba�ar�s�z ��rencilerin Listesi:** Notu 50'nin alt�nda olan t�m ��rencilerin listesini olu�turun. ��rencinin ad�, soyad�, b�l�m�, dersi ve ald��� notu g�steren bir sorgu yaz�n.
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
--Her ��retmenin verdi�i dersleri ve bu derslere kay�tl� olan ��rencilerin listesini getiren bir sorgu yaz�n. Sorgu sonu�lar�, ��retmen ad�, ders ad� ve ��renci ad�n� i�ermelidir.
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
