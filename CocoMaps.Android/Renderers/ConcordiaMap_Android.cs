using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Drawing;
using System.Collections.Generic;
using CocoMaps.Models;

[assembly: ExportRenderer (typeof(CocoMaps.ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var androidMapView = (MapView)Control;
			var formsMap = (CocoMaps.ConcordiaMap)sender;

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				//androidMapView.Map.Clear ();
				androidMapView.Map.MyLocationEnabled = formsMap.IsShowingUser;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MyLocationButtonEnabled = false;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = false;



				PolygonOptions pol = new PolygonOptions ();

				BuildingRepository br = new BuildingRepository ();

				foreach (Campus c in br.getCampusList()) {
				
					Console.WriteLine ("Shaping Campus " + c.Code);

					foreach (Building b in c.Buildings) {

						Console.WriteLine ("Shaping Building " + b.Name);

						pol = new PolygonOptions ();
						pol.InvokeFillColor (0x3F932439); // 3F -> transparency to ~25%
						pol.InvokeStrokeColor (0x00932439); // 932439 -> Concordia's red color

						foreach (Tuple<double, double> p in b.ShapeCoords) {
							pol.Add (new LatLng (p.Item1, p.Item2));
						}

						androidMapView.Map.AddPolygon (pol);
					
					}
				}

				_isDrawnDone = true;

			}

		}

	}
}