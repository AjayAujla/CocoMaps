using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class NavigationModelTest
	{
		[Test ()]
		public void TestSetandGetMethods ()
		{
			NavigationModel navigationTest = new NavigationModel ();

			navigationTest.Latitude = 200;
			Assert.Equals (200, navigationTest.Latitude);

			navigationTest.Longitude = 400;
			Assert.Equals (400, navigationTest.Longitude);

			navigationTest.DestinationAddress = "Fake Street";
			Assert.Equals ("Fake Street", navigationTest.DestinationAddress);

			navigationTest.DestinationName = "The place";
			Assert.Equals ("The place", navigationTest.DestinationName);
		}
	}
}

