using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	class RequestWeather
	{
		// Free user API key which allows for 3000 API calls per minute
		private string OPEN_WEATHER_MAP_API_KEY = "e29a8df99de1c58be0e4260575e6e25b";

		/*
		 *	Query for weather based on campus	 
		 */
		public async Task<RootObject> GetWeather (string campus)
		{
			string uri = "http://api.openweathermap.org/data/2.5/weather?q=Montreal&units=metric&APIID" + OPEN_WEATHER_MAP_API_KEY;

			JsonValue json = await JsonUtil.FetchJsonAsync (uri);

			// Returns null if the fetch failed
			if (string.IsNullOrWhiteSpace (json.ToString ())) {
				return null;
			}

			// Returns root of deserialized JSON containing all weather information
			return JsonConvert.DeserializeObject<RootObject> (json.ToString ());
		}
	}
}