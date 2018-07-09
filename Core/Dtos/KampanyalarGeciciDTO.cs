using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class KampanyalarGeciciDTO
	{
		public bool Aktif
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

		public string Tanim
		{
			get;
			set;
		}

		public KampanyalarGeciciDTO()
		{
		}
	}
}