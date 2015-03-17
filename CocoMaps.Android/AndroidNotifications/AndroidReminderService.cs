using System;
using Android.Support.V4.App;
using Android.Content;
using Android.App;
using Xamarin.Forms;
using Android.Graphics;
using Android.OS;

namespace CocoMaps.Android
{
	public class AndroidReminderService 
	{
		public AndroidReminderService ()
		{
		}
			

		public void Remind (DateTime dateTime, string title, string message)
		{

			Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
			alarmIntent.PutExtra ("message", message);
			alarmIntent.PutExtra ("title", title);

			PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
			AlarmManager alarmManager = (AlarmManager) Forms.Context.GetSystemService(Context.AlarmService);

			var dateTimeHour = (long)dateTime.Hour;
			var dateTimeMinute = (long)dateTime.Minute;
			var dateTimeTotalMinutes = dateTimeHour * 60 + dateTimeMinute;
			var dateTimeTrigger = dateTimeTotalMinutes * 100000;

			var dateNow = DateTime.Now;

			/*if (dateTime < dateNow);
			else*/
				alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + 5 * 1000, pendingIntent);
	

		}
			
	}																												
}

