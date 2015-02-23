using System;
using Xamarin.Forms;
using Android.Views;
using Android.Gms.Common.Apis;
using Android.Views.InputMethods;
using Android.Gms.Identity.Intents;
using System.Runtime.Remoting.Messaging;
using Android.Gms.Drive;
using Android.Views.Animations;

namespace CocoMaps.Shared
{
	public class DetailsViewModel : RelativeLayout
	{

		private enum ContentState
		{
			ShowingBuildingDetails,
			ShowingDirectionDetails}

		;

		private static DetailsViewModel directionsViewModel;
		private static ContentState contentState;


		private static Label title = new Label {
			Text = "Title",
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			FontSize = 20
		};
		private static Label details = new Label {
			Text = "Details",
			TextColor = Helpers.Color.Gray.ToFormsColor (),
			FontSize = 10
		};
		private static Button closeLayoutButton = new Button {
			Text = "X",
			TextColor = Color.Gray,
			BackgroundColor = Color.Transparent
		};
		private static Button showDetailsButton = new Button {
			Text = "Show More",
			FontSize = 8,
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			BackgroundColor = Color.Transparent
		};
		private static TableView directionSteps = new TableView {
			Intent = TableIntent.Form,
			HasUnevenRows = true,
			Root = new TableRoot {
			
			}
		};

		public static DetailsViewModel getInstance {
			get {
				if (directionsViewModel == null) {
					directionsViewModel = new DetailsViewModel {
						Padding = 14,
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor (),
						WidthRequest = App.ScreenSize.Width,
						HeightRequest = App.ScreenSize.Height
					};
					directionsViewModel.Init ();
				
				}
				return directionsViewModel;
			}
		}

		private DetailsViewModel ()
		{
		}

		public void Init ()
		{
			directionsViewModel.Children.Add (DetailsViewModel.title, Constraint.Constant (14));
			directionsViewModel.Children.Add (DetailsViewModel.details, Constraint.Constant (14), Constraint.Constant (25));
			directionsViewModel.Children.Add (DetailsViewModel.closeLayoutButton, Constraint.Constant (App.ScreenSize.Width - 50), Constraint.Constant (-10));
			directionsViewModel.Children.Add (DetailsViewModel.showDetailsButton, Constraint.Constant (App.ScreenSize.Width - 100), Constraint.Constant (-10));
			directionsViewModel.Children.Add (DetailsViewModel.directionSteps, Constraint.Constant (14), Constraint.Constant (50));
			closeLayoutButton.Clicked += DetailsViewModel.Hide;
			showDetailsButton.Clicked += DetailsViewModel.ShowDetails;
		}

		public void UpdateView (Directions direction)
		{

			contentState = ContentState.ShowingDirectionDetails;

			DetailsViewModel.title.Text = direction.routes [0].summary;
			DetailsViewModel.title.TextColor = Helpers.Color.Navy.ToFormsColor ();

			DetailsViewModel.details.Text = direction.routes [0].legs [0].distance.text + " (" + direction.routes [0].legs [0].duration.text + ")";

			directionSteps.Root.Clear ();
			foreach (Leg leg in direction.routes[0].legs) {
				foreach (Step step in leg.steps) {
					directionSteps.Root.Add (new TableSection {
						new TextCell {
							Text = step.html_instructions,
							Detail = step.distance.text + " (" + step.duration.text + ")"
						}
					});
				}
			}
		}

		public void UpdateView (Building building)
		{
			contentState = ContentState.ShowingBuildingDetails;

			DetailsViewModel.title.Text = building.Code + " - " + building.Name;
			DetailsViewModel.title.TextColor = Helpers.Color.Maroon.ToFormsColor ();

			DetailsViewModel.details.Text = building.Address;

			directionSteps.Root.Clear ();
			if (building.Services != null && building.Services.Count > 0) {
				foreach (Service service in building.Services) {

					directionSteps.Root.Add (new TableSection {
						new TextCell {
							Text = service.Name,
							Detail = service.RoomNumber
						}
					});
				
				}
			} else {
				directionSteps.Root.Add (new TableSection {
					new TextCell {
						Text = building.Code + " Building has no services"
					}
				});
			}
		}

		public void ShowSummary ()
		{
			int currentPos = (int)directionsViewModel.Y;
			int desiredPos = (int)(App.ScreenSize.Height - 100);
			showDetailsButton.Opacity = 1;
			directionsViewModel.TranslateTo (0, desiredPos - currentPos);
		}

		static void ShowDetails (object sender, EventArgs e)
		{
			int currentPos = (int)directionsViewModel.Y;
			int desiredPos = (int)(App.ScreenSize.Height - 100 - directionSteps.Height);
			Console.WriteLine ("HEIGHT: " + directionSteps.Height);
			directionsViewModel.TranslateTo (0, desiredPos - currentPos);
			if (DetailsViewModel.contentState == ContentState.ShowingBuildingDetails)
				showDetailsButton.Opacity = 0;
			else {
				showDetailsButton.Text = "Show Less";
				showDetailsButton.Clicked += HideDetails;
			}
		}

		static void Hide (object sender, EventArgs e)
		{
			int currentPos = (int)directionsViewModel.Y;
			int desiredPos = (int)(App.ScreenSize.Height);
			directionsViewModel.TranslateTo (0, desiredPos - currentPos);
		}

		static void HideDetails (object sender, EventArgs e)
		{
			directionsViewModel.ShowSummary ();
			showDetailsButton.Text = "Show More";
			showDetailsButton.Clicked += ShowDetails;
		}

	}
}