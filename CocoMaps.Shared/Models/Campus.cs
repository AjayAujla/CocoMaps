using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class Campus
	{

		public Campus () {}

		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public List<Building> Buildings {
			get;
			set;
		}

	}
}