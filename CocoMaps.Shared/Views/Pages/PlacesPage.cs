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

			var foodButton = new Button { Text = "Food" };
			var restaurantButton = new Button { Text = "Restaurant" };
			var cafeButton = new Button { Text = "Cafe" };
			var libraryButton = new Button { Text = "Library" };

			foodButton.Clicked += handlePlacesButton;
			restaurantButton.Clicked+= handlePlacesButton;
			cafeButton.Clicked += handlePlacesButton;
			libraryButton.Clicked += handlePlacesButton;


			var placesButtons = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { foodButton, restaurantButton, cafeButton, libraryButton }
			};


			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			stack.Children.Add (segments);
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

		void handlePlacesButton (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "Food":
				map.Pins.Clear ();
				var foodSGW = new FoodPlaces ();
				var foodSGWJSONObject = foodSGW.getSGWFoodPlaces ();
				foreach (Result r in foodSGWJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Food"
					};
					map.Pins.Add (pin);
				}
				var foodLoyola = new FoodPlaces ();
				var foodLoyolaJSONObject = foodLoyola.getLoyolaFoodPlaces ();
				foreach (Result r in foodLoyolaJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Food"
					};
					map.Pins.Add (pin);
				}
				break;
			case "Restaurant":
				map.Pins.Clear ();
				var restaurantSGW = new RestaurantPlaces ();
				var restaurantSGWJSONObject = restaurantSGW.getSGWRestaurantPlaces ();
				foreach (Result r in restaurantSGWJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Restaurant"
					};
					map.Pins.Add (pin);
				}
				var restaurantLoyola = new RestaurantPlaces ();
				var restaurantLoyolaJSONObject = restaurantLoyola.getLoyolaRestaurantPlaces ();
				foreach (Result r in restaurantLoyolaJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Restaurant"
					};
					map.Pins.Add (pin);
				}
				break;
			case "Cafe":
				map.Pins.Clear ();
				var cafeSGW = new CafePlaces ();
				var cafeSGWJSONObject = cafeSGW.getSGWCafePlaces ();
				foreach (Result r in cafeSGWJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Cafe"
					};
					map.Pins.Add (pin);
				}
				var cafeLoyola = new CafePlaces ();
				var cafeLoyolaJSONObject = cafeLoyola.getLoyolaCafePlaces ();
				foreach (Result r in cafeLoyolaJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Cafe"
					};
					map.Pins.Add (pin);
				}
				break;
			case "Library":
				map.Pins.Clear ();
				var librarySGW = new LibraryPlaces ();
				var librarySGWJSONObject = librarySGW.getSGWLibraryPlaces ();
				foreach (Result r in librarySGWJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Library"
					};
					map.Pins.Add (pin);
				}
				var libraryLoyola = new LibraryPlaces ();
				var libraryLoyolaJSONObject = libraryLoyola.getLoyolaLibraryPlaces ();
				foreach (Result r in libraryLoyolaJSONObject.results) {
					var lat = r.geometry.location.lat;
					var lng = r.geometry.location.lng;
					var position = new Position (lat, lng);
					var name = r.name;
					var pin = new Pin {
						Type = PinType.Place,
						Position = position,
						Label = name,
						Address = "Library"
					};
					map.Pins.Add (pin);
				}
				break;
			}
		}
	}
}

