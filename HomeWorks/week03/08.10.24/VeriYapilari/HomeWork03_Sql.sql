--   Her personelin mevcut maaþýný listeleyin (En son güncelleme tarihine göre).

--select
--	p.Ad + ' ' + p.Soyad [Ýsim],
--	m.MaasMiktari,
--	m.GüncellemeTarihi

--from Personel p
--	join Maaslar m on p.PersonelId = m.PersonelId
	
go
--   Tüm personelin ortalama maaþýný hesaplayan bir sorgu yazýn.
--select 
--AVG(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
-- Ayný pozisyonda çalýþan personelin maaþlarýný karþýlaþtýrarak en yüksek ve en düþük maaþlarý getirin.
--select 
--p.Ad,
--p.Pozisyon,
--max (m.MaasMiktari),
--MIN(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--group by p.Pozisyon,p.Ad
go
--Tüm personelin adýný, soyadýný ve pozisyonunu listeleyin. (`SELECT` ve `FROM`)
--select 
--*
--from Personel p
go
-- Hangi pozisyonda kaç personel çalýþtýðýný gösteren bir liste oluþturun. (`GROUP BY` ve `COUNT`),
--select 
--p.Pozisyon,
--count(p.Pozisyon)
--from Personel p
--group by p.Pozisyon
go
--her personelin en son maaþ miktarýný ve güncelleme tarihini listeleyin. (`JOIN` ve `MAX`)
--select 
--p.Ad,
--m.MaasId,
--m.MaasMiktari
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
---   "Öðretmen" pozisyonunda çalýþan tüm personelleri listeleyin. (`WHERE`)
--select 
--*
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--	where p.Pozisyon = 'Öðretmen'
go
--Tüm personelin ortalama maaþýný hesaplayýn. (`AVG`)
--select 
--avg(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
-- En yüksek maaþ alan personelin adýný, soyadýný ve maaþýný listeleyin. (`ORDER BY` ve `LIMIT`)
--select top 1
--p.Ad,
--p.Soyad,
--m.MaasMiktari
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--order by m.MaasMiktari desc
go
--Bir personelin tüm maaþ deðiþikliklerini kronolojik sýrayla listeleyin. (`WHERE` ve `ORDER BY`)
go
--Ayný pozisyondaki personellerin maaþlarýný karþýlaþtýrarak en yüksek ve en düþük maaþý listeleyin. (`GROUP BY` ve `HAVING`)

--select 
--    p.Pozisyon,
--    max(m.MaasMiktari) as EnYuksekMaas,
--    min(m.MaasMiktari) as EnDusukMaas
--from 
--    Personel p
--    join Maaslar m on p.PersonelID = m.PersonelID
--group by 
--    p.Pozisyon
--	having 
--    count(m.PersonelID) > 1
go
--ANLAÞILMAYAN ÖRNEKLER

--   Son 6 ay içinde maaþý güncellenen personelleri listeleyin. (`WHERE` ve `DATEADD`)
--   Maaþý en az iki kez güncellenmiþ olan personelleri listeleyin. (`GROUP BY` ve `HAVING`) 
