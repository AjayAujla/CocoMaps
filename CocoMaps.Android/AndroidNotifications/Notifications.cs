using System;
using Android.App;
using Android.Content;
using Android.OS;
using Java.Lang;
using CocoMaps.Shared;
using System.Collections.Generic;



namespace CocoMaps.Android
{
	[Activity(Label = "Notifications", MainLauncher = false, Icon = "@drawable/Icon")]
	public class Notifications : Activity
	{

		private static readonly int notificationId = 1000;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//getDayOfWeek
			//getCalendarList for that day
			//for each item in calendarList call nextClassNotification(className)
			foreach ( CalendarItems c in BaseCalendar.MondayCalItems){

			}

			this.Finish ();

		}

		public void nextClassNotification()
		{
			// Create the PendingIntent with the back stack             
			// When the user clicks the notification, SecondActivity will start up.
			Intent startCocoMaps = new Intent(this, typeof(MainActivity));

			TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
			stackBuilder.AddParentStack(Class.FromType(typeof(MainActivity)));
			stackBuilder.AddNextIntent(startCocoMaps);

			PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

			// Build the notification
			Notification.Builder builder = new Notification.Builder(this)
				.SetAutoCancel(true) // dismiss the notification from the notification area when the user clicks on it
				.SetContentIntent(resultPendingIntent) // start up this activity when the user clicks the intent.
				.SetContentTitle("You have a class starting soon") // Set the title
				.SetSmallIcon(Resource.Drawable.splash) // This is the icon to display
				.SetDefaults(NotificationDefaults.Vibrate)
				.SetContentText("Your next class will be starting in 15 minutes"); // the message to display.

			// Publish the notification
			NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify(notificationId, builder.Build());

			//Create Notification Intent
			var notificationIntent = new Intent (this, typeof(Notifications));

			TaskStackBuilder notificationBuilder = TaskStackBuilder.Create(this);
			stackBuilder.AddNextIntent(notificationIntent);

			PendingIntent notificationPendingIntent = notificationBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

			AlarmManager alarmManager = (AlarmManager)GetSystemService (Context.AlarmService);
			alarmManager.SetExact(AlarmType.RtcWakeup, CalendarStartTime - 15, notificationPendingIntent);

		}

	}
		
}

