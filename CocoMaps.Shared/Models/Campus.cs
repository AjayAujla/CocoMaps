using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class Campus
	{
		private string code;
		private string name;
		private List<Building> SGWBuildings;
		private List<Building> LOYBuildings;
		public static List<Campus> CampusList;

		public Campus () {}

		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public List<Building> SGWBuildingsList {
			get;
			set;
		}

		public List<Building> LOYBuildingsList {
			get;
			set;
		}
	}
}

