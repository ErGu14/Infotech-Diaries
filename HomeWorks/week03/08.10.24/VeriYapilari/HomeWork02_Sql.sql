
--create table Ogrenciler (
--    OgrenciID int primary key identity(1,1) not null,
--    Ad nvarchar(50) not null,
--    Soyad nvarchar(50) not null,
--    Bolum nvarchar(50) not null,
--    KayitTarihi date not null
--);
--go


---- Kitaplar Tablosu
--create table Kitaplar (
--    KitapID int primary key identity(1,1) not null,
--    KitapAdi nvarchar(100) not null,
--    Yazar nvarchar(100) not null,
--    YayinYili int not null,
--    SayfaSayisi int not null,
--    ISBN nvarchar(20) not null
--);
--go

---- Dergiler Tablosu
--create table Dergiler (
--    DergiID int primary key identity(1,1) not null,
--    DergiAdi nvarchar(100) not null,
--    Yayinci nvarchar(100) not null,
--    YayinTarihi date not null,
--    Sayi int not null
--);
--go

---- DVDler Tablosu
--create table DVDler (
--    DVDID int primary key identity(1,1) not null,
--    DVDAdi nvarchar(100) not null,
--    Yoneten nvarchar(100) not null,
--    YayinYili int not null,
--    Sure int not null
--);
--go

---- OduncAlmalar Tablosu
--create table OduncAlmalar (
--    OgrenciID int not null,
--    KitapID int null,
--    DergiID int null,
--    DVDID int null,
--    OduncTarihi date not null,
--    foreign key (OgrenciID) references Ogrenciler(OgrenciID),
--    foreign key (KitapID) references Kitaplar(KitapID),
--    foreign key (DergiID) references Dergiler(DergiID),
--    foreign key (DVDID) references DVDler(DVDID)
--);
--go

--insert into Ogrenciler (Ad, Soyad, Bolum, KayitTarihi)
--values
--    ('Ahmet', 'Yýlmaz', 'Bilgisayar Mühendisliði', '2021-09-15'),
--    ('Ayþe', 'Öztürk', 'Elektrik Elektronik Mühendisliði', '2021-09-15'),
--    ('Mehmet', 'Demir', 'Makine Mühendisliði', '2021-09-15'),
--    ('Elif', 'Kýlýç', 'Ýþletme', '2021-09-15'),
--    ('Hasan', 'Çelik', 'Kimya Mühendisliði', '2021-09-15'),
--    ('Fatma', 'Kaya', 'Hukuk', '2021-09-15'),
--    ('Ali', 'Þahin', 'Týp', '2021-09-15'),
--    ('Zeynep', 'Koç', 'Mimarlýk', '2021-09-15'),
--    ('Murat', 'Çetin', 'Psikoloji', '2021-09-15'),
--    ('Emine', 'Yýldýrým', 'Eczacýlýk', '2021-09-15');
--go



