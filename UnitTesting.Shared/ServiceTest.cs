using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class ServiceTest
	{
		[Test ()]
		public void TestSetandGetMethods ()
		{
			Service s = new Service ();

			s.Name = "Student Center";
			Assert.Equals ("Student Center", s.Name);

			s.RoomNumber = "LB-185";
			Assert.Equals ("LB-185", s.RoomNumber);

			s.URI = "https://www.concordia.ca/students/birks.html";
			Assert.Equals ("https://www.concordia.ca/students/birks.html", s.URI);
		}


	}
}