using BL.Data;
using BL.Repository;
using Core.Dtos;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class KampanyalarController : Controller
    {
        ASIRGroupDBEntities db = new ASIRGroupDBEntities();

        KampanyalarRepo kampanyalarRepo = new KampanyalarRepo();
        SabitlerRepo sabitlerRepo = new SabitlerRepo();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DescriptionGetir([DataSourceRequest] DataSourceRequest request)
        {
            JsonResult jsonResult;
            try
            {
                int genelID = (int)base.Session["genelID"];
                List<jsTree> jsTrees = new List<jsTree>();
                jsTree _jsTree = new jsTree();
                this.db.Database.Connection.Open();
                using (this.db.Database.Connection)
                {
                    SqlDataReader sqlDataReader = (new SqlCommand()
                    {
                        Connection = (SqlConnection)this.db.Database.Connection,
                        CommandText = string.Concat("Set nocount on Set Dateformat dmy " +
                        "IF OBJECT_ID('tempdb..#Description') IS NOT NULL begin drop table #Description end " +
                        "Declare @sp_Sirket_Kod varchar(10)=1 Declare @spGenelid int = ", genelID.ToString(), 
                        " Declare @spSecim bit = 1 " +
                        "Declare @spTeklifMasterid int= 0 " +
                        "select s.Aciklamaid, t.StokAciklama, g.Kategoriid, g.Kampanyaid into #Description from StokKarti s " +
                        "inner join KampanyalarGecici g on g.Genelid=@spGenelid and g.Kampanyaid=s.Kampanyaid and g.Secim=1 " +
                        "inner join StokKartiTanim t on t.Sirket_Kod = s.Sirket_Kod and t.id = s.Aciklamaid where s.Sirket_Kod = @sp_Sirket_Kod  " +
                        "group by s.Aciklamaid, t.StokAciklama, g.Kategoriid, g.Kampanyaid " +
                        "Delete DescriptionGecici " +
                        "where Genelid = @spGenelid and not exists(select * from #Description where Aciklamaid=DescriptionGecici.Aciklamaid)                                                                                                                                                                                                                                                insert into DescriptionGecici(Genelid, Kategoriid, KategoriAciklama, Aciklamaid, StokAciklama, Secim)                                                                 select @spGenelid, t.Kategoriid, isnull((select Tanim from Kategoriler where Sirket_Kod = @sp_Sirket_Kod and id = t.Kategoriid), ''),                                 t.Aciklamaid, t.StokAciklama, @spSecim from #Description t                                                                                                            where not exists(select id from DescriptionGecici where Genelid = @spGenelid and Aciklamaid = t.Aciklamaid)                                                           select DISTINCT g.Genelid, Aciklamaid, StokAciklama, Secim, Kategoriid, KategoriAciklama from DescriptionGecici g where g.Genelid = @spGenelid order by g.KategoriAciklama, g.StokAciklama                                                     ")
                    }).ExecuteReader(CommandBehavior.CloseConnection);

                    if (sqlDataReader != null)
                    {
                        List<KampanyalarDescriptionDTO> kampanyalarDescriptionDTOs = new List<KampanyalarDescriptionDTO>();
                        while (sqlDataReader.Read())
                        {
                            kampanyalarDescriptionDTOs.Add(new KampanyalarDescriptionDTO()
                            {
                                Genelid = (int)sqlDataReader["Genelid"],
                                Aciklamaid = (int)sqlDataReader["Aciklamaid"],
                                StokAciklama = (string)sqlDataReader["StokAciklama"],
                                Secim = (bool)sqlDataReader["Secim"],
                                Kategoriid = (int)sqlDataReader["Kategoriid"],
                                KategoriAciklama = (string)sqlDataReader["KategoriAciklama"]
                            });
                        }
                        sqlDataReader.Close();

                        foreach (var kategori in kampanyalarDescriptionDTOs
                            .GroupBy(group => group.Kategoriid)
                            .Select(select => new { key = select.Key, item = select.ToList() }))
                        {
                            _jsTree = new jsTree()
                            {
                                id = string.Concat("*", kategori.key),
                                text = kategori.item.Select(s=>s.KategoriAciklama).FirstOrDefault(),
                                parent = "#",
                                state = new jsTree_state()
                                {
                                    opened = false,
                                    disabled = false,
                                    selected = false
                                },
                                li_attr = new jsTree_attr()
                                {
                                    @class = "root"
                                }
                            };
                            jsTrees.Add(_jsTree);
                            foreach (KampanyalarDescriptionDTO kampanyalarDescriptionDTO in kategori.item)
                            {
                                _jsTree = new jsTree()
                                {
                                    id = kampanyalarDescriptionDTO.Aciklamaid.ToString(),
                                    text = kampanyalarDescriptionDTO.StokAciklama,
                                    parent = string.Concat("*", kategori.key),
                                    state = new jsTree_state()
                                    {
                                        opened = false,
                                        disabled = false,
                                        selected = true
                                    },
                                    li_attr = new jsTree_attr()
                                    {
                                        @class = "treeKampanya"
                                    }
                                };
                                jsTrees.Add(_jsTree);
                            }
                        }
                        jsonResult = base.Json(jsTrees, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        jsonResult = null;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            finally
            {
                this.db.Database.Connection.Close();
            }
            return jsonResult;
        }

        public JsonResult KampanyaTreeDoldur()
        {
            //string webKullaniciNo = Session["WebKullaniciNo"].ToString();
            //WebKullanicilari webKullanicilari = this.db.WebKullanicilari.FirstOrDefault(w => w.WebKullaniciNo == webKullaniciNo);
            //List<WebKullaniciYetkileri> webKullaniciYetkileri = webKullanicilari.WebKullaniciYetkileri.ToList();
            //List<jsTree> Tree = new List<jsTree>();
            ///* Kategoriler ve kampanyalar*/
            //List<Kategoriler> kategoriler = (from kat in db.Kategoriler
            //                  join kam in db.Kampanyalar.Where(w => w.Aktif && w.PortaldeGoster) on kat.id equals kam.Kategoriid
            //                  select new Kategoriler()
            //                  {
            //                      id = kat.id,
            //                      Tanim = kat.Tanim
            //                  }).ToList();

            //foreach (var kategori in kategoriler)
            //{
            //    jsTree Node = new jsTree();
            //    Node = new jsTree();
            //    Node.id = "*" + kategori.id;
            //    Node.text = kategori.Tanim;
            //    Node.parent = "#";
            //    Node.state = new jsTree_state() { opened = false, disabled = false, selected = false };
            //    Node.li_attr = new jsTree_attr { @class = "root" };


            //    if (webKullaniciYetkileri.Count() != 0)
            //    {
            //        if (!webKullaniciYetkileri.Select(s => s.Kategoriid).Contains(kategori.id)) continue;
            //    }

            //    Tree.Add(Node);

            //    List<Kampanyalar> kategoriyegoreKampanyalar = db.Kampanyalar
            //                                                    .Where(w => w.Kategoriid == kategori.id && w.Aktif && w.PortaldeGoster)
            //                                                    .OrderBy(oby => oby.Tanim).ToList();

            //    foreach (var kampanya in kategoriyegoreKampanyalar)
            //    {
            //        Node = new jsTree();
            //        Node.id = "$" + kampanya.id.ToString();
            //        Node.text = kampanya.Tanim;
            //        Node.parent = "*" + kampanya.Kategoriid;
            //        Node.state = new jsTree_state() { opened = false, disabled = false, selected = false };
            //        Node.li_attr = new jsTree_attr { @class = "treeKampanya" };
            //        if (Request.IsAuthenticated && webKullanicilari.WebKullaniciRoles == "Kategori")
            //        {
            //            Node.li_attr = new jsTree_attr()
            //            {
            //                @class = "hidden"
            //            };
            //        }
            //        Tree.Add(Node);
            //    }
            //}

            //return Json(Tree, JsonRequestBehavior.AllowGet);

            string webKullaniciNo = Session["WebKullaniciNo"].ToString();
            WebKullanicilari webKullanicilari = this.db.WebKullanicilari.FirstOrDefault(w => w.WebKullaniciNo == webKullaniciNo);
            List<WebKullaniciYetkileri> webKullaniciYetkileri = webKullanicilari.WebKullaniciYetkileri.ToList();
            List<jsTree> Tree = new List<jsTree>();
            /* Kategoriler ve kampanyalar*/
            List<Kampanyalar> kampanyalar = db.Kampanyalar.Where(w => w.Aktif && w.PortaldeGoster).OrderBy(o => o.Tanim).ToList();
            jsTree Node = new jsTree();
            //var kategoriyeGoreKampanyalar = kampanyalar.GroupBy(group => group.Kategoriid).Select(select => new { key = select.Key, item = select.ToList().OrderBy(o => o.Kategoriler.Tanim) });
            var kategoriyeGoreKampanyalar = (from w in kampanyalar
                                            where w.Aktif
                                            select w into oby
                                            orderby oby.Kategoriler.Tanim
                                            select oby into g
                                            group g by g.Kategoriid into s
                                            select new { kategoriId = s.Key, kampanyalar = s.ToList<Kampanyalar>() }).ToList();

            //Node = new jsTree();
            //Node.id = "**" + "0";
            //Node.text = "Kategorilerine Göre Kampanyalar";
            //Node.parent = "#";
            //Node.state = new jsTree_state() { opened = true, disabled = false, selected = false };
            //Node.li_attr = new jsTree_attr { @class = "root" };
            //Tree.Add(Node);

            foreach (var grupItem in kategoriyeGoreKampanyalar.ToList())
            {
                //foreach (var yetki in webKullaniciYetkileri)
                //{
                //    yetki.Kategoriid
                //}
                Node = new jsTree();
                Node.id = "*" + grupItem.kategoriId;
                Node.text = grupItem.kampanyalar.Where(w => w.Kategoriid == grupItem.kategoriId).Select(s => s.Kategoriler.Tanim).FirstOrDefault();
                Node.parent = "#";
                Node.state = new jsTree_state() { opened = false, disabled = false, selected = false };
                Node.li_attr = new jsTree_attr { @class = "root" };


                if (webKullaniciYetkileri.Count() != 0)
                {
                    if (!webKullaniciYetkileri.Select(s => s.Kategoriid).Contains(grupItem.kategoriId)) continue;
                }

                Tree.Add(Node);

                foreach (var item in grupItem.kampanyalar)
                {
                    Node = new jsTree();
                    Node.id = "$" + item.id.ToString();
                    Node.text = item.Tanim;
                    Node.parent = "*" + grupItem.kategoriId;
                    Node.state = new jsTree_state() { opened = false, disabled = false, selected = false };
                    Node.li_attr = new jsTree_attr { @class = "treeKampanya" };
                    if (Request.IsAuthenticated && webKullanicilari.WebKullaniciRoles == "Kategori")
                    {
                        Node.li_attr = new jsTree_attr()
                        {
                            @class = "hidden"
                        };
                    }
                    Tree.Add(Node);
                }
            }
            return Json(Tree, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult KampanyalarGeciciKaydet(string selectedCampaigns, bool isEdit = false)
        {
            ActionResult actionResult;
            int item = (int)base.Session["genelID"];
            try
            {
                string[] strArrays = (new Regex("(\\\"\\$|\\\"\\#|\"\\\\*)"))
                                            .Replace(selectedCampaigns, string.Empty)
                                            .Replace("]", "").Replace("[", "")
                                            .Split(new char[] { ',' });
                this.KampanyalarGeciciSil(item);
                KampanyalarGeciciDTO kampanyalarGeciciDTO = new KampanyalarGeciciDTO();
                for (int i = 0; i < strArrays.Length; i++)
                {
                    string str = strArrays[i];
                    if (!str.StartsWith("*") && !(str == ""))
                    {
                        int ınt32 = Convert.ToInt32(str);
                        Kampanyalar kampanyalar = (
                            from w in this.db.Kampanyalar
                            where w.id == ınt32
                            select w).FirstOrDefault<Kampanyalar>();
                        kampanyalarGeciciDTO.Genelid = item;
                        kampanyalarGeciciDTO.Kampanyaid = kampanyalar.id;
                        kampanyalarGeciciDTO.Kategoriid = kampanyalar.Kategoriid;
                        kampanyalarGeciciDTO.Secim = true;
                        kampanyalarGeciciDTO.Aktif = kampanyalar.Aktif;
                        kampanyalarGeciciDTO.Tanim = kampanyalar.Tanim;
                        kampanyalarGeciciDTO.KayitTarihi = new DateTime?(DateTime.Now);
                        kampanyalarGeciciDTO = this.kampanyalarRepo.KaydetKampanyalarGecici(new KampanyalarGecici(), kampanyalarGeciciDTO);
                    }
                }
                actionResult = base.Json(new RequestResult()
                {
                    Type = new int?(1),
                    Success = true,
                    Message = "Campaigns is Loading",
                    ReturnUrl = ""
                });
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return actionResult;
        }

        public void PasiflikAyarla([DataSourceRequest] DataSourceRequest request, string selectedDescriptions)
        {
            try
            {
                try
                {
                    string[] strArrays = (new Regex("(\\\"\\|\\\"\\#|\"\\\\*)"))
                                                    .Replace(selectedDescriptions, string.Empty)
                                                    .Replace("]", "")
                                                    .Replace("[", "")
                                                    .Split(new char[] { ',' });
                    string str = "(";
                    for (int i = 0; i < strArrays.Count<string>(); i++)
                    {
                        if (!strArrays[i].Contains<char>('*'))
                        {
                            str = string.Concat(str, strArrays[i], ",");
                        }
                    }
                    str = string.Concat(str.TrimEnd(new char[] { ',' }), ")");
                    if (str == "()")
                    {
                        str = "(0)";
                    }
                    int item = (int)base.Session["genelID"];
                    this.db.Database.Connection.Open();
                    using (this.db.Database.Connection)
                    {
                        SqlCommand sqlCommand = new SqlCommand()
                        {
                            Connection = (SqlConnection)this.db.Database.Connection,
                            CommandText = string.Concat(new string[] { "UPDATE DescriptionGecici SET Secim = 0 WHERE Genelid =", item.ToString(), " UPDATE DescriptionGecici SET Secim = 1 WHERE Genelid =", item.ToString(), " AND Aciklamaid IN ", str })
                        };
                        sqlCommand.ExecuteReader(CommandBehavior.CloseConnection).Close();
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
        }

        public JsonResult KampanyalariGetirInt(int? parent)
        {

            List<string> Kategori = new List<string>();
            List<string> Kampanya = new List<string>();
            /* Bolumler ve birimler */
            var kampanyalar = db.Kampanyalar.ToList();

            string Node = "";
            var kategoriyeGoreGrupluListe = kampanyalar.GroupBy(group => group.Kategoriid).Select(select => new { key = select.Key, item = select.ToList() });
            foreach (var grupItem in kategoriyeGoreGrupluListe.ToList())
            {
                //   Node = "*" + grupItem.key;
                //   TreeUst.Add(Node);

                foreach (var item in grupItem.item)
                {
                    //   Node = "$" + item.ID.ToString();
                    //   TreeUst.Add(Node);
                    var kampanyaListesi = kampanyalar.Where(w=>w.Kategoriid == item.Kategoriid);
                    Node = item.id.ToString();
                    Kategori.Add(Node);
                    foreach (var item2 in kampanyaListesi)
                    {
                        Node = item2.id.ToString();
                        Kampanya.Add(Node);
                    }
                }
            }

            return Json(new { Kategori, Kampanya }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult KampanyalarGeciciKaydet(string selectedCampaigns)
        //{
        //    try
        //    {

        //        Regex regex = new Regex("(\\\"\\$|\\\"\\#|\"\\\\*)");
        //        string cleanString = regex.Replace(selectedCampaigns, String.Empty);
        //        cleanString = cleanString.Replace("]", "");
        //        cleanString = cleanString.Replace("[", "");
        //        //JavaScriptSerializer js = new JavaScriptSerializer();
        //        //List<int> selectedCampaignList = (List<int>)js.Deserialize(cleanString, typeof(List<int>));

        //        string[] selectedCampaignList = cleanString.Split(',');

        //        //KampanyalarGecici tablosunda daha önce aynı genelID ye sahip kayıtlar varsa önce onlar siliniyor.
        //        var sabitler = db.Sabitler.FirstOrDefault();
        //        int genelID = sabitler.Genelid + 1;
        //        KampanyalarGeciciSil(genelID);

        //        KampanyalarGeciciDTO kampanyalarGeciciDTO = new KampanyalarGeciciDTO();

        //        foreach (string item in selectedCampaignList)
        //        {
                    
        //            if (item.StartsWith("*") && !(item == "")) continue;

        //            int seciliKampanyaID = Convert.ToInt32(item);
        //            var kampanya = db.Kampanyalar.Where(w => w.id == seciliKampanyaID).FirstOrDefault();
        //            kampanyalarGeciciDTO.Genelid = genelID;
        //            kampanyalarGeciciDTO.Kampanyaid = kampanya.id;
        //            kampanyalarGeciciDTO.Kategoriid = kampanya.Kategoriid;
        //            kampanyalarGeciciDTO.Secim = true;
        //            kampanyalarGeciciDTO.Aktif = kampanya.Aktif;
        //            kampanyalarGeciciDTO.Tanim = kampanya.Tanim;
        //            kampanyalarGeciciDTO.KayitTarihi = DateTime.Now;

        //            kampanyalarGeciciDTO = kampanyalarRepo.KaydetKampanyalarGecici(new KampanyalarGecici(), kampanyalarGeciciDTO);
        //        }

                

        //        return Json(new RequestResult
        //        {
        //            Type = 2,
        //            Success = true,
        //            Message = "İşlem Başarılı",
        //            ReturnUrl = ""
        //        });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public void KampanyalarGeciciSil(int genelID)
        {
            try
            {
                using (var db = new ASIRGroupDBEntities())
                {
                    var entity = db.KampanyalarGecici.Where(q => q.Genelid == genelID).ToList();

                    if (entity != null)
                    {
                        db.KampanyalarGecici.RemoveRange(entity);
                        var result = db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult GetCampaignsFromSP([DataSourceRequest] DataSourceRequest request)
        //{
        //    var sabitler = db.Sabitler.FirstOrDefault();
        //    int genelID = sabitler.Genelid + 1;

        //    int totalCount = 0;
        //    // int pageSize = request.PageSize;
        //    int pageSize = 0;
        //    var SPdenGelenKampanyalar = kampanyalarRepo.KampanyalListesi(genelID, request.Page, pageSize, totalCount);
        //    return Json(new DataSourceResult()
        //    {
        //        Data = SPdenGelenKampanyalar,
        //        Total = totalCount
        //    });
        //}

        public ActionResult GetCampaignsFromSP([DataSourceRequest] DataSourceRequest request, string seciliKampanyalar = "", string filtre = "", bool isEdit = false, int masterID = 0)
        {
            ActionResult actionResult;
            int genelID = (int)base.Session["genelID"];
            base.Session["filtre"] = filtre;
            if (seciliKampanyalar == "[]" && masterID == 0)
            {
                this.KampanyalarGeciciSil(genelID);
            }
            try
            {
                this.db.Database.Connection.Open();
                using (this.db.Database.Connection)
                {
                    SqlCommand sqlCommand = new SqlCommand()
                    {
                        Connection = (SqlConnection)this.db.Database.Connection,
                        CommandText = string.Concat(
                                                new object[] { "EXECUTE StokKartAramaWeb @sp_Sirket_Kod = '1', @spGenelid = ", genelID.ToString(),
                                                               " , @spAramaMetni = '", filtre,
                                                               "', @spBakiyeler = 0, @spResimli = 0, @spKullaniciRole = '",
                                                               base.Session["WebKullaniciRoles"], "', @spKullaniciNo = '", base.Session["WebKullaniciNo"], "'" })
                    };
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (sqlDataReader != null)
                    {
                        List<StokKartAramaWebDTO> stokKartAramaWebDTOs = new List<StokKartAramaWebDTO>();
                        while (sqlDataReader.Read())
                        {
                            stokKartAramaWebDTOs.Add(new StokKartAramaWebDTO()
                            {
                                id = (int)sqlDataReader["id"],
                                Sirket_Kod = (string)sqlDataReader["Sirket_Kod"],
                                SKUKodu = (string)sqlDataReader["SKUKodu"],
                                KayitTarihi = new DateTime?((sqlDataReader["KayitTarihi"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["KayitTarihi"])),
                                KullaniciKodu = (string)sqlDataReader["KullaniciKodu"],
                                DegisiklikTarihi = new DateTime?((sqlDataReader["DegisiklikTarihi"].ToString().Length <= 0 ? DateTime.Now : (DateTime)sqlDataReader["DegisiklikTarihi"])),
                                DegKullaniciKodu = (string)sqlDataReader["DegKullaniciKodu"],
                                Marka = (string)sqlDataReader["Marka"],
                                UreticiBarkodNo = (string)sqlDataReader["UreticiBarkodNo"],
                                UrunBarkodNo = (string)sqlDataReader["UrunBarkodNo"],
                                StokIsmi = (string)sqlDataReader["StokIsmi"],
                                StokAciklama = (string)sqlDataReader["StokAciklama"],
                                Ozellik = (string)sqlDataReader["Ozellik"],
                                EkstraOzellik = (string)sqlDataReader["EkstraOzellik"],
                                Renk = (string)sqlDataReader["Renk"],
                                En = (sqlDataReader["En"] == null ? 0 : (double)sqlDataReader["En"]),
                                Boy = (sqlDataReader["Boy"] == null ? 0 : (double)sqlDataReader["Boy"]),
                                Yukseklik = (sqlDataReader["Yukseklik"] == null ? 0 : (double)sqlDataReader["Yukseklik"]),
                                Agirlik = (sqlDataReader["Agirlik"] == null ? 0 : (double)sqlDataReader["Agirlik"]),
                                Puan = (sqlDataReader["Puan"] == null ? 0 : (double)sqlDataReader["Puan"]),
                                UreticiStokKodu = (string)sqlDataReader["UreticiStokKodu"],
                                KonseptTanim = (string)sqlDataReader["KonseptTanim"]
                            });
                        }
                        sqlDataReader.Close();
                        actionResult = base.Json(stokKartAramaWebDTOs
                            .ToDataSourceResult(request, 
                                        (StokKartAramaWebDTO p) 
                                            => new {
                                                        id = p.id,
                                                        Sirket_Kod = p.Sirket_Kod,
                                                        SKUKodu = p.SKUKodu,
                                                        KayitTarihi = p.KayitTarihi,
                                                        KullaniciKodu = p.KullaniciKodu,
                                                        DegisiklikTarihi = p.DegisiklikTarihi,
                                                        DegKullaniciKodu = p.DegKullaniciKodu,
                                                        Marka = p.Marka,
                                                        UreticiBarkodNo = p.UreticiBarkodNo,
                                                        UrunBarkodNo = p.UrunBarkodNo,
                                                        StokIsmi = p.StokIsmi,
                                                        StokAciklama = p.StokAciklama,
                                                        Ozellik = p.Ozellik,
                                                        EkstraOzellik = p.EkstraOzellik,
                                                        Renk = p.Renk,
                                                        En = p.En,
                                                        Boy = p.Boy,
                                                        Yukseklik = p.Yukseklik,
                                                        Agirlik = p.Agirlik,
                                                        Puan = p.Puan,
                                                        UreticiStokKodu = p.UreticiStokKodu,
                                                        KonseptTanim = p.KonseptTanim
                                                    }), JsonRequestBehavior.AllowGet);
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
            finally
            {
                this.db.Database.Connection.Close();
            }
            return actionResult;
        }

        public JsonResult GetImageSeriesFromFolder(string imageName)
        {
            //Array.ForEach(System.IO.Directory.GetFiles(base.Server.MapPath("~/Images")), System.IO.File.Delete);

            List<string> strs = new List<string>();
            try
            {
                for (int i = 1; i < 20; i++)
                {
                    string str = string.Concat(imageName, " - ", i.ToString(), ".jpg");
                    FtpWebRequest networkCredential = (FtpWebRequest)WebRequest.Create(string.Concat("ftp://ftp.asirgroupcloud.com/", str));
                    networkCredential.Method = "RETR";
                    networkCredential.Credentials = new NetworkCredential("images", "Jz95xXDQ");
                    networkCredential.UseBinary = true;
                    if (System.IO.File.Exists(string.Concat(base.Server.MapPath("~/Images"), "/", str)))
                    {
                        System.IO.File.Delete(string.Concat(base.Server.MapPath("~/Images"), "/", str));
                    }
                    Stream responseStream = ((FtpWebResponse)networkCredential.GetResponse()).GetResponseStream();
                    FileStream fileStream = new FileStream(string.Concat(base.Server.MapPath("~/Images"), "/", str), FileMode.Create);
                    byte[] numArray = new byte[2047];
                    int ınt32 = 1;
                    while (ınt32 != 0)
                    {
                        ınt32 = responseStream.Read(numArray, 0, (int)numArray.Length);
                        fileStream.Write(numArray, 0, ınt32);
                    }
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
            catch (WebException webException)
            {
                string statusDescription = ((FtpWebResponse)webException.Response).StatusDescription;
            }
            IEnumerable<string> list =
                from fn in Directory.EnumerateFiles(base.Server.MapPath("~/Images"))
                select string.Concat("Images/", Path.GetFileName(fn));
            list = (
                from w in list
                where w.Contains(imageName)
                select w).ToList<string>();
            return base.Json(list, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = new int?(2147483647)
            };
        }

    }
}
