using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public enum WeatherConditions
	{
		Sunny,
		PartlyCloudy,
		Cloudy,
		Showers,
		ScatteredShowers,
		Thunderstorms,
		Snow
	}

	public class Weather
	{
		public Weather ()
		{
		}

		public string Place {
			get;
			set;
		}

		public WeatherConditions Condition {
			get;
			set;
		}

		public Position campusPosition {
			get;
			set;
		}
	}
}