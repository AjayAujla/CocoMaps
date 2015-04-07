using Xamarin.Forms;
using CocoMaps.Shared;
using System;
using System.Runtime.Remoting.Channels;
using Xamarin.Forms.Maps;
using Android.Gms.Maps.Model;
using CocoMaps.Indoor;

namespace CocoMaps.Shared
{
	public class IndoorLocationViewModel : RelativeLayout
	{
		enum ViewState
		{
			Expanded,
			Hidden
		}

		static IndoorLocationViewModel instance;

		public static IndoorLocationViewModel getInstance {
			get {
				if (instance == null) {
					instance = new IndoorLocationViewModel {
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor (),
						HeightRequest = 200
					};
					instance.Init ();
				}
				return instance;
			}
		}

		IndoorLocationViewModel ()
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

		void Init ()
		{
			
			foreach (string s in H.getInstance.graph.Nodes.Keys) {
				if (s.Length <= 3) {   // v is a room, not an intersection
					FromPicker.Items.Add ("H - " + s);
					ToPicker.Items.Add ("H - " + s);
				}
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
			instance.Children.Add (StartButton,
				Constraint.RelativeToView (FromPicker, (parent, sibling) => sibling.X + sibling.Width - StartButton.WidthRequest),
				Constraint.RelativeToView (ToPicker, (parent, sibling) => sibling.Y + sibling.Height + 5)
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


			instance.Padding = 10;
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
			double desiredPos = 0;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Expanded;

			toggleButton.Source = ImageSource.FromFile ("button_directions_toggle.png");

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

	}
}