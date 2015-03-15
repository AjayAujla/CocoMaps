﻿using System.Linq;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;

namespace CocoMaps.Shared
{
	public class RootPage : MasterDetailPage
	{
		IMenuOptions previousItem;

		// Initialize Pages
		MasterPage pMaster;
		//BasePOI pPOI;
		ConcordiaServices pServices;
		NextClass pNextClass;
		BaseCalendar pCalendar;
		BaseShuttleBus pShuttleBus;
		Settings pSettings;


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
			/*case 3:
				if ((pPOI == null)) {
					pPOI = new BasePOI (menuOption);
				}
				return pPOI; */
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
			case 8:
				if ((pCalendar == null)) {
					pCalendar = new BaseCalendar (menuOption);
				}
				return  pCalendar;
			case 9:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			case 10:
				if ((pShuttleBus == null)) {
					pShuttleBus = new BaseShuttleBus (menuOption);
				}
				return pShuttleBus;
			case 11:
				if ((pSettings == null)) {
					pSettings = new Settings (menuOption);
				}
				return pSettings;
			default:
				if ((pMaster == null)) {
					pMaster = new MasterPage (menuOption);
				}
				return pMaster;
			}
		}
	}
}