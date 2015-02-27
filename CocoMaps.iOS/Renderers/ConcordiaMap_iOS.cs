using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.iOS;
using MapKit;
using CoreLocation;
using Xamarin.Forms;
using CocoMaps.Shared;
using Xamarin.Forms.Maps.iOS;

[assembly: ExportRenderer (typeof(CocoMaps.Shared.ConcordiaMap), typeof(CocoMaps.iOS.ConcordiaMap_iOS))]

namespace CocoMaps.iOS
{

	public class ConcordiaMap_iOS : ViewRenderer
	{

		bool _isDrawnDone;
		MKPolygon polygonpOverlay;
		MKPolygonRenderer polygonRenderer;

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			double lat = 45.49770304029157;
			double lon = -73.57904434204102;

			if (!_isDrawnDone) {

				CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
				MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 200, 200);
				SetNativeControl (
					new MKMapView () {
						// change map type, show user location and allow zooming and panning
						MapType = MKMapType.Standard,
						ShowsUserLocation = true,
						ZoomEnabled = true,
						ScrollEnabled = true,
						CenterCoordinate = mapCenter,
						Region = mapRegion
					}
				);

				var iOSMapView = (MKMapView)Control;

				#region Private Variables
				MapDelegate _mapDelegate;
				#endregion
				_mapDelegate = new MapDelegate ();
				iOSMapView.Delegate = _mapDelegate;


				iOSMapView.ShowsUserLocation = true;
				iOSMapView.ZoomEnabled = true;

				BuildingRepository br = BuildingRepository.getInstance;
				MKPolygon pol;
				//CLLocationCoordinate2D[] coordinates;

				foreach (Campus c in br.getCampusList()) {

					Console.WriteLine ("Number of buildings in " + c.Code + " is " + c.Buildings.Count);

					foreach (Building b in c.Buildings) {

						foreach (Position p in b.ShapeCoords) {

						}
						Console.WriteLine ("SHAPED " + b.Name);

						//pol = MKPolygon.FromCoordinates (coordinates);

						iOSMapView.OverlayRenderer = (m, o) => {
							polygonRenderer = new MKPolygonRenderer (o as MKPolygon);
							polygonRenderer.FillColor = CocoMaps.Shared.Helpers.Color.Maroon;
							polygonRenderer.Alpha = 0.5f;

							return polygonRenderer;
						};

						//iOSMapView.AddOverlay (pol);

					}

				}

				Console.WriteLine ("ADDED OVERLAYS");
				_isDrawnDone = true;

			}


		}

	}
}