using System;

namespace CocoMaps.Shared
{
	public class Department
	{

		public Department(String name, String url){
			Name = name;
			URI = url;
		}

		public String Name {
			get;
			set;
		}

		public String URI {
			get;
			set;
		}

	}
}