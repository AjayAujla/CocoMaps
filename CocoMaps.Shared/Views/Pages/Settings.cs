using System;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms;
using CocoMaps.Android;
using CocoMaps.Shared;

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
			var soundCell = new SwitchCell {
				Text = "Sound"
			};
			var vibrationCell = new SwitchCell {
				Text = "Vibration"
			};

			useGoogleMapsCell.OnChanged += (sender, e) => {
				// toggle bool
				useDeviceMap = !useDeviceMap;
				Console.WriteLine ("Use Google Maps? " + useDeviceMap);
			};

			eventNotificationCell.OnChanged += (sender, e) => {
				AlarmReceiver.notificationFlag = !AlarmReceiver.notificationFlag;

				if( AlarmReceiver.notificationFlag == true){

					AndroidReminderService a = new AndroidReminderService ();
					var dateNow = DateTime.Now;
					var today = dateNow.DayOfWeek;
					var earlyNotice = new TimeSpan (0, 15, 0);


					AndroidReminderService.setUpAlarmManager (a, dateNow, today, earlyNotice);
				}
			};

			Content = new TableView {
				Root = new TableRoot ("Settings") {
					new TableSection ("Map Settings") {
						useGoogleMapsCell,
						eventNotificationCell,
					},
					new TableSection ("Alerts and Notifications") {
							vibrationCell,
							soundCell,
						},


				}
			};
		}
	}
}
