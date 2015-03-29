using CocoMaps.Shared.ViewModels;
using Xamarin.Forms;
using System;

namespace CocoMaps.Shared
{
	public class FAQ : ContentPage
	{
		public FAQ (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, menuItem.Title);
			SetValue (Page.IconProperty, menuItem.Icon);
		}
	}
}