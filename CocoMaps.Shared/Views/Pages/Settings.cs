using System;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms;

namespace CocoMaps.Shared
{
	public class Settings : ContentPage
	{

		// TIP: Use this page for DIY -> http://iosapi.xamarin.com/?link=T%3aXamarin.Forms.Cell
		// TO-DO: Save user's preferences in a file on his device

		static public TravelMode TravelMode = TravelMode.walking;

		static public bool useDeviceMap;

		static public int poiRadius = 1000;

		// Google's API Radius Limit is 50,000 meters
		// We restrict our app to 5,000 meters
		const int POI_RADIUS_LIMIT = 5000;

		public Settings (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "Settings");
			SetValue (Page.IconProperty, menuItem.Icon);

			var useGoogleMapsCell = new SwitchCell {
				Text = "Use Google Maps App"
			};

			var eventNotificationCell = new SwitchCell {
				Text = "Even Notifications"
			};

			useGoogleMapsCell.OnChanged += (sender, e) => {
				// toggle bool
				useDeviceMap = !useDeviceMap;
				Console.WriteLine ("Use Google Maps? " + useDeviceMap);
			};


			var poiRadiusCell = new EntryCell {
				Label = "Points of Interest Radius in Meters:",
				Placeholder = "meters",
				Text = poiRadius.ToString (),
				Keyboard = Keyboard.Numeric
			};

			poiRadiusCell.Completed += (sender, e) => {
				int radius;
				if (Int32.TryParse (poiRadiusCell.Text, out radius)) {
					if (radius <= 0) // negative value
						DisplayAlert ("Heads Up!", "Radius can't be negative or zero...", "OK");
					else if (radius > 0 && radius <= POI_RADIUS_LIMIT) // valid range
						poiRadius = radius;
					else // greater than 5,000 meters
						DisplayAlert ("Heads Up!", "Maximum radius is " + POI_RADIUS_LIMIT + " meters", "OK");
				}
				poiRadiusCell.Text = poiRadius.ToString ();
			};

			Content = new TableView {
				Root = new TableRoot ("Settings") {
					new TableSection ("Map Settings") {
						useGoogleMapsCell,
						eventNotificationCell,
						poiRadiusCell
					}
				}
			};
		}
	}
}