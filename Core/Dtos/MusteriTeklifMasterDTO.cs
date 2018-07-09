using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class MusteriTeklifMasterDTO
	{
		public DateTime? DegisiklikTarihi
		{
			get;
			set;
		}

		public string DegKullaniciKodu
		{
			get;
			set;
		}

		public string DovizKod
		{
			get;
			set;
		}

		public bool FiyatlariSonraKullanma
		{
			get;
			set;
		}

		public int id
		{
			get;
			set;
		}

		public DateTime KayitTarihi
		{
			get;
			set;
		}

		public string KullaniciKodu
		{
			get;
			set;
		}

		public string MKampanyaAdi
		{
			get;
			set;
		}

		public int MKampanyaid
		{
			get;
			set;
		}

		public string MKampanyaKodu
		{
			get;
			set;
		}

		public DateTime? MKampanyaTarih1
		{
			get;
			set;
		}

		public DateTime? MKampanyaTarih2
		{
			get;
			set;
		}

		public int Musteriid
		{
			get;
			set;
		}

		public int Opsiyon
		{
			get;
			set;
		}

		public bool SiparisiGeldi
		{
			get;
			set;
		}

		public int sipmasterid
		{
			get;
			set;
		}

		public string Sirket_Kod
		{
			get;
			set;
		}

		public bool StokVerildi
		{
			get;
			set;
		}

		public DateTime? Tarih
		{
			get;
			set;
		}

		public string TeklifAdi
		{
			get;
			set;
		}

		public MusteriTeklifMasterDTO()
		{
		}
	}
}