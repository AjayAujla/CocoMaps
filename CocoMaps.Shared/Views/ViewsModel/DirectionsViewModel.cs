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
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor ()
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
			WidthRequest = 100
		};

		Button CancelButton = new Button {
			Text = "Cancel",
			TextColor = Helpers.Color.Gray.ToFormsColor (),
			BackgroundColor = Color.Transparent,
			WidthRequest = 100
		};

		Button TestWeatherButton = new Button {
			Text = "Weather",
			TextColor = Helpers.Color.Maroon.ToFormsColor (),
			BackgroundColor = Color.Transparent,
			WidthRequest = 100,
		};

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
			instance.Children.Add (CancelButton,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X),
				Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.Y)
			);
			instance.Children.Add (TestWeatherButton,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X + 100),
				Constraint.RelativeToView (StartButton, (parent, sibling) => sibling.Y)
			);

			instance.Padding = 10;

			FromPicker.SelectedIndexChanged += (sender, e) => {
				if (FromPicker.SelectedIndex >= 0)
					Start = FromPicker.Items [FromPicker.SelectedIndex];
			};
			ToPicker.SelectedIndexChanged += (sender, e) => {
				if (ToPicker.SelectedIndex >= 0)
					End = ToPicker.Items [ToPicker.SelectedIndex];
			};

			SwapIcon.Clicked += (sender, e) => SwapFromToValues ();
			CancelButton.Clicked += (sender, e) => Hide ();
			//TestWeatherButton.Clicked += async (sender, e) => AddWeatherInfo ();

			TravelWalkingModeButton.Clicked += HandleTravelModeButtons;
			TravelShuttleModeButton.Clicked += HandleTravelModeButtons;
			TravelTransitModeButton.Clicked += HandleTravelModeButtons;
			TravelDrivingModeButton.Clicked += HandleTravelModeButtons;

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
		}

		public void Hide ()
		{
			double currentPos = instance.Y;
			double desiredPos = 0 - instance.Height;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Hidden;
		}

		public void Toggle ()
		{
			if (viewState == ViewState.Hidden) {
				Expand ();
			} else if (viewState == ViewState.Expanded) {
				Hide ();
			}
		}

		public async void AddWeatherInfo ()
		{
			RequestWeather weather = new RequestWeather ();
			Image image = await weather.FetchWeatherAndParse ("LOY");

			instance.Children.Add (image,
				Constraint.Constant (12),
				Constraint.Constant (17)
			);
		}
	}
}