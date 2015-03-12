using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Java.Security;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class MasterPage : ContentPage
	{
		readonly ConcordiaMap map;
		SearchBar searchBar;
		RelativeLayout mainLayout;
		RelativeLayout directionsLayout;

		Label networkStatus = new Label {
			TextColor = Color.White
		};

		Button testButton = new Button { Text = "Directions", HeightRequest = 50, BackgroundColor = Color.Maroon };

		static Button _POIButton = new Button { 
			Text = "POI", 
			HeightRequest = 40,
			BackgroundColor = Color.Gray,
			Opacity = 0.7,
			BorderRadius = 0,
			IsEnabled = false
		};

		public static Button POIButton {
			get {
				return _POIButton;
			}
		}

		public MasterPage (IMenuOptions menuItem)
		{

			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "CocoMaps");
			SetValue (Page.IconProperty, menuItem.Icon);

			map = new ConcordiaMap {
				IsShowingUser = true
			};

			map.MoveToRegion (MapSpan.FromCenterAndRadius (Campus.SGWPosition, Xamarin.Forms.Maps.Distance.FromKilometers (0.2)));

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




			searchBar = new SearchBar {
				Placeholder = "search buildings...",
				WidthRequest = App.ScreenSize.Width - 64,
				HeightRequest = 50
			};

			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;

			NextButton.Clicked += async (sender, e) => {
				string start = "7141 Sherbrooke Street W. Montreal QC";
				string dest = "1455 De Maisonneuve Blvd. W. Montreal QC";

				RequestDirections directionsRequest = RequestDirections.getInstance;

				Directions directions = await directionsRequest.getDirections (start, dest, TravelMode.walking);


			};

			searchBar.TextChanged += HandleTextChanged;

			mainLayout = new RelativeLayout {
				BackgroundColor = Color.Transparent,
				WidthRequest = App.ScreenSize.Width,
				HeightRequest = App.ScreenSize.Height - 48
			};

			directionsLayout = new RelativeLayout {
				BackgroundColor = Helpers.Color.DarkGray.ToFormsColor ()
			};

			searchBar.PropertyChanged += (sender, e) => {
				if (e.PropertyName.Equals ("IsFocused") && !IsFocused)
					directionsLayout.TranslateTo (0, -Height, 100);
			};

			DependencyService.Get<INetwork> ().ReachabilityChanged += obj => {
				if (obj == NetworkStatus.NotReachable) {
					networkStatus.BackgroundColor = Color.Red;
					networkStatus.Text = "Offline";
				} else {
					// Network is connected
					if (App.isHostReachable ("googleapis.com")) {
						PlacesRepository placesRepo = PlacesRepository.getInstance;
					}
					networkStatus.BackgroundColor = Color.Green;
					networkStatus.Text = "Online";
				}
			};

			testButton.Clicked += async (sender, e) => {
				bool r = await DependencyService.Get<INetwork> ().IsReachable ("google.com", new TimeSpan (5));
				await DisplayAlert ("Network Connection:", r ? "Connected :)" : "Not Connected :(", "Whatever");
			};

			LoaderViewModel loaderView = LoaderViewModel.getInstance;

			DetailsViewModel detailsLayout = DetailsViewModel.getInstance;

			Console.WriteLine (mainLayout.Width + " x " + mainLayout.Height + ", " + mainLayout.WidthRequest + " x " + mainLayout.HeightRequest);

			mainLayout.Children.Add (map,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Width),
				Constraint.RelativeToParent (parent => Height));
				
			mainLayout.Children.Add (directionsLayout, Constraint.Constant (0));
			mainLayout.Children.Add (_POIButton, Constraint.Constant (150), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (testButton, Constraint.Constant (50), Constraint.Constant (50));
			//mainLayout.Children.Add (searchBar, Constraint.Constant (0));
			mainLayout.Children.Add (SGWButton, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (LOYButton, Constraint.Constant (80), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (NextButton, Constraint.RelativeToParent (parent => Width - 160), Constraint.Constant (10));
			mainLayout.Children.Add (networkStatus, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 80));
			mainLayout.Children.Add (detailsLayout, Constraint.Constant (0), Constraint.RelativeToParent (parent => Height));
			mainLayout.Children.Add (loaderView, Constraint.RelativeToParent (parent => Width / 2 - loaderView.WidthRequest / 2), Constraint.RelativeToParent ((parent) => Height / 2 - loaderView.HeightRequest / 2));

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