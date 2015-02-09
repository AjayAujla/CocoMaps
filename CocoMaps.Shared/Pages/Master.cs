using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace CocoMaps.Shared.Pages
{
	public class MasterPage : ContentPage
	{
		ConcordiaMap map;
		Position SGWPosition;
		Position LOYPosition;

		public MasterPage (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "CocoMaps");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			map = new ConcordiaMap () {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			// Those are the exact coordinates given by Google Maps
			// When searching for those campuses - DO NOT CHANGE!!!
			SGWPosition = new Position (45.4971711, -73.5790942);
			LOYPosition = new Position (45.4585649, -73.6400639);

			map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition,
				Distance.FromMiles (0.1)));

			var pin = new Pin {
				Type = PinType.Place,
				Position = LOYPosition,
				Label = "Loyola Campus",
				Address = "7141 Rue Sherbrooke Ouest"
			};

			map.Pins.Add (pin);

			var streetButton = new Button { Text = "Street" };
			var hybridButton = new Button { Text = "Hybrid" };
			var satelliteButton = new Button { Text = "Satellite" };
			var SGWButton = new Button { Text = "SGW" };
			var LOYButton = new Button { Text = "LOY" };

			streetButton.Clicked += HandleClicked;
			hybridButton.Clicked += HandleClicked;
			satelliteButton.Clicked += HandleClicked;

			SGWButton.Clicked += HandleCampusRegion;
			LOYButton.Clicked += HandleCampusRegion;


			var segments = new StackLayout { 
				Spacing = 10,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { streetButton, hybridButton, /*satelliteButton,*/ SGWButton, LOYButton }
			};


			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			stack.Children.Add (segments);
			Content = stack;
		}

		void HandleCampusRegion (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "SGW":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition,
					Distance.FromMiles (0.1)));
				break;
			case "LOY":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (LOYPosition,
					Distance.FromMiles (0.2)));
				break;
			}
		}

		void HandleClicked (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "Street":
				map.MapType = MapType.Street;
				break;
			case "Hybrid":
				map.MapType = MapType.Hybrid;
				break;
			case "Satellite":
				map.MapType = MapType.Satellite;
				break;
			}
		}
	}
}