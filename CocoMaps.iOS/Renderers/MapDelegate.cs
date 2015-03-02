using System;
using MapKit;

namespace CocoMaps.iOS
{
	class MapDelegate : MKMapViewDelegate
	{
		public override void DidSelectAnnotationView (MKMapView mapView, MKAnnotationView view)
		{
			var sampleAnnotation = view.Annotation as SampleMapAnnotation;

			if (sampleAnnotation != null) {

				//demo accessing the coordinate of the selected annotation to zoom in on it
				mapView.Region = MKCoordinateRegion.FromDistance (sampleAnnotation.Coordinate, 500, 500);

				//demo accessing the title of the selected annotation
				Console.WriteLine ("{0} was tapped", sampleAnnotation.Title);
			}

		}
	}
}