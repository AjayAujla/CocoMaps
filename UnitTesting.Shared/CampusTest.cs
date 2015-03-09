using NUnit.Framework;
using System;
using System.Collections.Generic;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class CampusTest
	{
		[Test ()]
		public void TestSetandGetMethods ()
		{
			Campus c = new Campus ();

			c.ID = 1;
			Assert.Equals (1, c.ID);

			c.Code = "SGW";
			Assert.Equals ("SGW", c.Code);

			c.Name = "Sir George Williams";
			Assert.Equals ("Sir George Williams", c.Name);

			c.Address = "Sherbrooke";
			Assert.Equals ("Sherbrooke", c.Address);

			Building b1 = new Building ();
			c.Buildings.Add (b1);
			List<Building> l = new List<Building>(b1);
			Assert.Equals(l, c.Buildings);
		}

		[Test ()]
		public void TestGetBuildingByCodeNullList ()
		{
			Campus c = new Campus ();

			Assert.Null(c.GetBuildingByCode("Loy"));
		}

		[Test ()]
		public void TestGetBuildingByCodeActiveList ()
		{
			Campus c = new Campus ();

			Building b1 = new Building ();
			b1.Code = "SGW";

			Building b2 = new Building ();
			b2.Code = "Loy";

			c.Buildings.Add (b1);
			c.Buildings.Add (b2);

			Assert.Equals(b2, c.GetBuildingByCode("Loy"));
		}

		[Test ()]
		public void TestGetBuildingByCodeNotFound ()
		{
			Campus c = new Campus ();

			Building b1 = new Building ();
			b1.Code = "SGW";
			c.Buildings.Add (b1);

			Assert.Null(c.GetBuildingByCode("Loy"));
		}
	}
}