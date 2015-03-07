using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Json;
using Xamarin.Forms;

namespace CocoMaps.Shared
{
	public class RequestDirections
	{
		static RequestDirections requestDirections;
		static TravelMode travelMode = TravelMode.walking;

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

		public async Task<Directions> getDirections (string origin, string destination, TravelMode mode)
		{
			// Create a request for the URL.
			var requestUrl = string.Format ("https://maps.google.com/maps/api/directions/json?origin={0}+Montreal&destination={1}+Montreal&mode={2}&sensor=true", origin, destination, mode);
			JsonValue json = await JsonUtil.FetchJsonAsync (requestUrl);

			return JsonConvert.DeserializeObject<Directions> (json.ToString ());
		}

	}
}