using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin;
using CocoMaps.Shared.Pages;
using CocoMaps;
using Android.Graphics.Drawables;
using Android.Content.PM;


namespace CocoMaps
{
	[Activity (Label = "CocoMaps", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			StartActivity (typeof(MainActivity));
		}
	}

	[Activity (Label = "CocoMaps", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Forms.Init (this, bundle);
			FormsMaps.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}