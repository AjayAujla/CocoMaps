using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class Campus
	{

		public Campus ()
		{
		}

		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public List<Building> Buildings {
			get;
			set;
		}

		public Building GetBuildingByCode (string code)
		{
			foreach (Building building in Buildings) {
				if (building.Code.Equals (code))
					return building;
			}
			return null;
		}

	}
}