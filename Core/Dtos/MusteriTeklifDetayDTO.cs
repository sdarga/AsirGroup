using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class MusteriTeklifDetayDTO
	{
		public double Agirlik
		{
			get;
			set;
		}

		public double AlisFiyatiTL
		{
			get;
			set;
		}

		public double AsirStok
		{
			get;
			set;
		}

		public double BirTaneicinAlisFiyati
		{
			get;
			set;
		}

		public double BlokeStok
		{
			get;
			set;
		}

		public double Boy
		{
			get;
			set;
		}

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

		public string EkstraOzellik
		{
			get;
			set;
		}

		public double En
		{
			get;
			set;
		}

		public string Image64
		{
			get
			{
				if (this.KucukResim == null)
				{
					return " <img src='assets/admin/layout/img/avatar.png' />";
				}
				return string.Concat("data:image/png;base64,", Convert.ToBase64String(this.KucukResim));
			}
			set
			{
			}
		}

		public bool Iptal
		{
			get;
			set;
		}

		public int id
		{
			get;
			set;
		}

		public double KalanStok
		{
			get;
			set;
		}

		public DateTime KayitTarihi
		{
			get;
			set;
		}

		public string KonseptTanim
		{
			get;
			set;
		}

		public byte[] KucukResim
		{
			get;
			set;
		}

		public string KullaniciKodu
		{
			get;
			set;
		}

		public double ListeAlisFiyati
		{
			get;
			set;
		}

		public double Marj
		{
			get;
			set;
		}

		public string Marka
		{
			get;
			set;
		}

		public int Masterid
		{
			get;
			set;
		}

		public double Miktar
		{
			get;
			set;
		}

		public double OzelFiyat
		{
			get;
			set;
		}

		public string Ozellik
		{
			get;
			set;
		}

		public double Puan
		{
			get;
			set;
		}

		public string Renk
		{
			get;
			set;
		}

		public double RetailFiyat
		{
			get;
			set;
		}

		public double SatisFiyati
		{
			get;
			set;
		}

		public int sipdetayid
		{
			get;
			set;
		}

		public string Sirket_Kod
		{
			get;
			set;
		}

		public string SKUKodu
		{
			get;
			set;
		}

		public string StokAciklama
		{
			get;
			set;
		}

		public string StokIsmi
		{
			get;
			set;
		}

		public double TedarikciStogu
		{
			get;
			set;
		}

		public string UreticiBarkodNo
		{
			get;
			set;
		}

		public string UreticiStokKodu
		{
			get;
			set;
		}

		public string UrunBarkodNo
		{
			get;
			set;
		}

		public double UyariMarj
		{
			get;
			set;
		}

		public double VerilecekStok
		{
			get;
			set;
		}

		public double Yukseklik
		{
			get;
			set;
		}

		public MusteriTeklifDetayDTO()
		{
		}
	}
}