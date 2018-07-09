using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class KampanyalarDescriptionDTO
	{
		public int Aciklamaid
		{
			get;
			set;
		}

		public int Genelid
		{
			get;
			set;
		}

		public int id
		{
			get;
			set;
		}

		public int Kampanyaid
		{
			get;
			set;
		}

		public string KategoriAciklama
		{
			get;
			set;
		}

		public int Kategoriid
		{
			get;
			set;
		}

		public DateTime? KayitTarihi
		{
			get;
			set;
		}

		public bool Secim
		{
			get;
			set;
		}

		public string StokAciklama
		{
			get;
			set;
		}

		public KampanyalarDescriptionDTO()
		{
		}
	}
}