﻿using System;
using Android.Content;
using Android.App;
using Android.Support.V4.App;
using Android.Media;
using Android.Graphics;

namespace CocoMaps.Android
{
	[BroadcastReceiver]
	public class AlarmReceiver : BroadcastReceiver 
	{
		public static bool notificationFlag = false;
		public static bool notificationSoundFlag = false;
		public static bool notificationVibrateFlag = false;

		public override void OnReceive (Context context, Intent intent)
		{
			if (notificationFlag == true) {
				var message = intent.GetStringExtra ("message");
				var title = intent.GetStringExtra ("title");

				var notIntent = new Intent (context, typeof(MainActivity));
				var contentIntent = PendingIntent.GetActivity (context, 0, notIntent, PendingIntentFlags.CancelCurrent);
				var manager = NotificationManagerCompat.From (context);

				var soundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
			
				//Generate a notification with just short text and small icon
				var builder = new NotificationCompat.Builder (context)
							.SetContentIntent (contentIntent)
							.SetSmallIcon (Resource.Drawable.splash)
							.SetContentTitle (title)
							.SetContentText (message)
							.SetWhen (Java.Lang.JavaSystem.CurrentTimeMillis ())
							.SetAutoCancel (true)
							.SetStyle (new NotificationCompat.BigTextStyle ().BigText (message));

				if (notificationSoundFlag == true)
					builder.SetSound(soundUri);

				if (notificationVibrateFlag == true)
					builder.SetVibrate(new long[] {1000, 0, 0, 1000} );


	
			
			
				var notification = builder.Build ();

				manager.Notify (0, notification);
			}
		}
	}
}

