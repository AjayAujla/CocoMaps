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

	}
}