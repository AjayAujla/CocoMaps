using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CocoMaps.Models;
using CocoMaps.Shared;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
<<<<<<< HEAD
using Newtonsoft.Json;
using Xamarin.Forms;
=======
>>>>>>> origin/Abhi3
using Xamarin.Forms.Maps;
using System.Json;

namespace CocoMaps.Shared
{
	public class BaseCalendar : AuthBasePage
	{

		Boolean UseOnlineCalendar = false;
	
		CalendarListRootObject CalListObj = null;

		CalendarRootObject LocalCalObj = null;
		CalendarRootObject OnlineCalObj = null;

		List<CalendarItems> MondayCalItems = new List<CalendarItems>{};
		List<CalendarItems> TuesdayCalItems = new List<CalendarItems>{};
		List<CalendarItems> WednesdayCalItems = new List<CalendarItems>{};
		List<CalendarItems> ThursdayCalItems = new List<CalendarItems>{};
		List<CalendarItems> FridayCalItems = new List<CalendarItems>{};


		public BaseCalendar (IMenuOptions menuItem)
		{

			MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => {

				var viewModel = new MasterViewModel ();
				BindingContext = viewModel;

				this.SetValue (Page.TitleProperty, "Calendar");
				this.SetValue (Page.IconProperty, menuItem.Icon);
		

				setCalendarList();

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

		public void setCalendarList()
		{
			CalendarRootObject CRO = getCalendarObj ();

			foreach(CalendarItem CI in CRO.items)
			{
				string[] CalSummary = CI.summary.ToLower().Split ('-');

				if(CalSummary[0] == "concordia")
				{
					string[] days = CI.description.ToLower().Split (',');

					string course = getCourseID(CalSummary[CalSummary.Length-1]);

					string courseType = getCourseType(CalSummary[1]) + "-" + CalSummary[2].ToUpper();

					string courseLocation = CI.location;

					string courseStartTime = getCourseTime(CI.start.dateTime);

					string courseEndTime = getCourseTime(CI.end.dateTime);

					foreach(string day in days)
					{
						string courseDay = char.ToUpper(day[0]) + day.Substring(1);

						if (day == "monday")
						{
							MondayCalItems.Add(new CalendarItems(course, courseType, courseDay , courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
						else if (day == "tuesday")
						{
							TuesdayCalItems.Add(new CalendarItems(course, courseType, courseDay , courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
						else if (day == "wednesday")
						{
							WednesdayCalItems.Add(new CalendarItems(course, courseType, courseDay , courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
						else if (day == "thursday")
						{
							ThursdayCalItems.Add(new CalendarItems(course, courseType, courseDay , courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
						else if (day == "friday")
						{
							FridayCalItems.Add(new CalendarItems(course, courseType, courseDay , courseLocation, courseStartTime, courseEndTime, Color.Maroon));
						}
					}
				}

			}

		}

		public string getCourseTime(string Time)
		{
			return Time.Substring(11,5);
		}

		public string getCourseType(string ct)
		{
			if(ct =="lec")
			{
				return "Lecture";
			}
			else if(ct =="tut")
			{
				return "Tutorial";
			}
			else if(ct =="lab")
			{
				return "Tutorial";
			}
			else
			{
				return ct;
			}

		}

		public string getCourseID(string course)
		{
			if (course.Length == 7) 
			{
				char[] C = course.ToCharArray();

				string courseName = C [0].ToString() + C [1].ToString() + C [2].ToString() + C [3].ToString();
				string courseID = C [4].ToString() + C [5].ToString() + C [6].ToString();

				string nCourse = courseName.ToUpper() + "-" + courseID;

				return nCourse;

			}
			else 
			{
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

		public string GetLocalCalendar()
		{
			string CalJsonText = "";

			Assembly assembly = Assembly.GetExecutingAssembly();
			string[] resources = assembly.GetManifestResourceNames();

			foreach (string resource in resources)
			{
				if(resource.Equals("CocoMaps.Android.LocalCalendar.json"))
				{
					Stream stream = assembly.GetManifestResourceStream(resource);
					if (stream != null)
					{
						using (var reader = new System.IO.StreamReader (stream)) {
							CalJsonText = reader.ReadToEnd ();
						}
					}
				}
			}

			return CalJsonText;
		}


		public void ProcessCalendarJson()
		{
			LocalCalObj =  JsonConvert.DeserializeObject<CalendarRootObject> (GetLocalCalendar ());
		}


		public CalendarRootObject getCalendarObj()
		{
			var CLO1 = getCalendarListObj ();

			if(UseOnlineCalendar)
			{
				if ((OnlineCalObj == null)) {processCalendarList ();}
				return OnlineCalObj;
			}
			else
			{
				if ((LocalCalObj == null)) {ProcessCalendarJson ();}
				return LocalCalObj;
			}

		}

		public CalendarListRootObject getCalendarListObj()
		{
			if ((CalListObj == null)) {requestCalendarList();}

			return CalListObj;
		}

		public void processCalendarList()
		{
			var CLO = getCalendarListObj ();

			foreach(CalendarListItem OCI in CLO.items)
			{
				string[] CalListSummary = OCI.summary.ToLower().Split ('-');

				if (CalListSummary [0] == "@ConcordiaCalendar") 
				{
					RequestOnlineCalendar (OCI.id);

					UseOnlineCalendar = true;
				}
			}
		}

		public async Task<CalendarRootObject> RequestOnlineCalendar(string CalID)
		{
			string token = App.Instance.Token;

			var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/calendars/{0}/events?alwaysIncludeEmail=false&singleEvents=false&fields=description%2Citems(description%2Cend%2Cid%2Clocation)%2Csummary&key={1}", CalID , token);

			JsonValue OnlineCalJson = await JsonUtil.FetchJsonAsync (requestUrl);

			OnlineCalObj = JsonConvert.DeserializeObject<CalendarRootObject> (OnlineCalJson.ToString ());

			return OnlineCalObj;

		}

		public async Task<CalendarListRootObject> requestCalendarList()
		{
			string token = App.Instance.Token;

			var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/users/me/calendarList?key={0}" , token);

			JsonValue CalListJson = await JsonUtil.FetchJsonAsync (requestUrl);

			CalListObj = JsonConvert.DeserializeObject<CalendarListRootObject> (CalListJson.ToString ());

			return CalListObj;

		}

	}
}

