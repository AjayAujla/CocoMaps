using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class NavRootPage : NavRootBasePage
	{
		public NavRootPage ()
		{
			Navigation.PushModalAsync (new RootPage ());
		}
	}
}

