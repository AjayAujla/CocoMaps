using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class CalendarStart
	{
		public string dateTime { get; set; }
		public string timeZone { get; set; }
	}

	public class CalendarEnd
	{
		public string dateTime { get; set; }
		public string timeZone { get; set; }
	}

	public class CalendarItem
	{
		public string etag { get; set; }
		public string id { get; set; }
		public string summary { get; set; }
		public string location { get; set; }
		public CalendarStart start { get; set; }
		public CalendarEnd end { get; set; }
		public string description { get; set; }
	}

	public class CalendarRootObject
	{
		public string etag { get; set; }
		public string summary { get; set; }
		public string description { get; set; }
		public List<CalendarItem> items { get; set; }
	}
}

