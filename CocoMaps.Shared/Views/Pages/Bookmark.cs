using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Collections;

#if __ANDROID__
using Android.Provider;

namespace CocoMaps.Shared
{
	public class Bookmark : ContentPage
	{
		ListView listView;

		BookmarksRepository bookmarksRepository = new BookmarksRepository ();
		static IEnumerable<BookmarkItems> BookMitems = new List<BookmarkItems> ();

		public Bookmark (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Bookmarks");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			BookMitems = PopulateDatabase ();

			listView = new ListView {

				// Source of data items.
				ItemsSource = BookMitems,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate (() => {

					// Create views with bindings for displaying each property.
					Label nameLabel = new Label ();
					nameLabel.SetBinding (Label.TextProperty, "bName");

					Label addressLabel = new Label ();
					addressLabel.SetBinding (Label.TextProperty, "bAddress");

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
										nameLabel,
										addressLabel,
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
			listView.ItemSelected += HandleItemSelected;
		}

		async void HandleItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				BookmarkItems eBookmark = e.SelectedItem as BookmarkItems;
				int totalNumberOfBookmarks = bookmarksRepository.NumberOfBookmarks ();

				var BookmarksClickedInput = await DisplayActionSheet (eBookmark.bName, "Cancel", null, "Get Directions", "Update Bookmark", "Delete Bookmark", "Delete All Bookmarks");

				if (BookmarksClickedInput.Equals ("Get Directions")) {

					var BookmarksNameInput = "Get Directions To : " + eBookmark.bName;
					string BookmarkDetails = "Destination : " + "\r\n\r\n" + eBookmark.bAddress + "\r\n";
					var BookmarksInput = await DisplayAlert (BookmarksNameInput, BookmarkDetails, "Proceed", "Cancel");

					if (BookmarksInput) {
						DependencyService.Get<IPhoneService> ().LaunchMap (eBookmark.bAddress);
					}
				}
				if (BookmarksClickedInput.Equals ("Update Bookmark")) {
					/*eBookmark.bName = "abc";
					eBookmark.bAddress = "def";*/
					bookmarksRepository.SaveBookmark (eBookmark);
					await DisplayAlert (eBookmark.bName + " Deleted.", "", "Proceed");
				}
				if (BookmarksClickedInput.Equals ("Delete Bookmark")) {
					var BookmarksInput = await DisplayAlert ("Delete " + eBookmark.bName + " at " + eBookmark.bAddress + "?", "", "Proceed", "Cancel");

					if (BookmarksInput) {
						bookmarksRepository.DeleteBookmark (eBookmark);
						await DisplayAlert (eBookmark.bName + " Deleted.", "", "Proceed");
					}
				} 
				if (BookmarksClickedInput.Equals ("Delete All Bookmarks")) {
					var BookmarksInput = await DisplayAlert ("Delete All Bookmarks?", "All " + totalNumberOfBookmarks + " Bookmarks will be Deleted", "Proceed", "Cancel");

					if (BookmarksInput) {
						bookmarksRepository.DeleteAllBookmarks ();
						await DisplayAlert ("Deleted all bookmarks", "", "Proceed");
					}
				}
				this.listView.ItemsSource = bookmarksRepository.GetAllBookmarks ();
				// de-select the item
				((ListView)sender).SelectedItem = null; 
			}
		}

		IEnumerable<BookmarkItems> PopulateDatabase ()
		{
			bookmarksRepository.CreateTable ();

			/*bookmarksRepository.SaveBookmark (new BookmarkItems ("SGW-EV", "1515 St. Catherine W., Montreal", new Position (45.48939, -73.57788), "ic_menu_bookmark"));
			bookmarksRepository.SaveBookmark (new BookmarkItems ("SGW-FG", "1616 Rue Sainte-Catherine Ouest, Montreal", new Position (45.46945, -73.60376), "ic_menu_bookmark"));
			bookmarksRepository.SaveBookmark (new BookmarkItems ("SGW-CB", "1425 René Lévesque W., Montreal", new Position (45.496426, -73.577896), "fav_icon"));
			bookmarksRepository.SaveBookmark (new BookmarkItems ("LOY-GE", "7141 Sherbrooke W., Montreal", new Position (45.45837, -73.63822), "fav_icon"));
			bookmarksRepository.SaveBookmark (new BookmarkItems ("LOY-RF", "7141 Sherbrooke W., Montreal", new Position (45.4688, -73.60512), "fav_icon"));*/

			return bookmarksRepository.GetAllBookmarks ();
		}
	}
}
#endif