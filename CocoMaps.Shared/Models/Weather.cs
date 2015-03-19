using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class Weather
	{
		public string icon { get; set; }
	}

	public class Main
	{
		public double temp { get; set; }
	}

	public class RootObject
	{
		public List<Weather> weather { get; set; }

		public Main main { get; set; }
	}
}