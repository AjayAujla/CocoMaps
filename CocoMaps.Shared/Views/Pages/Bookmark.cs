using Xamarin.Forms;
using CocoMaps.Shared;

namespace CocoMaps.Shared.Pages
{
	public class Bookmark : ContentPage
	{

		Button directionButton;
		Button deleteButton;

		public Bookmark (IMenuOptions menuItem)
		{
		
			this.SetValue (Page.TitleProperty, "Bookmark");
			this.SetValue (Page.IconProperty, menuItem.Icon);
		
	

			// Buttons
			this.directionButton = new Button {
				Text = "Directions",
				BorderWidth = 0,
				WidthRequest = 50,
				//HorizontalOptions = LayoutOptions.Start,
			};
	

			this.deleteButton = new Button {
				Text = "Website",
				BorderWidth = 0,
				WidthRequest = 50,
				//HorizontalOptions = LayoutOptions.End,
			};
	

		}

	}
}
