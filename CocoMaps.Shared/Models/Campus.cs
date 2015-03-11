using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class Campus
	{

		// Those are the exact coordinates given by Google Maps
		// When searching for those campuses - DO NOT CHANGE!!!
		public static Position SGWPosition = new Position (45.4971711, -73.5790942);
		public static Position LOYPosition = new Position (45.4585649, -73.6400639);

		public int ID {
			get;
			set;
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

		public Position Position {
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