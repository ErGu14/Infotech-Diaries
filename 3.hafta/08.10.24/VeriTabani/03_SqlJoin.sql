-- JO�N ��LEMLER�

--select 
--	d.Ad as [Ders Ad�],
--	b.Ad as [B�l�m Ad�]
--from Dersler d join B�l�ms b on d.BolumId=b.Id
--where b.Ad = 'Elektrik M�hendisli�i'

select 
	--o.ad + ' ' + o.Soyad as [��renci],
	--d.ad as DERS
	*
	
from Ogrenciler o join OgrenciDersler od on o.Id = od.OgrenciId
	join Dersler d on od.DersId = d.Id