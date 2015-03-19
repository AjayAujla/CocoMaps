using Xamarin.Forms;
using CocoMaps.Shared;
using System;
using System.Runtime.Remoting.Channels;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class DirectionsViewModel : RelativeLayout
	{
		enum ViewState
		{
			Expanded,
			Hidden
		}

		static DirectionsViewModel instance;

		public static DirectionsViewModel getInstance {
			get {
				if (instance == null) {
					instance = new DirectionsViewModel {
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor (),
						HeightRequest = 250
					};
					instance.Init ();
				}
				return instance;
			}
		}

		DirectionsViewModel ()
		{
		}

		static ViewState viewState;

		public String Start {
			get;
			set;
		}

		public String End {
			get;
			set;
		}

		public TravelMode TravelMode {
			get;
			set;
		}

		BuildingRepository buildingRepo = BuildingRepository.getInstance;

		Picker _fromPicker;

		public Picker FromPicker {
			get {
				if (_fromPicker == null)
					_fromPicker = new Picker { HeightRequest = 50 };
				return _fromPicker;
			}
			set {
			}
		}

		Picker _toPicker;

		public Picker ToPicker {
			get { 
				if (_toPicker == null)
					_toPicker = new Picker { HeightRequest = 50 };
				return _toPicker;
			}
			set {
			}
		}

		Image DirectionsIcon = new Image {
			Source = ImageSource.FromFile ("ic_dir_sign.png"),
			Opacity = 0.6
		};

		Button SwapIcon = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_dir_swap.png"),
			BackgroundColor = Color.Transparent
		};

		Button TravelWalkingModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_walking.png"),
			BackgroundColor = Helpers.Color.Blue.ToFormsColor (),
			BorderRadius = 50,
		};
		public Button TravelShuttleModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_shuttle.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 50,
		};
		Button TravelTransitModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_transit.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 50,
		};
		Button TravelDrivingModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_driving.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 50,
		};

		public Button StartButton = new Button {
			Text = "Start",
			TextColor = Color.White,
			BackgroundColor = Helpers.Color.Blue.ToFormsColor (),
			BorderRadius = 0,
			WidthRequest = 100,
			HeightRequest = 50
		};

		Image toggleButton = new Image {
			BackgroundColor = Color.Transparent,
			Source = ImageSource.FromFile ("button_details_toggle.png"),
			WidthRequest = 50,
			HeightRequest = 50,
		};

		RelativeLayout toggleLayout = new RelativeLayout ();

		Label temperatureLabel;
		Image weatherConditionIcon;

		void Init ()
		{
			foreach (Building building in buildingRepo.BuildingList.Values) {
				FromPicker.Items.Add (building.Code);
				ToPicker.Items.Add (building.Code);
			}

			FromPicker.Title = "Search from here ...";
			ToPicker.Title = "... All the way there!";

			TravelMode = TravelMode.walking;

			instance.Children.Add (FromPicker,
				Constraint.Constant (68),
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Width - 68 * 2),
				null
			);
			instance.Children.Add (ToPicker,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X),
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.Height),
				Constraint.RelativeToParent (parent => Width - 68 * 2),
				null
			);
			instance.Children.Add (DirectionsIcon,
				Constraint.Constant (12),
				Constraint.Constant (17)
			);
			instance.Children.Add (SwapIcon,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X + sibling.Width),
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.Height - sibling.Height / 2)
			);
			instance.Children.Add (TravelWalkingModeButton,
				Constraint.RelativeToView (ToPicker, (parent, sibling) => sibling.X - 20),
				Constraint.RelativeToView (ToPicker, (parent, sibling) => sibling.Y + sibling.Height + 10)
			);
			instance.Children.Add (TravelShuttleModeButton,
				Constraint.RelativeToView (TravelWalkingModeButton, (parent, sibling) => sibling.X + sibling.Width + 5),
				Constraint.RelativeToView (TravelWalkingModeButton, (parent, sibling) => sibling.Y)
			);
			instance.Children.Add (TravelTransitModeButton,
				Constraint.RelativeToView (TravelShuttleModeButton, (parent, sibling) => sibling.X + sibling.Width + 5),
				Constraint.RelativeToView (TravelShuttleModeButton, (parent, sibling) => sibling.Y)
			);
			instance.Children.Add (TravelDrivingModeButton,
				Constraint.RelativeToView (TravelTransitModeButton, (parent, sibling) => sibling.X + sibling.Width + 5),
				Constraint.RelativeToView (TravelTransitModeButton, (parent, sibling) => sibling.Y)
			);
			instance.Children.Add (StartButton,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X + sibling.Width - StartButton.WidthRequest),
				Constraint.RelativeToView (TravelWalkingModeButton, (parent, sibling) => sibling.Y + sibling.Height + 5)
			);
			instance.Children.Add (toggleButton,
				Constraint.RelativeToParent (Parent => Width / 2 - toggleButton.Width / 2),
				Constraint.RelativeToParent (Parent => instance.Height - toggleButton.Height / 2)
			);

			var toggleTap = new TapGestureRecognizer ();
			toggleTap.Tapped += (sender, e) => Toggle ();
			toggleButton.GestureRecognizers.Add (toggleTap);
			toggleLayout.GestureRecognizers.Add (toggleTap);


			FromPicker.SelectedIndexChanged += (sender, e) => {
				if (FromPicker.SelectedIndex >= 0)
					Start = FromPicker.Items [FromPicker.SelectedIndex];
			};
			ToPicker.SelectedIndexChanged += (sender, e) => {
				if (ToPicker.SelectedIndex >= 0)
					End = ToPicker.Items [ToPicker.SelectedIndex];
			};

			SwapIcon.Clicked += (sender, e) => SwapFromToValues ();

			TravelWalkingModeButton.Clicked += HandleTravelModeButtons;
			TravelShuttleModeButton.Clicked += HandleTravelModeButtons;
			TravelTransitModeButton.Clicked += HandleTravelModeButtons;
			TravelDrivingModeButton.Clicked += HandleTravelModeButtons;

			instance.Padding = 10;
		}

		void SwapFromToValues ()
		{
			int temp = FromPicker.SelectedIndex;
			FromPicker.SelectedIndex = ToPicker.SelectedIndex;
			ToPicker.SelectedIndex = temp;
		}

		// Xamarin.Forms XLabs has a class classed ButtonGroup
		void HandleTravelModeButtons (object sender, EventArgs e)
		{
			Button b = sender as Button;
			TravelWalkingModeButton.BackgroundColor = Color.Transparent;
			TravelShuttleModeButton.BackgroundColor = Color.Transparent;
			TravelTransitModeButton.BackgroundColor = Color.Transparent;
			TravelDrivingModeButton.BackgroundColor = Color.Transparent;

			if (b.Image.File.Contains ("walking"))
				TravelMode = TravelMode.walking;
			if (b.Image.File.Contains ("shuttle"))
				TravelMode = TravelMode.shuttle;
			if (b.Image.File.Contains ("transit"))
				TravelMode = TravelMode.transit;
			if (b.Image.File.Contains ("driving"))
				TravelMode = TravelMode.driving;
			
			b.BackgroundColor = Helpers.Color.Blue.ToFormsColor ();

			Console.WriteLine ("TravelMode: " + TravelMode);
		}

		public void Expand ()
		{
			double currentPos = instance.Y;
			double desiredPos = 0;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Expanded;

			toggleButton.Source = ImageSource.FromFile ("button_directions_toggle.png");

			AddWeatherInfo ();
		}

		public void Hide ()
		{
			double currentPos = instance.Y;
			double desiredPos = 0 - instance.Height - 25;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Hidden;

			toggleButton.Source = ImageSource.FromFile ("button_directions_toggle.png");
		}

		public void Toggle ()
		{
			if (viewState == ViewState.Hidden) {
				Expand ();
			} else if (viewState == ViewState.Expanded) {
				Hide ();
			}
		}

		/*
		 * Fetches and displays current weather information in the Directions pane
		 */
		public async void AddWeatherInfo ()
		{
			if (App.isConnected () && App.isHostReachable ("openweathermap.org")) {
				RequestWeather requestWeather = new RequestWeather ();

				try {
					var weatherRequest = await requestWeather.GetWeather ("LOY");
					if (weatherRequest != null) {

						// Display temperature
						if (temperatureLabel == null) {
							temperatureLabel = new Label () {
								Text = Math.Round (weatherRequest.main.temp, 0) + " °C",
								TextColor = Helpers.Color.Gray.ToFormsColor (),
							};

							instance.Children.Add (temperatureLabel,
								Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.X - 60),
								Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.Y + 15)
							);
						}

						// Display weather condition icon
						if (weatherConditionIcon == null) {
							string imagePath = requestWeather.GetImagePath (weatherRequest.weather [0].icon);
							if (!String.IsNullOrWhiteSpace (imagePath)) {
								weatherConditionIcon = new Image () {
									Source = ImageSource.FromFile (imagePath),
								};

								instance.Children.Add (weatherConditionIcon, 
									Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.X - 125),
									Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.Y)
								);
							}
						}
					}
				} catch (Exception ex) {
					Console.WriteLine ("Unable to retrieve weather data.\n" + ex.ToString ());
				}
			} else {
				Console.WriteLine ("The application cannot access the network for finding current weather information.");
			}
		}
	}
}