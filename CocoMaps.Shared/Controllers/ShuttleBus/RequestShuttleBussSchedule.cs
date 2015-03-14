using System;
using System.Collections.Generic;
using Java.Sql;

namespace CocoMaps.Shared
{
	public class RequestShuttleBusSchedule
	{
		static RequestShuttleBusSchedule requestShuttleBusSchedule;

		public static RequestShuttleBusSchedule getInstance {
			get {
				if (requestShuttleBusSchedule == null) {
					requestShuttleBusSchedule = new RequestShuttleBusSchedule ();
				}
				return requestShuttleBusSchedule;
			}
		}

		RequestShuttleBusSchedule ()
		{

		}

		public List<String> NonFridayLOYDepartures = new List<String> {
			"7:45",
			"8:00",
			"8:15",
			"8:30",
			"8:45",
			"9:00",
			"9:15",
			"9:30",
			"9:45",
			"10:00",
			"10:15",
			"10:30",
			"10:55",
			"11:15",
			"11:30",
			"12:00",
			"12:30",
			"13:00",
			"13:30",
			"14:00",
			"14:30",
			"15:00",
			"15:30",
			"16:00",
			"16:30",
			"17:00",
			"17:30",
			"18:00",
			"18:30",
			"19:00",
			"19:30",
			"20:00",
			"20:15",
			"20:30",
			"20:45",
			"21:10",
			"21:35",
			"22:00",
			"22:00",
			"23:30"
		};
		public List<String> NonFridaySGWDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:30",
			"8:45",
			"9:00",
			"9:15",
			"9:30",
			"9:45",
			"10:00",
			"10:15",
			"10:30",
			"11:00",
			"11:15",
			"11:45",
			"12:00",
			"12:30",
			"13:00",
			"13:30",
			"14:00",
			"14:30",
			"15:00",
			"15:30",
			"16:00",
			"16:30",
			"17:00",
			"17:30",
			"18:00",
			"18:30",
			"19:00",
			"19:30",
			"19:45",
			"20:00",
			"20:15",
			"20:45",
			"21:00",
			"21:10",
			"21:35",
			"22:00",
			"22:00",
			"23:30"
		};

		public List<String> FridayLOYDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:45",
			"9:00",
			"9:15",
			"9:45",
			"10:00",
			"10:15",
			"11:00",
			"11:15",
			"11:45",
			"12:00",
			"12:15",
			"12:45",
			"13:15",
			"13:30",
			"13:45",
			"14:15",
			"14:30",
			"14:45",
			"15:15",
			"15:30",
			"15:45",
			"16:15",
			"16:30",
			"16:45",
			"17:15",
			"18:15",
			"18:45",
			"19:15",
			"19:45"
		};
		public List<String> FridaySGWDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:45",
			"9:15",
			"9:30",
			"9:45",
			"10:15",
			"10:30",
			"10:45",
			"11:30",
			"11:45",
			"12:15",
			"12:45",
			"13:00",
			"13:15",
			"13:45",
			"14:00",
			"14:15",
			"14:45",
			"15:00",
			"15:15",
			"15:45",
			"16:00",
			"16:15",
			"16:45",
			"17:15",
			"17:45",
			"18:15",
			"18:45",
			"19:15",
			"19:45"
		};

		public String[] GetSGWNextPassages (int numberOfNextPassages)
		{

			// No passages during weekend
//			if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday
//			    || DateTime.Today.DayOfWeek || DayOfWeek.Sunday)
//				return null;


			for (int i = 0; i < numberOfNextPassages; ++i) {




			}


			return null;

		}

		public String[] GetLOYNextPassages (int numberOfNextPassages)
		{


			return null;
		}

	}
}