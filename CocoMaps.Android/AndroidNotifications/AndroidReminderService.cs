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

			//TODO: For demo set after 5 seconds.
			alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + 5 * 1000, pendingIntent);
	

		}
			
	}
}

