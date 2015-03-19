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

		public async Task<WeatherRootObject> GetWeather (string campus)
		{
			string uri = "http://api.openweathermap.org/data/2.5/weather?q=Montreal&units=metric&APIID" + OPEN_WEATHER_MAP_API_KEY;

			// Query for weather information in JSON format
			JsonValue json = await JsonUtil.FetchJsonAsync (uri);

			// Returns null if the fetch failed
			if (string.IsNullOrWhiteSpace (json.ToString ())) {
				return null;
			}

			// Returns root of deserialized JSON containing all weather information
			return JsonConvert.DeserializeObject<WeatherRootObject> (json.ToString ());
		}


		/*
		 * XXd: weather code for day time icon
		 * XXn: weather code for night time icon
		 * Selects corresponding image based on weather icon code from OpenWeatherMap query
		 */
		public string GetImagePath (string weatherCode)
		{
			string imagePath = "";

			//Clear Sky Day
			if (weatherCode.Equals ("01d")) { 
				imagePath = "ic_weather_sunny.png";
			}

			//Clear Sky Night
			if (weatherCode.Equals ("01n")) { 
				imagePath = "ic_weather_moonlight.png"; 
			}

			//Few Clouds Day
			if (weatherCode.Equals ("02d")) {
				imagePath = "ic_weather_partlycloudy_day.png"; 
			}

			//Few Clouds Night
			if (weatherCode.Equals ("02n")) {
				imagePath = "ic_weather_partlycloudy_night.png"; 
			}

			//Scattered Clouds
			if (weatherCode.Equals ("03d") || weatherCode.Equals ("03n")) { 
				imagePath = "ic_weather_cloudy.png";
			}

			//Broken Clouds
			if (weatherCode.Equals ("04d") || weatherCode.Equals ("04n")) { 
				imagePath = "ic_weather_cloudy.png";
			}

			//Shower Rain
			if (weatherCode.Equals ("09d") || weatherCode.Equals ("09n")) { 
				imagePath = "ic_weather_showers.png";
			}

			//Rain
			if (weatherCode.Equals ("10d") || weatherCode.Equals ("10n")) { 
				imagePath = "ic_weather_showers.png";
			}

			//Thunderstorm
			if (weatherCode.Equals ("11d") || weatherCode.Equals ("11n")) { 
				imagePath = "ic_weather_thunderstorms.png";
			}

			//Snow
			if (weatherCode.Equals ("13d") || weatherCode.Equals ("13n")) { 
				imagePath = "ic_weather_snow.png";
			}

			//Mist
			if (weatherCode.Equals ("50d") || weatherCode.Equals ("50n")) { 
				imagePath = "ic_weather_mist.png";
			}

			return imagePath;
		}
	}
}