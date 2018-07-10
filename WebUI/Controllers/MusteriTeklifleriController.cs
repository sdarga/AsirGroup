using BL.Data;
using Core.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebUI.Controllers
{
    [Authorize]
    public class MusteriTeklifleriController : Controller
    {
        private ASIRGroupDBEntities db = new ASIRGroupDBEntities();

        public MusteriTeklifleriController()
        {
        }

        public ActionResult Index()
        {
            return base.View();
        }

        public ActionResult MusteriKampanyaTeklifiDuzenle(int masterid, string seciliKampanyalar)
        {
            ActionResult actionResult;
            try
            {
                List<int> seciliKampanyaIDleri = (List<int>)(new JavaScriptSerializer()).Deserialize(seciliKampanyalar, typeof(List<int>));
                string genelID = base.Session["genelID"].ToString();
                string filtre = base.Session["filtre"].ToString();
                List<StokKartAramaWeb_Result> list = this.db.StokKartAramaWeb("1", new int?(Convert.ToInt32(genelID)), filtre, new bool?(false), new bool?(false),"", Session["WebKullaniciNo"].ToString()).ToList<StokKartAramaWeb_Result>();
                foreach (int seciliKampanyaID in seciliKampanyaIDleri)
                {
                    using (ASIRGroupDBEntities aSIRGroupDBEntity = new ASIRGroupDBEntities())
                    {
                        StokKartAramaWebDTO stokKartAramaWebDTO = (
                            from item in list
                            select new StokKartAramaWebDTO()
                            {
                                id = item.id,
                                Sirket_Kod = item.Sirket_Kod,
                                SKUKodu = item.SKUKodu,
                                Marka = item.Marka,
                                Birim = item.Birim,
                                UreticiBarkodNo = item.UreticiBarkodNo,
                                UrunBarkodNo = item.UrunBarkodNo,
                                StokIsmi = item.StokIsmi,
                                Aktif = item.Aktif,
                                Ozellik = item.Ozellik,
                                StokBitincePasif = item.StokBitincePasif,
                                EkstraOzellik = item.EkstraOzellik,
                                Renk = item.Renk,
                                KayitTarihi = item.KayitTarihi,
                                KullaniciKodu = item.KullaniciKodu,
                                Kampanyaid = item.Kampanyaid,
                                Aciklamaid = item.Aciklamaid,
                                DegisiklikTarihi = item.DegisiklikTarihi,
                                DegKullaniciKodu = item.DegKullaniciKodu,
                                AlisFiyati = item.AlisFiyati,
                                DovizKodu = item.DovizKodu,
                                GercekAlisFiyati = item.GercekAlisFiyati,
                                En = item.En,
                                Boy = item.Boy,
                                Yukseklik = item.Yukseklik,
                                Agirlik = item.Agirlik,
                                Puan = item.Puan,
                                KampanyaPuan = item.KampanyaPuan,
                                UreticiStokKodu = item.UreticiStokKodu,
                                KampanyaDosyaIsmi = item.KampanyaDosyaIsmi,
                                Sira = item.Sira,
                                StokAciklama = item.StokAciklama,
                                StokTurkceAciklama = item.StokTurkceAciklama,
                                Konseptid = item.Konseptid,
                                KonseptTanim = item.KonseptTanim,
                                TedarikciAdi = item.TedarikciAdi,
                                FizikiStok = item.FizikiStok,
                                MusAcikSipMik = item.MusAcikSipMik,
                                AsirStokMik = item.AsirStokMik,
                                BlokeStokMik = item.BlokeStokMik,
                                TedStokMik = item.TedStokMik,
                                TedAcikSipMik = item.TedAcikSipMik,
                                AktarMik = item.AktarMik,
                                AlisKDVOrani = item.AlisKDVOrani,
                                SatisKDVOrani = item.SatisKDVOrani
                            } into w
                            where w.id == seciliKampanyaID
                            select w).FirstOrDefault<StokKartAramaWebDTO>();
                        if ((from w in aSIRGroupDBEntity.MusteriTeklifDetay
                             where w.SKUKodu == stokKartAramaWebDTO.SKUKodu && w.Masterid == masterid
                             select w).Count<MusteriTeklifDetay>() <= 0)
                        {
                            MusteriTeklifDetay musteriTeklifDetay = new MusteriTeklifDetay()
                            {
                                Sirket_Kod = stokKartAramaWebDTO.Sirket_Kod,
                                Masterid = masterid,
                                SKUKodu = stokKartAramaWebDTO.SKUKodu,
                                BirTaneicinAlisFiyati = stokKartAramaWebDTO.GercekAlisFiyati,
                                ListeAlisFiyati = stokKartAramaWebDTO.AlisFiyati,
                                SatisFiyati = 0,
                                OzelFiyat = 0,
                                Marj = 0,
                                RetailFiyat = 0,
                                Miktar = 0,
                                Iptal = false,
                                KayitTarihi = DateTime.Now,
                                KullaniciKodu = stokKartAramaWebDTO.KullaniciKodu,
                                DegisiklikTarihi = stokKartAramaWebDTO.DegisiklikTarihi,
                                DegKullaniciKodu = stokKartAramaWebDTO.DegKullaniciKodu,
                                TedarikciStogu = 0,
                                AsirStok = 0,
                                BlokeStok = 0,
                                KalanStok = 0,
                                VerilecekStok = 0,
                                UyariMarj = 0,
                                sipdetayid = 0
                            };
                            aSIRGroupDBEntity.MusteriTeklifDetay.Add(musteriTeklifDetay);
                            aSIRGroupDBEntity.SaveChanges();
                            base.Session["musteriTeklifMasterID"] = masterid;
                        }
                    }
                }
                actionResult = base.Json(seciliKampanyalar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return actionResult;
        }

        public ActionResult MusteriKampanyaTeklifiOlustur(string seciliKampanyalar, string musteriKampanyalari)
        {
            ActionResult actionResult;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                MusteriKampanyalari musteriKampanyalari1 = (MusteriKampanyalari)javaScriptSerializer.Deserialize(musteriKampanyalari, typeof(MusteriKampanyalari));
                List<int> ınt32s = (List<int>)javaScriptSerializer.Deserialize(seciliKampanyalar, typeof(List<int>));
                MusteriTeklifMaster musteriTeklifMaster = new MusteriTeklifMaster()
                {
                    Sirket_Kod = musteriKampanyalari1.Sirket_Kod,
                    Tarih = DateTime.Now,
                    Musteriid = musteriKampanyalari1.Musteriid,
                    MKampanyaid = 0,
                    TeklifAdi = musteriKampanyalari1.MKampanyaAdi,
                    Opsiyon = 0,
                    DovizKod = (
                        from w in this.db.CariKart
                        where w.id == musteriKampanyalari1.Musteriid
                        select w into s
                        select s.DovizKod).FirstOrDefault<string>(),
                    StokVerildi = false,
                    KayitTarihi = DateTime.Now,
                    KullaniciKodu = musteriKampanyalari1.KullaniciKodu,
                    Webden = true,
                    DegKullaniciKodu = "",
                    sipmasterid = 0,
                    FiyatlariSonraKullanma = true
                };
                this.db.MusteriTeklifMaster.Add(musteriTeklifMaster);
                this.db.SaveChanges();
                string str = base.Session["genelID"].ToString();
                string str1 = base.Session["filtre"].ToString();
                List<StokKartAramaWeb_Result> list = this.db.StokKartAramaWeb("1", new int?(Convert.ToInt32(str)), str1, new bool?(false), new bool?(false),"", Session["WebKullaniciNo"].ToString()).ToList<StokKartAramaWeb_Result>();
                foreach (int ınt32 in ınt32s)
                {
                    using (ASIRGroupDBEntities aSIRGroupDBEntity = new ASIRGroupDBEntities())
                    {
                        StokKartAramaWebDTO stokKartAramaWebDTO = (
                            from item in list
                            select new StokKartAramaWebDTO()
                            {
                                id = item.id,
                                Sirket_Kod = item.Sirket_Kod,
                                SKUKodu = item.SKUKodu,
                                Marka = item.Marka,
                                Birim = item.Birim,
                                UreticiBarkodNo = item.UreticiBarkodNo,
                                UrunBarkodNo = item.UrunBarkodNo,
                                StokIsmi = item.StokIsmi,
                                Aktif = item.Aktif,
                                Ozellik = item.Ozellik,
                                StokBitincePasif = item.StokBitincePasif,
                                EkstraOzellik = item.EkstraOzellik,
                                Renk = item.Renk,
                                KayitTarihi = item.KayitTarihi,
                                KullaniciKodu = item.KullaniciKodu,
                                Kampanyaid = item.Kampanyaid,
                                Aciklamaid = item.Aciklamaid,
                                DegisiklikTarihi = item.DegisiklikTarihi,
                                DegKullaniciKodu = item.DegKullaniciKodu,
                                AlisFiyati = item.AlisFiyati,
                                DovizKodu = item.DovizKodu,
                                GercekAlisFiyati = item.GercekAlisFiyati,
                                En = item.En,
                                Boy = item.Boy,
                                Yukseklik = item.Yukseklik,
                                Agirlik = item.Agirlik,
                                Puan = item.Puan,
                                KampanyaPuan = item.KampanyaPuan,
                                UreticiStokKodu = item.UreticiStokKodu,
                                KampanyaDosyaIsmi = item.KampanyaDosyaIsmi,
                                Sira = item.Sira,
                                StokAciklama = item.StokAciklama,
                                StokTurkceAciklama = item.StokTurkceAciklama,
                                Konseptid = item.Konseptid,
                                KonseptTanim = item.KonseptTanim,
                                TedarikciAdi = item.TedarikciAdi,
                                FizikiStok = item.FizikiStok,
                                MusAcikSipMik = item.MusAcikSipMik,
                                AsirStokMik = item.AsirStokMik,
                                BlokeStokMik = item.BlokeStokMik,
                                TedStokMik = item.TedStokMik,
                                TedAcikSipMik = item.TedAcikSipMik,
                                AktarMik = item.AktarMik,
                                AlisKDVOrani = item.AlisKDVOrani,
                                SatisKDVOrani = item.SatisKDVOrani
                            } into w
                            where w.id == ınt32
                            select w).FirstOrDefault<StokKartAramaWebDTO>();
                        if (stokKartAramaWebDTO != null)
                        {
                            MusteriTeklifDetay musteriTeklifDetay = new MusteriTeklifDetay()
                            {
                                Sirket_Kod = stokKartAramaWebDTO.Sirket_Kod,
                                Masterid = musteriTeklifMaster.id,
                                SKUKodu = stokKartAramaWebDTO.SKUKodu,
                                BirTaneicinAlisFiyati = stokKartAramaWebDTO.GercekAlisFiyati,
                                ListeAlisFiyati = stokKartAramaWebDTO.AlisFiyati,
                                SatisFiyati = 0,
                                OzelFiyat = 0,
                                Marj = 0,
                                RetailFiyat = 0,
                                Miktar = 0,
                                Iptal = false,
                                KayitTarihi = DateTime.Now,
                                KullaniciKodu = stokKartAramaWebDTO.KullaniciKodu,
                                DegisiklikTarihi = stokKartAramaWebDTO.DegisiklikTarihi,
                                DegKullaniciKodu = stokKartAramaWebDTO.DegKullaniciKodu,
                                TedarikciStogu = 0,
                                AsirStok = 0,
                                BlokeStok = 0,
                                KalanStok = 0,
                                VerilecekStok = 0,
                                UyariMarj = 0,
                                sipdetayid = 0
                            };
                            aSIRGroupDBEntity.MusteriTeklifDetay.Add(musteriTeklifDetay);
                            aSIRGroupDBEntity.SaveChanges();
                            base.Session["musteriTeklifMasterID"] = musteriTeklifMaster.id;
                        }
                    }
                }
                actionResult = base.Json(seciliKampanyalar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return actionResult;
        }

        public ActionResult MusteriTeklifDetayGetir([DataSourceRequest] DataSourceRequest request, int masterID)
        {
            ActionResult actionResult;
            try
            {
                try
                {
                    this.db.Database.Connection.Open();
                    using (this.db.Database.Connection)
                    {
                        SqlCommand sqlCommand = new SqlCommand()
                        {
                            Connection = (SqlConnection)this.db.Database.Connection,
                            CommandText = string.Concat(new object[] 
                            {
                                " Set nocount on " +
                                " Set Dateformat dmy" +
                                " Declare @DovizKod varchar(10), @Tarih smalldatetime" +
                                " Declare @sp_Sirket_Kod varchar(10), @spMasterid int" +
                                " select s.SKUKodu, s.StokIsmi, s.Marka, s.UrunBarkodNo, " +
                                " s.Ozellik, s.EkstraOzellik, s.Renk, " +
                                " s.AlisFiyati, s.Puan, s.En, s.Boy, s.Yukseklik, " +
                                " s.Agirlik, s.DovizKodu, s.UreticiBarkodNo, s.UreticiStokKodu,                                                                                              " +
                                " isnull((select Tanim from Kampanyalar where Sirket_Kod = s.Sirket_Kod and id = s.Kampanyaid), '') KampanyaDosyaIsmi,                                       " +
                                " isnull((select StokAciklama from StokKartiTanim where Sirket_Kod = s.Sirket_Kod and id = s.Aciklamaid),'') StokAciklama                                 " +
                                " into #Stok                                                                                                                                             " +
                                " from StokKarti s where s.Sirket_Kod = 1 and                                                                                                                           " +
                                " exists(select id from MusteriTeklifDetay where Sirket_Kod = s.Sirket_Kod and SKUKodu = s.SKUKodu and Masterid = ", masterID, " )" +
                                " set @DovizKod = '???'                                                                                                                                      " +
                                " Select @DovizKod = DovizKod, @Tarih = Tarih  from MusteriTeklifMaster Where id = ", masterID, "" +
                                " select @DovizKod DovizKod, d.*,                                                                                                                                                       " +
                                " isnull(s.StokIsmi, '') StokIsmi,                                                                                                                           " +
                                " isnull(s.Marka, '') Marka,                                                                                                                                 " +
                                " isnull(s.UrunBarkodNo, '') UrunBarkodNo,                                                                                                                   " +
                                " isnull(s.UreticiBarkodNo, '') UreticiBarkodNo,                                                                                                             " +
                                " isnull(s.UreticiStokKodu, '') UreticiStokKodu,                                                                                                             " +
                                " isnull(s.StokAciklama, '') StokAciklama,                                                                                                                   " +
                                " isnull(s.KampanyaDosyaIsmi, '') KampanyaDosyaIsmi,                                                                                                         " +
                                " isnull(s.Ozellik, '') Ozellik,                                                                                                                             " +
                                " isnull(s.EkstraOzellik, '') EkstraOzellik,                                                                                                                 " +
                                " isnull(s.Renk, '') Renk,                                                                                                                                   " +
                                " isnull(s.Puan, 0) Puan,                                                                                                                                    " +
                                " isnull(s.En, 0) En,                                                                                                                                        " +
                                " isnull(s.Boy, 0) Boy,                                                                                                                                      " +
                                " isnull(s.Yukseklik, 0) Yukseklik,                                                                                                                          " +
                                " isnull(s.Agirlik, 0) Agirlik,                                                                                                                              " +
                                " dbo.KonseptGetir(d.Sirket_Kod, d.SKUKodu) KonseptTanim,                                                                                                    " +
                                " round(isnull(s.AlisFiyati, 0) * dbo.DovizKuruBul(@Tarih, isnull(s.DovizKodu, 'TRL'), 'TRL'), 2) as AlisFiyatiTL                                         " +
                                " from MusteriTeklifDetay d inner                                                                                                                            " +
                                " join #Stok s on d.SKUKodu=s.SKUKodu                                                                                                                        " +
                                " where d.Masterid =  ", masterID, "  " +
                                " order by s.KampanyaDosyaIsmi,  s.AlisFiyati, s.Marka, s.StokAciklama, s.StokIsmi "
                            })
                        };
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (sqlDataReader != null)
                        {
                            List<MusteriTeklifDetayDTO> musteriTeklifDetayDTOs = new List<MusteriTeklifDetayDTO>();
                            while (sqlDataReader.Read())
                            {
                                musteriTeklifDetayDTOs.Add(new MusteriTeklifDetayDTO()
                                {
                                    DovizKod = (string)sqlDataReader["DovizKod"],
                                    id = (int)sqlDataReader["id"],
                                    Sirket_Kod = (string)sqlDataReader["Sirket_Kod"],
                                    Masterid = (int)sqlDataReader["Masterid"],
                                    SKUKodu = (string)sqlDataReader["SKUKodu"],
                                    BirTaneicinAlisFiyati = (sqlDataReader["BirTaneicinAlisFiyati"] == null ? 0 : (double)sqlDataReader["BirTaneicinAlisFiyati"]),
                                    ListeAlisFiyati = (sqlDataReader["ListeAlisFiyati"] == null ? 0 : (double)sqlDataReader["ListeAlisFiyati"]),
                                    SatisFiyati = (sqlDataReader["SatisFiyati"] == null ? 0 : (double)sqlDataReader["SatisFiyati"]),
                                    OzelFiyat = (sqlDataReader["OzelFiyat"] == null ? 0 : (double)sqlDataReader["OzelFiyat"]),
                                    Marj = (sqlDataReader["Marj"] == null ? 0 : (double)sqlDataReader["Marj"]),
                                    RetailFiyat = (sqlDataReader["RetailFiyat"] == null ? 0 : (double)sqlDataReader["RetailFiyat"]),
                                    Miktar = (sqlDataReader["Miktar"] == null ? 0 : (double)sqlDataReader["Miktar"]),
                                    Iptal = (bool)sqlDataReader["Iptal"],
                                    KayitTarihi = (sqlDataReader["KayitTarihi"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["KayitTarihi"]),
                                    KullaniciKodu = (string)sqlDataReader["KullaniciKodu"],
                                    DegisiklikTarihi = new DateTime?((sqlDataReader["DegisiklikTarihi"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["DegisiklikTarihi"])),
                                    DegKullaniciKodu = (string)sqlDataReader["DegKullaniciKodu"],
                                    TedarikciStogu = (sqlDataReader["TedarikciStogu"] == null ? 0 : (double)sqlDataReader["TedarikciStogu"]),
                                    AsirStok = (sqlDataReader["AsirStok"] == null ? 0 : (double)sqlDataReader["AsirStok"]),
                                    BlokeStok = (sqlDataReader["BlokeStok"] == null ? 0 : (double)sqlDataReader["BlokeStok"]),
                                    KalanStok = (sqlDataReader["KalanStok"] == null ? 0 : (double)sqlDataReader["KalanStok"]),
                                    VerilecekStok = (sqlDataReader["VerilecekStok"] == null ? 0 : (double)sqlDataReader["VerilecekStok"]),
                                    UyariMarj = (sqlDataReader["UyariMarj"] == null ? 0 : (double)sqlDataReader["UyariMarj"]),
                                    sipdetayid = (int)sqlDataReader["sipdetayid"],
                                    Marka = (string)sqlDataReader["Marka"],
                                    UreticiBarkodNo = (string)sqlDataReader["UreticiBarkodNo"],
                                    UrunBarkodNo = (string)sqlDataReader["UrunBarkodNo"],
                                    StokIsmi = (string)sqlDataReader["StokIsmi"],
                                    StokAciklama = (string)sqlDataReader["StokAciklama"],
                                    Ozellik = (string)sqlDataReader["Ozellik"],
                                    EkstraOzellik = (string)sqlDataReader["EkstraOzellik"],
                                    Renk = (string)sqlDataReader["Renk"],
                                    AlisFiyatiTL = (sqlDataReader["AlisFiyatiTL"] == null ? 0 : (double)sqlDataReader["AlisFiyatiTL"]),
                                    En = (sqlDataReader["En"] == null ? 0 : (double)sqlDataReader["En"]),
                                    Boy = (sqlDataReader["AlisFiyatiTL"] == null ? 0 : (double)sqlDataReader["AlisFiyatiTL"]),
                                    Yukseklik = (sqlDataReader["Yukseklik"] == null ? 0 : (double)sqlDataReader["Yukseklik"]),
                                    Agirlik = (sqlDataReader["Agirlik"] == null ? 0 : (double)sqlDataReader["Agirlik"]),
                                    Puan = (sqlDataReader["Puan"] == null ? 0 : (double)sqlDataReader["Puan"]),
                                    UreticiStokKodu = (string)sqlDataReader["UreticiStokKodu"],
                                    KonseptTanim = (string)sqlDataReader["KonseptTanim"]
                                });
                            }
                            sqlDataReader.Close();
                            JsonResult nullable = base.Json(musteriTeklifDetayDTOs.OrderByDescending(o=>o.id).ToDataSourceResult(request, (MusteriTeklifDetayDTO p) => new { DovizKod = p.DovizKod, id = p.id, Sirket_Kod = p.Sirket_Kod, Masterid = p.Masterid, SKUKodu = p.SKUKodu, BirTaneicinAlisFiyati = p.BirTaneicinAlisFiyati, ListeAlisFiyati = p.ListeAlisFiyati, SatisFiyati = p.SatisFiyati, OzelFiyat = p.OzelFiyat, Marj = p.Marj, RetailFiyat = p.RetailFiyat, Miktar = p.Miktar, Iptal = p.Iptal, KayitTarihi = p.KayitTarihi, KullaniciKodu = p.KullaniciKodu, DegisiklikTarihi = p.DegisiklikTarihi, DegKullaniciKodu = p.DegKullaniciKodu, TedarikciStogu = p.TedarikciStogu, AsirStok = p.AsirStok, BlokeStok = p.BlokeStok, KalanStok = p.KalanStok, VerilecekStok = p.VerilecekStok, UyariMarj = p.UyariMarj, sipdetayid = p.sipdetayid, Marka = p.Marka, UreticiBarkodNo = p.UreticiBarkodNo, UrunBarkodNo = p.UrunBarkodNo, StokIsmi = p.StokIsmi, StokAciklama = p.StokAciklama, Ozellik = p.Ozellik, EkstraOzellik = p.EkstraOzellik, Renk = p.Renk, AlisFiyatiTL = p.AlisFiyatiTL, En = p.En, Boy = p.Boy, Yukseklik = p.Yukseklik, Agirlik = p.Agirlik, Puan = p.Puan, UreticiStokKodu = p.UreticiStokKodu, KonseptTanim = p.KonseptTanim }), JsonRequestBehavior.AllowGet);
                            nullable.MaxJsonLength = new int?(2147483647);
                            actionResult = nullable;
                        }
                        else
                        {
                            actionResult = null;
                        }
                    }
                }
                catch (SqlException sqlException)
                {
                    throw;
                }
            }
            finally
            {
                this.db.Database.Connection.Close();
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult MusteriTeklifDetaySil(int id)
        {
            ActionResult actionResult;
            try
            {
                if (id != 0)
                {
                    try
                    {
                        using (ASIRGroupDBEntities aSIRGroupDBEntity = new ASIRGroupDBEntities())
                        {
                            MusteriTeklifDetay musteriTeklifDetay = (
                                from q in aSIRGroupDBEntity.MusteriTeklifDetay
                                where q.id == id
                                select q).FirstOrDefault<MusteriTeklifDetay>();
                            if (musteriTeklifDetay != null)
                            {
                                aSIRGroupDBEntity.MusteriTeklifDetay.Remove(musteriTeklifDetay);
                                aSIRGroupDBEntity.SaveChanges();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
                actionResult = base.Json(new RequestResult()
                {
                    Success = true
                });
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return actionResult;
        }

    //    public ActionResult MusteriTeklifleriGetir([DataSourceRequest] DataSourceRequest request)
    //    {
    //        MusteriTeklifleriController.<> c__DisplayClass4_0 variable = null;
    //        Convert.ToInt32(base.Session["musteriTeklifMasterID"]);
    //        DbSet<MusteriTeklifDetay> musteriTeklifDetay = this.db.MusteriTeklifDetay;
    //        ParameterExpression parameterExpression = Expression.Parameter(typeof(MusteriTeklifDetay), "w");
    //        IQueryable<MusteriTeklifDetay> musteriTeklifDetays = musteriTeklifDetay.Where<MusteriTeklifDetay>(Expression.Lambda<Func<MusteriTeklifDetay, bool>>(Expression.Equal(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_Masterid").MethodHandle)), Expression.Field(Expression.Constant(variable, typeof(MusteriTeklifleriController.<> c__DisplayClass4_0)), FieldInfo.GetFieldFromHandle(typeof(MusteriTeklifleriController.<> c__DisplayClass4_0).GetField("masterID").FieldHandle))), new ParameterExpression[] { parameterExpression }));
    //        parameterExpression = Expression.Parameter(typeof(MusteriTeklifDetay), "p");
    //        ConstructorInfo methodFromHandle = (ConstructorInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod(".ctor", new Type[] { typeof(u003cidu003ej__TPar), typeof(u003cSirket_Kodu003ej__TPar), typeof(u003cMasterIDu003ej__TPar), typeof(u003cSKUKoduu003ej__TPar), typeof(u003cListeAlisFiyatiu003ej__TPar), typeof(u003cSatisFiyatiu003ej__TPar), typeof(u003cTeklifAdiu003ej__TPar) }).MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle);
    //        Expression[] expressionArray = new Expression[] { Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_id").MethodHandle)), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_Sirket_Kod").MethodHandle)), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_Masterid").MethodHandle)), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_SKUKodu").MethodHandle)), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_ListeAlisFiyati").MethodHandle)), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_SatisFiyati").MethodHandle)), Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifDetay).GetMethod("get_MusteriTeklifMaster").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(MusteriTeklifMaster).GetMethod("get_TeklifAdi").MethodHandle)) };
    //        MemberInfo[] memberInfoArray = new MemberInfo[] { (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_id").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_Sirket_Kod").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_MasterID").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_SKUKodu").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_ListeAlisFiyati").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_SatisFiyati").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).GetMethod("get_TeklifAdi").MethodHandle, typeof(<> f__AnonymousType9<int, string, int, string, double, double, string>).TypeHandle) };
    //    var list = musteriTeklifDetays.Select(Expression.Lambda(Expression.New(methodFromHandle, (IEnumerable<Expression>)expressionArray, memberInfoArray), new ParameterExpression[] { parameterExpression })).ToList();
    //        return base.Json(list.ToDataSourceResult(request, (p) => new { id = p.id, Sirket_Kod = p.Sirket_Kod, MasterID = p.MasterID, SKUKodu = p.SKUKodu, ListeAlisFiyati = p.ListeAlisFiyati, SatisFiyati = p.SatisFiyati, TeklifAdi = p.TeklifAdi
    //}), JsonRequestBehavior.AllowGet);
    //    }

public ActionResult MusteriTeklifMasterGetir([DataSourceRequest] DataSourceRequest request, string baslangicTarihi = "", string bitisTarihi = "")
{
    ActionResult actionResult;
    int ınt32 = 0;
    string str = "";
    if (baslangicTarihi != "" && bitisTarihi != "")
    {
        str = string.Concat(new string[] { "where MKampanyaTarih1 >= '", baslangicTarihi.Split(new char[] { '-' })[2], "-", baslangicTarihi.Split(new char[] { '-' })[1], "-", baslangicTarihi.Split(new char[] { '-' })[0], "' and MKampanyaTarih2 <= '", bitisTarihi.Split(new char[] { '-' })[2], "-", bitisTarihi.Split(new char[] { '-' })[1], "-", bitisTarihi.Split(new char[] { '-' })[0], "'" });
    }
    Convert.ToInt32(base.Session["musteriTeklifMasterID"]);
    try
    {
        try
        {
            this.db.Database.Connection.Open();
            using (this.db.Database.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand()
                {
                    Connection = (SqlConnection)this.db.Database.Connection,
                    CommandText = string.Concat(new string[] { "select * from (select m.*,  isnull((select MKampanyaKodu from MusteriKampanyalari where id = m.MKampanyaid), '') MKampanyaKodu,  isnull((select MKampanyaAdi from MusteriKampanyalari where id = m.MKampanyaid),m.TeklifAdi) MKampanyaAdi,  (select Tarih1 from MusteriKampanyalari where id = m.MKampanyaid) MKampanyaTarih1,  (select Tarih2 from MusteriKampanyalari where id = m.MKampanyaid) MKampanyaTarih2,  cast(case when exists(select id from MusteriSiparisMaster where Teklifid = m.id) then 1 else 0 end as bit) SiparisiGeldi  from MusteriTeklifMaster m  where m.Musteriid = ", base.Session["userID"].ToString(), " and m.Webden = 1 and m.KullaniciKodu = '", base.Session["WebKullaniciNo"].ToString(), "') s ", str, " order by Tarih desc, id" })
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (sqlDataReader != null)
                {
                    List<MusteriTeklifMasterDTO> musteriTeklifMasterDTOs = new List<MusteriTeklifMasterDTO>();
                    while (sqlDataReader.Read())
                    {
                        musteriTeklifMasterDTOs.Add(new MusteriTeklifMasterDTO()
                        {
                            id = (int)sqlDataReader["id"],
                            Tarih = new DateTime?((sqlDataReader["Tarih"] == null ? DateTime.Now : (DateTime)sqlDataReader["Tarih"])),
                            MKampanyaKodu = (string)sqlDataReader["MKampanyaKodu"],
                            Sirket_Kod = (string)sqlDataReader["Sirket_Kod"],
                            MKampanyaAdi = (string)sqlDataReader["MKampanyaAdi"],
                            MKampanyaTarih1 = new DateTime?((sqlDataReader["MKampanyaTarih1"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["MKampanyaTarih1"])),
                            MKampanyaTarih2 = new DateTime?((sqlDataReader["MKampanyaTarih2"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["MKampanyaTarih2"])),
                            StokVerildi = (bool)sqlDataReader["StokVerildi"],
                            SiparisiGeldi = (bool)sqlDataReader["SiparisiGeldi"]
                        });
                    }
                    sqlDataReader.Close();
                    DataSourceResult dataSourceResult = musteriTeklifMasterDTOs.ToDataSourceResult(request, (MusteriTeklifMasterDTO p) => new { MasterID = p.id, Tarih = p.Tarih, MKampanyaKodu = p.MKampanyaKodu, Sirket_Kod = p.Sirket_Kod, MKampanyaAdi = p.MKampanyaAdi, MKampanyaTarih1 = p.MKampanyaTarih1, MKampanyaTarih2 = p.MKampanyaTarih2, StokVerildi = p.StokVerildi, SiparisiGeldi = p.SiparisiGeldi });
                    dataSourceResult.Total = ınt32;
                    actionResult = base.Json(dataSourceResult, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    actionResult = null;
                }
            }
        }
        catch (SqlException sqlException)
        {
            throw;
        }
    }
    finally
    {
        this.db.Database.Connection.Close();
    }
    return actionResult;
}

[HttpPost]
public ActionResult MusteriTeklifMasterSil(int id)
{
    ActionResult actionResult;
    try
    {
        if (id != 0)
        {
            try
            {
                using (ASIRGroupDBEntities aSIRGroupDBEntity = new ASIRGroupDBEntities())
                {
                    List<MusteriTeklifDetay> list = (
                        from w in aSIRGroupDBEntity.MusteriTeklifDetay
                        where w.Masterid == id
                        select w).ToList<MusteriTeklifDetay>();
                    if (list != null)
                    {
                        aSIRGroupDBEntity.MusteriTeklifDetay.RemoveRange(list);
                        aSIRGroupDBEntity.SaveChanges();
                    }
                    MusteriTeklifMaster musteriTeklifMaster = (
                        from q in aSIRGroupDBEntity.MusteriTeklifMaster
                        where q.id == id
                        select q).FirstOrDefault<MusteriTeklifMaster>();
                    if (musteriTeklifMaster != null)
                    {
                        aSIRGroupDBEntity.MusteriTeklifMaster.Remove(musteriTeklifMaster);
                        aSIRGroupDBEntity.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        actionResult = base.Json(new RequestResult()
        {
            Success = true
        }, JsonRequestBehavior.AllowGet);
    }
    catch (Exception exception1)
    {
        throw exception1;
    }
    return actionResult;
}

public ActionResult SatisFiyatiSorgula([DataSourceRequest] DataSourceRequest request, int? masterID)
{
    DbSet<MusteriTeklifDetay> musteriTeklifDetay = this.db.MusteriTeklifDetay;
    bool flag = false;
    flag = ((
        from w in musteriTeklifDetay
        where (int?)w.Masterid == masterID && w.SatisFiyati > 0
        select w).ToList<MusteriTeklifDetay>().Count<MusteriTeklifDetay>() <= 0 ? false : true);
    return base.Json(flag, JsonRequestBehavior.AllowGet);
}
    }
}