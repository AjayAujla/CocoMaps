using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class POI : ContentPage
	{

		readonly ConcordiaMap map;
		Position SGWPosition;
		Position LOYPosition;


		public POI (IMenuOptions menuItem, String pageName)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, pageName);
			SetValue (Page.IconProperty, menuItem.Icon);

			// too many common codes from current location - will refactor
			map = ConcordiaMap.getInstance;

			// Those are the exact coordinates given by Google Maps
			// When searching for those campuses - DO NOT CHANGE!!!
			SGWPosition = new Position (45.4971711, -73.5790942);
			LOYPosition = new Position (45.4585649, -73.6400639);

			map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition, Xamarin.Forms.Maps.Distance.FromMiles (0.1)));


			var SGWButton = new Button { Text = "SGW" };
			var LOYButton = new Button { Text = "LOY" };

			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;

			showPOI (pageName);

			var POIButtons = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { SGWButton, LOYButton }
			};

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			stack.Children.Add (POIButtons);
			Content = stack;

		}

		void HandleCampusRegionButton (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "SGW":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition, Xamarin.Forms.Maps.Distance.FromMiles (0.1)));
				break;
			case "LOY":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (LOYPosition,	Xamarin.Forms.Maps.Distance.FromMiles (0.1)));
				break;
			}
		}

		async void showPOI (String POItype)
		{
			map.Pins.Clear ();
			var placesRequest = RequestPlaces.getInstance;

			if (POItype.ToLower () == "coffee") {
				POItype = "cafe";
			}

			Places places = await placesRequest.getPlaces (POItype.ToLower (), SGWPosition);
			foreach (Result r in places.results) {
				var pin = new Pin {
					Type = PinType.Place,
					Position = new Position (r.geometry.location.lat, r.geometry.location.lng),
					Label = r.name,
					Address = r.vicinity
				};
				map.Pins.Add (pin);
			}
			places = await placesRequest.getPlaces (POItype.ToLower (), LOYPosition);
			foreach (Result r in places.results) {
				var pin = new Pin {
					Type = PinType.Place,
					Position = new Position (r.geometry.location.lat, r.geometry.location.lng),
					Label = r.name,
					Address = r.vicinity
				};
				map.Pins.Add (pin);
			}
		}
	}
}