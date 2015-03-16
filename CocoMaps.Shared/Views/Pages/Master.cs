using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared;
using Android.Media.Audiofx;
using System.Diagnostics;
using Android.Views;

namespace CocoMaps.Shared
{
	public class MasterPage : ContentPage
	{
		readonly ConcordiaMap map;
		RelativeLayout mainLayout;

		Label networkStatus = new Label {
			TextColor = Color.White
		};

		BuildingRepository buildingRepo = BuildingRepository.getInstance;
		LoaderViewModel loaderView = LoaderViewModel.getInstance;
		DetailsViewModel detailsLayout = DetailsViewModel.getInstance;
		DirectionsViewModel searchViewModel = DirectionsViewModel.getInstance;

		static Button _testButton = new Button { Text = "TestButton", HeightRequest = 50, BackgroundColor = Color.Maroon };

		static Button _POIButton = new Button { 
			Text = "POI", 
			HeightRequest = 40,
			BackgroundColor = Color.Gray,
			Opacity = 0.7,
			BorderRadius = 0,
			IsEnabled = false
		};

		Button _SearchButton;

		// Needed to access this button from ConcordiaMapRenderer.cs
		public static Button POIButton {
			get {
				return _POIButton;
			}
		}
		// Needed to access this button from ConcordiaMapRenderer.cs
		public static Button TestButton {
			get {
				return _testButton;
			}
		}

		public Button SearchButton {
			get {
				if (_SearchButton == null) {
					_SearchButton = new Button {
						Image = (FileImageSource)ImageSource.FromFile ("ic_map_search.png"),
						HeightRequest = 40,
						WidthRequest = 40,
						BackgroundColor = Color.White,
						Opacity = 0.7,
						BorderRadius = 0
					};
				}
				return _SearchButton;
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

			var SearchPicker = new Picker {
				BackgroundColor = Helpers.Color.DarkGray.ToFormsColor (),
				IsVisible = false
			};

			var NextButtonAlert = new Button { Text = "Next Class", 
				HeightRequest = 40,
				BackgroundColor = Color.White,
				Opacity = 0.7,
				BorderRadius = 0
			};

			foreach (Building building in buildingRepo.BuildingList.Values)
				SearchPicker.Items.Add (building.Code);

			SGWButton.Clicked += HandleCampusRegionButton;
			LOYButton.Clicked += HandleCampusRegionButton;

			SearchButton.Clicked += (sender, e) => {
				// if() fixes a problem where the SearchPicker would not show anymore due to Events conflicts
				if (SearchPicker.IsFocused)
					SearchPicker.Unfocus ();
				SearchPicker.Focus ();
			};

			SearchPicker.SelectedIndexChanged += (sender, e) => {

				Picker picker = sender as Picker;
				Building building;

				if (buildingRepo.BuildingList.TryGetValue (picker.Items [picker.SelectedIndex], out building)) {
					map.MoveToRegion (MapSpan.FromCenterAndRadius (building.Position, Xamarin.Forms.Maps.Distance.FromKilometers (0.05)));
					detailsLayout.UpdateView (building);
				}
			};


			NextButtonAlert.Clicked += async (sender, e) => {

				NextClassFunc NCF = new NextClassFunc();

				CalendarItems CI = NCF.getNextClassItem();

				//string ClassDetails = "Class : " + CI.Title1 + "\r\n" + "Time : " + CI.Day + " " + "(" + CI.StartTime + " - " + CI.EndTime + ")" + "\r\n" + "Location : " + CI.Room+ "\r\n" + "Destination : " + NCF.getClassLocation(CI.Room);

				string ClassDetails = "Class : " + CI.Title1 + "\r\n" + "Time : " + CI.Day + " " + "(" + CI.StartTime + " - " + CI.EndTime + ")" + "\r\n" + "Location : " + CI.Room+ "\r\n";

				var NextClassInput = await DisplayAlert ("Get Directions To Next Class", ClassDetails , "Cancel", "Proceed");

				if(NextClassInput.ToString().ToLower() == "proceed")
				{
					Debug.WriteLine("Answer: " + NextClassInput);
				}
				else
				{
					// Cancel- Do Nothing
				}
			};

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
					if (App.isHostReachable ("googleapis.com")) {
						PlacesRepository placesRepo = PlacesRepository.getInstance;
					}
					networkStatus.BackgroundColor = Color.Green;
					networkStatus.Text = "Online";
				}
			};

//			TestButton.Clicked += async (sender, e) => {
//				bool r = await DependencyService.Get<INetwork> ().IsReachable ("googleapis.com", new TimeSpan (5));
//				await DisplayAlert ("Network Connection:", r ? "Connected :)" : "Not Connected :(", "Whatever");
//			};

			mainLayout.Children.Add (map,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Width),
				Constraint.RelativeToParent (parent => Height));

			mainLayout.Children.Add (_POIButton, Constraint.Constant (150), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (TestButton, Constraint.Constant (50), Constraint.Constant (50));
			//mainLayout.Children.Add (searchBar, Constraint.Constant (0));
			mainLayout.Children.Add (SGWButton, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (LOYButton, Constraint.Constant (80), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (SearchButton, Constraint.Constant (14), Constraint.Constant (14));
			mainLayout.Children.Add (SearchPicker, Constraint.Constant (0), Constraint.Constant (0));

			mainLayout.Children.Add (NextButtonAlert, Constraint.RelativeToParent (parent => Width - 160), Constraint.Constant (10));
			mainLayout.Children.Add (networkStatus, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 80));
			mainLayout.Children.Add (detailsLayout,
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Height),
				Constraint.RelativeToParent (parent => Width),
				null
			);
			mainLayout.Children.Add (loaderView, Constraint.RelativeToParent (parent => Width / 2 - loaderView.WidthRequest / 2), Constraint.RelativeToParent ((parent) => Height / 2 - loaderView.HeightRequest / 2));


//			mainLayout.Children.Add (searchViewModel,
//				Constraint.Constant (0),
//				Constraint.Constant (0),
//				Constraint.RelativeToParent (parent => Width), null);
			
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