using System;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.iOS;
using MapKit;
using UIKit;
using CoreLocation;
using Protocols_Delegates_Events;
using CocoMaps.Shared.Pages;
using Xamarin.Forms;
using CocoMaps.Shared;
using System.Drawing;
using System.Collections.Generic;
using CocoMaps.Models;

[assembly: ExportRenderer (typeof(CocoMaps.ConcordiaMap), typeof(CocoMaps.iOS.ConcordiaMap_iOS))]

namespace CocoMaps.iOS
{

	public class ConcordiaMap_iOS : ViewRenderer
	{

		MKPolygon polygonpOverlay;
		MKPolygonRenderer polygonRenderer;

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

			#region Private Variables
			SampleMapDelegate _mapDelegate;
			#endregion
			_mapDelegate = new SampleMapDelegate ();
			iOSMapView.Delegate = _mapDelegate;

			iOSMapView.OverlayRenderer = (m, o) => {
				if(polygonRenderer == null) {
					polygonRenderer = new MKPolygonRenderer(o as MKPolygon);
					polygonRenderer.FillColor = CocoMaps.Shared.Helpers.Color.Maroon;
					polygonRenderer.Alpha = 0.5f;
				}
				return polygonRenderer;
			};

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

		}

	}
}