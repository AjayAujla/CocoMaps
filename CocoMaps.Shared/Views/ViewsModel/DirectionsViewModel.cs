using Xamarin.Forms;
using CocoMaps.Shared;

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

		BuildingRepository buildingRepo = BuildingRepository.getInstance;


		Picker FromPicker {
			get;
			set;
		}

		Picker ToPicker {
			get;
			set;
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
			BackgroundColor = Color.Transparent,
			BorderRadius = 0
		};
		Button TravelShuttleModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_shuttle.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 0
		};
		Button TravelTransitModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_transit.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 0
		};
		Button TravelDrivingModeButton = new Button {
			Image = (FileImageSource)ImageSource.FromFile ("ic_travel_driving.png"),
			BackgroundColor = Color.Transparent,
			BorderRadius = 0
		};

		Button StartButton = new Button {
			Text = "Start",
			TextColor = Color.White,
			BackgroundColor = Helpers.Color.Navy.ToFormsColor (),
			BorderRadius = 0,
			WidthRequest = 100
		};

		Button CancelButton = new Button {
			Text = "Cancel",
			TextColor = Helpers.Color.Gray.ToFormsColor (),
			BackgroundColor = Color.Transparent,
			WidthRequest = 100
		};

		void Init ()
		{

			FromPicker = new Picker { HeightRequest = 50 };
			ToPicker = new Picker { HeightRequest = 50 };

			foreach (Building building in buildingRepo.BuildingList.Values) {
				FromPicker.Items.Add (building.Code);
				ToPicker.Items.Add (building.Code);
			}

			FromPicker.Title = "search from here...";
			ToPicker.Title = "...all the way there!";


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

			instance.Padding = 10;

			SwapIcon.Clicked += (sender, e) => SwapFromToValues ();
			CancelButton.Clicked += (sender, e) => Hide ();


		}


		void SwapFromToValues ()
		{
			int temp = FromPicker.SelectedIndex;
			FromPicker.SelectedIndex = ToPicker.SelectedIndex;
			ToPicker.SelectedIndex = temp;

		}

		public void Expand ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height / 3;
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

	}

}