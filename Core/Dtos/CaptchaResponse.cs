using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class CaptchaResponse
	{
		[JsonProperty("error-codes")]
		public List<string> ErrorCodes
		{
			get;
			set;
		}

		[JsonProperty("success")]
		public string Success
		{
			get;
			set;
		}

		public CaptchaResponse()
		{
		}
	}
}