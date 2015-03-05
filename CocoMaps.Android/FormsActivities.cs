using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin;
using Android.Content.PM;
using CocoMaps.Shared;

namespace CocoMaps.Android
{
	[Activity (Label = "CocoMaps", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class AppActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{

			App.ScreenSize = new Size (
				Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density,
				Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);

			App.ScreenPixels = new Size (
				Resources.DisplayMetrics.WidthPixels,
				Resources.DisplayMetrics.HeightPixels);

			base.OnCreate (savedInstanceState);
			Forms.Init (this, savedInstanceState);
			FormsMaps.Init (this, savedInstanceState);

			string AppType = Intent.GetStringExtra ("AppType");

			if (AppType == "GoogleDisabled") 
			{
				SetPage (App.Instance.GetGoogleDisabledPage());
			} 
			else if (AppType == "GoogleEnabled") 
			{
				SetPage (App.Instance.GetGoogleEnabledPage());
			}
				

		}

	}
}

