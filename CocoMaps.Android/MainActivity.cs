using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin;
using Android.Content.PM;
using CocoMaps.Shared;
using Android.Content;

namespace CocoMaps.Android
{
	[Activity (Label = "CocoMaps", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			StartActivity (typeof(MainActivity));
		}
	}


	[Activity (Label = "CocoMaps", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
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

			SetPage (App.Instance.GetMainPage ());

		}

		/*public override void OnBackPressed()
		{
			AlertDialog.Builder CloseAlert = new AlertDialog.Builder (this);

			CloseAlert.SetTitle ("Close CocoMaps ?");

			CloseAlert.SetPositiveButton ("Yes", OkClicked);

			CloseAlert.SetNegativeButton ("No", CancelClicked);

			RunOnUiThread (() => 
			{
				CloseAlert.Show ();
			});

		}

		
		private void OkClicked (object sender, DialogClickEventArgs e)
		{
			Finish();	
		}

		private void CancelClicked (object sender, DialogClickEventArgs e)
		{
			//Do Nothing
		}
		*/

	}

}