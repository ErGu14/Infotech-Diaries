--Select sorgular�
--******************************************************--
-- TEMEL SELECT ��LEMLER�
--******************************************************--

--select * from B�l�ms
--select * from Dersler
--select Ad, Kredi from Dersler
--select
	--ad as 'DERS ADI', 
	--AD as [Ders Ad�],
	--kredi as A�IRLIK
--from Dersler

--select
--	dbo.Ogrenciler.Ad,
--	dbo.Ogrenciler.Soyad,
--	dbo.Ogrenciler.DogumTarihi
--from dbo.Ogrenciler

--select 
--	o.Ad,
--	o.Soyad,
--	o.DogumTarihi
	
--from Ogrenciler o

--select 
--	o.ad + ' ' +o.Soyad as [��renci],
--	o.DogumTarihi as [Do�um Tarihi]
--from Ogrenciler o

--******************************************************--
-- f�LTRELEME VE AGREGATE
--******************************************************--

--select 
--	*
--from Dersler d 
--where d.BolumId = 3

--select *
--from dersler d
--where kredi >= 6 and d.BolumId = 3

--select *
--from Dersler d
----where d.kredi >= 4 and d.kredi <= 6
--where d.kredi between 4 and 6

--select *
--from Ogrenciler o
----where o.DogumTarihi is null
--where o.DogumTarihi is not null

--select sum(d.kredi) as [Kredilerin Toplam�]
--from Dersler d
--where d.BolumId = 1

--select count(*) as [��renci say�s�]
--from Ogrenciler o
--where o.BolumId = 3

--select COUNT(o.DogumTarihi )
--from Ogrenciler o
--where o.DogumTarihi is not null

--select avg(d.kredi)
--from Dersler d