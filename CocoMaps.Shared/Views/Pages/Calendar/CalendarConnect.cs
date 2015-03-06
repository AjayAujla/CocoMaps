using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace CocoMaps.Shared
{
	public class CalendarConnect : ContentPage
	{

		//CalendarService Cal;

		OAuthSettings tok = App.Instance.OAuthSettings;

		public CalendarConnect (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Next Class");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			//var Cal = new Google.Apis.Calendar.v3.CalendarService (tok);

			string tok = App.Instance.Token;

			Label label1 = new Label
			{
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Token : "
			};

			Label label2 = new Label
			{
				Text = tok + "\r\n \r\n",

				Font = Font.SystemFontOfSize(NamedSize.Large)
			};

			this.Content = new StackLayout
			{
				Children =
				{
					label1,
					label2,
				}
				};

		}
	}
}

