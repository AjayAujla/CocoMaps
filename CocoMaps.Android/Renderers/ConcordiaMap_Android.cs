using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Collections.Generic;
using Android.Graphics;

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;
		string _from = "";
		string _to = "";
		MarkerOptions testMarker;

		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			Console.WriteLine (e.Marker.Title + " CLICKED!!!");
		}

		Paint paint = new Paint (PaintFlags.AntiAlias);
		Rect bounds = new Rect ();

		BitmapDescriptor GetCustomBitmapDescriptor (string text)
		{
			using (Paint paint = new Paint (PaintFlags.LinearText)) {
				paint.Color = Android.Graphics.Color.White;
				paint.TextSize = 45;
				paint.SetTypeface (Typeface.DefaultBold);

				using (Rect bounds = new Rect ()) {
					using (Bitmap baseBitmap = BitmapFactory.DecodeResource (Resources, CocoMaps.Android.Resource.Drawable.buildingCodeIcon)) {
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

		bool InPolygon (Building building, double testX, double testY)
		{
			int i, j;
			List<LatLng> latlnglist = new List<LatLng> ();
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
			var formsMap = (ConcordiaMap)sender;
			BuildingRepository buildingRepo = BuildingRepository.getInstance;

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				//androidMapView.Map.Clear ();
				androidMapView.Map.MyLocationEnabled = true;
				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;

				androidMapView.Map.MapClick += (object senderr, GoogleMap.MapClickEventArgs ee) => {
					foreach (Campus c in buildingRepo.getCampusList()) {
						foreach (Building b in c.Buildings) {
							if (InPolygon (b, ee.Point.Latitude, ee.Point.Longitude)) {

								// Drop a pin wherever we touch, for testing accuracy
								testMarker = new MarkerOptions ();
								testMarker.SetPosition (new LatLng (ee.Point.Latitude, ee.Point.Longitude));
								testMarker.SetTitle (b.Code);
								testMarker.SetSnippet (b.Name);

								androidMapView.Map.AddMarker (testMarker);

								Console.WriteLine ("COORDINATES ARE IN BUILDING " + b.Campus + ", " + b.Code + " - " + b.Name);
								break;
							}
						}
					}
				};

				androidMapView.Map.MapLongClick += (object senderr, GoogleMap.MapLongClickEventArgs ee) => {

					foreach (Campus c in buildingRepo.getCampusList()) {
						foreach (Building b in c.Buildings) {
							if (InPolygon (b, ee.Point.Latitude, ee.Point.Longitude)) {
							
								if (_from.Equals ("")) {
									_from = b.Address;
									androidMapView.Map.AddMarker (new MarkerOptions ()
										.SetTitle (b.Code)
										.SetSnippet (b.Address)
										.SetPosition (new LatLng (b.ShapeCoords [0].Item1, b.ShapeCoords [0].Item2)));
								} else {
									_to = b.Address;
									androidMapView.Map.AddMarker (new MarkerOptions ()
										.SetTitle (b.Code)
										.SetSnippet (b.Address)
										.SetPosition (new LatLng (b.ShapeCoords [0].Item1, b.ShapeCoords [0].Item2)));

									RequestDirections directionsRequest = RequestDirections.getInstance;

									var directions = directionsRequest.getDirections (_from, _to, CocoMaps.Shared.GoogleDirections.Mode.Walking);

									if (directions.status.Equals ("OK")) {

										PolylineOptions polyline = new PolylineOptions ();
										polyline.InvokeColor (0x7F00768e);
										var directionsString = "";

										foreach (CocoMaps.Shared.GoogleDirections.Route route in directions.routes) {
											route.overview_polyline.decodedPoints = GooglePoints.Decode (route.overview_polyline.points);
											foreach (LatLng point in route.overview_polyline.decodedPoints) {
												polyline.Add (point);
											}
											foreach (CocoMaps.Shared.GoogleDirections.Leg leg in route.legs) {
												foreach (CocoMaps.Shared.GoogleDirections.Step step in leg.steps) {
													directionsString += step.html_instructions;
												}
											}

											androidMapView.Map.AddPolyline (polyline);

										}
									}

									//DependencyService.Get<ITextToSpeech> ().Speak (directionsString);
									_from = "";
									_to = "";
								}


								break;
							}
						}
					}
				};

				//foreach (Campus c in buildingRepo.getCampusList()) {

					foreach (Building b in buildingRepo.GetCampusByCode("SGW").Buildings) {

						using (PolygonOptions polygon = new PolygonOptions ()) {
							var markerWithIcon = new MarkerOptions ();


							//androidMapView.Map.MarkerClick += this.HandleMarkerClick;

							
							polygon.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439).Geodesic (true);

							foreach (Tuple<double, double> p in b.ShapeCoords)
								polygon.Add (new LatLng (p.Item1, p.Item2));
							androidMapView.Map.AddPolygon (polygon);

						markerWithIcon.SetPosition (new LatLng (b.Position.Item1, b.Position.Item2))
							.SetTitle (b.Code)
							.SetSnippet (b.Name)
							.InvokeIcon (GetCustomBitmapDescriptor (b.Code)); //BitmapDescriptorFactory.FromAsset ("CarWashMapIcon.png")
						androidMapView.Map.AddMarker (markerWithIcon);

							//polygon = new PolygonOptions ();
						}
					//}
				}

				_isDrawnDone = true;

			}

		}

	}
}