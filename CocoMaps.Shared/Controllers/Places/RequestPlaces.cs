﻿using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class RequestPlaces
	{
		private static RequestPlaces requestPlaces;

		private RequestPlaces ()
		{
		}

		public static RequestPlaces getInstance {
			get {
				if (requestPlaces == null)
					requestPlaces = new RequestPlaces ();
				return requestPlaces;
			}
		}

		public Places getPlaces (string type, Position position)
		{
			// Create a request for the URL.
			string requestUrl = string.Format ("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=800&types={2}&key=AIzaSyCQBvq9vXLCQnTAk2RTlJFBvenkevBz_D8", position.Latitude, position.Longitude, type);
			WebRequest request = WebRequest.Create (requestUrl);
			// Get the response.
			WebResponse response = request.GetResponse ();
			// Display the status.
			Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			Stream dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string json = reader.ReadToEnd ();
			// Clean up the streams and the response.
			reader.Close ();
			response.Close ();

			return JsonConvert.DeserializeObject<Places> (json);
		}
	}
}