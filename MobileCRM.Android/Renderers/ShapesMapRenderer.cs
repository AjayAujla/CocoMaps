using System;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Xamarin.Forms;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;

[assembly: ExportRenderer (typeof(MobileCRM.ShapesMap), typeof(MobileCRMAndroid.ShapesMapRenderer))]
namespace MobileCRMAndroid
{

	public class ShapesMapRenderer : MapRenderer
		{
			bool _isDrawnDone;
	
		

			protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
			{
				base.OnElementPropertyChanged (sender, e);
				var androidMapView = (MapView)Control;
				var formsMap = (MobileCRM.ShapesMap)sender;

				if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {
					//androidMapView.Map.Clear ();

					androidMapView.Map.MyLocationEnabled = formsMap.IsShowingUser;

					// Hall Building Shape
					PolygonOptions HBldgShape = new PolygonOptions();
					HBldgShape.Add(new LatLng(45.49770304029157, -73.57904434204102));
					HBldgShape.Add(new LatLng(45.497372148435424, -73.57834160327911));
					HBldgShape.Add(new LatLng(45.49683820520362, -73.57885658740997));
					HBldgShape.Add(new LatLng(45.497172860356585, -73.57953786849976));
					HBldgShape.Add(new LatLng(45.49770304029157, -73.57904434204102));
					// 3F -> transparency to ~25%  // 932439 -> Concordia's red color
					HBldgShape.InvokeFillColor (0x3F932439);
					HBldgShape.InvokeStrokeColor (0x3F932439);
					androidMapView.Map.AddPolygon (HBldgShape);

					_isDrawnDone = true;

				}
			}

	}
}
