using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class BaseShuttleBus : TabbedPage
	{
		public BaseShuttleBus (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Calendar");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			var MondayShuttle = new ShuttleBus (menuItem, "Monday");
			var TuesdayShuttle = new ShuttleBus (menuItem, "Tuesday");
			var WednesdayShuttle = new ShuttleBus (menuItem, "Wednesday");
			var ThursdayShuttle = new ShuttleBus (menuItem, "Thursday");
			var FridayShuttle = new ShuttleBus (menuItem, "Friday");

			this.Children.Add (MondayShuttle);
			this.Children.Add (TuesdayShuttle);
			this.Children.Add (WednesdayShuttle);
			this.Children.Add (ThursdayShuttle);
			this.Children.Add (FridayShuttle);

			InitializeTabOnCurrentWeekday ();
		}

		/*
		 * 	Initialize the shuttle bus schedule page on the tab corresponding to the current (or upcoming) week day
		 */
		public void InitializeTabOnCurrentWeekday ()
		{
			int dayOfWeek = (int)DateTime.Now.DayOfWeek;

			// Checks if the current day falls on the weekend and changes it to Monday.
			if (dayOfWeek <= 0 || dayOfWeek >= 6) {dayOfWeek = 1;}
			
			// Starts the page with the tab corresponding to the current day
			this.CurrentPage = this.Children [dayOfWeek-1];
		}
	}
}