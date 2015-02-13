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

			this.map = new ConcordiaMap () {
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (sender, e) => Console.WriteLine ("Tapped");
			map.GestureRecognizers.Add (tapGestureRecognizer);

			// Those are the exact coordinates given by Google Maps
			// When searching for those campuses - DO NOT CHANGE!!!
			SGWPosition = new Position (45.4971711, -73.5790942);
			LOYPosition = new Position (45.4585649, -73.6400639);

			this.map.MoveToRegion (MapSpan.FromCenterAndRadius (SGWPosition, Distance.FromMiles (0.1)));

			var SGWPin = new Pin {
				Type = PinType.Place,
				Position = SGWPosition,
				Label = "Sir George Williams Campus",
				Address = "1455 De Maisonneuve W."
			};

			var LOYPin = new Pin {
				Type = PinType.Place,
				Position = LOYPosition,
				Label = "Loyola Campus",
				Address = "7141 Rue Sherbrooke Ouest"
			};

			//map.Pins.Add (SGWPin);
			//map.Pins.Add (LOYPin);


			var SGWButton = new Button { Text = "SGW" };
			var LOYButton = new Button { Text = "LOY" };

			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;


			var segments = new StackLayout {
				Spacing = 10,
				Opacity = 0.5,
				HorizontalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal, 
				Children = { SGWButton, LOYButton }
			};


			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add (map);
			stack.Children.Add (segments);
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
	}
}