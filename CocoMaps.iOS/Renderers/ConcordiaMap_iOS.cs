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
using System.Runtime.InteropServices;

[assembly: ExportRenderer (typeof(CocoMaps.ConcordiaMap), typeof(CocoMaps.iOS.ConcordiaMap_iOS))]

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
				SampleMapDelegate _mapDelegate;
				#endregion
				_mapDelegate = new SampleMapDelegate ();
				iOSMapView.Delegate = _mapDelegate;


				iOSMapView.ShowsUserLocation = true;
				iOSMapView.ZoomEnabled = true;

				BuildingRepository br = new BuildingRepository ();
				MKPolygon pol;
				CLLocationCoordinate2D[] coordinates;

				foreach (Campus c in br.getCampusList()) {

					Console.WriteLine ("Number of buildings in " + c.Code + " is " + c.Buildings.Count);

					foreach (Building b in c.Buildings) {
						Console.WriteLine ("Number of coordinates in " + b.Code + " is " + b.ShapeCoords.Length);
						coordinates = new CLLocationCoordinate2D[b.ShapeCoords.Length];

						foreach (Tuple<double, double> p in b.ShapeCoords) {
							for (int i = 0; i < b.ShapeCoords.Length; i++)
								coordinates [i++] = new CLLocationCoordinate2D (p.Item1, p.Item2);
						}
						Console.WriteLine ("SHAPED " + b.Name);

						pol = MKPolygon.FromCoordinates (coordinates);

						iOSMapView.OverlayRenderer = (m, o) => {
							polygonRenderer = new MKPolygonRenderer (o as MKPolygon);
							polygonRenderer.FillColor = CocoMaps.Shared.Helpers.Color.Maroon;
							polygonRenderer.Alpha = 0.5f;

							return polygonRenderer;
						};

						iOSMapView.AddOverlay (pol);

					}

				}

				Console.WriteLine ("ADDED OVERLAYS");
				_isDrawnDone = true;

			}


		}

	}
}