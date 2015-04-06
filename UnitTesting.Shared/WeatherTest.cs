using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class WeatherTest
	{
		[Test ()]
		public void TestSetandGet ()
		{
			Weather weatherTest = new Weather ();

			weatherTest.icon = "test";
			Assert.Equals ("test", weatherTest.icon);
		}
	}

	[TestFixture ()]
	public class MainTest{
		
		[Test ()]
		public void TestSetandGet(){
			Main mainTest = new Main ();

			mainTest.temp = 26;
			Assert.Equals (26, mainTest.temp);

		}
	}
}

