using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	class OpenWeatherMapService
	{
		private string OPEN_WEATHER_MAP_API_KEY = "e29a8df99de1c58be0e4260575e6e25b";

		public async Task<WeatherRoot> GetWeather (string campus)
		{
			Position campusPosition = Campus.SGWPosition;

			if (campus.Equals ("LOY")) {
				campusPosition = Campus.LOYPosition;
			}
			if (campus.Equals ("SGW")) {
				campusPosition = Campus.SGWPosition;
			}

			string uri = "api.openweathermap.org/data/2.5/weather?lat=" +
			             campusPosition.Latitude +
			             "&lon=" +
			             campusPosition.Longitude +
			             "&units=metric" +
			             "&APIID" + OPEN_WEATHER_MAP_API_KEY;

			//string uri = "api.openweathermap.org/data/2.5/weather?q=London&units=metric";

			JsonValue json = await JsonUtil.FetchJsonAsync (uri);//client.GetStringAsync (uri);

			if (string.IsNullOrWhiteSpace (json))
				return null;

			WeatherRoot wr = JsonConvert.DeserializeObject<WeatherRoot> (json.ToString ());
			Console.WriteLine ("Temp " + (int)wr.MainWeather.Temp);
			Console.WriteLine ("Main " + wr.Weather [0].Main);
			Console.WriteLine ("Description " + wr.Weather [0].Description);
		
			return wr;
		}
	}
}