--insert into Kitaplar (KitapAdi, Yazar, YayinYili, SayfaSayisi, ISBN)
--values
--    ('Suç ve Ceza', 'Fyodor Dostoyevski', 1866, 671, '978-6053608228'),
--    ('Sefiller', 'Victor Hugo', 1862, 1456, '978-9750721336'),
--    ('1984', 'George Orwell', 1949, 352, '978-9750718534'),
--    ('Bülbülü Öldürmek', 'Harper Lee', 1960, 336, '978-0061120084'),
--    ('Kürk Mantolu Madonna', 'Sabahattin Ali', 1943, 177, '978-6053608273'),
--    ('Tutunamayanlar', 'Oðuz Atay', 1972, 724, '978-9754700110'),
--    ('Yüzyýllýk Yalnýzlýk', 'Gabriel Garcia Marquez', 1967, 471, '978-9750802580'),
--    ('Don Kiþot', 'Miguel de Cervantes', 1605, 1072, '978-9750525847'),
--    ('Saatleri Ayarlama Enstitüsü', 'Ahmet Hamdi Tanpýnar', 1961, 371, '978-9750805868'),
--    ('Savaþ ve Barýþ', 'Lev Tolstoy', 1869, 1225, '978-6053327419'),
--    ('Çavdar Tarlasýnda Çocuklar', 'J.D. Salinger', 1951, 234, '978-9755706846'),
--    ('Ýnce Memed', 'Yaþar Kemal', 1955, 419, '978-9750809927'),
--    ('Küçük Prens', 'Antoine de Saint-Exupery', 1943, 96, '978-6053607429'),
--    ('Beyaz Diþ', 'Jack London', 1906, 264, '978-9750718533'),
--    ('Bir Kýþ Gecesi Eðer Bir Yolcu', 'Italo Calvino', 1979, 260, '978-9754709445'),
--    ('Alice Harikalar Diyarýnda', 'Lewis Carroll', 1865, 200, '978-6053608276'),
--    ('Fahrenheit 451', 'Ray Bradbury', 1953, 158, '978-9750705229'),
--    ('Þeker Portakalý', 'Jose Mauro de Vasconcelos', 1968, 182, '978-9750718532'),
--    ('Anna Karenina', 'Lev Tolstoy', 1877, 864, '978-6053607428'),
--    ('Yeraltýndan Notlar', 'Fyodor Dostoyevski', 1864, 140, '978-9750706165');
--go

--insert into Dergiler (DergiAdi, Yayinci, YayinTarihi, Sayi)
--values
--    ('Bilim ve Teknik', 'TÜBÝTAK', '2023-04-01', 550),
--    ('Atlas', 'Doðan Burda', '2023-05-15', 275),
--    ('Popular Science', 'Gürer Yayýnlarý', '2023-06-10', 210),
--    ('National Geographic', 'National Geographic Society', '2023-07-20', 330),
--    ('Focus', 'Doðan Burda', '2023-08-05', 145);
--go

--insert into DVDler (DVDAdi, Yoneten, YayinYili, Sure)
--values
--    ('Eþkýya', 'Yavuz Turgul', 1996, 128),
--    ('Ayla', 'Can Ulkay', 2017, 125),
--    ('GORA', 'Ömer Faruk Sorak', 2004, 127),
--    ('Babam ve Oðlum', 'Çaðan Irmak', 2005, 108),
--    ('Kýþ Uykusu', 'Nuri Bilge Ceylan', 2014, 196);
--go


--insert into OduncAlmalar (OgrenciID, KitapID, DergiID, DVDID, OduncTarihi)
--values
--    (1, 1, null, null, '2023-01-15'),
--    (2, 2, null, null, '2023-02-20'),
--    (3, 3, null, null, '2023-03-05'),
--    (4, null, 1, null, '2023-04-10'),
--    (5, null, 2, null, '2023-05-25'), 
--    (6, null, null, 1, '2023-06-18'),
--    (7, null, null, 2, '2023-07-22'),
--    (8, 4, null, null, '2023-08-15'),
--    (9, null, 3, null, '2023-09-30'),
--    (10, null, null, 3, '2023-10-05');
--go
go

use KutuphaneDB
go
--   Tüm kitaplarýn adýný, yazarýný ve yayýn yýlýný listeleyin. (`SELECT` ve `FROM`)

--select *
--from Kitaplar
go

--yayýn yýlý 2000’den sonra olan kitaplarýn isimlerini ve yazarlarýný listeleyin. (`WHERE`)

--select 
--	k.KitapAdi,
--	k.YayinYili
--from Kitaplar k
--where k.YayinYili >= 1900
go

--   Hangi öðrencinin hangi kitaplarý ödünç aldýðýný gösteren bir liste oluþturun. (`JOIN`)
--select 
--	o.Ad,
--	k.KitapAdi
	

--from Kitaplar k
--	join OduncAlmalar oa on oa.KitapID = k.KitapID
--		join Ogrenciler o on o.OgrenciID = oa.OgrenciID

