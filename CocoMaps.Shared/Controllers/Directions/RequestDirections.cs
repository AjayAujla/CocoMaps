using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Json;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class RequestDirections
	{
		static RequestDirections requestDirections;
		static TravelMode travelMode = TravelMode.walking;

		public static String SGWShuttlePosition = "1455 De Maisonneuve Blvd. W.";
		public static String LOYShuttlePosition = "7137 Sherbrooke St West";

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
			if (App.isConnected ()) {
				// Create a request for the URL.
				var requestUrl = string.Format ("https://maps.google.com/maps/api/directions/json?origin={0}+Montreal&destination={1}+Montreal&mode={2}&sensor=true", origin, destination, mode);
				JsonValue json = await JsonUtil.FetchJsonAsync (requestUrl);
			
				return JsonConvert.DeserializeObject<Directions> (json.ToString ());
			}
			return null;
		}

		// To be able to get directions based on Position attributes
		public async Task<Directions> getDirections (Position origin, Position destination, TravelMode mode)
		{
			String _origin = origin.Latitude + "," + origin.Latitude;
			String _destination = destination.Latitude + "," + destination.Longitude;

			return await getDirections (_origin, _destination, mode);
		}
	}
}