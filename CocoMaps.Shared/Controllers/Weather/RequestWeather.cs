using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
			/*string uri = "api.openweathermap.org/data/2.5/weather?lat=" +
			             campusPosition.Latitude.ToString () +
			             "&lon=" +
			             campusPosition.Longitude.ToString () +
			             "&units=metric" +
			             "&APIID" + OPEN_WEATHER_MAP_API_KEY;
*/
			string uri = "http://api.openweathermap.org/data/2.5/weather?q=London&units=metric";

			var client = new HttpClient ();
			var json = await client.GetStringAsync (uri);

			if (string.IsNullOrWhiteSpace (json))
				return null;

			return JsonConvert.DeserializeObject<WeatherRoot> (json);
		}
	}
}