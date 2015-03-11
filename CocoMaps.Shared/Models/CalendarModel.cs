using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;


namespace CocoMaps.Shared
{
	public class CalendarItems
	{
		public CalendarItems (string eventName, String type, String day, String room, String startTime, String endTime, Color bcolor)
		{
			this.EventName = eventName;
			this.Room = room;
			this.Day = day;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.BoxColor = bcolor;
			this.EventType = type;

			this.Title1 = eventName + " (" + type + ")";
			this.Title2 = day + " " + room + " " + "(" + startTime + " - " + endTime + ")";
		}

		public string EventName { private set; get; }

		public string Title1 { private set; get; }

		public string Title2 { private set; get; }

		public string EventType { private set; get; }

		public string Room { private set; get; }

		public string Day { private set; get; }

		public string StartTime { private set; get; }

		public string EndTime { private set; get; }

		public Color BoxColor { private set; get; }


	}
}



