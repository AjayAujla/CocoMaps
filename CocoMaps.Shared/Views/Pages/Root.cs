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

		// Initialize Pages
		MasterPage pMaster = null;
		BasePOI pPOI = null;
		ConcordiaServices pServices = null;
		NextClass pNextClass = null;
		BaseCalendar pCalendar = null;
		BaseShuttleBus pShuttleBus = null;
		CalendarConnect pConnect = null;


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

			Detail = setPage (menuOption);

			IsPresented = false;
		}

		public Page setPage (IMenuOptions menuOption)
		{

			int MenuNumber = menuOption.MenuNum;

			switch (MenuNumber) {
			case 1:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			case 2:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			case 3:
				if ((pPOI == null)) {
					pPOI = new BasePOI (menuOption);
				}
				return pPOI;
			case 4:
				if ((pServices == null)) {
					pServices = new ConcordiaServices (menuOption);
				}
				return pServices;
			case 5:
				if ((pNextClass == null)) {
					pNextClass = new NextClass (menuOption);
				}
				return pNextClass;
			case 6:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			case 7:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			case 8:
				if ((pCalendar == null)) {
					pCalendar = new BaseCalendar (menuOption);
				}
				return  pCalendar;
			case 9:
				if ((pConnect == null)) {
					pConnect = new CalendarConnect (menuOption);
				}
				return pConnect;
			case 10:
				if ((pShuttleBus == null)) {
					pShuttleBus = new BaseShuttleBus (menuOption);
				}
				return pShuttleBus;
			default:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			}
		}
	}
}