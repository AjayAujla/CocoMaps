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

		Position _from = new Position (0, 0);
		Position _to = new Position (0, 0);

		MapView androidMapView;

		Marker _startPin;
		Marker _endPin;
		Marker _toiletPin;

		Android.Gms.Maps.Model.Polyline polyline;
		PolylineOptions polylineOptions;
		PolylineOptions shuttleBusPolyline;

		PlacesRepository placesRepo;
		ShuttleBusPolyline shuttleBusPolylinePoints = ShuttleBusPolyline.getInstance;
		BuildingRepository buildingRepo = BuildingRepository.getInstance;
		DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

		// used to map Markers' ID (a string) to their representative object
		Dictionary<String, Building> MarkerBuilding = new Dictionary<String, Building> ();
		Dictionary<Marker, Result> MarkerPOI = new Dictionary<Marker, Result> ();
		Dictionary<String, Directions> MarkerDirections = new Dictionary<String, Directions> ();



		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			Building building;
			Directions directions;

			if (MarkerBuilding.TryGetValue (e.Marker.Id, out building))
				DetailsViewModel.getInstance.UpdateView (building);
			else if (MarkerDirections.TryGetValue (e.Marker.Id, out directions)) {
				if (directions != null)
					DetailsViewModel.getInstance.UpdateView (directions);
			} else
				e.Marker.ShowInfoWindow ();
		
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
			





			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {
				
				androidMapView = (MapView)Control;

				var loaderViewModel = LoaderViewModel.getInstance;


				// Initializing Start and End Markers, and directions' Polyline
				using (MarkerOptions mo = new MarkerOptions ()) {
					mo.SetPosition (new LatLng (0, 0))
						.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_start));

					_startPin = androidMapView.Map.AddMarker (mo);

					mo.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_end));

					_endPin = androidMapView.Map.AddMarker (mo);

					polylineOptions = new PolylineOptions ();
					polylineOptions.InvokeColor (0x7F00768e).InvokeWidth (20);

				}

				using (MarkerOptions toilet = new MarkerOptions ()) {
					toilet.SetPosition (new LatLng (45.4972631, -73.5787094))
						.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.toilet_male));

					_toiletPin = androidMapView.Map.AddMarker (toilet);

					//toilet.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_end));

					//_endPin = androidMapView.Map.AddMarker (toilet);

				}
				androidMapView.Map.MapClick += (senderr, ee) => detailsLayout.Hide ();

				androidMapView.Map.MapLongClick += async (senderr, ee) => {

					if (App.isConnected ()) {


						Building building = GoogleUtil.PointInBuilding (ee.Point.Latitude, ee.Point.Longitude);
						if (building != null) {

							// For displaying the pins just above the building's code pin
							double pinOffsetY = 0.0001;
							Directions directions = null;

							if (_from.Latitude == 0 && _from.Longitude == 0) {
							
								// resetting previous polyline
								if (polyline != null) {
									polyline.Points.Clear ();
									polyline.Remove ();
									polylineOptions.Points.Clear ();
									MarkerDirections.Clear ();
									_endPin.Position = new LatLng (0, 0);
								}

								_from = building.Position;

								// defining the origin pin
								_startPin.Title = building.Code;
								_startPin.Snippet = building.Address;
								_startPin.Position = new LatLng (building.Position.Latitude + pinOffsetY, building.Position.Longitude);

								// linking _startPin to path
								polylineOptions.Add (new LatLng (building.Position.Latitude, building.Position.Longitude));

								MarkerDirections.Add (_startPin.Id, directions);

							} else {
								
								_to = building.Position;
								MarkerDirections.Clear ();
								// defining the destination pin
								_endPin.Title = building.Code;
								_endPin.Snippet = building.Address;
								_endPin.Position = new LatLng (building.Position.Latitude + pinOffsetY, building.Position.Longitude);

								loaderViewModel.Show ();

								RequestDirections directionsRequest = RequestDirections.getInstance;
								directions = await directionsRequest.getDirections (_from, _to, TravelMode.walking);

								if (directions.status.Equals ("OK")) {

									foreach (Route route in directions.routes) {

										detailsLayout.UpdateView (directions);

										route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);

										foreach (Position point in route.overview_polyline.decodedPoints)
											polylineOptions.Add (new LatLng (point.Latitude, point.Longitude));

										// linking path to _endPin pin
										polylineOptions.Add (new LatLng (building.Position.Latitude, building.Position.Longitude));

										polyline = androidMapView.Map.AddPolyline (polylineOptions);

										MarkerDirections.Add (_startPin.Id, directions);
										MarkerDirections.Add (_endPin.Id, directions);

									}

								}

								loaderViewModel.Hide ();

								_from = new Position (0, 0);
								_to = new Position (0, 0);

							}

						}
					}
				};

				base.OnElementPropertyChanged (sender, e);


				//var formsMap = (ConcordiaMap)sender;

				DrawShuttlePins ();

				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = false;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;

