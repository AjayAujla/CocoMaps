using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

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
				new BookmarkItems ("SGW-EV", "1515 St. Catherine W., Montreal", new Position (45.48939, -73.57788), "ic_menu_bookmark"),
				new BookmarkItems ("SGW-FG", "1616 Rue Sainte-Catherine Ouest, Montreal", new Position (45.46945, -73.60376), "ic_menu_bookmark"),
				new BookmarkItems ("SGW-CB", "1425 René Lévesque W., Montreal", new Position (45.496426, -73.577896), "fav_icon"),
				new BookmarkItems ("LOY-GE", "7141 Sherbrooke W., Montreal", new Position (45.45837, -73.63822), "fav_icon"),
				new BookmarkItems ("LOY-RF", "7141 Sherbrooke W., Montreal", new Position (45.4688, -73.60512), "fav_icon"),
			};

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

					Image icon = new Image ();
					icon.SetBinding (Image.SourceProperty, "IconSource");

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

			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				Children = {
					listView
				}
			};

			PopulateAndDisplayDatabase ();

			listView.ItemSelected += HandleItemSelected;
		}

		async void HandleItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			BookmarkItems eBookmark = e.SelectedItem as BookmarkItems;

			var BookmarksClickedInput = await DisplayActionSheet (eBookmark.bName, "Cancel", null, "Delete Bookmark", "Get Directions");

			if (BookmarksClickedInput.Equals ("Delete Bookmark")) {
				//Delete Bookmark code
			} 
			if (BookmarksClickedInput.Equals ("Get Directions")) {

				var BookmarksNameInput = "Get Directions To : " + eBookmark.bName;
				string BookmarkDetails = "Destination : " + "\r\n\r\n" + eBookmark.bAddress + "\r\n";
				var BookmarksInput = await DisplayAlert (BookmarksNameInput, BookmarkDetails, "Proceed", "Cancel");

				if (BookmarksInput) {
					DependencyService.Get<IPhoneService> ().LaunchMap (eBookmark.bAddress);
				}
			}
			((ListView)sender).SelectedItem = null; 
		}

		void PopulateAndDisplayDatabase ()
		{
			Console.WriteLine ("PopulateAndDisplayDatabase");
			BookmarksRepository bookmarksRepository = new BookmarksRepository ();


			bookmarksRepository.CreateTable ();

			foreach (var bookmark in BookMitems) {
				bookmarksRepository.SaveBookmark (bookmark);
			}
			Console.WriteLine ("After saving 5 bookmarks " + bookmarksRepository.NumberOfBookmarks ());

			bookmarksRepository.GetAllBookmarks ();

			Console.WriteLine ("Before deleting 5 bookmarks " + bookmarksRepository.NumberOfBookmarks ());


			//bookmarksRepository.DeleteAllBookmarks ();

			Console.WriteLine ("After deleting 5 bookmarks ");

			bookmarksRepository.GetAllBookmarks ();

			//bookmarksRepository.BookmarksTable.Close ();

		}
	}
}

#endif