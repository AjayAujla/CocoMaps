using Xamarin.Forms;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class Bookmark : ContentPage
	{

		//Button directionButton;
		//Button deleteButton;

		public Bookmark (IMenuOptions menuItem)
		{
		
			this.SetValue (Page.TitleProperty, "Bookmark");
			this.SetValue (Page.IconProperty, menuItem.Icon);
		
	

			// Buttons
			/*this.directionButton = new Button {
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
			}; */

			var GetDirectionButton = new Button { Text = "Direction" };

			var pushClass0 = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal, 
				Children = { GetDirectionButton }
			};

			var DeleteButton = new Button { Text = "Delete" };

			var pushClass1 = new StackLayout {
				Spacing = 5,
				HorizontalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal, 
				Children = { DeleteButton }
			};

			var label0 = new Label {
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Peel Pub"
			};

		

		Content = new StackLayout {
			Children = {
				label0,
				pushClass0,
				pushClass1


			}
		};


		}
	}
}
