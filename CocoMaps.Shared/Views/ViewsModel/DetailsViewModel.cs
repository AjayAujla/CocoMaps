using System;
using Xamarin.Forms;
using CocoMaps.Shared;
using System.Runtime.InteropServices;
using Android.Content.Res;
using Android.Gms.Identity.Intents;


using System.ComponentModel.Design.Serialization;


using Android.Gms.Drive;
using Android.Views;

namespace CocoMaps.Shared
{
	public class DetailsViewModel : RelativeLayout
	{

		enum ViewState
		{
			Expanded,
			Minimized,
			Hidden
		}


		static DetailsViewModel instance;
		static ViewState viewState;

		double _pageHeight;
		const double minimizedFooterHeight = 100;
		const double expandedFooterHeight = 400;

		double _minimizedFooterY;
		double _expandedFooterY;

		Label title = new Label {
			Text = "Title",
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			FontSize = 20,
			WidthRequest = App.ScreenSize.Width - 110,
			HorizontalOptions = LayoutOptions.Start
		};
		Label details = new Label {
			Text = "Details",
			TextColor = Helpers.Color.Gray.ToFormsColor (),
			FontSize = 10
		};

		Image image = new Image {
			Source = ImageSource.FromFile ("sgw.jpg"),
			WidthRequest = 100,
			HeightRequest = 100
		};
		Image atm = new Image {
			Source = ImageSource.FromFile ("hasatm.jpg"),
			WidthRequest = 16,
			HeightRequest = 16
		};
		Image bikerack = new Image {
			Source = ImageSource.FromFile ("hasbikerack.jpg"),
			WidthRequest = 16,
			HeightRequest = 16
		};
		Image infokiosk = new Image {
			Source = ImageSource.FromFile ("hasinfokiosk.jpg"),
			WidthRequest = 16,
			HeightRequest = 16
		};
		Image parkinglot = new Image {
			Source = ImageSource.FromFile ("hasparkinglot.jpg"),
			WidthRequest = 16,
			HeightRequest = 16
		};
		Image accessibility = new Image {
			Source = ImageSource.FromFile ("hasaccessibility.jpg"),
			WidthRequest = 16,
			HeightRequest = 16
		};

		StackLayout featuresImages = new StackLayout {
			Orientation = StackOrientation.Horizontal,
			Spacing = 5
		};

		Image toggleButton = new Image {
			BackgroundColor = Color.Transparent,
			Source = ImageSource.FromFile ("button_details_toggle.png"),
			WidthRequest = 50,
			HeightRequest = 50
		};

		Button showDetailsButton = new Button {
			Text = "Show More",
			FontSize = 8,
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			BackgroundColor = Color.Transparent
		};
		TableView list = new TableView {
			Intent = TableIntent.Form,
			HasUnevenRows = true,
			Root = new TableRoot {

			}
		};

		public static DetailsViewModel getInstance {
			get {
				if (instance == null) {
					instance = new DetailsViewModel {
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor ()
					};
					instance.Init ();

				}
				return instance;
			}
		}

		DetailsViewModel ()
		{
		}

