using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CocoMaps.Shared
{
	public class LibraryPlaces
	{
		public Places getSGWLibraryPlaces(){
			// Create a request for the URL. 
			WebRequest request = WebRequest.Create ("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=45.4971711,%20-73.5790942&radius=800&types=library&key=AIzaSyCQBvq9vXLCQnTAk2RTlJFBvenkevBz_D8");
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

			Places foodPlaces = JsonConvert.DeserializeObject<Places> (json);
			return foodPlaces;
		}

		public Places getLoyolaLibraryPlaces(){
			// Create a request for the URL. 
			WebRequest request = WebRequest.Create ("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=45.4585649,%20-73.6400639&radius=800&types=library&key=AIzaSyCQBvq9vXLCQnTAk2RTlJFBvenkevBz_D8");
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

			Places foodPlaces = JsonConvert.DeserializeObject<Places> (json);
			return foodPlaces;
		}
	}
}

