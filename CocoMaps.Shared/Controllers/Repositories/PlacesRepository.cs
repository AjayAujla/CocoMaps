using System;
using CocoMaps.Shared;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocoMaps.Shared
{
	public class PlacesRepository
	{
		static PlacesRepository repository;

		public List<Result> POIs {
			get;
			set;
		}

		// TIP: Supported POIs here -> https://developers.google.com/places/documentation/supported_types
		public String[] POIsQuery {
			get {
				return new [] {"cafe", "food", "bar", "atm|bank|library"
				};
			}
		}

		public static PlacesRepository getInstance {
			get {
				if (repository == null) {
					repository = new PlacesRepository ();
				}
				return repository;
			}
		}

		PlacesRepository ()
		{
			// fetch places asynchronously here
			// on map page, we will only have to set markers visibility IsVisible = true/false
		}

		public void PrintPOI ()
		{
			if (POIs != null)
				foreach (Result result in POIs)
					Console.WriteLine (result.types [0] + " -> " + result.name + " @ " + result.vicinity);
		
		}

		async public Task<List<Result>> FetchPlaces ()
		{

			var placesRequest = RequestPlaces.getInstance;
			Places places;
			POIs = new List<Result> ();

			foreach (String poi in POIsQuery) {


				foreach (Campus campus in BuildingRepository.getInstance.getCampusList()) {
				
					String _next_page_token = "";
					int i = 0;

					do {

						Console.WriteLine ("SEARCHING NEARBY: " + campus.Name + " #" + i++);

						places = await placesRequest.getPlaces (poi, campus.Position, _next_page_token);

						if (places.status == "OK") {
					
							foreach (Result place in places.results)
								POIs.Add (place);

							if (places.next_page_token != null)
								_next_page_token = places.next_page_token;
							
						}
					} while(places.next_page_token != null); // places.next_page_token != null
				}
			}

			return POIs;
		}

	}

}