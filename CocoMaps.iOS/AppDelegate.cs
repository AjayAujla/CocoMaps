using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin;
using Xamarin.Forms.Platform.iOS;
using CocoMaps.Shared;

namespace CocoMaps.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : FormsApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication uiApplication, NSDictionary launchOptions)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			App.ScreenSize.Width = window.Bounds.Width;
			App.ScreenSize.Height = window.Bounds.Height;

			CocoMapsApp.Init (typeof(CocoMapsApp).Assembly);
			Forms.Init ();
			FormsMaps.Init ();

			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes {
				TextColor = UIColor.White
			});

			LoadApplication (new App ());

			return base.FinishedLaunching (uiApplication, launchOptions);
		}
	}
}

