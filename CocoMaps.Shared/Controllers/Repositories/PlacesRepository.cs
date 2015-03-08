using System;
using CocoMaps.Shared;
using System.Collections.Generic;
using Android.Graphics;

namespace CocoMaps.Shared
{
	public class PlacesRepository
	{
		static PlacesRepository repository;

		readonly List<Places> cafes = new List<Places> ();
		readonly List<Places> food = new List<Places> ();
		readonly List<Places> libraries = new List<Places> ();

		public static PlacesRepository getInstance {
			get {
				if (repository == null)
					repository = new PlacesRepository ();
				return repository;
			}
		}

		private PlacesRepository ()
		{
			// fetch places asynchronously here
			// on map page, we will only have to set markers visibility IsVisible = true/false
		}
	}
}