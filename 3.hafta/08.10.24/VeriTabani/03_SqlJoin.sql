-- JOÝN ÝÞLEMLERÝ

--select 
--	d.Ad as [Ders Adý],
--	b.Ad as [Bölüm Adý]
--from Dersler d join Bölüms b on d.BolumId=b.Id
--where b.Ad = 'Elektrik Mühendisliði'

select 
	--o.ad + ' ' + o.Soyad as [Öðrenci],
	--d.ad as DERS
	*
	
from Ogrenciler o join OgrenciDersler od on o.Id = od.OgrenciId
	join Dersler d on od.DersId = d.Id