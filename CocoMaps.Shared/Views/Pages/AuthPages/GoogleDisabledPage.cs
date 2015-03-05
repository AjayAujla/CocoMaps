using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class GoogleDisabledPage : gBasePage
	{

		public GoogleDisabledPage (Boolean bbb)
		{

			if(bbb == true)
			{
				MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => {
					Navigation.PushModalAsync (new RootPage ());
				});
			}
			else
			{
				Navigation.PushModalAsync (new RootPage ());
			}
		}
		/*
		public GoogleDisabledPage ()
		{

			MessagingCenter.Subscribe<App> (this, "GoogleDisabled", (senderr) => {
				Navigation.PushModalAsync (new RootPage ());
			});
		}*/
	}
}


