using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CocoMaps.Shared;
using CocoMaps.Shared.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Json;
using System.Linq;

#if __ANDROID__
using CocoMaps.Android;
#endif

namespace CocoMaps.Shared
{
	public class BaseCalendar : TabbedPage
	{
		public static List<CalendarItems> MondayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> TuesdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> WednesdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> ThursdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> FridayCalItems = new List<CalendarItems>{ };

		public BaseCalendar (IMenuOptions menuItem , CalendarRootObject CRO)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Calendar");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			setCalendarList(CRO);

			sortCalendarList ();

			#if __ANDROID__

			AndroidReminderService a = new AndroidReminderService ();

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

			InitializeTabOnCurrentWeekday ();

			var dateNow = DateTime.Now;
			var today = dateNow.DayOfWeek;
			var earlyNotice = new TimeSpan (0, 15, 0);

			AndroidReminderService.alarmManagerCreationForNotificationOfCurrentDay (a, dateNow, today, earlyNotice);

			#endif

		}

		public void sortCalendarList ()
		{
			MondayCalItems = MondayCalItems.OrderBy (o => o.StartTime).ToList ();
			TuesdayCalItems = TuesdayCalItems.OrderBy (o => o.StartTime).ToList ();
			WednesdayCalItems = WednesdayCalItems.OrderBy (o => o.StartTime).ToList ();
			ThursdayCalItems = ThursdayCalItems.OrderBy (o => o.StartTime).ToList ();
			FridayCalItems = FridayCalItems.OrderBy (o => o.StartTime).ToList ();
		}

		public void setCalendarList (CalendarRootObject CRO)
		{
			foreach (CalendarItem CI in CRO.items) {
				string[] CalSummary = CI.summary.ToLower ().Split ('-');

				if (CalSummary [0] == "concordia") {
					string[] days = CI.description.ToLower ().Split (',');

					string course = getCourseID (CalSummary [CalSummary.Length - 1]);

					string courseType = getCourseType (CalSummary [1]) + "-" + CalSummary [2].ToUpper ();

					string courseLocation = CI.location;

					string courseStartTime = getCourseTime (CI.start.dateTime);

					string courseEndTime = getCourseTime (CI.end.dateTime);

					foreach (string day in days) {
						string courseDay = char.ToUpper (day [0]) + day.Substring (1);

						if (day == "monday") {
							MondayCalItems.Add (new CalendarItems (course, courseType, courseDay, courseLocation, courseStartTime, courseEndTime, Color.Maroon));

						} else if (day == "tuesday") {
							TuesdayCalItems.Add (new CalendarItems (course, courseType, courseDay, courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						} else if (day == "wednesday") {
							WednesdayCalItems.Add (new CalendarItems (course, courseType, courseDay, courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						} else if (day == "thursday") {
							ThursdayCalItems.Add (new CalendarItems (course, courseType, courseDay, courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						} else if (day == "friday") {
							FridayCalItems.Add (new CalendarItems (course, courseType, courseDay, courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
					}
				}

			}

		}

		public string getCourseTime (string Time)
		{
			return Time.Substring (11, 5);
		}

		public string getCourseType (string ct)
		{
			if (ct == "lec") {
				return "Lecture";
			} else if (ct == "tut") {
				return "Tutorial";
			} else if (ct == "lab") {
				return "Tutorial";
			} else {
				return ct;
			}

		}

		public string getCourseID (string course)
		{
			if (course.Length == 7) {
				char[] C = course.ToCharArray ();

				string courseName = C [0].ToString () + C [1].ToString () + C [2].ToString () + C [3].ToString ();
				string courseID = C [4].ToString () + C [5].ToString () + C [6].ToString ();

				string nCourse = courseName.ToUpper () + "-" + courseID;

				return nCourse;

			} else {
				return course;
			}
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

		public void InitializeTabOnCurrentWeekday ()
		{
			int dayOfWeek = (int)DateTime.Today.DayOfWeek;

			// Checks if the current day falls on the weekend and changes it to Monday.
			if (dayOfWeek == 0 || dayOfWeek == 6) {
				dayOfWeek = 1;
			}

			// Starts the page with the tab corresponding to the current day
			this.CurrentPage = this.Children [dayOfWeek - 1];
		}

	}
}