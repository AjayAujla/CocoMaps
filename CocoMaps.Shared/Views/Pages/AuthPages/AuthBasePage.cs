using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared.Pages;


namespace CocoMaps.Shared
{
	public class AuthBasePage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsAuthenticated && App.Instance.IsGoogleEnabled)
			{
				Navigation.PushModalAsync (new AuthLoginPage ());
			}

			
		}
	}
}

