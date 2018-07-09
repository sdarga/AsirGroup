
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/20/2018 14:32:26
-- Generated from EDMX file: D:\Projeler\Asir\AsirGorup\BL\Data\AsirGroupModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ASIRGroupDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Kampanyalar_Kategoriler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kampanyalar] DROP CONSTRAINT [FK_Kampanyalar_Kategoriler];
GO
IF OBJECT_ID(N'[dbo].[FK_MusteriTeklifDetay_MusteriTeklifMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MusteriTeklifDetay] DROP CONSTRAINT [FK_MusteriTeklifDetay_MusteriTeklifMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_TeklifDetay_TeklifMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MusteriTeklifDetay] DROP CONSTRAINT [FK_TeklifDetay_TeklifMaster];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kampanyalar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kampanyalar];
GO
IF OBJECT_ID(N'[dbo].[KampanyalarGecici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KampanyalarGecici];
GO
IF OBJECT_ID(N'[dbo].[Kategoriler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategoriler];
GO
IF OBJECT_ID(N'[dbo].[MusteriKampanyalari]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriKampanyalari];
GO
IF OBJECT_ID(N'[dbo].[MusterilerGecici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusterilerGecici];
GO
IF OBJECT_ID(N'[dbo].[MusteriSiparisDetay]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriSiparisDetay];
GO
IF OBJECT_ID(N'[dbo].[MusteriSiparisMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriSiparisMaster];
GO
IF OBJECT_ID(N'[dbo].[MusteriTeklifAktarim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriTeklifAktarim];
GO
IF OBJECT_ID(N'[dbo].[MusteriTeklifDetay]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriTeklifDetay];
GO
IF OBJECT_ID(N'[dbo].[MusteriTeklifMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusteriTeklifMaster];
GO
IF OBJECT_ID(N'[dbo].[Sirketler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sirketler];
GO
IF OBJECT_ID(N'[ASIRGroupDBModelStoreContainer].[Sabitler]', 'U') IS NOT NULL
    DROP TABLE [ASIRGroupDBModelStoreContainer].[Sabitler];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kampanyalar'
CREATE TABLE [dbo].[Kampanyalar] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Tanim] varchar(100)  NOT NULL,
    [Aktif] bit  NOT NULL,
    [Kategoriid] int  NOT NULL,
    [Tedarikciid] int  NOT NULL,
    [KayitTarihi] datetime  NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NOT NULL,
    [Aciklama] varchar(100)  NOT NULL
);
GO

-- Creating table 'KampanyalarGecici'
CREATE TABLE [dbo].[KampanyalarGecici] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Genelid] int  NOT NULL,
    [Tanim] varchar(100)  NOT NULL,
    [Aktif] bit  NOT NULL,
    [Secim] bit  NOT NULL,
    [Kampanyaid] int  NOT NULL,
    [Kategoriid] int  NOT NULL,
    [KayitTarihi] datetime  NULL
);
GO

-- Creating table 'Kategoriler'
CREATE TABLE [dbo].[Kategoriler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Tanim] varchar(50)  NOT NULL,
    [Aktif] bit  NOT NULL,
    [KayitTarihi] datetime  NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NOT NULL
);
GO

-- Creating table 'MusteriKampanyalari'
CREATE TABLE [dbo].[MusteriKampanyalari] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [MKampanyaKodu] varchar(30)  NOT NULL,
    [MKampanyaAdi] varchar(60)  NOT NULL,
    [Musteriid] int  NOT NULL,
    [Tarih1] datetime  NOT NULL,
    [Tarih2] datetime  NOT NULL,
    [Aktif] bit  NOT NULL,
    [KayitTarihi] datetime  NULL,
    [KullaniciKodu] varchar(50)  NOT NULL,
    [DegKayitTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(50)  NOT NULL
);
GO

-- Creating table 'MusterilerGecici'
CREATE TABLE [dbo].[MusterilerGecici] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Genelid] int  NOT NULL,
    [Musteriid] int  NOT NULL,
    [KisaAdi] varchar(30)  NOT NULL,
    [YetkiliSicilNo] varchar(10)  NOT NULL,
    [Secim] bit  NOT NULL,
    [SiparisNo] int  NOT NULL,
    [KayitTarihi] datetime  NULL
);
GO

-- Creating table 'MusteriSiparisDetay'
CREATE TABLE [dbo].[MusteriSiparisDetay] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Masterid] int  NOT NULL,
    [TeklifDetayid] int  NOT NULL,
    [TeklifMasterid] int  NOT NULL,
    [Stokid] int  NOT NULL,
    [SKUKodu] varchar(20)  NOT NULL,
    [Miktar] float  NOT NULL,
    [Fiyat] float  NOT NULL,
    [MalTutari] float  NOT NULL,
    [Isk1] float  NOT NULL,
    [Isk2] float  NOT NULL,
    [TopIskTutari] float  NOT NULL,
    [KdvDahil] bit  NOT NULL,
    [KDVOrani] float  NOT NULL,
    [KdvTutari] float  NOT NULL,
    [AraToplam] float  NOT NULL,
    [GenelToplam] float  NOT NULL,
    [Kapandi] bit  NOT NULL,
    [Aciklama] varchar(100)  NOT NULL,
    [iptalEdildi] bit  NOT NULL,
    [iptalAciklama] varchar(100)  NOT NULL,
    [KayitTarihi] datetime  NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NOT NULL,
    [SevkMiktari] float  NOT NULL,
    [SonSevkTarihi] datetime  NULL,
    [IptalMiktari] float  NOT NULL,
    [IptalMiktari2] float  NOT NULL
);
GO

-- Creating table 'MusteriSiparisMaster'
CREATE TABLE [dbo].[MusteriSiparisMaster] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [SiparisTarihi] datetime  NULL,
    [Musteriid] int  NOT NULL,
    [SiparisTipi] int  NOT NULL,
    [Teklifid] int  NOT NULL,
    [MKampanyaid] int  NOT NULL,
    [MKampanyaKodu] varchar(30)  NOT NULL,
    [YurtIciDisi] varchar(15)  NOT NULL,
    [DovizKod] varchar(3)  NOT NULL,
    [Oncelik] int  NOT NULL,
    [DipIskYuzdelik] bit  NOT NULL,
    [DipIskYuzde] float  NOT NULL,
    [DipIskTutar] float  NOT NULL,
    [VATyuzdelik] bit  NOT NULL,
    [VATyuzde] float  NOT NULL,
    [VATtutar] float  NOT NULL,
    [FreightTutar] float  NOT NULL,
    [SatirIsk1] float  NOT NULL,
    [SatirIsk2] float  NOT NULL,
    [Onay] bit  NOT NULL,
    [OnayTarihi] datetime  NULL,
    [FaturaCariid] int  NOT NULL,
    [FaturaCariKod] varchar(25)  NOT NULL,
    [FaturaCariAdi] varchar(100)  NOT NULL,
    [FaturaAdresi] varchar(200)  NOT NULL,
    [FaturaPostaKodu] varchar(15)  NOT NULL,
    [FaturaIlceSemt] varchar(30)  NOT NULL,
    [FaturaIL] varchar(30)  NOT NULL,
    [FaturaUlke] varchar(30)  NOT NULL,
    [TeslimatAdresi] varchar(200)  NOT NULL,
    [TeslimatPostaKodu] varchar(15)  NOT NULL,
    [TeslimatIlceSemt] varchar(30)  NOT NULL,
    [TeslimatIL] varchar(30)  NOT NULL,
    [TeslimatUlke] varchar(30)  NOT NULL,
    [TeslimatCariid] int  NOT NULL,
    [TeslimatCariKod] varchar(25)  NOT NULL,
    [TeslimatCariAdi] varchar(100)  NOT NULL,
    [KayitTarihi] datetime  NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NOT NULL,
    [Aciklama] varchar(200)  NOT NULL,
    [ExcelGonderildi] bit  NOT NULL,
    [PDFGonderildi] bit  NOT NULL,
    [ExcelMailAcik] varchar(200)  NOT NULL,
    [PDFMailAcik] varchar(200)  NOT NULL,
    [InvoiceNo] varchar(20)  NOT NULL,
    [SatisKodu] varchar(30)  NOT NULL,
    [SatisAdi] varchar(100)  NOT NULL,
    [EFaturaGonder] varchar(15)  NOT NULL,
    [SahisAdi1] varchar(40)  NOT NULL,
    [SahisAdi2] varchar(40)  NOT NULL,
    [SahisSoyadi] varchar(40)  NOT NULL,
    [CariAlias] varchar(255)  NOT NULL,
    [EFaturaDurumAciklamasi] varchar(600)  NOT NULL,
    [EFaturaZardUUID] varchar(40)  NOT NULL,
    [EFaturaAciklama] varchar(750)  NOT NULL,
    [IrsaliyeYOK] bit  NOT NULL,
    [ETTNuuid] uniqueidentifier  NULL,
    [ettnUUIDstr] varchar(50)  NOT NULL,
    [hk_IhracKaydi] varchar(5)  NOT NULL,
    [hk_VergiReasonCode] varchar(20)  NOT NULL,
    [SeriNo] varchar(3)  NOT NULL,
    [BelgeNo] varchar(40)  NOT NULL,
    [EFaturaProfileIDType] varchar(20)  NOT NULL,
    [VergiDairesi] varchar(25)  NOT NULL,
    [VergiNo] varchar(20)  NOT NULL
);
GO

-- Creating table 'MusteriTeklifAktarim'
CREATE TABLE [dbo].[MusteriTeklifAktarim] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Genelid] int  NOT NULL,
    [SKUKodu] varchar(20)  NOT NULL,
    [SatisFiyati] float  NOT NULL,
    [RetailFiyat] float  NOT NULL,
    [Miktar] float  NOT NULL,
    [KayitTarihi] datetime  NOT NULL
);
GO

