using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using CocoMaps.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Indoor;

[assembly: ExportRenderer (typeof(IndoorMap), typeof(CocoMapsAndroid.IndoorMapRenderer))]

namespace CocoMapsAndroid
{
	public class IndoorMapRenderer : MapRenderer
	{
		bool _isDrawnDone;

		Position _from = new Position (0, 0);
		Position _to = new Position (0, 0);

		MapView androidMapView;

		Marker _startPin;
		Marker _endPin;

		List<Android.Gms.Maps.Model.Polyline> polylines = new List<Android.Gms.Maps.Model.Polyline> ();
		List<Directions> directions = new List<Directions> ();
		Directions totalDirections;


		PolylineOptions polylineOptions;

		// used to map Markers' ID (a string) to their representative object
		Dictionary<String, Building> MarkerBuilding = new Dictionary<String, Building> ();
		Dictionary<String, Directions> MarkerDirections = new Dictionary<String, Directions> ();


		void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			Building building;

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

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				androidMapView = (MapView)Control;

				androidMapView.Map.UiSettings.MyLocationButtonEnabled = true;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = true;
				androidMapView.Map.SetIndoorEnabled (true);

//				androidMapView.Map.IndoorLevelActivated += (lsender, le) => {
//					if (androidMapView.Map.FocusedBuilding != null)
//						Console.WriteLine ("IndoorLevelActivated: " + androidMapView.Map.FocusedBuilding.ActiveLevelIndex);
//				};
//
//				androidMapView.Map.IndoorBuildingFocused += (lsender, le) => {
//					if (androidMapView.Map.FocusedBuilding != null) {
//						Console.WriteLine ("IndoorBuildingFocused: " + androidMapView.Map.FocusedBuilding.Levels);
//						foreach (IndoorLevel Level in androidMapView.Map.FocusedBuilding.Levels) {
//							Console.WriteLine (Level.ShortName + " - " + Level.Name);
//							Level.Activate ();
//						}
//					}
//				};

				IndoorLocationViewModel indoorLocationViewModel = IndoorLocationViewModel.getInstance;
				indoorLocationViewModel.StartButton.Clicked += async (startButtonSender, startButtonEvent) => {

					Vertex _originClass;
					Vertex _destinationClass;


					// If both Start and End are specified, and they are not the same
					if (indoorLocationViewModel.Start != null && indoorLocationViewModel.End != null
					    && !indoorLocationViewModel.Start.Equals (indoorLocationViewModel.End)) {

						String pickedOption = indoorLocationViewModel.Start;
						int dashIndex = pickedOption.IndexOf ('-');
						pickedOption = pickedOption.Substring (dashIndex + 1);
						pickedOption = pickedOption.Trim ();

						Console.WriteLine (pickedOption);

						Console.WriteLine ("PICKED OPTION:" + pickedOption);

						Indoor_H.getInstance.Vertices.TryGetValue (pickedOption, out _originClass);

						pickedOption = indoorLocationViewModel.End;
						dashIndex = pickedOption.IndexOf ('-');
						pickedOption = pickedOption.Substring (dashIndex + 1);
						pickedOption = pickedOption.Trim ();

						Console.WriteLine ("PICKED OPTION:" + pickedOption);

						Indoor_H.getInstance.Vertices.TryGetValue (pickedOption, out _destinationClass);

						if (_originClass != null && _destinationClass != null) {

							_startPin.Position = new LatLng (_originClass.lat, _originClass.lon);
							_endPin.Position = new LatLng (_destinationClass.lat, _destinationClass.lon);

							// Move map to destination class and zoom in it
							androidMapView.Map.MoveCamera (CameraUpdateFactory.NewLatLngZoom (new LatLng (_destinationClass.lat, _destinationClass.lon), 45));
						}

					}

				};

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


				base.OnElementPropertyChanged (sender, e);

				DrawShuttlePins ();
				DrawBuildingsPolygons ();

				androidMapView.Map.MarkerClick += HandleMarkerClick;

				_isDrawnDone = true;
				androidMapView.Map.SetIndoorEnabled (true);
				Console.WriteLine ("Indoor? " + androidMapView.Map.IsIndoorEnabled.ToString ());
			}
		}

		void DrawShuttlePins ()
		{

			RequestShuttleBusSchedule requestShuttleBusSchedule = RequestShuttleBusSchedule.getInstance;

			List<String> nextDepartures;
			String nextDeparturesString;
			MarkerOptions markerOptions = new MarkerOptions ();

			foreach (Campus campus in BuildingRepository.getInstance.getCampusList()) {
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

		void DrawBuildingsPolygons ()
		{
			Marker marker;
			IEnumerable<Position> points;
			// Adding all Buildings' Icons and Buildings' Polygons
			foreach (Building b in BuildingRepository.getInstance.BuildingList.Values) {
				using (PolygonOptions polygonOptions = new PolygonOptions ()) {

					polygonOptions.InvokeFillColor (0x3F932439).InvokeStrokeColor (0x00932439);
					points = GoogleUtil.Decode (b.ShapeCoords);

					foreach (Position p in points)
						polygonOptions.Add (new LatLng (p.Latitude, p.Longitude));

					androidMapView.Map.AddPolygon (polygonOptions);

				}
				using (MarkerOptions buildingCodeMarker = new MarkerOptions ()) {

					buildingCodeMarker.SetTitle (b.Code)
						.SetSnippet (b.Name)
						.SetPosition (new LatLng (b.Position.Latitude, b.Position.Longitude))
						.InvokeIcon (GetCustomBitmapDescriptor (b.Code));

					marker = androidMapView.Map.AddMarker (buildingCodeMarker);

					// Creating an association between the marker and the building object
					MarkerBuilding.Add (marker.Id, b);

				}
			}
		}

	}
}