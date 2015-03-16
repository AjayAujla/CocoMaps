using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Json;

namespace CocoMaps.Shared
{

	public static class JsonUtil
	{

		// Gets Json data from the passed URL.
		public static async Task<JsonValue> FetchJsonAsync (string url)
		{

			if (App.isConnected ()) {
				// Create an HTTP web request using the URL:
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (new Uri (url));
				request.ContentType = "application/json";
				request.Method = "GET";

				// Send the request to the server and wait for the response:
				using (WebResponse response = await request.GetResponseAsync ()) {
					// Get a stream representation of the HTTP web response:
					using (Stream stream = response.GetResponseStream ()) {
						// Use this stream to build a JSON document object:
						JsonValue jsonDoc = await Task.Run (() => JsonValue.Load (stream));
						Console.Out.WriteLine ("Json Response: {0}", jsonDoc);

						// Return the JSON document:
						return jsonDoc;
					}
				}
			} else
				return null;
		}

	}
}