-- Creating table 'MusteriTeklifDetay'
CREATE TABLE [dbo].[MusteriTeklifDetay] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Masterid] int  NOT NULL,
    [SKUKodu] varchar(20)  NOT NULL,
    [BirTaneicinAlisFiyati] float  NOT NULL,
    [ListeAlisFiyati] float  NOT NULL,
    [SatisFiyati] float  NOT NULL,
    [OzelFiyat] float  NOT NULL,
    [Marj] float  NOT NULL,
    [RetailFiyat] float  NOT NULL,
    [Miktar] float  NOT NULL,
    [Iptal] bit  NOT NULL,
    [KayitTarihi] datetime  NOT NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NULL,
    [TedarikciStogu] float  NOT NULL,
    [AsirStok] float  NOT NULL,
    [BlokeStok] float  NOT NULL,
    [KalanStok] float  NOT NULL,
    [VerilecekStok] float  NOT NULL,
    [UyariMarj] float  NOT NULL,
    [sipdetayid] int  NOT NULL
);
GO

-- Creating table 'MusteriTeklifMaster'
CREATE TABLE [dbo].[MusteriTeklifMaster] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [Musteriid] int  NOT NULL,
    [MKampanyaid] int  NOT NULL,
    [TeklifAdi] varchar(60)  NOT NULL,
    [Opsiyon] int  NOT NULL,
    [DovizKod] varchar(3)  NOT NULL,
    [StokVerildi] bit  NOT NULL,
    [KayitTarihi] datetime  NOT NULL,
    [KullaniciKodu] varchar(20)  NOT NULL,
    [DegisiklikTarihi] datetime  NULL,
    [DegKullaniciKodu] varchar(20)  NOT NULL,
    [sipmasterid] int  NOT NULL,
    [FiyatlariSonraKullanma] bit  NOT NULL
);
GO