		public void Init ()
		{
			_pageHeight = App.ScreenSize.Height;
			_minimizedFooterY = _pageHeight - minimizedFooterHeight;
			_expandedFooterY = _pageHeight - expandedFooterHeight;
			viewState = ViewState.Hidden;

			instance.Children.Add (title, 
				Constraint.Constant (14),
				Constraint.Constant (0),
				Constraint.RelativeToParent (parent => Width - image.Width),
				null
			);

			instance.Children.Add (details, 
				Constraint.Constant (14),
				Constraint.RelativeToView (title, (parent, sibling) => sibling.Y + sibling.Height - 5),
				Constraint.RelativeToParent (parent => Width - image.Width),
				null
			);

			instance.Children.Add (image, 
				Constraint.RelativeToParent (Parent => Width - image.Width),
				Constraint.Constant (0)
			);

			featuresImages.Children.Add (atm);
			featuresImages.Children.Add (accessibility);
			featuresImages.Children.Add (bikerack);
			featuresImages.Children.Add (parkinglot);
			featuresImages.Children.Add (infokiosk);

			instance.Children.Add (featuresImages, 
				Constraint.Constant (14),
				Constraint.RelativeToView (details, (parent, sibling) => sibling.Y + sibling.Height + 5));

			instance.Children.Add (toggleButton,
				Constraint.RelativeToParent (Parent => Width / 2 - toggleButton.Width / 2),
				Constraint.RelativeToParent (Parent => -toggleButton.Height / 2)
			);
			var toggleButtonTap = new TapGestureRecognizer ();
			toggleButtonTap.Tapped += (sender, e) => Toggle ();

			toggleButton.GestureRecognizers.Add (toggleButtonTap);

			instance.Children.Add (list, Constraint.Constant (14), Constraint.Constant (100));
		
		}

		public void UpdateView (Directions direction)
		{
		
			title.Text = direction.routes [0].legs [0].distance.text + " (" + direction.routes [0].legs [0].duration.text + ")";
			title.TextColor = Helpers.Color.Navy.ToFormsColor ();

			details.Text = "To " + direction.routes [0].legs [0].end_address;

			featuresImages.IsVisible = false;

			toggleButton.Source = ImageSource.FromFile ("button_directions_toggle.png");

			list.Root.Clear ();
			foreach (Leg leg in direction.routes[0].legs) {
				foreach (Step step in leg.steps) {
					list.Root.Add (new TableSection {
						new TextCell {
							Text = step.html_instructions_nohtml,
							Detail = step.distance.text + " (" + step.duration.text + ")"
						}
					});
				}
			}
			Minimize ();
		}

		public void UpdateView (Building building)
		{

			title.Text = building.Code + " Building";
			title.TextColor = Helpers.Color.Maroon.ToFormsColor ();

			details.Text = building.Address;

			featuresImages.IsVisible = true;

			atm.IsVisible = building.HasAtm;
			atm.IsVisible = building.HasAccessibility;
			atm.IsVisible = building.HasBikeRack;
			atm.IsVisible = building.HasParkingLot;
			atm.IsVisible = building.HasInfoKiosk;

			image.Source = ImageSource.FromFile ("building_" + building.Code.ToLower () + ".jpg");

			toggleButton.Source = ImageSource.FromFile ("button_buildings_toggle.png");

			list.Root.Clear ();
			if (building.Services != null) {
				foreach (Service service in building.Services) {

					list.Root.Add (new TableSection {
						new TextCell {
							Text = service.Name,
							Detail = service.RoomNumber
						}
					});

				}
			} else {
				list.Root.Add (new TableSection {
					new TextCell {
						Text = building.Code + " Building has no services"
					}
				});
			}
			Minimize ();
		}

		public void UpdateView (string buildingCode)
		{
			Building building;
			foreach (Campus campus in BuildingRepository.getInstance.getCampusList()) {
				building = campus.GetBuildingByCode (buildingCode);
				if (building != null) {
					UpdateView (building);
					break;
				}
			}

		}

		public void Minimize ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height - image.Height;
			instance.TranslateTo (0, desiredPos - currentPos);
			toggleButton.RotateTo (0);
			viewState = ViewState.Minimized;
		}

		public void Expand ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height / 3;
			instance.TranslateTo (0, desiredPos - currentPos);
			toggleButton.RotateTo (180);
			viewState = ViewState.Expanded;
		}

		public void Hide ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height + toggleButton.Height / 2;
			instance.TranslateTo (0, desiredPos - currentPos);
			toggleButton.RotateTo (0);
			viewState = ViewState.Hidden;
		}

		public void Toggle ()
		{
			if (viewState == ViewState.Minimized) {
				Expand ();
			} else if (viewState == ViewState.Expanded) {
				Minimize ();
			}
		}

	}
}