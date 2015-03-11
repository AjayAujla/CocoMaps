using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Collections.Generic;
using Android.Graphics;
using Xamarin.Forms.Maps;
using Android.OS;

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;
		string _from = "";
		string _to = "";
		PlacesRepository placesRepo = PlacesRepository.getInstance;

		Dictionary<String, Building> MarkerBuilding = new Dictionary<String, Building> ();
		Dictionary<Marker, Result> MarkerPOI = new Dictionary<Marker, Result> ();


		Element MainLayout {
			get {
				return this.Element.Parent;
			}
		}


		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			Building building;
			if (MarkerBuilding.TryGetValue (e.Marker.Id, out building))
				DetailsViewModel.getInstance.UpdateView (building);
			else {
				e.Marker.ShowInfoWindow ();
			}
		}

		BitmapDescriptor GetCustomBitmapDescriptor (string text)
		{
			using (var paint = new Paint (PaintFlags.LinearText)) {
				paint.Color = Android.Graphics.Color.White;
				paint.TextSize = 45;
				paint.SetTypeface (Typeface.DefaultBold);

				using (var bounds = new Rect ()) {
					using (var baseBitmap = BitmapFactory.DecodeResource (Resources, CocoMaps.Android.Resource.Drawable.ic_buildingcode_transparent)) {
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

				androidMapView.Map.MapLongClick += async (senderr, ee) => {

					if (App.isConnected ()) {

						Building building = GoogleUtil.PointInBuilding (ee.Point.Latitude, ee.Point.Longitude);
						if (building != null) {

							if (_from.Equals ("")) {
								_from = building.Address;
								androidMapView.Map.AddMarker (new MarkerOptions ()
									.SetTitle (building.Code)
									.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.Position.Latitude, building.Position.Longitude))
									.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_start)));
							} else {
								_to = building.Address;
								androidMapView.Map.AddMarker (new MarkerOptions ()
									.SetTitle (building.Code)
									.SetSnippet (building.Address)
									.SetPosition (new LatLng (building.Position.Latitude, building.Position.Longitude))
									.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_end)));

								var loaderViewModel = LoaderViewModel.getInstance;
								loaderViewModel.Show ();

								RequestDirections directionsRequest = RequestDirections.getInstance;

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

				Marker marker;

				// Adding all Buildings' Icons and Buildings' Polygons
				foreach (Campus c in buildingRepo.getCampusList()) {
					foreach (Building b in c.Buildings) {
						using (PolygonOptions polygon = new PolygonOptions ()) {
							using (MarkerOptions buildingCodeMarker = new MarkerOptions ()) {

								buildingCodeMarker.SetTitle (b.Code)
									.SetSnippet (b.Name)
									.SetPosition (new LatLng (b.Position.Latitude, b.Position.Longitude))
									.InvokeIcon (GetCustomBitmapDescriptor (b.Code)); //BitmapDescriptorFactory.FromAsset ("CarWashMapIcon.png")
								buildingCodeMarker.Flat (true);
								buildingCodeMarker.GetHashCode ();
								marker = androidMapView.Map.AddMarker (buildingCodeMarker);

								// Creating an association between the marker and the building object
								MarkerBuilding.Add (marker.Id, b);

							}
							polygon.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439).Geodesic (true);

							foreach (Position p in b.ShapeCoords)
								polygon.Add (new LatLng (p.Latitude, p.Longitude));


							androidMapView.Map.AddPolygon (polygon);

						}
					}
				}

				RelativeLayout rl = MainLayout as RelativeLayout;
				Button but = rl.Children [3] as Button;
				bool isPOIAdded = false;
				bool isPOIVisible = false;

				Button bb =	MasterPage.POIButton;

				bb.Clicked += async (send, ev) => {

					if (App.isConnected ()) {

						// Adding all POIs' Icons
						if (!isPOIAdded) {
							foreach (Result result in placesRepo.POIs) {
								using (MarkerOptions poiMarker = new MarkerOptions ()) {
									poiMarker.SetTitle (result.name)
										.SetSnippet (result.vicinity)
										.SetPosition (new LatLng (result.geometry.location.lat, result.geometry.location.lng));

									// Tried to get resources dynamically (e.g. CocoMaps.Android.Resource.Drawable + result.type[0] or FromAsset())
									// But failed miserably
									if (result.types.Contains ("cafe"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_cafe));
									else if (result.types.Contains ("bar"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_bar));
									else if (result.types.Contains ("food"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_food));
									else if (result.types.Contains ("bank"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_bank));
									else if (result.types.Contains ("atm"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_atm));
									else if (result.types.Contains ("gaz_station"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_gaz_station));
									else if (result.types.Contains ("library"))
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_library));
									else
										poiMarker.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_default));
									
									marker = androidMapView.Map.AddMarker (poiMarker);

									MarkerPOI.Add (marker, result);

								}
							}
							isPOIAdded = true;
						} else {

							// toggling markers visibility
							foreach (Marker m in MarkerPOI.Keys) {
								m.Visible = !m.Visible;
							}
					
						}
					}




				};
				androidMapView.Map.MarkerClick += HandleMarkerClick;

				_isDrawnDone = true;

			}

		}

	}
}