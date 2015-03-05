
using Android.Content.PM;
using CocoMaps.Shared;
using System;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace CocoMaps.Android
{
	[Activity (Label = "CocoMaps", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			StartActivity (typeof(ChooseApp));
		}
	}

	[Activity (Label = "CocoMaps", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class ChooseApp : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.Main);

			Button GoogleApp = FindViewById<Button>(Resource.Id.button1);

			Button NormalApp = FindViewById<Button>(Resource.Id.button2);

			GoogleApp.Click += delegate {
				var GoogleAppIntent = new Intent (this, typeof(AppActivity));
				GoogleAppIntent.PutExtra ("AppType", "GoogleEnabled");
				StartActivity (GoogleAppIntent);
			};

			NormalApp.Click += delegate {
				var NormalAppIntent = new Intent (this, typeof(AppActivity));
				NormalAppIntent.PutExtra ("AppType", "GoogleDisabled");
				StartActivity (NormalAppIntent);
			};


		}
	}


}
