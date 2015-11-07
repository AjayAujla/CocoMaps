using System;
using Xamarin.Forms;
using System.Collections.Generic;
using CocoMaps.Shared.CustomViews;

namespace CocoMaps.Shared
{
	public class MenuPage : ContentPage
	{
		readonly List<IMenuOptions> OptionItems = new List<IMenuOptions> ();

		public ListView Menu { get; set; }

		public RelativeLayout layout = new RelativeLayout ();

		public MenuPage ()
		{
			OptionItems.Add (new Campus_MenuOption ());
			OptionItems.Add (new IndoorDirections_MenuOption ());
			OptionItems.Add (new ConcordiaServices_MenuOption ());
			OptionItems.Add (new Bookmarks_MenuOption ());
			OptionItems.Add (new Calendar_MenuOption ());
			OptionItems.Add (new ShuttleBus_MenuOption ());
			OptionItems.Add (new ShuttleBusTracker_MenuOption ());
			OptionItems.Add (new Settings_MenuOption ());
//			OptionItems.Add (new FAQ_MenuOption ());
			OptionItems.Add (new Exit_MenuOption ());

			BackgroundColor = Helpers.Color.DarkGray.ToFormsColor ();


			Image sidebarSlideImage = new Image {
				Source = ImageSource.FromFile ("sidebar_slide.png")
			};

			var label = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					TextColor = Color.FromHex ("AAAAAA"),
					Text = "MENU",
				}
			};

			layout.Children.Add (label, 
				Constraint.Constant (0), 
				Constraint.Constant (0));

			Menu = new ListView {
				ItemsSource = OptionItems,
				BackgroundColor = Color.Transparent,
			};

			var cell = new DataTemplate (typeof(DarkTextCell));
			cell.SetBinding (TextCell.TextProperty, "Title");
			cell.SetBinding (TextCell.DetailProperty, "Count");
			cell.SetBinding (ImageCell.ImageSourceProperty, "IconSource");
			cell.SetValue (VisualElement.BackgroundColorProperty, Color.Transparent);

			Menu.ItemTemplate = cell;

			sidebarSlideImage.Rotation = 180;
			layout.Children.Add (sidebarSlideImage,
				Constraint.RelativeToParent (parent => Width - 25),
				Constraint.RelativeToParent (parent => Height / 2 - 50)
			);

			layout.Children.Add (Menu, 
				Constraint.Constant (0), 
				Constraint.RelativeToView (label, (parent, sibling) => sibling.Y + sibling.Height + 5),
				Constraint.RelativeToParent (parent => Width), 
				Constraint.RelativeToParent (parent => Height - label.Y - 100));

			Content = layout;
		}
	}
}