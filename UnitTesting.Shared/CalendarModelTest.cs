using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class CalendarModelTest
	{

		[Test ()]
		public void TestConstructor ()
		{
			CalendarItems CI = new CalendarItems ("TestEventName", "TestType", "TestDay", "TestRoom", "12:00", "1:00", Color.Blue);

			Assert.Equals ("TestEventName", CI.EventName);
			Assert.Equals ("TestType", CI.EventType);
			Assert.Equals ("TestDay", CI.Day);
			Assert.Equals ("TestRoom", CI.Room);
			Assert.Equals ("12:00", CI.StartTime);
			Assert.Equals ("1:00", CI.EndTime);
			Assert.Equals ("Azure", CI.BoxColor);
		}
	}
}