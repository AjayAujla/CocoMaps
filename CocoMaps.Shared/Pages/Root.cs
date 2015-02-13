using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Models;


namespace CocoMaps.Shared.Pages
{
	public class RootPage : MasterDetailPage
	{
		IMenuOptions previousItem;

		public RootPage ()
		{
			var optionsPage = new MenuPage { Icon = "settings.png", Title = "menu" };

			optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as IMenuOptions);

			Master = optionsPage;

			NavigateTo (optionsPage.Menu.ItemsSource.Cast<IMenuOptions> ().First ());

		}

		void NavigateTo (IMenuOptions menuOption)
		{
			if (previousItem != null)
				previousItem.Selected = false;

			menuOption.Selected = true;
			previousItem = menuOption;

			var displayPage = PageForOption (menuOption);

			#if WINDOWS_PHONE
			Detail = new ContentPage();//work around to clear current page.
			#endif
			Detail = new NavigationPage (displayPage) {
				BarBackgroundColor = Helpers.Color.Maroon.ToFormsColor (),
			};


			IsPresented = false;
		}

		Page PageForOption (IMenuOptions menuOption)
		{
			// TODO: Refactor this to the Builder pattern (see ICellFactory).
			if (menuOption.Title == "Current Location") {
				return new MasterPage (menuOption);
			}
			if (menuOption.Title == "Campus Maps") {
				return new MasterPage (menuOption);
			}
			if (menuOption.Title == "Points of Interest") {
				return new MasterPage (menuOption);
			}
			if (menuOption.Title == "Concordia Services") {
				return new ConcordiaServices (menuOption);
			}
			if (menuOption.Title == "Building Directions") {
				return new MasterPage (menuOption);
			}
			if (menuOption.Title == "Indoor Directions") {
				return new MasterPage (menuOption);
			}
			if (menuOption.Title == "Calendar") {
				return new Calendar (menuOption);
			}
			if (menuOption.Title == "Settings") {
				return new MasterPage (menuOption);
			}
			throw new NotImplementedException ("Unknown menu option: " + menuOption.Title);
		}
	}
}