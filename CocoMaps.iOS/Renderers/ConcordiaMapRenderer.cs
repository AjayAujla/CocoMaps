using System;
using Xamarin.Forms.Maps;
using MapKit;
using CoreLocation;
using Xamarin.Forms;
using CocoMaps.Shared;
using UIKit;
using CoreGraphics;
using Xamarin.Forms.Maps.iOS;
using System.Drawing;

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMaps.iOS.ConcordiaMap_iOS))]

namespace CocoMaps.iOS
{

	public class ConcordiaMap_iOS : MapRenderer
	{

		bool _isDrawnDone;
		MKPolygon polygonpOverlay;
		MKPolygonRenderer polygonRenderer;
		MKMapView iOSMapView;

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			double lat = 45.49770304029157;
			double lon = -73.57904434204102;

			if (!_isDrawnDone) {
				//iOSMapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

				CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
				MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 200, 200);
//				SetNativeControl (
//					new MKMapView () {
//						// change map type, show user location and allow zooming and panning
//						MapType = MKMapType.Standard,
//						ShowsUserLocation = true,
//						PitchEnabled = true,
//						ZoomEnabled = true,
//						ShowsPointsOfInterest = false,
//						ScrollEnabled = true,
//						CenterCoordinate = mapCenter,
//						Region = mapRegion
//					}
//				);

				Console.WriteLine (e.PropertyName);

				MKMapViewDelegate _mapDelegate = new MKMapViewDelegate ();
				//iOSMapView.Delegate = _mapDelegate;

				//var mapClickGesture = new UITapGestureRecognizer (MapClick);
				//iOSMapView.AddGestureRecognizer (mapClickGesture);

				var mapLongClickGesture = new UILongPressGestureRecognizer (tap => {

					CGPoint point = tap.LocationInView (this);
					var mapPoint = ConvertPointToView (point, this);
					Console.WriteLine (mapPoint.X + "x" + point.Y);
				});
				//iOSMapView.AddGestureRecognizer (mapLongClickGesture);


				BuildingRepository br = BuildingRepository.getInstance;
				MKPolygon pol;


				foreach (Building building in br.BuildingList.Values) {

					CLLocationCoordinate2D[] coordinates = new CLLocationCoordinate2D[building.ShapeCoords.Count];

					int i = 0;
					foreach (Position coordinate in building.ShapeCoords)
						coordinates [i++] = new CLLocationCoordinate2D (coordinate.Latitude, coordinate.Longitude);

					pol = MKPolygon.FromCoordinates (coordinates);
					//iOSMapView.AddOverlay (pol);
				}

//				iOSMapView.OverlayRenderer = (m, o) => {
//					polygonRenderer = new MKPolygonRenderer (o as MKPolygon);
//					polygonRenderer.FillColor = CocoMaps.Shared.Helpers.Color.Maroon;
//					polygonRenderer.Alpha = 0.5f;
//
//					return polygonRenderer;
//				};

				Console.WriteLine ("ADDED POLYGONS");
				_isDrawnDone = true;

			}

		}
		//
		//		void MapClick (UITapGestureRecognizer tapBuilding)
		//		{
		//			CGPoint point = tapBuilding.LocationInView (this);
		//			Console.WriteLine (point.X + ", " + point.Y);
		//
		//			foreach (IMKOverlay overlay in iOSMapView.Overlays) {
		//				if (overlay is MKPolygon) {
		//
		//					Building building = GoogleUtil.PointInBuilding (point.X, point.Y);
		//					if (building != null)
		//						Console.WriteLine (building);
		//				}
		//			}
		//		}
		//
		//		void MapLongClick (UILongPressGestureRecognizer gestureRecognizer)
		//		{
		//			Console.WriteLine ("FIRING EVENT!!!");
		//		}


	}
}