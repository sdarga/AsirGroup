using BL.Data;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private ASIRGroupDBEntities db = new ASIRGroupDBEntities();

		public HomeController()
		{
		}

		public ActionResult About()
		{
			((dynamic)base.ViewBag).Message = "Your app description page.";
			return base.View();
		}

		public ActionResult Contact()
		{
			((dynamic)base.ViewBag).Message = "Your contact page.";
			return base.View();
		}

		public ActionResult deneme()
		{
			//List<StokKartAramaWebDTO> list = (
			//	from item in (new ASIRGroupDBEntities()).StokKartAramaWeb("1", (int)Session["genelID"], "", false, false)
			//	select new StokKartAramaWebDTO()
			//	{
			//		id = item.id,
			//		Sirket_Kod = item.Sirket_Kod,
			//		SKUKodu = item.SKUKodu,
			//		Marka = item.Marka,
			//		Birim = item.Birim,
			//		UreticiBarkodNo = item.UreticiBarkodNo,
			//		UrunBarkodNo = item.UrunBarkodNo,
			//		StokIsmi = item.StokIsmi,
			//		Aktif = (bool)item.Aktif,
			//		Ozellik = item.Ozellik,
			//		StokBitincePasif = (bool)item.StokBitincePasif,
			//		EkstraOzellik = item.EkstraOzellik,
			//		Renk = item.Renk,
			//		KayitTarihi = item.KayitTarihi,
			//		KullaniciKodu = item.KullaniciKodu,
			//		Kampanyaid = (int)item.Kampanyaid,
			//		Aciklamaid = (int)item.Aciklamaid,
			//		DegisiklikTarihi = item.DegisiklikTarihi,
			//		DegKullaniciKodu = item.DegKullaniciKodu,
			//		AlisFiyati = (double)item.AlisFiyati,
			//		DovizKodu = item.DovizKodu,
			//		GercekAlisFiyati = (double)item.GercekAlisFiyati,
			//		En = (double)item.En,
			//		Boy = (double)item.Boy,
			//		Yukseklik = (double)item.Yukseklik,
			//		Agirlik = (double)item.Agirlik,
			//		Puan = (double)item.Puan,
			//		KampanyaPuan = (double)item.KampanyaPuan,
			//		UreticiStokKodu = item.UreticiStokKodu,
			//		KampanyaDosyaIsmi = item.KampanyaDosyaIsmi,
			//		Sira = (int)item.Sira,
			//		StokAciklama = item.StokAciklama,
			//		StokTurkceAciklama = item.StokTurkceAciklama,
			//		Konseptid = item.Konseptid,
			//		//KonseptTanim = item.KonseptTanim,
			//		TedarikciAdi = item.TedarikciAdi,
			//		FizikiStok = item.FizikiStok,
			//		MusAcikSipMik = item.MusAcikSipMik,
			//		AsirStokMik = item.AsirStokMik,
			//		BlokeStokMik = item.BlokeStokMik,
			//		TedStokMik = item.TedStokMik,
			//		TedAcikSipMik = item.TedAcikSipMik,
			//		AktarMik = (double)item.AktarMik,
			//		AlisKDVOrani = (double)item.AlisKDVOrani,
			//		SatisKDVOrani = (double)item.SatisKDVOrani
			//	}).ToList<StokKartAramaWebDTO>();
			return base.View();
		}

		public ActionResult Index()
		{
			return View();
		}
	}
}