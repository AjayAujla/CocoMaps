using System;
using CocoMaps.Shared;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class PlacesRepository
	{
		static PlacesRepository repository;

		readonly List<Pin> cafes = new List<Pin> ();
		readonly List<Pin> food = new List<Pin> ();
		readonly List<Pin> libraries = new List<Pin> ();

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

		async void Init ()
		{
			var placesRequest = RequestPlaces.getInstance;

			Places places = await placesRequest.getPlaces ("cafe", Campus.SGWPosition);
			foreach (Result r in places.results) {
				var pin = new Pin {
					Type = PinType.Place,
					Position = new Position (r.geometry.location.lat, r.geometry.location.lng),
					Label = r.name,
					Address = r.vicinity
				};
				cafes.Add (pin);
				Console.WriteLine (pin.Label);
			}

		}
	}
}