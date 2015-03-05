using Xamarin.Forms;
using Xamarin;
using CocoMaps.Shared.Pages;
using System;

namespace CocoMaps.Shared
{
	public class App : Application
	{
		public static Size ScreenSize;
		public static Size ScreenPixels;
		public static int StatusBarHeight = 25;

		static volatile App appInstance;

		static object syncApp = new Object();

		NavigationPage NavPage;
		string _Token;

		Boolean GoogleEnabled = false;

		public static App Instance
		{
			get 
			{
				if (appInstance == null) 
				{
					lock (syncApp) 
					{
						if (appInstance == null) {
							appInstance = new App ();

							//if (GoogleEnabled) 
							//{
								appInstance.OAuthSettings = 
									new OAuthSettings (
										clientId: "189708382965-8e2o6rtnvihkd40fn54elflfdrmrpemf.apps.googleusercontent.com", 
										scope: "https://www.googleapis.com/auth/calendar",  		
										authorizeUrl: "https://accounts.google.com/o/oauth2/auth",  	
										redirectUrl: "https://www.google.com/oauth2callback");
							//}   
						}
					}
				}

				return appInstance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

		public void setGoogleEnabled(bool value)
		{
			GoogleEnabled = value;
		}

		public Page GetMainPage ()
		{

			var MainPage = new AuthMainPage();

			NavPage = new NavigationPage(MainPage);

			return NavPage;
		}

		public bool IsGoogleEnabled {
			get { return GoogleEnabled; }
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		public string Token {
			get { return _Token; }
		}

		public void SaveToken(string token)
		{
			_Token = token;

			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => NavPage.Navigation.PopModalAsync ());
			}
		}

		public static bool isConnected ()
		{
			if (DependencyService.Get<INetwork> ().InternetConnectionStatus () == NetworkStatus.NotReachable)
				return false;
			return true;
		}

	}
}