using System;
using System.Runtime.CompilerServices;

namespace Core.Dtos
{
	public class jsTree
	{
		public string a_attr
		{
			get;
			set;
		}

		public bool children
		{
			get;
			set;
		}

		public string icon
		{
			get;
			set;
		}

		public string id
		{
			get;
			set;
		}

		public jsTree_attr li_attr
		{
			get;
			set;
		}

		public string parent
		{
			get;
			set;
		}

		public jsTree_state state
		{
			get;
			set;
		}

		public string text
		{
			get;
			set;
		}

		public jsTree()
		{
			jsTree_state jsTreeState = new jsTree_state()
			{
				opened = false,
				disabled = false,
				selected = false,
				hidden = false
			};
			jsTree_attr jsTreeAttr = new jsTree_attr();
		}
	}
}