using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class BaseCalendar : AuthBasePage
	{
		public BaseCalendar (IMenuOptions menuItem)
		{

			MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => {

				var viewModel = new MasterViewModel ();
				BindingContext = viewModel;

				this.SetValue (Page.TitleProperty, "Calendar");
				this.SetValue (Page.IconProperty, menuItem.Icon);

				// Define some data.
				List<CalendarItems> MondayCalItems = new List<CalendarItems> {
					new CalendarItems ("SOEN-341", "Lecture", "Monday", "H-431", "13:15", "14:30", Color.Maroon)
					// ...etc.,...

				};

				List<CalendarItems> TuesdayCalItems = new List<CalendarItems> {
					// ...etc.,...

				};

				List<CalendarItems> WednesdayCalItems = new List<CalendarItems> {
					new CalendarItems ("COMP-345", "Laboratory", "Wednesday", "H-807", "08:15", "10:30", Color.Maroon),
					new CalendarItems ("ENCS-282", "Tutorial", "Wednesday", "FG-B050", "18:15", "20:30", Color.Maroon)
					// ...etc.,...

				};

				List<CalendarItems> ThursdayCalItems = new List<CalendarItems> {
					new CalendarItems ("SOEN-341", "Lecture", "Thursday", "H-431", "13:15", "14:30", Color.Maroon),
					new CalendarItems ("COMP-345", "Laboratory", "Thursday", "H-807", "08:15", "10:30", Color.Maroon),
					new CalendarItems ("ENCS-282", "Tutorial", "Thursday", "FG-B050", "18:15", "20:30", Color.Maroon),
					// ...etc.,...

				};

				List<CalendarItems> FridayCalItems = new List<CalendarItems> {
					// ...etc.,...

				};

				#if __ANDROID__

				var MonCal = new Calendar (menuItem, "Mon", testList (MondayCalItems));
				var TueCal = new Calendar (menuItem, "Tue", testList (TuesdayCalItems));
				var WedCal = new Calendar (menuItem, "Wed", testList (WednesdayCalItems));
				var ThuCal = new Calendar (menuItem, "Thu", testList (ThursdayCalItems));
				var FriCal = new Calendar (menuItem, "Fri", testList (FridayCalItems));

				this.Children.Add (MonCal);
				this.Children.Add (TueCal);
				this.Children.Add (WedCal);
				this.Children.Add (ThuCal);
				this.Children.Add (FriCal);

				#endif

			});
		}

		public List<CalendarItems> testList (List<CalendarItems> Cal)
		{
			if (Cal.Count == 0) {
				List<CalendarItems> newCal = new List<CalendarItems> {
					new CalendarItems ("No Classes Today", "Whoooo!", "Have Fun", "XD", "", "", Color.Green)
					// ...etc.,...

				};

				return newCal;
			} else {
				return Cal;
			}

		}
	}
}

