using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class BuildingTest
	{
		[Test ()]
		public void TestSetandGetMethods ()
		{
			Department d = new Department();

			d.Name = "Department of Computer Science & Software Engineering";
			Assert.Equals ("Department of Computer Science & Software Engineering", d.Name);

			d.URI = "http://www.concordia.ca/encs/computer-science-software-engineering.html";
			Assert.Equals ("http://www.concordia.ca/encs/computer-science-software-engineering.html", d.URI);
		}
	}
}