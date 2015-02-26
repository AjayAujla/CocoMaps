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

		static void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			var m = sender as Marker;
			Console.WriteLine ("Marker Clicked!");
			//DetailsViewModel.getInstance.UpdateView (directions);
			DetailsViewModel.getInstance.ShowSummary ();


//			if (m != null)
//				Console.WriteLine (m.Title + " CLICKED!!!");

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

		static bool InPolygon (Building building, double testX, double testY)
		{
			int i, j;
			var latlnglist = new List<LatLng> ();
			bool c = false;

			foreach (Tuple<double, double> point in building.ShapeCoords)
				latlnglist.Add (new LatLng (point.Item1, point.Item2));

			for (i = 0, j = latlnglist.Count - 1; i < latlnglist.Count - 1; j = i++) {
				if ((latlnglist [i].Longitude > testY) != (latlnglist [j].Longitude > testY) &&
				    (testX < (latlnglist [j].Latitude - latlnglist [i].Latitude) * (testY - latlnglist [i].Longitude) / (latlnglist [j].Longitude - latlnglist [i].Longitude) + latlnglist [i].Latitude))
					c = !c;
			}
			return c;
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
				androidMapView.Map.UiSettings.MapToolbarEnabled = false;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;

				androidMapView.Map.MapClick += (senderr, ee) => {

					foreach (Campus campus in buildingRepo.getCampusList()) {
						foreach (Building building in campus.Buildings) {
							if (InPolygon (building, ee.Point.Latitude, ee.Point.Longitude)) {


								detailsLayout.UpdateView (building);
								detailsLayout.ShowSummary ();

								Console.WriteLine ("COORDINATES ARE IN " + building);
								return;
							}
						}
					}
				};

				androidMapView.Map.MapLongClick += async (senderr, ee) => {

					if (App.isConnected ()) {
						foreach (Campus campus in buildingRepo.getCampusList()) {
							foreach (Building building in campus.Buildings) {
								if (InPolygon (building, ee.Point.Latitude, ee.Point.Longitude)) {
							
									if (_from.Equals ("")) {
										_from = building.Address;
										androidMapView.Map.AddMarker (new MarkerOptions ()
											.SetTitle (building.Code)
											.SetSnippet (building.Address)
											.SetPosition (new LatLng (building.ShapeCoords [0].Item1, building.ShapeCoords [0].Item2)));
									} else {
										_to = building.Address;
										androidMapView.Map.AddMarker (new MarkerOptions ()
											.SetTitle (building.Code)
											.SetSnippet (building.Address)
											.SetPosition (new LatLng (building.ShapeCoords [0].Item1, building.ShapeCoords [0].Item2)));

										RequestDirections directionsRequest = RequestDirections.getInstance;

										Directions directions = await directionsRequest.getDirections (_from, _to, TravelMode.walking);

										if (directions.status.Equals ("OK")) {

											var loader = ActivityLoading.getInstance ();
											ActivityLoading.Show (loader);

											PolylineOptions polyline = new PolylineOptions ();
											polyline.InvokeColor (0x7F00768e);
											var directionsString = "";

											foreach (Route route in directions.routes) {

												detailsLayout.UpdateView (directions);
												detailsLayout.ShowSummary ();

												route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
												foreach (Position point in route.overview_polyline.decodedPoints) {
													polyline.Add (new LatLng (point.Latitude, point.Longitude));
												}
												foreach (Leg leg in route.legs) {
													foreach (Step step in leg.steps) {
														directionsString += step.html_instructions;
													}
												}
											}
											androidMapView.Map.AddPolyline (polyline);


											ActivityLoading.Hide (loader);
										}
										//DependencyService.Get<ITextToSpeech> ().Speak (directionsString);
										_from = "";
										_to = "";
									}

									break;
								}
							}
						}
					}
				};

				foreach (Campus c in buildingRepo.getCampusList()) {

					foreach (Building b in buildingRepo.GetCampusByCode("SGW").Buildings) {

						using (PolygonOptions polygon = new PolygonOptions ()) {
							using (MarkerOptions buildingCodeMarker = new MarkerOptions ()) {

								buildingCodeMarker.SetPosition (new LatLng (b.Position.Item1, b.Position.Item2))
									.SetTitle (b.Code)
									.SetSnippet (b.Name)
									.InvokeIcon (GetCustomBitmapDescriptor (b.Code)); //BitmapDescriptorFactory.FromAsset ("CarWashMapIcon.png")
								buildingCodeMarker.Flat (true);
								androidMapView.Map.AddMarker (buildingCodeMarker);
							}
							polygon.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439).Geodesic (true);

							foreach (Tuple<double, double> p in b.ShapeCoords)
								polygon.Add (new LatLng (p.Item1, p.Item2));


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