using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocoMaps.Shared
{
	public class MasterPage : ContentPage
	{
		readonly ConcordiaMap map;
		SearchBar searchBar;
		RelativeLayout mainLayout;
		Label networkStatus = new Label {
			TextColor = Color.White
		};

		public MasterPage (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			PlacesRepository placesRepo = PlacesRepository.getInstance;

			SetValue (Page.TitleProperty, "CocoMaps");
			SetValue (Page.IconProperty, menuItem.Icon);

			map = ConcordiaMap.getInstance;
			map.IsShowingUser = true;

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
			var NextButton = new Button { Text = "Next Class", 
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

			NextButton.Clicked += async (sender, e) => {
				string start = "7141 Sherbrooke Street W. Montreal QC";
				string dest = "1455 De Maisonneuve Blvd. W. Montreal QC";

				RequestDirections directionsRequest = RequestDirections.getInstance;

				Directions directions = await directionsRequest.getDirections (start, dest, TravelMode.walking);

			};

			searchBar.PropertyChanged += HandleFocusChange;
			searchBar.TextChanged += HandleTextChanged;

			mainLayout = new RelativeLayout {
				BackgroundColor = Color.Transparent,
				WidthRequest = App.ScreenSize.Width,
				HeightRequest = App.ScreenSize.Height - 48
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
				DependencyService.Get<IPhoneService> ().LaunchNavigationAsync (
					new NavigationModel () { 
						Latitude = Campus.SGWPosition.Latitude,
						Longitude = Campus.SGWPosition.Longitude,
						DestinationAddress = "1455 De Maisonneuve Blvd. W.",
						DestinationName = "SGW Campus"
					});
			};

			LoaderViewModel loader = LoaderViewModel.getInstance;
			//loader.Show ();

			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

			Console.WriteLine (mainLayout.Width + " x " + mainLayout.Height + ", " + mainLayout.WidthRequest + " x " + mainLayout.HeightRequest);

			mainLayout.Children.Add (map, 
				Constraint.Constant (0), 
				Constraint.Constant (0), 
				Constraint.RelativeToParent (parent => Width),
				Constraint.RelativeToParent (parent => Height)
			);
			mainLayout.Children.Add (searchBar, Constraint.Constant (0));
			mainLayout.Children.Add (loader, Constraint.RelativeToParent ((parent) => Width / 2 - loader.Width / 2), Constraint.RelativeToParent ((parent) => Height / 2 - loader.Height / 2));
			mainLayout.Children.Add (SGWButton, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (LOYButton, Constraint.Constant (80), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (NextButton, Constraint.Constant (145), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (networkStatus, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 80));
			mainLayout.Children.Add (detailsLayout, Constraint.Constant (0), Constraint.RelativeToParent (parent => Height));

			mainLayout.Children.Add (testButton, Constraint.Constant (50), Constraint.Constant (50));

			//mainLayout.Children.Add (picker, Constraint.Constant (100), Constraint.Constant (100));

			map.MoveToRegion (MapSpan.FromCenterAndRadius (Campus.SGWPosition, Xamarin.Forms.Maps.Distance.FromKilometers (0.1)));

			Content = mainLayout;

		}


		void HandleTextChanged (object sender, TextChangedEventArgs e)
		{
			var s = sender as SearchBar;
			Console.WriteLine (s.Text);
		}

		void HandleNextButton (object sender, TextChangedEventArgs e)
		{

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

		async void TestStuff (object sender, EventArgs e)
		{
			await DisplayAlert ("Network Status:", App.isConnected ().ToString (), "Whatever");
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

	}

}