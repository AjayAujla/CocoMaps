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


					switch (today) {
					case DayOfWeek.Monday:
						foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
							if(BaseCalendar.MondayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Tuesday:
						foreach (CalendarItems c in BaseCalendar.TuesdayCalItems) {
							if(BaseCalendar.TuesdayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Wednesday:
						foreach (CalendarItems c in BaseCalendar.WednesdayCalItems) {
							if(BaseCalendar.WednesdayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Thursday:
						foreach (CalendarItems c in BaseCalendar.ThursdayCalItems) {
							if(BaseCalendar.ThursdayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Friday:
						foreach (CalendarItems c in BaseCalendar.FridayCalItems) {
							if(BaseCalendar.FridayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Saturday:
						foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
							if(BaseCalendar.MondayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					case DayOfWeek.Sunday:
						foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
							if(BaseCalendar.MondayCalItems != null){
								var startingTime = TimeSpan.Parse (c.StartTime);
								var notificationHourMinute = startingTime - earlyNotice;
								var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
								a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
							}
						}
						break;
					}
				}
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