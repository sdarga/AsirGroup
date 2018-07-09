using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class JsonResponse
	{
		public object Data
		{
			get;
			set;
		}

		public string Error
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}

		public string StatusText
		{
			get;
			set;
		}

		public JsonResponse()
		{
		}
	}
}