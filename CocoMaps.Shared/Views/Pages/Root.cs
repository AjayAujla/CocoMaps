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

			setPage (menuOption);

			menuOption.Selected = true;
			previousItem = menuOption;

			Detail = PageForOption (menuOption);


			IsPresented = false;
		}

		public void setPage(IMenuOptions menuOption)
		{

			int MenuNumber = menuOption.MenuNum;

			switch (MenuNumber)
			{
				case 1:
					if ((pMaster == null)){pMaster = new MasterPage (menuOption);}
					break;
				case 2:
					if ((pMaster == null)){pMaster = new MasterPage (menuOption);}
					break;
				case 3:
					if ((pPOI == null)){pPOI = new BasePOI (menuOption);}
					break;
				case 4:
					if ((pServices == null)){pServices = new ConcordiaServices (menuOption);}
					break;
				case 5:
					if ((pNextClass == null)){pNextClass = new NextClass (menuOption);}
					break;
				case 6:
					if ((pMaster == null)){pMaster = new MasterPage (menuOption);}
					break;
				case 7:
					if ((pMaster == null)){pMaster = new MasterPage (menuOption);}
					break;
				case 8:
					if ((pCalendar == null)){pCalendar = new BaseCalendar (menuOption);}
					break;
				case 9:
					if ((pMaster == null)){pMaster = new MasterPage (menuOption);}
					break;
				default:

					break;
			}

		}

		Page PageForOption (IMenuOptions menuOption)
		{

			if ((menuOption.Title == "Current Location") && (pMaster != null)) {
				return pMaster;
			}
			if ((menuOption.Title == "Campus Maps") && (pMaster != null)) {
				return pMaster;
			}
			if ((menuOption.Title == "Points of Interest") && (pPOI != null)) {
				return pPOI;
			}
			if ((menuOption.Title == "Concordia Services") && (pServices != null)) {
				return pServices;
			}
			if ((menuOption.Title == "Next Class") && (pNextClass != null)) {
				return pNextClass;
			}
			if ((menuOption.Title == "Building Directions") && (pMaster != null)) {
				return pMaster;
			}
			if ((menuOption.Title == "Indoor Directions") && (pMaster != null)) {
				return pMaster;
			}
			if ((menuOption.Title == "Calendar") && (pCalendar != null)) {
				return pCalendar;
			}
			if ((menuOption.Title == "Settings") && (pMaster != null)) {
				return pMaster;
			}
			throw new NotImplementedException ("Unknown menu option: " + menuOption.Title);
		}
	}
}