using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using CocoMaps.Shared.GoogleDirections;

namespace CocoMaps.Shared
{
	public class RequestDirections
	{
		private static RequestDirections requestDirections;

		private RequestDirections ()
		{
		}

		public static RequestDirections getInstance {
			get {
				if (requestDirections == null)
					requestDirections = new RequestDirections ();
				return requestDirections;
			}
		}

		public Directions getDirections (string origin, string destination, CocoMaps.Shared.GoogleDirections.Mode mode)
		{
			// Create a request for the URL.
			var requestUrl = string.Format ("http://maps.google.com/maps/api/directions/json?origin={0}+Montreal&destination={1}+Montreal&mode={2}&sensor=true", origin, destination, mode);
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

			return JsonConvert.DeserializeObject<Directions> (json);
		}
	}
}