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
		Button bt;


		public void WriteConsole() {
			Console.WriteLine("EVENT TRIGGERED!!!");
		}


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



				// Hall Building Shape
				PolygonOptions shape = new PolygonOptions ();

				BuildingPolygons bp = new BuildingPolygons ();

				Campus cSGW = bp.getSGWcampus ();

				foreach (Building b in cSGW.SGWBuildingsList){

					shape = new PolygonOptions ();
					// 3F -> transparency to ~25%  // 932439 -> Concordia's red color
					shape.InvokeFillColor(0x3F932439);
					shape.InvokeStrokeColor (0x00932439);

					foreach (System.Drawing.PointF p in b.ShapeCoords) {
						shape.Add (new LatLng(p.X, p.Y));
					}

					Console.WriteLine ("Shaping " + b.Name);
					androidMapView.Map.AddPolygon (shape);

				};
					


				_isDrawnDone = true;

			}

		}

	}
}