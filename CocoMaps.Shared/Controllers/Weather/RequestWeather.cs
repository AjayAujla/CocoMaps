using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	class OpenWeatherMapService
	{
		// Free user API key for 3000 API calls per min
		private string OPEN_WEATHER_MAP_API_KEY = "e29a8df99de1c58be0e4260575e6e25b";

		private string InitializeUriBasedOnCampus (string campus)
		{
			Position campusPosition = Campus.SGWPosition;

			if (campus.Equals ("LOY")) {
				campusPosition = Campus.LOYPosition;
			}
			if (campus.Equals ("SGW")) {
				campusPosition = Campus.SGWPosition;
			}

			// Returns URI containing specific campus latitude and longitude in the query
			return "http://api.openweathermap.org/data/2.5/weather?lat=" +
			campusPosition.Latitude +
			"&lon=" +
			campusPosition.Longitude +
			"&units=metric" +
			"&APIID" + OPEN_WEATHER_MAP_API_KEY;
		}

		/*
		 *	Query for weather based on campus	 
		 */
		public async Task<RootObject> GetWeather (string campus)
		{
			JsonValue json = await JsonUtil.FetchJsonAsync (InitializeUriBasedOnCampus (campus));

			// Returns null if the fetch failed
			if (string.IsNullOrWhiteSpace (json.ToString ())) {
				return null;
			}

			// Returns root of deserialized JSON containing all weather information
			return JsonConvert.DeserializeObject<RootObject> (json.ToString ());
		}
	}
}