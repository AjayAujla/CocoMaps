using Xamarin.Forms;

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

		enum Infos
		{
			OnServices,
			OnDepartments
		}

		DirectionsViewModel directionsViewModel = DirectionsViewModel.getInstance;

		static DetailsViewModel instance;

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

		ViewState viewState;
		Infos infos;

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

		RelativeLayout toggleLayout = new RelativeLayout ();

		TableView directionsList = new TableView {
			Intent = TableIntent.Form,
			HasUnevenRows = true,
			Root = new TableRoot {
			}
		};

		TableView servicesList = new TableView {
			HasUnevenRows = true,
			Root = new TableRoot ()
		};

		TableView departmentsList = new TableView {
			HasUnevenRows = true,
			Root = new TableRoot ()
		};

		RelativeLayout listsHolder = new RelativeLayout ();

		Button servicesButton = new Button {
			Text = "Services",
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			BackgroundColor = Helpers.Color.LightGray.ToFormsColor (),
			BorderRadius = 0
		};

		Button departmentsButton = new Button {
			Text = "Departments",
			TextColor = Helpers.Color.Navy.ToFormsColor (),
			BackgroundColor = Helpers.Color.LightGray.ToFormsColor (),
			BorderRadius = 0
		};

		Button directionsButton = new Button {
			Text = "Directions",
			TextColor = Helpers.Color.Blue.ToFormsColor (),
			Image = (FileImageSource)ImageSource.FromFile ("ic_dir_buildings.png"),
			BackgroundColor = Color.Transparent
		};

		void Init ()
		{
			viewState = ViewState.Hidden;
			infos = Infos.OnServices;

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

			instance.Children.Add (toggleLayout,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (Parent => Width),
				Constraint.RelativeToView (image, (parent, sibling) => sibling.Height)
			);

			instance.Children.Add (directionsButton,
				Constraint.RelativeToView (featuresImages, (parent, sibling) => sibling.X - 10),
				Constraint.RelativeToView (featuresImages, (parent, sibling) => sibling.Y + sibling.Height - 5)
			);

			instance.Children.Add (servicesButton, 
				Constraint.Constant (0),
				Constraint.RelativeToView (image, (parent, sibling) => sibling.Y + sibling.Height + 5),
				Constraint.RelativeToParent (Parent => Width / 2),
				Constraint.Constant (50)
			);

			instance.Children.Add (departmentsButton, 
				Constraint.RelativeToView (servicesButton, (parent, sibling) => sibling.X + sibling.Width),
				Constraint.RelativeToView (servicesButton, (parent, sibling) => sibling.Y),
				Constraint.RelativeToParent (Parent => Width / 2),
				Constraint.Constant (50)
			);



			instance.Children.Add (toggleButton,
				Constraint.RelativeToParent (Parent => Width / 2 - toggleButton.Width / 2),
				Constraint.RelativeToParent (Parent => -toggleButton.Height / 2)
			);

			var toggleTap = new TapGestureRecognizer ();
			toggleTap.Tapped += (sender, e) => Toggle ();
			toggleButton.GestureRecognizers.Add (toggleTap);
			toggleLayout.GestureRecognizers.Add (toggleTap);

			instance.Children.Add (directionsList, 
				Constraint.Constant (0), 
				Constraint.RelativeToView (image, (parent, sibling) => sibling.Y + sibling.Height + 5),
				Constraint.RelativeToParent (Parent => Width),
				null
			);

			instance.Children.Add (listsHolder,
				Constraint.Constant (0), 
				// for hiding the TableSection which was causing a blank space
				Constraint.RelativeToView (servicesButton, (parent, sibling) => sibling.Y + 3),
				Constraint.RelativeToParent (Parent => Width * 2),
				Constraint.RelativeToView (servicesButton, (parent, sibling) => parent.Height - sibling.Y)
			);

			listsHolder.Children.Add (servicesList,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent (Parent => Width),
				Constraint.RelativeToParent (Parent => Height - servicesButton.Height * 2 - 10)
			);

			listsHolder.Children.Add (departmentsList,
				Constraint.RelativeToView (servicesList, (parent, sibling) => sibling.X + sibling.Width),
				Constraint.Constant (0),
				Constraint.RelativeToParent (Parent => Width),
				Constraint.RelativeToParent (Parent => Height - departmentsButton.Height * 2 - 10)
			);

			instance.RaiseChild (servicesButton);
			instance.RaiseChild (departmentsButton);

			servicesButton.Clicked += (sender, e) => ShowServices ();
			departmentsButton.Clicked += (sender, e) => ShowDepartments ();

			// For fixing the layout's heights and widths when changing
			// the device orientation while layout is expanded
			instance.SizeChanged += (sender, e) => {
				if (instance.viewState == ViewState.Expanded)
					instance.Expand ();
				if (instance.infos == Infos.OnServices)
					instance.ShowServices ();
				else
					instance.ShowDepartments ();
			};

		}

		public void UpdateView (Directions direction)
		{

			title.Text = direction.routes [0].legs [0].distance.text + " (" + direction.routes [0].legs [0].duration.text + ")";
			title.TextColor = Helpers.Color.Navy.ToFormsColor ();

			details.Text = "To " + direction.routes [0].legs [0].end_address;

			directionsList.IsVisible = true;

			// Hiding building details stuff
			image.IsVisible = false;
			featuresImages.IsVisible = false;
			servicesList.IsVisible = false;
			departmentsList.IsVisible = false;
			servicesButton.IsVisible = false;
			departmentsButton.IsVisible = false;
			directionsButton.IsVisible = false;

			toggleButton.Source = ImageSource.FromFile ("button_directions_toggle.png");

			directionsList.Root.Clear ();
			foreach (Leg leg in direction.routes[0].legs) {
				foreach (Step step in leg.steps) {
					directionsList.Root.Add (new TableSection {
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

			instance.ShowServices ();

			image.IsVisible = true;
			featuresImages.IsVisible = true;

			servicesList.IsVisible = true;
			departmentsList.IsVisible = true;
			servicesButton.IsVisible = true;
			departmentsButton.IsVisible = true;
			directionsButton.IsVisible = true;

			directionsList.IsVisible = false;

			atm.IsVisible = building.HasAtm;
			accessibility.IsVisible = building.HasAccessibility;
			bikerack.IsVisible = building.HasBikeRack;
			parkinglot.IsVisible = building.HasParkingLot;
			infokiosk.IsVisible = building.HasInfoKiosk;

			image.Source = ImageSource.FromFile ("building_" + building.Code.ToLower () + ".jpg");

			toggleButton.Source = ImageSource.FromFile ("button_buildings_toggle.png");

			int buildingIndex = BuildingRepository.getInstance.GetBuildingIndex (building);

			directionsButton.Clicked += (sender, e) => {

				// Open directions with Google Maps app
				if (Settings.useDeviceMap) {
					DependencyService.Get<IPhoneService> ().LaunchMap (building.Address);

				} else {
					
					// Open directions within CocoMaps app
					if (directionsViewModel.FromPicker.SelectedIndex == -1)
						directionsViewModel.FromPicker.SelectedIndex = buildingIndex;
					else if (directionsViewModel.ToPicker.SelectedIndex == -1)
						directionsViewModel.ToPicker.SelectedIndex = buildingIndex;
					else
						directionsViewModel.ToPicker.SelectedIndex = buildingIndex;
					
					instance.Minimize ();
					directionsViewModel.Expand ();
				}
			};

			servicesList.Root.Clear ();

			TableSection servicesSection = new TableSection ();

			servicesList.Root.Add (servicesSection);

			if (building.Services != null && building.Services.Count > 0) {

				TextCell textCell;

				foreach (Service service in building.Services) {

					textCell = new TextCell ();

					textCell.Text = service.Name;
					textCell.TextColor = Color.Black;
					textCell.DetailColor = Color.Gray;

					if (service.RoomNumber != null)
						textCell.Detail = service.RoomNumber;

					if (service.URI != null) {
						textCell.TextColor = Helpers.Color.Navy.ToFormsColor ();
						textCell.Tapped += (sender, e) => DependencyService.Get<IPhoneService> ().OpenBrowser (service.URI);
					}

					servicesSection.Add (
						textCell
					);

				}
			} else {

				servicesSection.Add (
					new TextCell {
						Text = "No services",
						TextColor = Color.Gray
					}
				);

			}

			departmentsList.Root.Clear ();

			TableSection departmentsSection = new TableSection ();

			departmentsList.Root.Add (departmentsSection);

			if (building.Departments != null && building.Departments.Count > 0) {

				TextCell textCell;
				foreach (Department department in building.Departments) {

					textCell = new TextCell ();

					textCell.Text = department.Name;
					textCell.TextColor = Color.Black;
					textCell.DetailColor = Color.Gray;

					if (department.URI != null) {
						textCell.TextColor = Helpers.Color.Navy.ToFormsColor ();
						textCell.Tapped += (sender, e) => DependencyService.Get<IPhoneService> ().OpenBrowser (department.URI);
					}

					departmentsSection.Add (
						textCell
					);
				}

			} else {

				departmentsSection.Add (
					new TextCell {
						Text = "No departments",
						TextColor = Color.Gray
					}
				);

			}

			Minimize ();
		}

		public void UpdateView (string buildingCode)
		{
			Building building;
			if (BuildingRepository.getInstance.BuildingList.TryGetValue (buildingCode, out building))
				UpdateView (building);
		}

		public void ShowServices ()
		{
			double currentPos = listsHolder.X;
			double desiredPos = 0;
			listsHolder.TranslateTo (desiredPos - currentPos, 0, 150);
			infos = Infos.OnServices;

			servicesButton.TextColor = Color.White;
			servicesButton.BackgroundColor = Helpers.Color.Navy.ToFormsColor ();

			departmentsButton.TextColor = Helpers.Color.Navy.ToFormsColor ();
			departmentsButton.BackgroundColor = Helpers.Color.FromHex (0xd2d2d2).ToFormsColor ();
		}

		public void ShowDepartments ()
		{
			double currentPos = listsHolder.X;
			double desiredPos = -listsHolder.Bounds.Width / 2;
			listsHolder.TranslateTo (desiredPos - currentPos, 0, 150);
			infos = Infos.OnDepartments;

			servicesButton.TextColor = Helpers.Color.Navy.ToFormsColor ();
			servicesButton.BackgroundColor = Helpers.Color.FromHex (0xd2d2d2).ToFormsColor ();

			departmentsButton.TextColor = Color.White;
			departmentsButton.BackgroundColor = Helpers.Color.Navy.ToFormsColor ();
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
			// Hide the top DirectionsView if we expand building details
			//directionsViewModel.Hide ();

			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height - instance.Height;
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