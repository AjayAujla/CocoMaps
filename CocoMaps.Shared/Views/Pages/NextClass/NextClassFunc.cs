using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Json;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CocoMaps.Android;
using CocoMaps.Shared;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace CocoMaps.Shared
{
	public class NextClassFunc
	{

		DateTime DateNow = DateTime.Now;

		Boolean NextClassFound = false;

		CalendarItems NextClassItem = null;

		Boolean UseOnlineCalendar = false;

		public CalendarListRootObject CalListObj = null;

		public CalendarRootObject LocalCalObj = null;
		public CalendarRootObject OnlineCalObj = null;

		public List<CalendarItems> MondayCalItems = new List<CalendarItems>{ };
		public List<CalendarItems> TuesdayCalItems = new List<CalendarItems>{ };
		public List<CalendarItems> WednesdayCalItems = new List<CalendarItems>{ };
		public List<CalendarItems> ThursdayCalItems = new List<CalendarItems>{ };
		public List<CalendarItems> FridayCalItems = new List<CalendarItems>{ };


		public NextClassFunc ()
		{
			setCalendarList ();

			sortCalendarList ();

			var DateTodayInt = getDateTodayInt ();

			setNextClass (DateTodayInt);
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

		public void processNextClass (int dayInt, List<CalendarItems> CurrentDayList)
		{
			string TimeNow = getTodayTime ();

			int DayToday = getDateTodayInt ();

			if (dayInt == DayToday) {
				if (CurrentDayList != null || CurrentDayList.Any ()) {
					foreach (CalendarItems CI in CurrentDayList) {
						string sTime = CI.StartTime.Replace (":", "");
						string tNow = TimeNow.Replace (":", "");

						int sTimeInt = int.Parse (sTime);
						int tNowInt = int.Parse (tNow);

						if (sTimeInt > tNowInt) {
							NextClassFound = true;

							NextClassItem = CI;

							break;
						}
					}

					if (!NextClassFound) {
						setNextClass (dayInt + 1);
					}

				} else {
					setNextClass (dayInt + 1);
				}

			} else {
				if (CurrentDayList != null || CurrentDayList.Any ()) {
					getFirstClass (CurrentDayList);
				} else {
					setNextClass (dayInt + 1);
				}
			}

		}

		public CalendarItems getNextClassItem ()
		{
			return NextClassItem;
		}

		public void getFirstClass (List<CalendarItems> CurrentDayList)
		{
			if (CurrentDayList != null) {
				NextClassFound = true;

				NextClassItem = CurrentDayList [0];
			}
		}

		public void setNextClass (int dayInt)
		{
			switch (dayInt) {
			case 1:
				processNextClass (dayInt, MondayCalItems);
				break;
			case 2:
				processNextClass (dayInt, TuesdayCalItems);
				break;
			case 3:
				processNextClass (dayInt, WednesdayCalItems);
				break;
			case 4:
				processNextClass (dayInt, ThursdayCalItems);
				break;
			case 5:
				processNextClass (dayInt, FridayCalItems);
				break;
			default:
				getFirstClass (MondayCalItems);
				break;
			}
		}


		public string getDateToday ()
		{
			string DateToday = (DateNow.DayOfWeek).ToString ().ToLower ();
			return DateToday;
		}

		public int getDateTodayInt ()
		{
			int DateTodayInt = (int)DateTime.Today.DayOfWeek;

			if (DateTodayInt <= 0 || DateTodayInt >= 6) {
				DateTodayInt = 1;
			}

			return DateTodayInt;
		}

		public string getTodayTime ()
		{
			string TodayTime = (DateNow.TimeOfDay).ToString ().Substring (0, 5);

			return TodayTime;
		}


		public string getClassLocation (string dest)
		{
			string destination = dest.Trim ().ToUpper ();

			string[] destination_array = destination.Split ('-');

			string campusLoc = destination_array [0];

			string roomLoc = destination_array [1];


			BuildingRepository BR = BuildingRepository.getInstance;

			Campus campus = BR.GetCampusByCode (campusLoc);

			Building building;
			BR.BuildingList.TryGetValue (roomLoc, out building);
			return building.Address;

		}
	}
}

