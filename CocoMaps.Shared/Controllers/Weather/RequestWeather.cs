using System;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class RequestWeather
	{
		private string OPEN_WEATHER_MAP_API_KEY = "e29a8df99de1c58be0e4260575e6e25b";

		public RequestWeather ()
		{

		}

		private async Task<JsonValue> FetchWeatherAsync (string uri)
		{


			// Fetch the weather information asynchronously, 
			//JsonValue json = await FetchWeatherAsync (uri);

			// Create an HTTP web request using the URI:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (uri));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ()) {
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ()) {
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine ("Response: {0}", jsonDoc.ToString ());

					return jsonDoc;
				}
			}
		}

		private Image Parse (JsonValue json)
		{
			JsonValue weatherResults = json ["weather"];
			string conditionIconPath = "WeatherIcons/" + weatherResults ["icon"] + ".png";
			string description = weatherResults ["main"];

			JsonValue weatherInformation = json ["main"];
			double temperature = weatherInformation ["temp"];


			Image weatherConditionIcon = new Image {
				Source = ImageSource.FromFile ("WeatherMap\\WeatherIcons\\Sunny.png"/*conditionIconPath*/),
			};
			Label temperatureLabel = new Label () { 
				Text = String.Format ("{0:F1}", temperature) + "°C",
			};
			Label descriptionLabel = new Label () { 
				Text = description, 
			};

			return weatherConditionIcon;
		}

		public async Task<Image> FetchWeatherAndParse (string campus)
		{
			Position campusPosition = Campus.SGWPosition;

			if (campus.Equals ("LOY")) {
				campusPosition = Campus.LOYPosition;
			}
			if (campus.Equals ("SGW")) {
				campusPosition = Campus.SGWPosition;
			}
			string uri = "api.openweathermap.org/data/2.5/weather?lat=" +
			             campusPosition.Latitude.ToString () +
			             "&lon=" +
			             campusPosition.Longitude.ToString () +
			             "&units=metric" +
			             "&APIID" + OPEN_WEATHER_MAP_API_KEY;

			JsonValue json = await FetchWeatherAsync (uri);
			return Parse (json);
		}
	}
}