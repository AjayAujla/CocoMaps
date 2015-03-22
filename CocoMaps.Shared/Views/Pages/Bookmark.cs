﻿using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;

#if __ANDROID__
using Android.Provider;

namespace CocoMaps.Shared
{
	public class Bookmark : ContentPage
	{
		// TEST - will have to be updated with the actual bokmarks list after

		public static List<BookmarkItems> BookMitems = new List<BookmarkItems>{ };

		// public Bookmark (IMenuOptions menuItem, List<BookmarkItems> BookMitems)

		public Bookmark (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Bookmarks");
			this.SetValue (Page.IconProperty, menuItem.Icon);


			// Sets Temporary List

			BookMitems = new List<BookmarkItems> {
				new BookmarkItems ("SGW-EV", "1515 St. Catherine W., Montreal", 45.496426, -73.577896, "fav_icon"),
				new BookmarkItems ("SGW-FG", "1616 Rue Sainte-Catherine Ouest, Montreal", 45.496426, -73.577896, "fav_icon"),
				new BookmarkItems ("SGW-CB", "1425 René Lévesque W., Montreal", 45.496426, -73.577896, "fav_icon"),
				new BookmarkItems ("LOY-GE", "7141 Sherbrooke W., Montreal", 45.496426, -73.577896, "fav_icon"),
				new BookmarkItems ("LOY-RF", "7141 Sherbrooke W., Montreal", 45.496426, -73.577896, "fav_icon"),
				// ...etc.,...
			};


			// Create the ListView.
			ListView listView = new ListView {
				// Source of data items.
				ItemsSource = BookMitems,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate (() => {
					// Create views with bindings for displaying each property.
					Label t1Label = new Label ();
					t1Label.SetBinding (Label.TextProperty, "bName");

					Label t2Label = new Label ();
					t2Label.SetBinding (Label.TextProperty, "bAddress");

					Image icon = new Image();
					icon.SetBinding(Image.SourceProperty, "IconSource");


					// Return an assembled ViewCell.
					return new ViewCell {
						View = new StackLayout {
							Padding = new Thickness (0, 5),
							Orientation = StackOrientation.Horizontal,
							Children = {
								icon,
								new StackLayout {
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,
									Children = {
										t1Label,
										t2Label,

									}
								}
							}
						}
					};
				})
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				Children = {
					listView
				}
			};

			listView.ItemSelected += async (sender, e) => 
			{
				if (e.SelectedItem == null) return;

				BookmarkItems eBookmark = e.SelectedItem as BookmarkItems;

				string BookmarkDetails = "Bookmark : " + "\r\n\r\n" + eBookmark.bName + "\r\n\r\n" + "Destination : " + "\r\n\r\n" + eBookmark.bAddress + "\r\n";

				var BookmarksClickedInput = await DisplayActionSheet (eBookmark.bName, "Cancel", null, "Delete Bookmark", "Get Directions");

				if (BookmarksClickedInput.Equals ("Cancel")) 
				{
					// Do Nothing
				}
				else if(BookmarksClickedInput.Equals ("Delete Bookmark"))
				{
					//Delete Bookmark code
				}
				else if(BookmarksClickedInput.Equals ("Get Directions"))
				{
					var BookmarksInput = await DisplayAlert ("Get Directions To Bookmark", BookmarkDetails, "Cancel", "Proceed");

					if (BookmarksInput.ToString ().ToLower () == "false") 
					{
						DependencyService.Get<IPhoneService> ().LaunchMap (eBookmark.bAddress);
					} 
					else 
					{
						// Cancel- Do Nothing
					}
				}
				else
				{
					//Do Nothing
				}


				((ListView)sender).SelectedItem = null; 
			};

		}
	}
}

#endif