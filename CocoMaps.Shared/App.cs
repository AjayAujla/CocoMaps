﻿using System;
using Xamarin.Forms;
using Android.OS;
using CocoMaps.Services;
using System.Threading.Tasks;

namespace CocoMaps.Shared
{
	public class App : Application
	{
		public static Size ScreenSize;
		public static Size ScreenPixels;
		public static int StatusBarHeight = 25;

		static volatile App appInstance;

		static object syncApp = new Object ();

		NavigationPage NavPage;
		string _Token;

		public static App Instance {
			get {
				if (appInstance == null) {
					lock (syncApp) {
						if (appInstance == null) {
							appInstance = new App ();

							appInstance.OAuthSettings = 
								new OAuthSettings (
								clientId: "189708382965-8e2o6rtnvihkd40fn54elflfdrmrpemf.apps.googleusercontent.com", 
								scope: "https://www.googleapis.com/auth/calendar",  		
								authorizeUrl: "https://accounts.google.com/o/oauth2/auth",  	
								redirectUrl: "https://www.google.com/oauth2callback");   
						}
					}
				}

				return appInstance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }


		public Page GetMainPage ()
		{
			RootPage RP = new RootPage();

			var MainPage = RP.pushMasterPage();

			NavPage = new NavigationPage (MainPage);

			return NavPage;
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace (_Token); }
		}

		public string Token {
			get { return _Token; }
		}

		public void SaveToken (string token)
		{
			_Token = token;

			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction {
			get {
				return new Action (() => NavPage.Navigation.PopModalAsync ());
			}
		}

		public static bool isConnected ()
		{
			return DependencyService.Get<INetwork> ().InternetConnectionStatus () != NetworkStatus.NotReachable;
		}

		public static bool isHostReachable (String host)
		{
			return DependencyService.Get<INetwork> ().IsReachable (host, new TimeSpan (5)).Result;
		}

		async public static Task<Xamarin.Forms.Maps.Position> GetCurrentPosition ()
		{
			IGeolocator geolocator = null;
			Xamarin.Forms.Maps.Position currentPosition;
			Position pos = null;

			if (geolocator == null) {
				geolocator = DependencyService.Get<IGeolocator> ();
				geolocator.StartListening (100, 100);
				pos = await geolocator.GetPositionAsync (10);
				geolocator.StopListening ();
			}

			// Converting current position to Xamarin.Forms' Position, since all our method use this one
			currentPosition = new Xamarin.Forms.Maps.Position (pos.Latitude, pos.Longitude);

			return currentPosition;
			
		}

		public static void CloseApp ()
		{
			System.Environment.Exit (0);
		}


	}
}