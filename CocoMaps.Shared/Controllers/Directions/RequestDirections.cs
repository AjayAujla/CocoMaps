using System;
using Newtonsoft.Json;
using CocoMaps.Shared.GoogleDirections;
using System.Threading.Tasks;
using System.Json;

namespace CocoMaps.Shared
{
	public class RequestDirections
	{
		static RequestDirections requestDirections;

		RequestDirections ()
		{
		}

		public static RequestDirections getInstance {
			get {
				if (requestDirections == null)
					requestDirections = new RequestDirections ();
				return requestDirections;
			}
		}

		public async Task<Directions> getDirections (string origin, string destination, CocoMaps.Shared.GoogleDirections.Mode mode)
		{
			// Create a request for the URL.
			var requestUrl = string.Format ("https://maps.google.com/maps/api/directions/json?origin={0}+Montreal&destination={1}+Montreal&mode={2}&sensor=true", origin, destination, mode.ToString ().ToLower ());
			JsonValue json = await JsonUtil.FetchJsonAsync (requestUrl);

			return JsonConvert.DeserializeObject<Directions> (json.ToString ());
		}
	}
}