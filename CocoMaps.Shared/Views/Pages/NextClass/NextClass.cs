using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CocoMaps.Shared
{
	public class NextClass : ContentPage
	{

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}

		DateTime DateNow = DateTime.Now;

		Boolean NextClassFound = false;

		CalendarItems NextClassItem = null;

		List<CalendarItems> Mon_CL = new List<CalendarItems>{};
		List<CalendarItems> Tue_CL = new List<CalendarItems>{};
		List<CalendarItems> Wed_CL = new List<CalendarItems>{};
		List<CalendarItems> Thu_CL = new List<CalendarItems>{};
		List<CalendarItems> Fri_CL = new List<CalendarItems>{};

		public NextClass (IMenuOptions menuItem ,BaseCalendar BC)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "Next Class");
			SetValue (Page.IconProperty, menuItem.Icon);

			if(BC == null)
			{
				var label0 = new Label {
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
					FontAttributes = FontAttributes.Bold,
					Text = "\r\n" + "CALENDAR NEEDS TO BE AUTHENTICATED FIRST" + "\r\n"
				};

				Content = new StackLayout {
					Children = {
						label0
					}
				};
			}
			else
			{
				Mon_CL = BC.getMondayList ();
				Tue_CL = BC.getTuesdayList ();
				Wed_CL = BC.getWednesdayList ();
				Thu_CL = BC.getThursdayList ();
				Fri_CL = BC.getFridayList ();

				var DateTodayInt = getDateTodayInt ();

				setNextClass(DateTodayInt);



				var label0 = new Label {
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
					FontAttributes = FontAttributes.Bold,
					Text = "\r\n" + "Time Now : "
				};


				var label1 = new Label {
					Text = DateNow.DayOfWeek.ToString() + " " + DateNow.ToString() + "\r\n",

					Font = Font.SystemFontOfSize (NamedSize.Large) 
				};


				var label2 = new Label {
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
					FontAttributes = FontAttributes.Bold,
					Text = "Your Next Class : "
				};


				var label3 = new Label {
					Text = "Class : " + NextClassItem.Title1,

					Font = Font.SystemFontOfSize (NamedSize.Large) 
				};

				var label4 = new Label {
					Text = "Details : " + NextClassItem.Title2 + "\r\n",

					Font = Font.SystemFontOfSize (NamedSize.Large) 
				};

				var label5 = new Label {
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
					FontAttributes = FontAttributes.Bold,
					Text = "Class Destination : "
				};


				var label6 = new Label {
					Text = getClassLocation(NextClassItem.Room) + "\r\n",

					Font = Font.SystemFontOfSize (NamedSize.Large) 
				};



				var NextClassButton = new Button { Text = "Get Directions to Next Class" };

				var pushClass = new StackLayout {
					Spacing = 5,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Orientation = StackOrientation.Horizontal, 
					Children = { NextClassButton }
				};

				//NextClassButton.Clicked += HandleNextClassButton(startLocation , destination);

				Content = new StackLayout {
					Children = {
						label0,
						label1,
						label2,
						label3,
						label4,
						label5,
						label6,
						pushClass
					}
				};
			}

		}

		public void processNextClass(int dayInt,List<CalendarItems> CurrentDayList)
		{
			string TimeNow = getTodayTime();

			if(CurrentDayList != null || CurrentDayList.Any())
			{
				foreach(CalendarItems CI in CurrentDayList)
				{

					string sTime = CI.StartTime.Replace(":", "");
					string tNow = TimeNow.Replace(":", "");

					int sTimeInt = int.Parse (sTime);
					int tNowInt = int.Parse (tNow);

					if(sTimeInt > tNowInt)
					{
						NextClassFound = true;

						NextClassItem =  CI;

						break;
					}
				}

				if(!NextClassFound)
				{
					setNextClass(dayInt + 1);
				}
			}
			else
			{
				setNextClass(dayInt + 1);
			}




		}

		public void getFirstClass(List<CalendarItems> CurrentDayList)
		{
			if (CurrentDayList != null) 
			{
				NextClassFound = true;

				NextClassItem =  CurrentDayList[0];
			}
		}

		public void setNextClass(int dayInt)
		{
			switch (dayInt) 
			{
			case 1:
				processNextClass (dayInt , Mon_CL);
				break;
			case 2:
				processNextClass (dayInt , Tue_CL);
				break;
			case 3:
				processNextClass (dayInt , Wed_CL);
				break;
			case 4:
				processNextClass (dayInt , Thu_CL);
				break;
			case 5:
				processNextClass (dayInt , Fri_CL);
				break;
			default:
				getFirstClass (Mon_CL);
				break;
			}
		}


		public string getDateToday()
		{
			string  DateToday = (DateNow.DayOfWeek).ToString().ToLower();
			return DateToday;
		}

		public int getDateTodayInt()
		{
			int DateTodayInt = (int)DateTime.Today.DayOfWeek;

			if (DateTodayInt <= 0 || DateTodayInt >= 6) {DateTodayInt = 1;}

			return DateTodayInt;
		}

		public string getTodayTime()
		{
			string TodayTime =(DateNow.TimeOfDay).ToString().Substring(0,5);

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

		static void HandleNextClassButton (string start, string end)
		{
			RequestDirections RD;

			//Task<Directions> GDirections = RD.getDirections(start , end , TravelMode.walking);

		}

	}

}