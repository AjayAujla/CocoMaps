using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Drawing;
using System.Collections.Generic;
using CocoMaps.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Android.Gms.Common.Data;
using Java.Lang;

[assembly: ExportRenderer (typeof(CocoMaps.ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;

		static async Task<string> RunAsync ()
		{
			Console.WriteLine ("CHECKPOINT 1");
			using (var client = new HttpClient ()) {
				client.BaseAddress = new Uri ("http://maps.google.com/maps/api/directions/json?");
				//client.DefaultRequestHeaders.Accept.Clear ();
				//client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
				Console.WriteLine ("CHECKPOINT 2");
				HttpResponseMessage response = await client.GetAsync ("origin=45.4971711,-73.5790942&destination=45.4585649,-73.6400639");
				Console.WriteLine ("CHECKPOINT 3");

				if (response.IsSuccessStatusCode) {

					var responseObject = await response.Content.ReadAsAsync<object> ();
					Console.WriteLine ("RESPONSE IS: " + responseObject.ToString ());
					return responseObject.ToString ();
					
				}
				return "Not Succeed";
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			base.OnElementPropertyChanged (sender, e);
			var androidMapView = (MapView)Control;
			var formsMap = (CocoMaps.ConcordiaMap)sender;

			//var result = RunAsync ();
			//Console.WriteLine (result.Result);

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				//androidMapView.Map.Clear ();
				androidMapView.Map.MyLocationEnabled = formsMap.IsShowingUser;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MyLocationButtonEnabled = false;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = false;
			

				PolygonOptions polygon = new PolygonOptions ();

				BuildingRepository br = BuildingRepository.Repository;

				foreach (Campus c in br.getCampusList()) {
				
					Console.WriteLine ("Shaping Campus " + c.Code);

					foreach (Building b in c.Buildings) {

						Console.WriteLine ("Shaping Building " + b.Name);

						polygon = new PolygonOptions ();
						polygon.InvokeFillColor (0x3F932439); // 3F -> opacity to ~25%
						polygon.InvokeStrokeColor (0x00932439); // 932439 -> Concordia's red color

						foreach (Tuple<double, double> p in b.ShapeCoords) {
							polygon.Add (new LatLng (p.Item1, p.Item2));
						}

						androidMapView.Map.AddPolygon (polygon);
					
					}
				}

				Console.WriteLine ();
				List<DirectionSteps> directions = GMapUtil.GetDirections (br.GetCampusByCode ("SGW").Address, br.GetCampusByCode ("LOY").Address, GMapUtil.Mode.Driving);

				List<LatLng> points = new List<LatLng> ();

				PolylineOptions polyline = new PolylineOptions ();
				polyline.InvokeColor (0x7F00768e);
				var directionsString = "";
				foreach (DirectionSteps direction in directions) {

					foreach (LatLng point in direction.DecodedPolyline) {
						polyline.Add (point);
					}

					foreach (DirectionStep step in direction.Steps) {
						directionsString += step.Description + ".";
					}
				}

				DependencyService.Get<ITextToSpeech> ().Speak (directionsString);
				androidMapView.Map.AddPolyline (polyline);


//				var address = "http://maps.google.com/maps/api/directions/json?origin=45.4971711,-73.5790942&destination=45.4585649,-73.6400639&mode=walking&sensor=true";
//				try {
//					var response = new System.Net.WebClient ().DownloadString (address);
//					Console.WriteLine ("JSON RESPONSE: " + response);
//				} catch (Exception excep) {
//					Console.WriteLine (excep.Message);
//				}

				//Console.WriteLine ("JSON RESPONSE: " + response);

				_isDrawnDone = true;

			}

		}
	}
}