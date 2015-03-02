using Xamarin.Forms;
using Xamarin;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class App : Application
	{
		public static Size ScreenSize;
		public static Size ScreenPixels;
		public static int StatusBarHeight = 25;

		public App ()
		{
			MainPage = new RootPage ();

			//DependencyService.Get<ITextToSpeech> ().Speak ("Welcome to CocoMaps");

		}

		public static bool isConnected ()
		{
			if (DependencyService.Get<INetwork> ().InternetConnectionStatus () == NetworkStatus.NotReachable)
				return false;
			return true;
		}

	}
}