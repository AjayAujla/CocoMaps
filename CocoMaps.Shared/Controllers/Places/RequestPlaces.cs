﻿using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class RequestPlaces
	{
		static RequestPlaces requestPlaces;

		RequestPlaces ()
		{
		}

		public static RequestPlaces getInstance {
			get {
				if (requestPlaces == null)
					requestPlaces = new RequestPlaces ();
				return requestPlaces;
			}
		}

		public async Task<Places> getPlaces (string types, Position position, String next_page_token = "")
		{
			
			// Create a request for the URL.
			string requestUrl = string.Format ("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&rankby=distance&types={2}&pagetoken={3}&key=AIzaSyCQBvq9vXLCQnTAk2RTlJFBvenkevBz_D8", position.Latitude, position.Longitude, types, next_page_token);
			JsonValue json = await JsonUtil.FetchJsonAsync (requestUrl);

			return JsonConvert.DeserializeObject<Places> (json.ToString ());
		}
	}
}