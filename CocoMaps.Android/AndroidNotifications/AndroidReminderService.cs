using System;
using Android.Content;
using Android.App;
using Xamarin.Forms;
using Android.OS;
using CocoMaps.Shared;

namespace CocoMaps.Android
{
	public class AndroidReminderService
	{
		public AndroidReminderService ()
		{
		}

		public void Remind (DateTime dateTime, string title, string message)
		{
			Intent alarmIntent = new Intent (Forms.Context, typeof(AlarmReceiver));
			alarmIntent.PutExtra ("message", message);
			alarmIntent.PutExtra ("title", title);

			PendingIntent pendingIntent = PendingIntent.GetBroadcast (Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
			AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService (Context.AlarmService);

			var dateTimeHour = (long)dateTime.Hour;
			var dateTimeMinute = (long)dateTime.Minute;
			var dateTimeTotalMinutes = dateTimeHour * 60 + dateTimeMinute;
			var dateTimeTrigger = dateTimeTotalMinutes * 100000;

			var dateNow = DateTime.Now;

			alarmManager.Set (AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + 5 * 1000, pendingIntent);
		}

		public static void alarmManagerCreationForNotificationOfCurrentDay (AndroidReminderService a, DateTime dateNow, DayOfWeek today, TimeSpan earlyNotice)
		{
			switch (today) {
			case DayOfWeek.Monday:
				foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
					if (BaseCalendar.MondayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Tuesday:
				foreach (CalendarItems c in BaseCalendar.TuesdayCalItems) {
					if (BaseCalendar.TuesdayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Wednesday:
				foreach (CalendarItems c in BaseCalendar.WednesdayCalItems) {
					if (BaseCalendar.WednesdayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Thursday:
				foreach (CalendarItems c in BaseCalendar.ThursdayCalItems) {
					if (BaseCalendar.ThursdayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Friday:
				foreach (CalendarItems c in BaseCalendar.FridayCalItems) {
					if (BaseCalendar.FridayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Saturday:
				foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
					if (BaseCalendar.MondayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			case DayOfWeek.Sunday:
				foreach (CalendarItems c in BaseCalendar.MondayCalItems) {
					if (BaseCalendar.MondayCalItems != null) {
						var startingTime = TimeSpan.Parse (c.StartTime);
						var notificationHourMinute = startingTime - earlyNotice;
						var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
						a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
					}
				}
				break;
			}
		}
	}
}