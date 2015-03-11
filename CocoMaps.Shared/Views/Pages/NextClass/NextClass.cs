using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class NextClass : ContentPage
	{
		public NextClass (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "Next Class");
			SetValue (Page.IconProperty, menuItem.Icon);


			string startLocation;
			string destination;

			// Test

			string testClass = "SGW-FG-965";
			startLocation = "7141 Sherbrooke Street W.";

			destination = getClassLocation (testClass);

			startLocation = startLocation + " Montreal QC";
			destination = destination + " Montreal QC";


			var label0 = new Label {
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Next Class : "
			};


			var label1 = new Label {
				Text = testClass,

				Font = Font.SystemFontOfSize (NamedSize.Large) 
			};

			var label2 = new Label {
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Destination : "
			};

			var label3 = new Label {
				Text = destination,

				Font = Font.SystemFontOfSize (NamedSize.Large)
			};

			var label4 = new Label {
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Current Location : "
			};

			var label5 = new Label {
				Text = startLocation + "\r\n \r\n",

				Font = Font.SystemFontOfSize (NamedSize.Large)
			};

			/*var NextClassButton = new Button {
				Text = "Get Directions to Next Class",
				HeightRequest = 50,
				WidthRequest = 100,
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				Opacity = 0.7,
				BorderRadius = 0
			};*/

			var NextClassButton = new Button { Text = "Get Directions to Next Class" };

			var pushClass = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { NextClassButton }
			};

			//NextClassButton.Clicked += HandleNextClassButton(startLocation , destination);

			Content = new StackLayout {
				Children = {
					label0,
					label1,
					label2,
					label3,
					label4,
					label5,
					pushClass
				}
			};



		}


		public string getClassLocation (string dest)
		{
			string destination = dest.Trim ().ToUpper ();

			string[] destination_array = destination.Split ('-');

			string campusLoc = destination_array [0];

			string roomLoc = destination_array [1];


			BuildingRepository BR = BuildingRepository.getInstance;

			Campus campus = BR.GetCampusByCode (campusLoc);

			Building building = campus.GetBuildingByCode (roomLoc);


			return building.Address;

		}

		static void HandleNextClassButton (string start, string end)
		{
			RequestDirections RD;

			//Task<Directions> GDirections = RD.getDirections(start , end , TravelMode.walking);

		}

	}

}