using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class ShuttleBusTracker : ContentPage
	{
		public ShuttleBusTracker (IMenuOptions menuItem)
		{

			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, menuItem.Title);
			SetValue (Page.IconProperty, menuItem.Icon);

			DisplayAlert ("Patience is a vertue", "Let's count sheeps while the page loads shall we.", "Challo!");

			Content = new WebView {
				Source = "http://shuttle.concordia.ca"
			};

		}
	}
}