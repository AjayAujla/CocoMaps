using System;

namespace CocoMaps.Shared
{
	public class Service
	{

		public Service(String name, String room, String url){
			Name = name;
			RoomNumber = room;
			URI = url;
		}

		public String Name {
			get;
			set;
		}

		public String RoomNumber {
			get;
			set;
		}

		public String URI {
			get;
			set;
		}

	}
}