-- Creating table 'Sirketler'
CREATE TABLE [dbo].[Sirketler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [SirketKod] varchar(10)  NOT NULL,
    [Sirket_Kod] varchar(10)  NOT NULL,
    [Sira] tinyint  NOT NULL
);
GO

-- Creating table 'Sabitler'
CREATE TABLE [dbo].[Sabitler] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ExcelDosyaYolu] varchar(300)  NOT NULL,
    [Marka] varchar(2)  NOT NULL,
    [UrunBarkodNo] varchar(2)  NOT NULL,
    [SKUKodu] varchar(2)  NOT NULL,
    [StokIsmi] varchar(2)  NOT NULL,
    [Renk] varchar(2)  NOT NULL,
    [StokAciklama] varchar(2)  NOT NULL,
    [Ozellik] varchar(2)  NOT NULL,
    [EkstraOzellik] varchar(2)  NOT NULL,
    [UreticiBarkodNo] varchar(2)  NOT NULL,
    [Aktif] varchar(2)  NOT NULL,
    [KampanyaDosyaIsmi] varchar(2)  NOT NULL,
    [Birim] varchar(2)  NOT NULL,
    [Genelid] int  NOT NULL,
    [AlisFiyati] varchar(2)  NOT NULL,
    [DovizKodu] varchar(2)  NOT NULL,
    [Host] varchar(50)  NOT NULL,
    [Port] int  NOT NULL,
    [Mailusername] varchar(50)  NOT NULL,
    [Mailpassword] varchar(20)  NOT NULL,
    [PuanKatsayi1] float  NOT NULL,
    [PuanKatsayi2] float  NOT NULL,
    [BirKoliUcreti] float  NOT NULL,
    [BirPaletUcreti] float  NOT NULL,
    [BirPaletForkliftUcreti] float  NOT NULL,
    [BirKoliM3] float  NOT NULL,
    [BirPaletM3] float  NOT NULL,
    [BirKoliKG] float  NOT NULL,
    [BirPaletKG] float  NOT NULL,
    [En] varchar(2)  NOT NULL,
    [Boy] varchar(2)  NOT NULL,
    [Yukseklik] varchar(2)  NOT NULL,
    [Agirlik] varchar(2)  NOT NULL,
    [UreticiStokKodu] varchar(2)  NOT NULL,
    [StokBitincePasif] varchar(2)  NOT NULL,
    [KonseptTanim] varchar(2)  NOT NULL,
    [OrtSevkSuresi] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Kampanyalar'
