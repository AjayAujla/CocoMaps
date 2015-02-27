using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class MasterPage : ContentPage
	{
		readonly ConcordiaMap map;
		SearchBar searchBar;
		RelativeLayout mainLayout;
		RelativeLayout directionsLayout;
		bool isDirections;
		Label networkStatus = new Label {
			TextColor = Color.White
		};

		Dictionary<string, TravelMode> travelMode = new Dictionary<string, TravelMode> {
			{ "Walking", TravelMode.walking },
			{ "Bicycling", TravelMode.bicycling },
			{ "Shuttle", TravelMode.shuttle },
			{ "Transit", TravelMode.transit },
			{ "Driving", TravelMode.driving }
		};

		public MasterPage (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "CocoMaps");
			SetValue (Page.IconProperty, menuItem.Icon);

			map = new ConcordiaMap {
				IsShowingUser = true,
				HeightRequest = App.ScreenSize.Height - App.StatusBarHeight - 48,  // 48 is top bar's height
				WidthRequest = App.ScreenSize.Width
			};

			var SGWButton = new Button {
				Text = "SGW",
				HeightRequest = 40,
				BackgroundColor = Color.White,
				Opacity = 0.7,
				BorderRadius = 0
			};
			var LOYButton = new Button { Text = "LOY", 
				HeightRequest = 40,
				BackgroundColor = Color.White,
				Opacity = 0.7,
				BorderRadius = 0
			};

			var checkNetworkButton = new Button { Text = "Check Connection", 
				HeightRequest = 40,
				BackgroundColor = Color.Aqua,
				Opacity = 0.7,
				BorderRadius = 0
			};

			var testButton = new Button { Text = "Directions", HeightRequest = 50, BackgroundColor = Color.Maroon };

			searchBar = new SearchBar {
				Placeholder = "search buildings...",
				WidthRequest = App.ScreenSize.Width - 64,
				HeightRequest = 50
			};

			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;
			checkNetworkButton.Clicked += TestStuff;

			searchBar.PropertyChanged += HandleFocusChange;
			searchBar.TextChanged += HandleTextChanged;

			mainLayout = new RelativeLayout {
				BackgroundColor = Color.Transparent,
				WidthRequest = App.ScreenSize.Width,
				HeightRequest = App.ScreenSize.Height - 48
			};

			directionsLayout = new RelativeLayout {
				BackgroundColor = Helpers.Color.DarkGray.ToFormsColor (),
				WidthRequest = App.ScreenSize.Width - 64,
				HeightRequest = 200,
				TranslationY = -200,
				HorizontalOptions = LayoutOptions.Center
			};

			searchBar.PropertyChanged += (sender, e) => {
				if (e.PropertyName.Equals ("IsFocused") && !IsFocused && isDirections)
					directionsLayout.TranslateTo (0, -Height, 100);
			};

			DependencyService.Get<INetwork> ().ReachabilityChanged += obj => {
				if (obj == NetworkStatus.NotReachable) {
					networkStatus.BackgroundColor = Color.Red;
					networkStatus.Text = "Offline";
				} else {
					// Network is connected
					networkStatus.BackgroundColor = Color.Green;
					networkStatus.Text = "Online";
				}
			};

			testButton.Clicked += (sender, e) => {
				var h = directionsLayout.HeightRequest;
				if (isDirections) {

					directionsLayout.TranslateTo (0, -h, 0);
					searchBar.Focus ();
					isDirections = false;
				} else {
					directionsLayout.TranslateTo (0, searchBar.Height, 500);
					searchBar.Focus ();
					isDirections = true;
				}
			};

			ActivityIndicator loader = ActivityLoading.getInstance ();

			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

			Console.WriteLine (mainLayout.Width + " x " + mainLayout.Height + ", " + mainLayout.WidthRequest + " x " + mainLayout.HeightRequest);

			mainLayout.Children.Add (map, Constraint.Constant (0));
			mainLayout.Children.Add (directionsLayout, Constraint.Constant (0));
			mainLayout.Children.Add (searchBar, Constraint.Constant (0));
			mainLayout.Children.Add (loader, Constraint.RelativeToParent ((parent) => Width / 2 - loader.Width / 2), Constraint.RelativeToParent ((parent) => Height / 2 - loader.Height / 2));
			mainLayout.Children.Add (SGWButton, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (LOYButton, Constraint.Constant (80), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (networkStatus, Constraint.Constant (154), Constraint.RelativeToParent (parent => Height - 44));
			mainLayout.Children.Add (detailsLayout, Constraint.Constant (0), Constraint.RelativeToParent (parent => Height));

			//mainLayout.Children.Add (picker, Constraint.Constant (100), Constraint.Constant (100));

			map.MoveToRegion (MapSpan.FromCenterAndRadius (Campus.SGWPosition, Xamarin.Forms.Maps.Distance.FromKilometers (0.2)));

			Content = mainLayout;

			Content.SizeChanged += (sender, e) => {
				// Orientation in Portrait Mode
				if (mainLayout.Width < mainLayout.Height) {
					searchBar.WidthRequest = App.ScreenSize.Width - 64;
					directionsLayout.WidthRequest = App.ScreenSize.Width - 64;
					map.HeightRequest = App.ScreenSize.Height - App.StatusBarHeight - 48;
					map.WidthRequest = App.ScreenSize.Width;
				}
				// Orientation in Landscape Mode
				if (mainLayout.Width > mainLayout.Height) {
					searchBar.WidthRequest = App.ScreenSize.Height - 64;
					directionsLayout.WidthRequest = App.ScreenSize.Height - 64;
					map.HeightRequest = App.ScreenSize.Width - App.StatusBarHeight - 48;
					map.WidthRequest = App.ScreenSize.Height;
				}
			};
		}


		void HandleTextChanged (object sender, TextChangedEventArgs e)
		{
			var s = sender as SearchBar;
			Console.WriteLine (s.Text);
		}

		void HandleFocusChange (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var s = sender as SearchBar;
			if (s.IsFocused) {
				s.Opacity = 1;
				s.BackgroundColor = Helpers.Color.DarkGray.ToFormsColor ();
			} else {
				s.Opacity = 0.5;
				s.BackgroundColor = Color.White;
			}
		}

		void TestStuff (object sender, EventArgs e)
		{
			DisplayAlert ("Network Status:", App.isConnected ().ToString (), "Dismiss");
		}

		void HandleCampusRegionButton (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "SGW":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (Campus.SGWPosition, Xamarin.Forms.Maps.Distance.FromKilometers (0.1)));
				break;
			case "LOY":
				map.MoveToRegion (MapSpan.FromCenterAndRadius (Campus.LOYPosition,	Xamarin.Forms.Maps.Distance.FromKilometers (0.1)));
				break;
			}
		}

		public static Building UpdateBuildingDetailsLayout (Building building)
		{
			return building;
		}

	}
}