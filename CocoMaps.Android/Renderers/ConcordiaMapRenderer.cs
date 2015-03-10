using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using Android.Graphics;
using Xamarin.Forms.Maps;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Android.Net;
using Java.IO;
using System;
using System.Runtime.InteropServices;
using Android.App;
using Android;
using System.Security.Cryptography;

#pragma warning disable 618

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;
		string _from = "";
		string _to = "";
		MapView _androidMapView;

		static ConcordiaMapRenderer _concordiaMapRenderer;

		public static ConcordiaMapRenderer getInstance {
			get {
				if (_concordiaMapRenderer == null)
					_concordiaMapRenderer = new ConcordiaMapRenderer ();
				return _concordiaMapRenderer;

			}
		}

		ConcordiaMap _concordiaMap {
			get { return Element as ConcordiaMap; }
		}

		Button NextClassButton {
			get {
				var _mainLayout = (RelativeLayout)Element.Parent;
				var button = _mainLayout.Children [5] as Button;
				return button;
			}
		}

		public MapView AndroidMapView {
			get { 
				if (_androidMapView == null)
					_androidMapView = Control as MapView;
				return _androidMapView;
			}
		}

		BuildingRepository _buildingRepository {
			get { return BuildingRepository.getInstance; }
		}

		PlacesRepository _placesRepository {
			get { return PlacesRepository.getInstance; }
		}

		DetailsViewModel _detailsLayout {
			get { return DetailsViewModel.getInstance; }
		}

		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			using (var currentMarker = e.Marker) {
				_concordiaMap.SelectedBuilding = _buildingRepository.GetBuildingByCode (currentMarker.Title);
				DetailsViewModel.getInstance.UpdateView (currentMarker.Title);
			}
		}

		BitmapDescriptor GetCustomBitmapDescriptor (string text)
		{
			using (var paint = new Paint (PaintFlags.LinearText)) {
				paint.SetStyle (Paint.Style.Fill);

				paint.TextSize = 45;
				paint.SetTypeface (Typeface.DefaultBold);

				using (var bounds = new Rect ()) {
					using (var baseBitmap = BitmapFactory.DecodeResource (Resources, CocoMaps.Android.Resource.Drawable.buildingCodeIcon)) {
						Bitmap bitmap = baseBitmap.Copy (Bitmap.Config.Argb8888, true);
						paint.GetTextBounds (text, 0, text.Length, bounds);

						float x = bitmap.Width / 2.0f;
						float y = (bitmap.Height - bounds.Height ()) / 2.0f - bounds.Top;

						var canvas = new Canvas (bitmap);

						//paint.Color = Android.Graphics.Color.Maroon;
						//canvas.DrawCircle (x, y, 50, paint);
						paint.Color = Android.Graphics.Color.White;
						canvas.DrawText (text, x, y, paint);

						BitmapDescriptor icon = BitmapDescriptorFactory.FromBitmap (bitmap);

						return (icon);
					}
				}
			}
		}

		public void getDirectionsToClass (Directions directions)
		{
			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;


			if (directions.status.Equals ("OK")) {

				var loader = LoaderViewModel.getInstance;
				loader.Show ();

				var polyline = new PolylineOptions ();
				polyline.InvokeColor (0x7F00768e);

				foreach (Route route in directions.routes) {

					detailsLayout.UpdateView (directions);

					route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
					foreach (Position point in route.overview_polyline.decodedPoints) {
						polyline.Add (new LatLng (point.Latitude, point.Longitude));
					}

				}
				AndroidMapView.Map.AddPolyline (polyline);

				loader.Hide ();
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				AndroidMapView.Map.Clear ();
				AndroidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				AndroidMapView.Map.UiSettings.ZoomControlsEnabled = true;

				AndroidMapView.Map.MapClick += (senderr, ee) => _detailsLayout.Hide ();

				NextClassButton.Clicked += async (senderrr, eee) => {

					DetailsViewModel detailsLayout = DetailsViewModel.getInstance;
					RequestDirections directionsRequest = RequestDirections.getInstance;

					const string start = "7141 Sherbrooke Street W. Montreal QC";
					const string dest = "1455 De Maisonneuve Blvd. W. Montreal QC";

					Directions directions = await directionsRequest.getDirections (start, dest, TravelMode.walking);
					if (directions.status.Equals ("OK")) {

						var loader = LoaderViewModel.getInstance;
						loader.Show ();

						var polyline = new PolylineOptions ();
						polyline.InvokeColor (0x7F00768e);

						foreach (Route route in directions.routes) {

							detailsLayout.UpdateView (directions);

							route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
							foreach (Position point in route.overview_polyline.decodedPoints) {
								polyline.Add (new LatLng (point.Latitude, point.Longitude));
							}

						}
						AndroidMapView.Map.AddPolyline (polyline);

						loader.Hide ();
					}
				};

				AndroidMapView.Map.MapLongClick += async (senderr, ee) => {

					if (App.isConnected ()) {

						Building building = GoogleUtil.PointInBuilding (ee.Point.Latitude, ee.Point.Longitude);
						if (building != null) {

							if (_from.Equals ("")) {
								_from = building.Address;
								AndroidMapView.Map.AddMarker (new MarkerOptions ()
									.SetTitle (building.Code)
									.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.Position.Latitude, building.Position.Longitude))
									.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.map_start_pin)));
							} else {
								_to = building.Address;
								AndroidMapView.Map.AddMarker (new MarkerOptions ()
											.SetTitle (building.Code)
											.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.Position.Latitude, building.Position.Longitude))
									.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.map_end_pin)));

								var loaderViewModel = LoaderViewModel.getInstance;
								loaderViewModel.Show ();

								RequestDirections directionsRequest = RequestDirections.getInstance;

								Directions directions = await directionsRequest.getDirections (_from, _to, TravelMode.walking);

								if (directions.status.Equals ("OK")) {

									if (Settings.useDeviceMap) {

										DependencyService.Get<IPhoneService> ().LaunchMap (
											directions.routes [0].legs [0].end_address);
//											new NavigationModel () {
//												Latitude = directions.routes [0].legs [0].end_location.lat,
//												Longitude = directions.routes [0].legs [0].end_location.lng,
//												DestinationAddress = directions.routes [0].legs [0].end_address,
//												DestinationName = directions.routes [0].summary
//											});

									} else {

										var polyline = new PolylineOptions ();
										polyline.InvokeColor (0x7F00768e);

										foreach (Route route in directions.routes) {

											_detailsLayout.UpdateView (directions);

											route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
											foreach (Position point in route.overview_polyline.decodedPoints) {
												polyline.Add (new LatLng (point.Latitude, point.Longitude));
											}

										}
										AndroidMapView.Map.AddPolyline (polyline);

									}
								}

								loaderViewModel.Hide ();

								_from = "";
								_to = "";
							}

						}
					}
				};

				foreach (Campus c in _buildingRepository.getCampusList()) {

					foreach (Building b in c.Buildings) {

						using (var polygon = new PolygonOptions ()) {
							using (var buildingCodeMarker = new MarkerOptions ()) {

								buildingCodeMarker.SetPosition (new LatLng (b.Position.Latitude, b.Position.Longitude))
									.SetTitle (b.Code)
									.SetSnippet (b.Name)
									.InvokeIcon (GetCustomBitmapDescriptor (b.Code)); //BitmapDescriptorFactory.FromAsset ("CarWashMapIcon.png")
								AndroidMapView.Map.AddMarker (buildingCodeMarker);
							}
							polygon.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439).Geodesic (true);

							foreach (Position p in b.ShapeCoords)
								polygon.Add (new LatLng (p.Latitude, p.Longitude));


							AndroidMapView.Map.AddPolygon (polygon);

						}
					}
				}

				AndroidMapView.Map.MarkerClick += HandleMarkerClick;

				_isDrawnDone = true;

			}

		}


	}
}