--   Her personelin mevcut maa��n� listeleyin (En son g�ncelleme tarihine g�re).

--select
--	p.Ad + ' ' + p.Soyad [�sim],
--	m.MaasMiktari,
--	m.G�ncellemeTarihi

--from Personel p
--	join Maaslar m on p.PersonelId = m.PersonelId
	
go
--   T�m personelin ortalama maa��n� hesaplayan bir sorgu yaz�n.
--select 
--AVG(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
-- Ayn� pozisyonda �al��an personelin maa�lar�n� kar��la�t�rarak en y�ksek ve en d���k maa�lar� getirin.
--select 
--p.Ad,
--p.Pozisyon,
--max (m.MaasMiktari),
--MIN(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--group by p.Pozisyon,p.Ad
go
--T�m personelin ad�n�, soyad�n� ve pozisyonunu listeleyin. (`SELECT` ve `FROM`)
--select 
--*
--from Personel p
go
-- Hangi pozisyonda ka� personel �al��t���n� g�steren bir liste olu�turun. (`GROUP BY` ve `COUNT`),
--select 
--p.Pozisyon,
--count(p.Pozisyon)
--from Personel p
--group by p.Pozisyon
go
--her personelin en son maa� miktar�n� ve g�ncelleme tarihini listeleyin. (`JOIN` ve `MAX`)
--select 
--p.Ad,
--m.MaasId,
--m.MaasMiktari
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
---   "��retmen" pozisyonunda �al��an t�m personelleri listeleyin. (`WHERE`)
--select 
--*
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--	where p.Pozisyon = '��retmen'
go
--T�m personelin ortalama maa��n� hesaplay�n. (`AVG`)
--select 
--avg(m.MaasMiktari)
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
go
-- En y�ksek maa� alan personelin ad�n�, soyad�n� ve maa��n� listeleyin. (`ORDER BY` ve `LIMIT`)
--select top 1
--p.Ad,
--p.Soyad,
--m.MaasMiktari
--from Personel p JOIN Maaslar m on m.PersonelId=p.PersonelId
--order by m.MaasMiktari desc
go
--Bir personelin t�m maa� de�i�ikliklerini kronolojik s�rayla listeleyin. (`WHERE` ve `ORDER BY`)
go
--Ayn� pozisyondaki personellerin maa�lar�n� kar��la�t�rarak en y�ksek ve en d���k maa�� listeleyin. (`GROUP BY` ve `HAVING`)

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
--ANLA�ILMAYAN �RNEKLER

--   Son 6 ay i�inde maa�� g�ncellenen personelleri listeleyin. (`WHERE` ve `DATEADD`)
--   Maa�� en az iki kez g�ncellenmi� olan personelleri listeleyin. (`GROUP BY` ve `HAVING`) 
