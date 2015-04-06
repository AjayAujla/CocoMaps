using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class IndoorMapPage : ContentPage
	{
		IndoorMap map;
		RelativeLayout mainLayout;

		Label networkStatus = new Label {
			TextColor = Color.White
		};

		BuildingRepository buildingRepo = BuildingRepository.getInstance;
		LoaderViewModel loaderView = LoaderViewModel.getInstance;
		DetailsViewModel detailsLayout = DetailsViewModel.getInstance;
		IndoorLocationViewModel indoorLocationViewModel = IndoorLocationViewModel.getInstance;

		static Button _testButton = new Button {
			Text = "Class Locator",
			HeightRequest = 40,
			BackgroundColor = Color.White,
			Opacity = 0.7,
			BorderRadius = 0
		};

		static Button _POIButton = new Button { 
			Text = "POI", 
			HeightRequest = 40,
			BackgroundColor = Color.White,
			Opacity = 0.7,
			BorderRadius = 0
		};

		public static Button _BookmarksButton = new Button { 
			//Text = "BM", 
			Image = "ic_map_bookmark.png",
			HeightRequest = 40,
			WidthRequest = 40,
			BackgroundColor = Color.White,
			Opacity = 0.7,
			BorderRadius = 0
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

		public IndoorMapPage (IMenuOptions menuItem)
		{
			RelativeLayout test = new RelativeLayout {
				BackgroundColor = Color.Blue,
				HeightRequest = 100,
				WidthRequest = 100
			};

			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "Indoor Directions");
			SetValue (Page.IconProperty, menuItem.Icon);

			map = new IndoorMap ();

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

			TestButton.Clicked += async (sender, e) => {
				indoorLocationViewModel.Expand ();
			};

			mainLayout.Children.Add (map,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Width),
				Constraint.RelativeToParent (parent => Height));

			Image sidebarSlideImage = new Image {
				Source = ImageSource.FromFile ("sidebar_slide.png")
			};

			mainLayout.Children.Add (sidebarSlideImage, 
				Constraint.Constant (0), 
				Constraint.RelativeToParent (parent => Height / 2 - 50));
			
			mainLayout.Children.Add (TestButton, Constraint.Constant (64), Constraint.Constant (14));
			//mainLayout.Children.Add (searchBar, Constraint.Constant (0));
			mainLayout.Children.Add (SGWButton, Constraint.Constant (15), Constraint.RelativeToParent (parent => Height - 54));
			mainLayout.Children.Add (LOYButton, Constraint.Constant (80), Constraint.RelativeToParent (parent => Height - 54));

			mainLayout.Children.Add (loaderView, Constraint.RelativeToParent (parent => Width / 2 - loaderView.WidthRequest / 2), Constraint.RelativeToParent ((parent) => Height / 2 - loaderView.HeightRequest / 2));

			mainLayout.Children.Add (SearchButton, Constraint.Constant (14), Constraint.Constant (14));
			mainLayout.Children.Add (SearchPicker, Constraint.Constant (0), Constraint.Constant (0));

			mainLayout.Children.Add (indoorLocationViewModel,
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => -Height),
				Constraint.RelativeToParent (parent => Width),
				null);

			Content = mainLayout;
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