ALTER TABLE [dbo].[Kampanyalar]
ADD CONSTRAINT [PK_Kampanyalar]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'KampanyalarGecici'
ALTER TABLE [dbo].[KampanyalarGecici]
ADD CONSTRAINT [PK_KampanyalarGecici]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Kategoriler'
ALTER TABLE [dbo].[Kategoriler]
ADD CONSTRAINT [PK_Kategoriler]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriKampanyalari'
ALTER TABLE [dbo].[MusteriKampanyalari]
ADD CONSTRAINT [PK_MusteriKampanyalari]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusterilerGecici'
ALTER TABLE [dbo].[MusterilerGecici]
ADD CONSTRAINT [PK_MusterilerGecici]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriSiparisDetay'
ALTER TABLE [dbo].[MusteriSiparisDetay]
ADD CONSTRAINT [PK_MusteriSiparisDetay]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriSiparisMaster'
ALTER TABLE [dbo].[MusteriSiparisMaster]
ADD CONSTRAINT [PK_MusteriSiparisMaster]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriTeklifAktarim'
ALTER TABLE [dbo].[MusteriTeklifAktarim]
ADD CONSTRAINT [PK_MusteriTeklifAktarim]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriTeklifDetay'
ALTER TABLE [dbo].[MusteriTeklifDetay]
ADD CONSTRAINT [PK_MusteriTeklifDetay]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'MusteriTeklifMaster'
ALTER TABLE [dbo].[MusteriTeklifMaster]
ADD CONSTRAINT [PK_MusteriTeklifMaster]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Sirketler'
ALTER TABLE [dbo].[Sirketler]
ADD CONSTRAINT [PK_Sirketler]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [ExcelDosyaYolu], [Marka], [UrunBarkodNo], [SKUKodu], [StokIsmi], [Renk], [StokAciklama], [Ozellik], [EkstraOzellik], [UreticiBarkodNo], [Aktif], [KampanyaDosyaIsmi], [Birim], [Genelid], [AlisFiyati], [DovizKodu], [Host], [Port], [Mailusername], [Mailpassword], [PuanKatsayi1], [PuanKatsayi2], [BirKoliUcreti], [BirPaletUcreti], [BirPaletForkliftUcreti], [BirKoliM3], [BirPaletM3], [BirKoliKG], [BirPaletKG], [En], [Boy], [Yukseklik], [Agirlik], [UreticiStokKodu], [StokBitincePasif], [KonseptTanim], [OrtSevkSuresi] in table 'Sabitler'
ALTER TABLE [dbo].[Sabitler]
ADD CONSTRAINT [PK_Sabitler]
    PRIMARY KEY CLUSTERED ([id], [ExcelDosyaYolu], [Marka], [UrunBarkodNo], [SKUKodu], [StokIsmi], [Renk], [StokAciklama], [Ozellik], [EkstraOzellik], [UreticiBarkodNo], [Aktif], [KampanyaDosyaIsmi], [Birim], [Genelid], [AlisFiyati], [DovizKodu], [Host], [Port], [Mailusername], [Mailpassword], [PuanKatsayi1], [PuanKatsayi2], [BirKoliUcreti], [BirPaletUcreti], [BirPaletForkliftUcreti], [BirKoliM3], [BirPaletM3], [BirKoliKG], [BirPaletKG], [En], [Boy], [Yukseklik], [Agirlik], [UreticiStokKodu], [StokBitincePasif], [KonseptTanim], [OrtSevkSuresi] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kategoriid] in table 'Kampanyalar'
