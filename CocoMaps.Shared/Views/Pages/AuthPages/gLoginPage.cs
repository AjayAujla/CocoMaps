using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class gLoginPage : ContentPage
	{
		public gLoginPage()
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Google Login Page");
			//this.SetValue (Page.IconProperty, menuItem.Icon);
		}
	}
}

