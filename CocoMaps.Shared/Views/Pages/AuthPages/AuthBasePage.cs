using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared.Pages;


namespace CocoMaps.Shared
{
	public class AuthBasePage : TabbedPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsAuthenticated)
			{
				Navigation.PushModalAsync (new AuthLoginPage ());
			}

			
		}
	}
}

