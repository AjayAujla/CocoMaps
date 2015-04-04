using System.Linq;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class RootPage : MasterDetailPage
	{
		IMenuOptions previousItem;

		// Initialize Pages
		MasterPage pMaster;
		ConcordiaServices pServices;
		Bookmark pBookmark;
		//IndoorDirections pIndoorDirections;
		CalendarConnect pCalendar;
		BaseShuttleBus pShuttleBus;
		ShuttleBusTracker pShuttleBusTracker;
		Settings pSettings;
		FAQ pFAQ;

		public RootPage ()
		{
			var optionsPage = new MenuPage { Icon = "settings.png", Title = "menu" };
			optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as IMenuOptions);
			Master = optionsPage;

			NavigateTo (optionsPage.Menu.ItemsSource.Cast<IMenuOptions> ().First ());
		}

		void NavigateTo (IMenuOptions menuOption)
		{
			if (previousItem != null) {
				previousItem.Selected = false;
			}

			menuOption.Selected = true;
			previousItem = menuOption;

			Detail = setPage (menuOption);

			IsPresented = false;
		}

		public Page setPage (IMenuOptions menuOption)
		{
			// Restore the top bar for all pages
			#if __ANDROID__
			Forms.SetTitleBarVisibility (AndroidTitleBarVisibility.Default);
			#endif

			string pageTitle = menuOption.Title;

			if (pageTitle.Equals ("Concordia Services")) {
				if ((pServices == null)) {
					pServices = new ConcordiaServices (menuOption);
				}
				return pServices;
			} 
			if (pageTitle.Equals ("Bookmarks")) {
				pBookmark = new Bookmark (menuOption);
				return pBookmark;
			} else if (pageTitle.Equals ("Calendar")) {
				if ((pCalendar == null)) {
					pCalendar = new CalendarConnect (menuOption);
				}
				return  pCalendar;
			} else if (pageTitle.Equals ("Shuttle Bus")) {
				if ((pShuttleBus == null)) {
					pShuttleBus = new BaseShuttleBus (menuOption);
				}
				return pShuttleBus;
			} else if (pageTitle.Equals ("Shuttle Bus Tracker")) {
				if ((pShuttleBusTracker == null)) {
					pShuttleBusTracker = new ShuttleBusTracker (menuOption);
				}
				return pShuttleBusTracker;
			} else if (pageTitle.Equals ("Settings")) {
				if ((pSettings == null)) {
					pSettings = new Settings (menuOption);
				}
				return pSettings;
			} else if (pageTitle.Equals ("FAQ")) {
				if ((pFAQ == null)) {
					pFAQ = new FAQ (menuOption);
				}
				return pFAQ;
			} else if (pageTitle.Equals ("Exit Application")) {
				/*if (Device.OS == TargetPlatform.Android) {
					App.CloseApp ();
				}
				return null;*/
				System.Environment.Exit (0);
				return null;
			} else { 
				// return the main map page if no other option is found
				/*if (string.IsNullOrEmpty (pageTitle) || pageTitle.Equals ("Campus Maps"))*/
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}

				// Hide top bar for map page only
				#if __ANDROID__
				Forms.SetTitleBarVisibility (AndroidTitleBarVisibility.Never);
				#endif

				//pMaster.SetValue (TitleProperty, pMaster.Title);

				return pMaster;
			}
		}
	}
}