using Xamarin.Forms;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class Bookmark : ContentPage
	{

		Button directionButton;
		Button deleteButton;

		public Bookmark (IMenuOptions menuItem)
		{

			this.SetValue (Page.TitleProperty, "Bookmark");
			this.SetValue (Page.IconProperty, menuItem.Icon);


			var pushClass0 = new Button {
				Text = "Directions",
				BorderWidth = 0,
				WidthRequest = 125,
			};

			var pushClass1 = new Button {
				Text = "Website",
				BorderWidth = 0,
				WidthRequest = 125,
			};

			var label0 = new Label {
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "\r" + "Peel Pub",
				VerticalOptions = LayoutOptions.Center
			};

			var x = new StackLayout 
			{ Spacing = 5,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = { label0,pushClass0,pushClass1}
			};



			Content = new StackLayout {
				Children = {
					x


				}
			};


		}
	}
}