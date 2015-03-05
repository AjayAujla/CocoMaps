using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class AuthMainPage : AuthBasePage
	{
		public AuthMainPage ()
		{

			bool GEnabled = App.Instance.IsGoogleEnabled;

			if(GEnabled)
			{
				MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => 
				{
					Navigation.PushModalAsync (new RootPage ());
				});
			}
			else
			{
				Navigation.PushModalAsync (new RootPage ());
			}
		}
	}
}

