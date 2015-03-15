using Xamarin.Forms;

namespace CocoMaps.Shared
{
	public class AuthBasePage : TabbedPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!App.Instance.IsAuthenticated) {
				Navigation.PushModalAsync (new AuthLoginPage ());
			}

			
		}
	}
}