//				androidMapView.Map.MapClick += (senderr, ee) => detailsLayout.Hide ();


				Marker marker;
				// Adding all Buildings' Icons and Buildings' Polygons
				foreach (Building b in buildingRepo.BuildingList.Values) {
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
				


				bool isPOIAdded = false;

				Button poiButton =	MasterPage.POIButton;

				poiButton.Clicked += async (send, ev) => {

					// Adding all POIs' Icons
					if (!isPOIAdded) {
						if (App.isConnected () && App.isHostReachable ("googleapis.com")) {

							LoaderViewModel.getInstance.Show ();

							// fetch places from google
							List<Result> places = await PlacesRepository.getInstance.FetchPlaces ();

							foreach (Result result in places) {
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
							LoaderViewModel.getInstance.Hide ();

						}
					} else {

						// toggling markers visibility
						foreach (Marker m in MarkerPOI.Keys) {
							m.Visible = !m.Visible;
						}
					

					}


				};
				androidMapView.Map.MarkerClick += HandleMarkerClick;

				_isDrawnDone = true;

			}

		}

		void DrawShuttlePins ()
		{
			RequestShuttleBusSchedule requestShuttleBusSchedule = RequestShuttleBusSchedule.getInstance;
			List<String> nextDepartures = requestShuttleBusSchedule.GetNextPassages (3, "SGW");
			String nextDeparturesString = "";

			MarkerOptions marker = new MarkerOptions ();

			if (nextDepartures == null || nextDepartures.Count == 0)
				nextDeparturesString = "no passages";
			else
				foreach (String departure in nextDepartures)
					nextDeparturesString += nextDepartures + " ";

			// SGW Shuttle Bus Marker
			marker.SetTitle ("SGW Shuttle Bus");
			marker.SetSnippet ("Next Departures: " + nextDeparturesString);
			marker.SetPosition (
				new LatLng (shuttleBusPolylinePoints.ShuttleBusPoints [0].Latitude, 
					shuttleBusPolylinePoints.ShuttleBusPoints [0].Longitude)
			);
			marker.InvokeIcon (
				BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_shuttle)
			);
			androidMapView.Map.AddMarker (marker);

			marker = new MarkerOptions ();

			nextDepartures = requestShuttleBusSchedule.GetNextPassages (3, "LOY");
			nextDeparturesString = "";

			if (nextDepartures == null || nextDepartures.Count == 0)
				nextDeparturesString = "no passages";
			else
				foreach (String departure in nextDepartures)
					nextDeparturesString += departure + " ";
			
			// LOY Shuttle Bus Marker
			int lastPoint = shuttleBusPolylinePoints.ShuttleBusPoints.Count;

			marker.SetTitle ("LOY Shuttle Bus");
			marker.SetSnippet ("Next Departures: " + nextDeparturesString);
			marker.SetPosition (
				new LatLng (shuttleBusPolylinePoints.ShuttleBusPoints [lastPoint - 1].Latitude, 
					shuttleBusPolylinePoints.ShuttleBusPoints [lastPoint - 1].Longitude)
			);
			marker.InvokeIcon (
				BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_shuttle)
			);
			androidMapView.Map.AddMarker (marker);

		}


		void DrawShuttlePolyline ()
		{
			// For drawing Shuttle bus only once
			if (shuttleBusPolyline == null) {
				
				shuttleBusPolyline = new PolylineOptions ();
				shuttleBusPolyline.InvokeColor (0x7F932439).InvokeWidth (20);

				foreach (Position point in shuttleBusPolylinePoints.ShuttleBusPoints)
					shuttleBusPolyline.Add (new LatLng (point.Latitude, point.Longitude));
			
				androidMapView.Map.AddPolyline (shuttleBusPolyline);

			}
		}

	}

}