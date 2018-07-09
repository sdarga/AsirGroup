using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class jsTree_state
	{
		public bool disabled
		{
			get;
			set;
		}

		public bool hidden
		{
			get;
			set;
		}

		public bool opened
		{
			get;
			set;
		}

		public bool selected
		{
			get;
			set;
		}

		public jsTree_state()
		{
			this.opened = false;
			this.disabled = false;
			this.selected = false;
			this.hidden = false;
		}
	}
}