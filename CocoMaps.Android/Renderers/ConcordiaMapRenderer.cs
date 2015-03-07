using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Collections.Generic;
using Android.Graphics;
using Xamarin.Forms.Maps;

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;
		string _from = "";
		string _to = "";

		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			var myMap = this.Element as ConcordiaMap;
			DetailsViewModel.getInstance.UpdateView (e.Marker.Title);
		
		}

		BitmapDescriptor GetCustomBitmapDescriptor (string text)
		{
			using (var paint = new Paint (PaintFlags.LinearText)) {
				paint.Color = Android.Graphics.Color.White;
				paint.TextSize = 45;
				paint.SetTypeface (Typeface.DefaultBold);

				using (var bounds = new Rect ()) {
					using (var baseBitmap = BitmapFactory.DecodeResource (Resources, CocoMaps.Android.Resource.Drawable.buildingCodeIcon)) {
						Bitmap bitmap = baseBitmap.Copy (Bitmap.Config.Argb8888, true);

						paint.GetTextBounds (text, 0, text.Length, bounds);

						float x = bitmap.Width / 2.0f;
						float y = (bitmap.Height - bounds.Height ()) / 2.0f - bounds.Top;

						Canvas canvas = new Canvas (bitmap);

						canvas.DrawText (text, x, y, paint);

						BitmapDescriptor icon = BitmapDescriptorFactory.FromBitmap (bitmap);

						return (icon);
					}
				}
			}
		}

		public void getDirectionsToClass (Directions directions)
		{
			var androidMapView = (MapView)Control;
			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;


			if (directions.status.Equals ("OK")) {

				var loader = LoaderViewModel.getInstance;
				loader.Show ();

				PolylineOptions polyline = new PolylineOptions ();
				polyline.InvokeColor (0x7F00768e);

				foreach (Route route in directions.routes) {

					detailsLayout.UpdateView (directions);

					route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
					foreach (Position point in route.overview_polyline.decodedPoints) {
						polyline.Add (new LatLng (point.Latitude, point.Longitude));
					}

				}
				androidMapView.Map.AddPolyline (polyline);


				loader.Hide ();
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			base.OnElementPropertyChanged (sender, e);
			var androidMapView = (MapView)Control;
			//var formsMap = (ConcordiaMap)sender;
			BuildingRepository buildingRepo = BuildingRepository.getInstance;
			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = false;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;

				androidMapView.Map.MapClick += (senderr, ee) => detailsLayout.Hide ();



//					Building building = GoogleUtil.PointInBuilding (ee.Point.Latitude, ee.Point.Longitude);
//					if (building != null) {
//
//						detailsLayout.UpdateView (building);
//
//						Console.WriteLine ("COORDINATES ARE IN " + building);
//
//					}
//					
//				};

				androidMapView.Map.MapLongClick += async (senderr, ee) => {

					if (App.isConnected ()) {

						Building building = GoogleUtil.PointInBuilding (ee.Point.Latitude, ee.Point.Longitude);
						if (building != null) {

							if (_from.Equals ("")) {
								_from = building.Address;
								androidMapView.Map.AddMarker (new MarkerOptions ()
											.SetTitle (building.Code)
											.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.ShapeCoords [0].Latitude, building.ShapeCoords [0].Longitude)));
							} else {
								_to = building.Address;
								androidMapView.Map.AddMarker (new MarkerOptions ()
											.SetTitle (building.Code)
											.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.ShapeCoords [0].Latitude, building.ShapeCoords [0].Longitude)));

								var loaderViewModel = LoaderViewModel.getInstance;
								loaderViewModel.Show ();

								RequestDirections directionsRequest = RequestDirections.getInstance;

								this.Element.PromptForTravelMode ();

								Directions directions = await directionsRequest.getDirections (_from, _to, TravelMode.walking);

								if (directions.status.Equals ("OK")) {

									PolylineOptions polyline = new PolylineOptions ();
									polyline.InvokeColor (0x7F00768e);

									foreach (Route route in directions.routes) {

										detailsLayout.UpdateView (directions);

										route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
										foreach (Position point in route.overview_polyline.decodedPoints) {
											polyline.Add (new LatLng (point.Latitude, point.Longitude));
										}

									}
									androidMapView.Map.AddPolyline (polyline);


								}

								loaderViewModel.Hide ();

								_from = "";
								_to = "";
							}

						}
					}
				};

				foreach (Campus c in buildingRepo.getCampusList()) {

					foreach (Building b in c.Buildings) {

						using (PolygonOptions polygon = new PolygonOptions ()) {
							using (MarkerOptions buildingCodeMarker = new MarkerOptions ()) {

								buildingCodeMarker.SetPosition (new LatLng (b.Position.Latitude, b.Position.Longitude))
									.SetTitle (b.Code)
									.SetSnippet (b.Name)
									.InvokeIcon (GetCustomBitmapDescriptor (b.Code)); //BitmapDescriptorFactory.FromAsset ("CarWashMapIcon.png")
								buildingCodeMarker.Flat (true);
								androidMapView.Map.AddMarker (buildingCodeMarker);
							}
							polygon.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439).Geodesic (true);

							foreach (Position p in b.ShapeCoords)
								polygon.Add (new LatLng (p.Latitude, p.Longitude));


							androidMapView.Map.AddPolygon (polygon);

						}
					}
				}

				androidMapView.Map.MarkerClick += HandleMarkerClick;

				_isDrawnDone = true;

			}

		}

	}
}