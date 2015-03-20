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
	public class BaseCalendar : AuthBasePage
	{

		Boolean UseOnlineCalendar = false;

		public CalendarListRootObject CalListObj = null;

		public CalendarRootObject LocalCalObj = null;
		public CalendarRootObject OnlineCalObj = null;

		public static List<CalendarItems> MondayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> TuesdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> WednesdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> ThursdayCalItems = new List<CalendarItems>{ };
		public static List<CalendarItems> FridayCalItems = new List<CalendarItems>{ };


		public BaseCalendar (IMenuOptions menuItem)
		{

			MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => {

				var viewModel = new MasterViewModel ();
				BindingContext = viewModel;

				this.SetValue (Page.TitleProperty, "Calendar");
				this.SetValue (Page.IconProperty, menuItem.Icon);

				setCalendarList ();

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

				switch (today) {
				case DayOfWeek.Monday:
					foreach (CalendarItems c in MondayCalItems) {
						if(MondayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Tuesday:
					foreach (CalendarItems c in TuesdayCalItems) {
						if(TuesdayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Wednesday:
					foreach (CalendarItems c in WednesdayCalItems) {
						if(WednesdayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Thursday:
					foreach (CalendarItems c in ThursdayCalItems) {
						if(ThursdayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Friday:
					foreach (CalendarItems c in FridayCalItems) {
						if(FridayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Saturday:
					foreach (CalendarItems c in MondayCalItems) {
						if(MondayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				case DayOfWeek.Sunday:
					foreach (CalendarItems c in MondayCalItems) {
						if(MondayCalItems != null){
							var startingTime = TimeSpan.Parse (c.StartTime);
							var notificationHourMinute = startingTime - earlyNotice;
							var notificationTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, notificationHourMinute.Hours, notificationHourMinute.Minutes, 0);
							a.Remind (dateNow, c.EventName, "Is starting soon at the following location " + c.Room);
						}
					}
					break;
				}

				#endif

			});
		}

		public void sortCalendarList ()
		{
			MondayCalItems = MondayCalItems.OrderBy (o => o.StartTime).ToList ();
			TuesdayCalItems = TuesdayCalItems.OrderBy (o => o.StartTime).ToList ();
			WednesdayCalItems = WednesdayCalItems.OrderBy (o => o.StartTime).ToList ();
			ThursdayCalItems = ThursdayCalItems.OrderBy (o => o.StartTime).ToList ();
			FridayCalItems = FridayCalItems.OrderBy (o => o.StartTime).ToList ();
		}

		public void setCalendarList ()
		{
			CalendarRootObject CRO = getCalendarObj ();

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

		public string GetLocalCalendar ()
		{
			string CalJsonText = "";

			Assembly assembly = Assembly.GetExecutingAssembly ();
			string[] resources = assembly.GetManifestResourceNames ();

			foreach (string resource in resources) {
				if (resource.Equals ("CocoMaps.Android.LocalCalendar.json")) {
					Stream stream = assembly.GetManifestResourceStream (resource);
					if (stream != null) {
						using (var reader = new System.IO.StreamReader (stream)) {
							CalJsonText = reader.ReadToEnd ();
						}
					}
				}
			}

			return CalJsonText;
		}


		public void ProcessCalendarJson ()
		{
			LocalCalObj = JsonConvert.DeserializeObject<CalendarRootObject> (GetLocalCalendar ());
		}


		public CalendarRootObject getCalendarObj ()
		{
			var CLO1 = getCalendarListObj ();

			if (UseOnlineCalendar) {
				if ((OnlineCalObj == null)) {
					processCalendarList ();
				}
				return OnlineCalObj;
			} else {
				if ((LocalCalObj == null)) {
					ProcessCalendarJson ();
				}
				return LocalCalObj;
			}

		}

		public CalendarListRootObject getCalendarListObj ()
		{
			if ((CalListObj == null)) {
				requestCalendarList ();
			}

			return CalListObj;
		}

		public void processCalendarList ()
		{
			var CLO = getCalendarListObj ();

			foreach (CalendarListItem OCI in CLO.items) {
				string[] CalListSummary = OCI.summary.ToLower ().Split ('-');

				if (CalListSummary [0] == "@ConcordiaCalendar") {
					RequestOnlineCalendar (OCI.id);

					UseOnlineCalendar = true;
				}
			}
		}

		public async Task<CalendarRootObject> RequestOnlineCalendar (string CalID)
		{
			string token = App.Instance.Token;

			var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/calendars/{0}/events?alwaysIncludeEmail=false&singleEvents=false&fields=description%2Citems(description%2Cend%2Cid%2Clocation)%2Csummary&key={1}", CalID, token);

			JsonValue OnlineCalJson = await JsonUtil.FetchJsonAsync (requestUrl);

			OnlineCalObj = JsonConvert.DeserializeObject<CalendarRootObject> (OnlineCalJson.ToString ());

			return OnlineCalObj;

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

		public async Task<CalendarListRootObject> requestCalendarList ()
		{
			string token = App.Instance.Token;

			var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/users/me/calendarList?key={0}", token);

			JsonValue CalListJson = await JsonUtil.FetchJsonAsync (requestUrl);

			CalListObj = JsonConvert.DeserializeObject<CalendarListRootObject> (CalListJson.ToString ());

			return CalListObj;

		}

		public List<CalendarItems> getMondayList ()
		{
			if ((MondayCalItems == null)) {
				setCalendarList ();
				sortCalendarList ();
			}
			return MondayCalItems;
		}

		public List<CalendarItems> getTuesdayList ()
		{
			if ((TuesdayCalItems == null)) {
				setCalendarList ();
				sortCalendarList ();
			}
			return TuesdayCalItems;
		}

		public List<CalendarItems> getWednesdayList ()
		{
			if ((WednesdayCalItems == null)) {
				setCalendarList ();
				sortCalendarList ();
			}
			return WednesdayCalItems;
		}

		public List<CalendarItems> getThursdayList ()
		{
			if ((ThursdayCalItems == null)) {
				setCalendarList ();
				sortCalendarList ();
			}
			return ThursdayCalItems;
		}

		public List<CalendarItems> getFridayList ()
		{
			if ((FridayCalItems == null)) {
				setCalendarList ();
				sortCalendarList ();
			}
			return FridayCalItems;
		}

	}
}