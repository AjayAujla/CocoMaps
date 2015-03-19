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
				Text = "Event Notifications"
			};

			useGoogleMapsCell.OnChanged += (sender, e) => {
				// toggle bool
				useDeviceMap = !useDeviceMap;
				Console.WriteLine ("Use Google Maps? " + useDeviceMap);
			};

			Content = new TableView {
				Root = new TableRoot ("Settings") {
					new TableSection ("Map Settings") {
						useGoogleMapsCell,
						eventNotificationCell,
					}
				}
			};
		}
	}
}