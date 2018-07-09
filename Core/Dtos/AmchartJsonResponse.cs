using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class AmchartJsonResponse
	{
		public string Name
		{
			get;
			set;
		}

		public double @value
		{
			get;
			set;
		}

		public AmchartJsonResponse()
		{
		}
	}
}