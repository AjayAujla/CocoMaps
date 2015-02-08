﻿using System;
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

		void NavigateTo (IMenuOptions option)
		{
			if (previousItem != null)
				previousItem.Selected = false;

			option.Selected = true;
			previousItem = option;

			var displayPage = PageForOption (option);

			#if WINDOWS_PHONE
			Detail = new ContentPage();//work around to clear current page.
			#endif
			Detail = new NavigationPage (displayPage) {
				BarBackgroundColor = Helpers.Color.Maroon.ToFormsColor (),
			};


			IsPresented = false;
		}

		Page PageForOption (IMenuOptions option)
		{
			// TODO: Refactor this to the Builder pattern (see ICellFactory).
			if (option.Title == "Current Location") {
				return new MasterPage (option);
			}
			if (option.Title == "Campus Maps") {
				return new MasterPage (option);
			}
			if (option.Title == "Points of Interest") {
				return new MasterPage (option);
			}
			if (option.Title == "Concordia Services") {
				return new MasterPage (option);
			}
			if (option.Title == "Building Directions") {
				return new MasterPage (option);
			}
			if (option.Title == "Indoor Directions") {
				return new MasterPage (option);
			}
			if (option.Title == "Calendar") {
				return new MasterPage (option);
			}
			if (option.Title == "Settings") {
				return new MasterPage (option);
			}
			throw new NotImplementedException ("Unknown menu option: " + option.Title);
		}
	}
}