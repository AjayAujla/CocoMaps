using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using CocoMaps.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using System.Threading.Tasks;
using CocoMaps.Indoor;

[assembly: ExportRenderer (typeof(ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{
	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;

		enum CampusDirection
		{
			WithinSGW,
			withinLOY,
			FromSGWtoLOY,
			FromLOYtoSGW
		}

		CampusDirection campusDirection;

		Position _from = new Position (0, 0);
		Position _to = new Position (0, 0);

		MapView androidMapView;

		Marker _startPin;
		Marker _endPin;

		List<Android.Gms.Maps.Model.Polyline> polylines = new List<Android.Gms.Maps.Model.Polyline> ();
		List<Directions> directions = new List<Directions> ();
		Directions totalDirections;

		Android.Gms.Maps.Model.Polyline shuttleBusPolyline;

		PolylineOptions polylineOptions;

		BuildingRepository buildingRepo = BuildingRepository.getInstance;
		DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

		// used to map Markers' ID (a string) to their representative object
		Dictionary<String, Building> MarkerBuilding = new Dictionary<String, Building> ();
		Dictionary<Marker, Result> MarkerPOI = new Dictionary<Marker, Result> ();
		Dictionary<String, Directions> MarkerDirections = new Dictionary<String, Directions> ();

		Dictionary<Marker, BookmarkItems> MarkerBookmarks = new Dictionary<Marker, BookmarkItems> ();

		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			Building building;
			Directions directions;
			BookmarkItems bookmark;

			if (MarkerBuilding.TryGetValue (e.Marker.Id, out building))
				DetailsViewModel.getInstance.UpdateView (building);
			else if (MarkerDirections.TryGetValue (e.Marker.Id, out totalDirections)) {
				if (totalDirections != null)
					DetailsViewModel.getInstance.UpdateView (totalDirections);
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

				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = false;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;


				androidMapView.Map.IndoorLevelActivated += (lsender, le) => {
					if (androidMapView.Map.FocusedBuilding != null)
						Console.WriteLine ("IndoorLevelActivated: " + androidMapView.Map.FocusedBuilding.ActiveLevelIndex);
				};

				androidMapView.Map.IndoorBuildingFocused += (lsender, le) => {
					if (androidMapView.Map.FocusedBuilding != null) {
						Console.WriteLine ("IndoorBuildingFocused: " + androidMapView.Map.FocusedBuilding.Levels);
						foreach (IndoorLevel Level in androidMapView.Map.FocusedBuilding.Levels) {
							Console.WriteLine (Level.ShortName + " - " + Level.Name);
							Level.Activate ();
						}
					}
				};

				Indoor_H indoor_H = Indoor_H.getInstance;
				polylineOptions = new PolylineOptions ();
				foreach (Vertex v in indoor_H.Vertices)
					polylineOptions.Add (new LatLng (v.x, v.y));

				polylines.Add (androidMapView.Map.AddPolyline (polylineOptions));


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

				androidMapView.Map.MapClick += (senderr, ee) => detailsLayout.Hide ();

				DirectionsViewModel directionsViewModel = DirectionsViewModel.getInstance;
				directionsViewModel.StartButton.Clicked += async (startButtonSender, startButtonEvent) => {

					if (App.isConnected ()) {
						Building _originBuilding;
						Building _destinationBuilding;


						// If both Start and End are specified, and they are not the same
						if (directionsViewModel.Start != null && directionsViewModel.End != null
						    && !directionsViewModel.Start.Equals (directionsViewModel.End)) {

							_originBuilding = buildingRepo.GetBuildingByCode (directionsViewModel.Start);
							_destinationBuilding = buildingRepo.GetBuildingByCode (directionsViewModel.End);

							// If buildings are within the same campus and chosen TravelMode was shuttle bus,
							// switch it to TravelMode.walking
							if (_originBuilding.Campus.Equals (_destinationBuilding.Campus)) {

								// If buildings are within the same campus, set CampusDirection to the right campus
								if (directionsViewModel.TravelMode == TravelMode.shuttle)
									directionsViewModel.TravelMode = TravelMode.walking;

								if (_originBuilding.Campus.Equals ("SGW"))
									campusDirection = CampusDirection.WithinSGW;
								else
									campusDirection = CampusDirection.withinLOY;
							} else {
								if (_originBuilding.Campus.Equals ("SGW") && _destinationBuilding.Campus.Equals ("LOY"))
									campusDirection = CampusDirection.FromSGWtoLOY;
								else if (_originBuilding.Campus.Equals ("LOY") && _destinationBuilding.Campus.Equals ("SGW"))
									campusDirection = CampusDirection.FromLOYtoSGW;
							}

							// For displaying the pins just above the building's code pin
							double pinOffsetY = 0.0001;

							// defining the origin pin
							_startPin.Title = _originBuilding.Code;
							_startPin.Snippet = _originBuilding.Address;
							_startPin.Position = new LatLng (_originBuilding.Position.Latitude + pinOffsetY, _originBuilding.Position.Longitude);

							// defining the destination pin
							_endPin.Title = _destinationBuilding.Code;
							_endPin.Snippet = _destinationBuilding.Address;
							_endPin.Position = new LatLng (_destinationBuilding.Position.Latitude + pinOffsetY, _destinationBuilding.Position.Longitude);

							ResetPolylines ();
							await GetDirectionsPolyline (_originBuilding.Position, _destinationBuilding.Position, directionsViewModel.TravelMode);
							DrawPolyline (directions);

							totalDirections = GoogleUtil.SumDirections (directions);

							MarkerDirections.Add (_startPin.Id, totalDirections);
							MarkerDirections.Add (_endPin.Id, totalDirections);

						}
						directionsViewModel.Hide ();
					}

				};

				base.OnElementPropertyChanged (sender, e);

				//var formsMap = (ConcordiaMap)sender;

				DrawShuttlePins ();
				DrawBuildingsPolygons ();

				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = false;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;

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

				Button BookmarksButton = MasterPage._BookmarksButton;

				bool bookmarksBool = false;

				BookmarksButton.Clicked += async (send, ev) => {

					// Adding all POIs' Icons
					if (!bookmarksBool) {

						if (App.isConnected ()) {

							Marker bMarker;
							LoaderViewModel.getInstance.Show ();

							BookmarkItems BI = new BookmarkItems ("Test", "This is my address", 45.496426, -73.577896);

							MarkerOptions bMarkerOptions = new MarkerOptions ();

							bMarkerOptions.SetTitle (BI.bName);
							bMarkerOptions.SetSnippet (BI.bAddress);
							bMarkerOptions.SetPosition (new LatLng (BI.bLat, BI.bLon));

							bMarkerOptions.InvokeIcon (BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.fav_icon));

							bMarker = androidMapView.Map.AddMarker (bMarkerOptions);

							MarkerBookmarks.Add (bMarker, BI);

						} 
						bookmarksBool = true;
						LoaderViewModel.getInstance.Hide ();

					} else {

						// toggling markers visibility
						foreach (Marker m in MarkerBookmarks.Keys) {
							m.Visible = !m.Visible;
						}
					}
				};


				Button NextClassButton = MasterPage.NextClassAlertEventButton;

				NextClassButton.PropertyChanged += async (send, ev) => {

					NextClassFunc NCF = new NextClassFunc ();
					CalendarItems CI = NCF.getNextClassItem ();

					string ClassDestination = NCF.getClassLocation (CI.Room);
					string start = "1515 St. Catherine W.";

					ResetPolylines ();
					Directions directions = await RequestDirections.getInstance.getDirections (start, ClassDestination, TravelMode.walking);
					getDirectionsToClass (directions);
				}; 

				bool isPOIAdded = false;

				MasterPage.POIButton.Clicked += async (send, ev) => {

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
			List<String> nextDepartures;
			String nextDeparturesString;
			MarkerOptions markerOptions = new MarkerOptions ();

			foreach (Campus campus in buildingRepo.getCampusList()) {
				nextDeparturesString = "";
				nextDepartures = requestShuttleBusSchedule.GetNextPassages (3, campus.Code);

				if (nextDepartures == null || nextDepartures.Count == 0)
					nextDeparturesString = "no passages";
				else
					foreach (String departure in nextDepartures)
						nextDeparturesString += departure + "  ";

				// Shuttle Bus Markers
				markerOptions.SetTitle (campus.Code + " Shuttle Bus");
				markerOptions.SetSnippet ("Next Departures: " + nextDeparturesString);

				if (campus.Code.Equals ("SGW"))
					markerOptions.SetPosition (
						new LatLng (ShuttleBusPolyline.SGWShuttleBusPosition.Latitude, 
							ShuttleBusPolyline.SGWShuttleBusPosition.Longitude)
					);
				else
					markerOptions.SetPosition (
						new LatLng (ShuttleBusPolyline.LOYShuttleBusPosition.Latitude, 
							ShuttleBusPolyline.LOYShuttleBusPosition.Longitude)
					);

				markerOptions.InvokeIcon (
					BitmapDescriptorFactory.FromResource (CocoMaps.Android.Resource.Drawable.ic_pin_shuttle)
				);

				androidMapView.Map.AddMarker (markerOptions);
			}
		}

		//		void DrawShuttlePolyline ()
		//		{
		//			// For drawing Shuttle bus only once
		//			if (shuttleBusPolyline == null) {
		//				PolylineOptions shuttleBusPolylineOptions = new PolylineOptions ();
		//				shuttleBusPolylineOptions.InvokeColor (unchecked((int)0xFF932439)).InvokeWidth (20);
		//
		//				foreach (Position point in ShuttleBusPolyline.getInstance.ShuttleBusDirections.routes[0].overview_polyline.decodedPoints)
		//					shuttleBusPolylineOptions.Add (new LatLng (point.Latitude, point.Longitude));
		//
		//				shuttleBusPolyline = androidMapView.Map.AddPolyline (shuttleBusPolylineOptions);
		//			} else
		//				shuttleBusPolyline.Visible = true;
		//		}

		// Allows us to draw 2 separated polylines at once, if needed
		async Task GetDirectionsPolyline (Position _start, Position _end, TravelMode mode)
		{
			if (mode == TravelMode.shuttle) {
				if (campusDirection == CampusDirection.FromSGWtoLOY) {
					await GetDirectionsPolyline (_start, ShuttleBusPolyline.SGWShuttleBusPosition, TravelMode.walking);
					directions.Add (ShuttleBusPolyline.getInstance.ShuttleBusDirections);
					await GetDirectionsPolyline (ShuttleBusPolyline.LOYShuttleBusPosition, _end, TravelMode.walking);
				} else if (campusDirection == CampusDirection.FromLOYtoSGW) {
					await GetDirectionsPolyline (_start, ShuttleBusPolyline.LOYShuttleBusPosition, TravelMode.walking);
					directions.Add (ShuttleBusPolyline.getInstance.ShuttleBusDirections);
					await GetDirectionsPolyline (ShuttleBusPolyline.SGWShuttleBusPosition, _end, TravelMode.walking);
				}

			} else {
				
				LoaderViewModel.getInstance.Show ();
				directions.Add (await RequestDirections.getInstance.getDirections (_start, _end, mode));
				LoaderViewModel.getInstance.Hide ();

			}
		}

		void DrawPolyline (IEnumerable<Position> positions, uint color = 0xFF00768E)
		{
			using (PolylineOptions polylineOptions = new PolylineOptions ()) {
				
				polylineOptions.InvokeWidth (20).InvokeColor (unchecked((int)color));

				foreach (Position point in positions) {
					polylineOptions.Add (new LatLng (point.Latitude, point.Longitude));
				}

				polylines.Add (androidMapView.Map.AddPolyline (polylineOptions));
			}
		}

		void DrawPolyline (Directions directions)
		{
			if (directions.status.Equals ("OK") || directions.status.Equals ("SHUTTLE")) {

				uint color = directions.status.Equals ("SHUTTLE") ? 0xFF932439 : 0xFF00768E;

				foreach (Route route in directions.routes) {

					route.overview_polyline.decodedPoints = GoogleUtil.Decode (route.overview_polyline.points);
					DrawPolyline (route.overview_polyline.decodedPoints, color);

				}

			}

		}

		void DrawPolyline (List<Directions> directions)
		{

			foreach (Directions direction in directions) {
				if (direction.status.Equals ("Shuttle"))
					continue;
				DrawPolyline (direction);
			}

		}

		void DrawBuildingsPolygons ()
		{
			Marker marker;
			// Adding all Buildings' Icons and Buildings' Polygons
			foreach (Building b in buildingRepo.BuildingList.Values) {
				using (PolygonOptions polygonOptions = new PolygonOptions ()) {
					using (MarkerOptions buildingCodeMarker = new MarkerOptions ()) {

						buildingCodeMarker.SetTitle (b.Code)
							.SetSnippet (b.Name)
							.SetPosition (new LatLng (b.Position.Latitude, b.Position.Longitude))
							.InvokeIcon (GetCustomBitmapDescriptor (b.Code));
						buildingCodeMarker.Flat (true);
						buildingCodeMarker.GetHashCode ();
						marker = androidMapView.Map.AddMarker (buildingCodeMarker);

						// Creating an association between the marker and the building object
						MarkerBuilding.Add (marker.Id, b);

					}
					polygonOptions.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439);

					foreach (Position p in b.ShapeCoords)
						polygonOptions.Add (new LatLng (p.Latitude, p.Longitude));

					androidMapView.Map.AddPolygon (polygonOptions);

				}
			}
		}

		void ResetPolylines ()
		{
			// resetting previous polyline
			polylines.ForEach (p => p.Remove ());
			polylines.Clear ();
			MarkerDirections.Clear ();
			directions.Clear ();
			if (shuttleBusPolyline != null)
				shuttleBusPolyline.Visible = false;
		}
	}
}