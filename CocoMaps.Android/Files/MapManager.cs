using System;
using CocoMaps.Shared;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

[assembly: Dependency (typeof(CocoMapsAndroid.MapManager))]

namespace CocoMapsAndroid
{
	public class MapManager : IMapManager
	{
		public void getDirectionsToClass (ConcordiaMap map, Directions directions)
		{
			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

			Console.WriteLine ("GETTING DIRECTIONS TO CLASS");

			var _androidMapView = ConcordiaMapRenderer.getInstance.AndroidMapView;

			Console.WriteLine ("GETTING DIRECTIONS TO CLASS 2");

			if (directions.status.Equals ("OK")) {

				var loader = LoaderViewModel.getInstance;
				loader.Show ();

				var polyline = new PolylineOptions ();
				polyline.InvokeColor (0x7F00768e);

				Console.WriteLine ("GETTING DIRECTIONS TO CLASS 3");

				foreach (Route route in directions.routes) {

					detailsLayout.UpdateView (directions);

					Console.WriteLine ("GETTING DIRECTIONS TO CLASS 4");

					route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
					foreach (Position point in route.overview_polyline.decodedPoints) {
						polyline.Add (new LatLng (point.Latitude, point.Longitude));
					}

				}

				Console.WriteLine ("GETTING DIRECTIONS TO CLASS 5");

				_androidMapView.Map.AddPolyline (polyline);

				Console.WriteLine ("GETTING DIRECTIONS TO CLASS 6");

				loader.Hide ();
			}
		}
	}
}