ALTER TABLE [dbo].[Kampanyalar]
ADD CONSTRAINT [FK_Kampanyalar_Kategoriler]
    FOREIGN KEY ([Kategoriid])
    REFERENCES [dbo].[Kategoriler]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kampanyalar_Kategoriler'
CREATE INDEX [IX_FK_Kampanyalar_Kategoriler]
ON [dbo].[Kampanyalar]
    ([Kategoriid]);
GO

-- Creating foreign key on [Masterid] in table 'MusteriTeklifDetay'
ALTER TABLE [dbo].[MusteriTeklifDetay]
ADD CONSTRAINT [FK_MusteriTeklifDetay_MusteriTeklifMaster]
    FOREIGN KEY ([Masterid])
    REFERENCES [dbo].[MusteriTeklifMaster]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusteriTeklifDetay_MusteriTeklifMaster'
CREATE INDEX [IX_FK_MusteriTeklifDetay_MusteriTeklifMaster]
ON [dbo].[MusteriTeklifDetay]
    ([Masterid]);
GO

-- Creating foreign key on [Masterid] in table 'MusteriTeklifDetay'
ALTER TABLE [dbo].[MusteriTeklifDetay]
ADD CONSTRAINT [FK_TeklifDetay_TeklifMaster]
    FOREIGN KEY ([Masterid])
    REFERENCES [dbo].[MusteriTeklifMaster]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeklifDetay_TeklifMaster'
CREATE INDEX [IX_FK_TeklifDetay_TeklifMaster]
ON [dbo].[MusteriTeklifDetay]
    ([Masterid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------