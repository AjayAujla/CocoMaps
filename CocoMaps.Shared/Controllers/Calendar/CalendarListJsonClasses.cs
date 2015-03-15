using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class CalendarListNotification
	{
		public string type { get; set; }
		public string method { get; set; }
	}

	public class CalendarListNotificationSettings
	{
		public List<CalendarListNotification> notifications { get; set; }
	}

	public class CalendarListItem
	{
		public string kind { get; set; }
		public string etag { get; set; }
		public string id { get; set; }
		public string summary { get; set; }
		public string timeZone { get; set; }
		public string colorId { get; set; }
		public string backgroundColor { get; set; }
		public string foregroundColor { get; set; }
		public bool selected { get; set; }
		public string accessRole { get; set; }
		public List<object> defaultReminders { get; set; }
		public CalendarListNotificationSettings notificationSettings { get; set; }
		public bool? primary { get; set; }
		public string description { get; set; }
	}

	public class CalendarListRootObject
	{
		public string kind { get; set; }
		public string etag { get; set; }
		public string nextSyncToken { get; set; }
		public List<CalendarListItem> items { get; set; }
	}
}