go

--   En fazla sayfa sayýsýna sahip 5 kitabý sayfa sayýsýna göre azalan sýrayla listeleyin. (`ORDER BY` ve `LIMIT`)

--select top 5
--	k.KitapAdi,
--	k.SayfaSayisi
--from Kitaplar k
--order by k.SayfaSayisi asc  Fyodor Dostoyevski
go
--   "Orhan Pamuk" adlý yazarýn kitaplarýný listeleyin. (`WHERE`)
--select*
--from Kitaplar k
--where k.Yazar = 'Fyodor Dostoyevski'
go

--   Öðrencilerin ödünç aldýðý dergileri ve bu dergilerin yayýncýlarýný listeleyin. (`JOIN`)

--select 
--	o.Ad,
--	o.Soyad,
--	d.DergiAdi,
--	d.Yayinci
--from Dergiler d
--	 join OduncAlmalar oa on oa.DergiID = d.DergiID
--		join Ogrenciler o on o.OgrenciID = oa.OgrenciID
go
---   Henüz hiçbir materyal ödünç almayan öðrencileri listeleyin. (`LEFT JOIN` ve `IS NULL`)
--select 
--	*
--from OduncAlmalar oa
--	left join Ogrenciler o on o.OgrenciID = oa.OgrenciID
--where oa.OgrenciID is null

go
--   Her kitabýn, derginin ve DVD'nin kaç kez ödünç alýndýðýný gruplandýrarak listeleyin. (`GROUP BY`)

--select 
--    k.KitapAdi,
--    count(oa.KitapID) as OduncSayisi
--from 
--    Kitaplar k
--    left join OduncAlmalar oa on k.KitapID = oa.KitapID
--group by 
--    k.KitapAdi

--go

--select 
--    d.DergiAdi,
--    count(oa.DergiID) as OduncSayisi
--from 
--    Dergiler d
--    left join OduncAlmalar oa on d.DergiID = oa.DergiID
--group by 
--    d.DergiAdi

--	go

--	select 
--    d.DVDAdi,
--    count(oa.DVDID) as OduncSayisi
--from 
--    DVDler d
--    left join OduncAlmalar oa on d.DVDID = oa.DVDID
--group by 
--    d.DVDAdi

go
--   Yayýn tarihi en eski olan 3 kitabý listeleyin. (`ORDER BY` ve `LIMIT`)
--select top 3 *
--from Kitaplar k
--order by k.YayinYili
go

--   "Ali Þahin" adlý öðrencinin ödünç aldýðý tüm materyalleri listeleyin. (`WHERE` ve `JOIN`)

--select 
--    o.Ad,
--    o.Soyad,
--    k.KitapAdi as MateryalAdi,
--    'Kitap' as Tur,
--    oa.OduncTarihi
--from 
--    Ogrenciler o
--    join OduncAlmalar oa on o.OgrenciID = oa.OgrenciID
--    join Kitaplar k on oa.KitapID = k.KitapID
--where 
--    o.Ad = 'Ali' and o.Soyad = 'Þahin'

--union all

--select 
--    o.Ad,
--    o.Soyad,
--    d.DergiAdi as MateryalAdi,
--    'Dergi' as Tur,
--    oa.OduncTarihi
--from 
--    Ogrenciler o
--    join OduncAlmalar oa on o.OgrenciID = oa.OgrenciID
--    join Dergiler d on oa.DergiID = d.DergiID
--where 
--    o.Ad = 'Ali' and o.Soyad = 'Þahin'

--union all

--select 
--    o.Ad,
--    o.Soyad,
--    dv.DVDAdi as MateryalAdi,
--    'DVD' as Tur,
--    oa.OduncTarihi
--from 
--    Ogrenciler o
--    join OduncAlmalar oa on o.OgrenciID = oa.OgrenciID
--    join DVDler dv on oa.DVDID = dv.DVDID
--where 
--    o.Ad = 'Ali' and o.Soyad = 'Þahin'