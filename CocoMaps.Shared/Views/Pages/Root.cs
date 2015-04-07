using System.Linq;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class RootPage : MasterDetailPage
	{
		RootPage RP_Map;
		RootPage RP_IndoorMap;
		RootPage RP_Services;
		RootPage RP_Bookmarks;
		RootPage RP_Calendar;
		RootPage RP_ShuttleBus;
		RootPage RP_ShuttleBusTracker;
		RootPage RP_Settings;
		RootPage RP_FAQ;

		MasterPage pMaster;
		IndoorMapPage pIndoorMap;
		ConcordiaServices pServices;
		Bookmark pBookmark;
		CalendarConnect pCalendar;
		BaseShuttleBus pShuttleBus;
		ShuttleBusTracker pShuttleBusTracker;
		Settings pSettings;
		FAQ pFAQ;

		MenuPage MP_Options = new MenuPage { Icon = "settings.png", Title = "menu" };

		public RootPage()
		{

		}

		public RootPage(Page MP_Content)
		{
			Master = MP_Options;

			Detail = MP_Content;

			SetValue (Page.TitleProperty, "Test");
			//SetValue (Page.IconProperty, menuItem.Icon);

			MP_Options.Menu.ItemSelected += (sender, e) => 
			{
				processRootPage(e.SelectedItem as IMenuOptions);
			};
		}


		public void processRootPage(IMenuOptions menuOption)
		{
			string pageTitle = menuOption.Title;

			if (pageTitle.Equals ("Indoor Directions")) 
			{
				if ((RP_IndoorMap == null)) 
				{
					if ((pIndoorMap == null)) 
					{
						pIndoorMap = new IndoorMapPage (menuOption);
					}

					RP_IndoorMap = new RootPage (pIndoorMap);
				}

				Navigation.PushModalAsync (RP_IndoorMap);

			}
			else if (pageTitle.Equals ("Calendar")) 
			{
				if ((RP_Calendar == null)) 
				{
					if ((pCalendar == null)) 
					{
						pCalendar = new CalendarConnect (menuOption);
					}

					RP_Calendar = new RootPage (pCalendar);
				}

				Navigation.PushModalAsync (RP_Calendar);

			}
			else if (pageTitle.Equals ("Settings")) 
			{
				if ((RP_Settings == null)) 
				{
					if ((pSettings == null)) 
					{
						pSettings = new Settings (menuOption);
					}

					RP_Settings = new RootPage (pSettings);
				}

				Navigation.PushModalAsync (RP_Settings);

			}
			else if (pageTitle.Equals ("Shuttle Bus Tracker")) 
			{
				if ((RP_ShuttleBusTracker == null)) 
				{
					if ((pShuttleBusTracker == null)) 
					{
						pShuttleBusTracker = new ShuttleBusTracker (menuOption);
					}

					RP_ShuttleBusTracker = new RootPage (pShuttleBusTracker);
				}

				Navigation.PushModalAsync (RP_ShuttleBusTracker);

			}
			else if (pageTitle.Equals ("Bookmarks")) 
			{
				if ((RP_Bookmarks == null)) 
				{
					if (pBookmark ==null) 
					{
						pBookmark = new Bookmark (menuOption);
					}

					RP_Bookmarks = new RootPage (pBookmark);
				}

				Navigation.PushModalAsync (RP_Bookmarks);

			} 
			else if (pageTitle.Equals ("Shuttle Bus")) 
			{
				if ((RP_ShuttleBus == null)) 
				{
					if ((pShuttleBus == null)) 
					{
						pShuttleBus = new BaseShuttleBus (menuOption);
					}

					RP_ShuttleBus = new RootPage (pShuttleBus);
				}

				Navigation.PushModalAsync (RP_ShuttleBus);

			} 
			else if (pageTitle.Equals ("FAQ"))
			{
				if ((RP_FAQ == null)) 
				{
					if ((pFAQ == null)) 
					{
						pFAQ = new FAQ (menuOption);
					}

					RP_FAQ = new RootPage (pFAQ);
				}

				Navigation.PushModalAsync (RP_FAQ);

			} 
			else if (pageTitle.Equals ("Concordia Services")) 
			{
				if ((RP_Services == null)) 
				{
					if ((pServices == null)) 
					{
						pServices = new ConcordiaServices (menuOption);
					}

					RP_Services = new RootPage (pServices);
				}

				Navigation.PushModalAsync (RP_Services);

			} 
			else if (pageTitle.Equals ("Exit Application")) 
			{
				System.Environment.Exit (0);
			} 
			else 
			{
				Navigation.PushModalAsync (pushMasterPage());
			}
		}

		public Page pushMasterPage()
		{
			if ((RP_Map == null)) 
			{
				if ((pMaster == null)) 
				{
					pMaster = new MasterPage ();
				}

				RP_Map = new RootPage (pMaster);
			}

			return RP_Map;
		}

	}
}