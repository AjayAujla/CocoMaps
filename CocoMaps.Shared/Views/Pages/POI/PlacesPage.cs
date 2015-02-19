using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace CocoMaps.Shared.Pages
{
	public class PlacesPage : ContentPage
	{
		ConcordiaMap map;
		Position SGWPosition;
		Position LOYPosition;

		public PlacesPage (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Points Of Interest");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			this.map = new ConcordiaMap () {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			// Those are the exact coordinates given by Google Maps
			// When searching for those campuses - DO NOT CHANGE!!!
			SGWPosition = new Position (45.4971711, -73.5790942);
			LOYPosition = new Position (45.4585649, -73.6400639);

			this.map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition, Distance.FromMiles (0.1)));


			var SGWButton = new Button { Text = "SGW" };
			var LOYButton = new Button { Text = "LOY" };


			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;


			var segments = new StackLayout { 
				Spacing = 10,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { SGWButton, LOYButton }
			};
			segments.BackgroundColor = Color.Transparent;

			var foodButton = new Button { Text = "Food" };
			var restaurantButton = new Button { Text = "Restaurant" };
			var cafeButton = new Button { Text = "Cafe" };
			var libraryButton = new Button { Text = "Library" };

			foodButton.BackgroundColor = Color.Transparent;
			restaurantButton.BackgroundColor = Color.Transparent;
			cafeButton.BackgroundColor = Color.Transparent;
			libraryButton.BackgroundColor = Color.Transparent;

			foodButton.Clicked += HandlePlacesButton;
			restaurantButton.Clicked += HandlePlacesButton;
			cafeButton.Clicked += HandlePlacesButton;
			libraryButton.Clicked += HandlePlacesButton;

			var placesButtons = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { foodButton, restaurantButton, cafeButton, libraryButton }
			};
			placesButtons.BackgroundColor = Color.Transparent;

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			//stack.Children.Add (segments);
			stack.Children.Add (placesButtons);
			this.Content = stack;

		}

		void HandleCampusRegionButton (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "SGW":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition, Distance.FromMiles (0.1)));
				break;
			case "LOY":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (LOYPosition,	Distance.FromMiles (0.2)));
				break;
			}
		}

		async void HandlePlacesButton (object sender, EventArgs e)
		{
			map.Pins.Clear ();
			var b = sender as Button;
			var placesRequest = RequestPlaces.getInstance;

			Places places = await placesRequest.getPlaces (b.Text.ToLower (), SGWPosition);
			foreach (Result r in places.results) {
				var pin = new Pin {
					Type = PinType.Place,
					Position = new Position (r.geometry.location.lat, r.geometry.location.lng),
					Label = r.name,
					Address = r.vicinity
				};
				map.Pins.Add (pin);
			}
			places = await placesRequest.getPlaces (b.Text.ToLower (), LOYPosition);
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