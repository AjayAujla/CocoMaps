using System;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.iOS;
using MapKit;
using CoreLocation;

[assembly: ExportRenderer (typeof(MobileCRM.ShapesMap), typeof(MobileCRM.iOS.ShapesMapRenderer))]
namespace MobileCRM.iOS
{

	public class ShapesMapRenderer : MapRenderer
	{

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			double lat = 45.49770304029157;
			double lon = -73.57904434204102;
			CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
			MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 200, 200);
			SetNativeControl(
				new MKMapView()
				{
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

				iOSMapView.ShowsUserLocation = true;

				MKPolygon HBldgShape = MKPolygon.FromCoordinates(
					new CLLocationCoordinate2D[]{
						new CLLocationCoordinate2D(45.49770304029157, -73.57904434204102),
						new CLLocationCoordinate2D(45.497372148435424, -73.57834160327911),
						new CLLocationCoordinate2D(45.49683820520362, -73.57885658740997),
						new CLLocationCoordinate2D(45.497172860356585, -73.57953786849976),
						new CLLocationCoordinate2D(45.49770304029157, -73.57904434204102)
					});


				iOSMapView.AddOverlay (HBldgShape);
				MKPolygonView polygonView = new MKPolygonView(HBldgShape);
				polygonView.FillColor = UIKit.UIColor.Blue;
				polygonView.StrokeColor = UIKit.UIColor.Red;

		}

	}
}
