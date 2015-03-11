using System;
using CocoMaps.Shared;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Java.Util;
using System.Threading.Tasks;
using Android.Gms.Fitness.Data;

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
				return new [] {"cafe", "food", "bar", "atm", "bank", "gaz_station", "library"
				};
			}
		}

		public static PlacesRepository getInstance {
			get {
				if (repository == null) {
					repository = new PlacesRepository ();
					repository.Init ();
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

		async void Init ()
		{
			var placesRequest = RequestPlaces.getInstance;
			Places places;
			POIs = new List<Result> ();

			// concatenating all POI queries into one string to make a single request to Google's API
			String pois = "";
			foreach (String poi in POIsQuery) {
				pois += poi + "|";
			}

			foreach (Campus campus in BuildingRepository.getInstance.getCampusList()) {

				Console.WriteLine ("SEARCHING NEARBY: " + campus.Name);
				places = await placesRequest.getPlaces (pois, campus.Position);

				if (places.status == "OK") {

					foreach (Result place in places.results)
						POIs.Add (place);

				}

			}

		}

	}

}