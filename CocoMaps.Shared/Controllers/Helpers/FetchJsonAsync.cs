using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using CocoMaps.Shared.GoogleDirections;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Json;

public static class JsonUtil
{

	// Gets Json data from the passed URL.
	public static async Task<JsonValue> FetchJsonAsync (string url)
	{
		// Create an HTTP web request using the URL:
		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
		request.ContentType = "application/json";
		request.Method = "GET";

		// Send the request to the server and wait for the response:
		using (WebResponse response = await request.GetResponseAsync ()) {
			// Get a stream representation of the HTTP web response:
			using (Stream stream = response.GetResponseStream ()) {
				// Use this stream to build a JSON document object:
				JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
				Console.Out.WriteLine ("Response: {0}", jsonDoc);

				// Return the JSON document:
				return jsonDoc;
			}
		}
	}
}