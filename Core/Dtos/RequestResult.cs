using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class RequestResult
	{
		public string Message
		{
			get;
			set;
		}

		public string ReturnUrl
		{
			get;
			set;
		}

		public bool Success
		{
			get;
			set;
		}

		public int? Type
		{
			get;
			set;
		}

		public RequestResult()
		{
		}
	}
}