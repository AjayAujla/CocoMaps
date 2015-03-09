using System;
using CocoMaps.Shared;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Java.Util;
using System.Threading.Tasks;

namespace CocoMaps.Shared
{
	public class PlacesRepository
	{
		static PlacesRepository repository;

		// TIP: Supported POIs here -> https://developers.google.com/places/documentation/supported_types
		List<String> POIs = new List<String> {
			"cafe", "food", "bar", "atm|bank", "gas_station", "restaurant", "library"
		};

		Dictionary<String, List<Result>> _POIsHolder;

		readonly List<Result> cafes = new List<Result> ();
		readonly List<Result> food = new List<Result> ();
		readonly List<Result> bar = new List<Result> ();
		readonly List<Result> atm_bank = new List<Result> ();
		readonly List<Result> gaz_stations = new List<Result> ();
		readonly List<Result> restaurants = new List<Result> ();
		readonly List<Result> libraries = new List<Result> ();


		public static PlacesRepository getInstance {
			get {
				if (repository == null)
					repository = new PlacesRepository ();
				return repository;
			}
		}

		PlacesRepository ()
		{
			// fetch places asynchronously here
			// on map page, we will only have to set markers visibility IsVisible = true/false
			Init ();
		}

		public Dictionary<String, List<Result>> POIsHolder {
			get { return _POIsHolder; }
		}

		async public void Init ()
		{
			var placesRequest = RequestPlaces.getInstance;
			Places places;
			var POIList = new List<Result> ();

			_POIsHolder = new Dictionary<String, List<Result>> {

				{ "cafe", cafes },
				{ "food", food },
				{ "bar", bar },
				{ "atm|bank", atm_bank },
				{ "gaz_station", gaz_stations },
				{ "restaurant", restaurants },
				{ "library", libraries }

			};

			foreach (String poi in POIs) {
				foreach (Campus campus in BuildingRepository.getInstance.getCampusList()) {

					places = await placesRequest.getPlaces (poi, campus.Position);

					if (places.status == "OK") {

						foreach (Result place in places.results) {


							if (_POIsHolder.TryGetValue (poi, out POIList)) {
								POIList.Add (place);
								Console.WriteLine ("POI ADDED!");
							}

						}

					}

				}

			}

		}


	}
}