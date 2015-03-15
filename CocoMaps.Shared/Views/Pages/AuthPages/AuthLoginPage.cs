using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class AuthLoginPage : ContentPage
	{
		public AuthLoginPage ()
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Google Login Page");
			//this.SetValue (Page.IconProperty, menuItem.Icon);
		}
	}
}

