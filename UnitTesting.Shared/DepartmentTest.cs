using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTest.Shared
{
	[TestFixture ()]
	public class BuildingTest
	{
		[Test ()]
		public void TestSetandGetMethods ()
		{
			Building buildTest = new Building ();

			buildTest.Code = "SGW";
			Assert.Equals ("SGW", buildTest.Code);

			buildTest.Name = "Henry Hall";
			Assert.Equals ("Henry Hall", buildTest.Name);

			Campus c = new Campus ();
			buildTest.Campus = c;
			Assert.Equals (c, buildTest.Campus);

			buildTest.Address = "Sherbrooke";
			Assert.Equals ("Sherbrooke", buildTest.Address);

			Position p = new Position ();
			buildTest.Position = p;
			Assert.Equals (p, buildTest.Position);

			buildTest.HasAtm = true;
			Assert.True (buildTest.HasAtm);

			buildTest.HasParkingLot = true;
			Assert.True (buildTest.HasParkingLot);

			buildTest.HasBikeRack = true;
			Assert.True (buildTest.HasBikeRack);

			buildTest.HasInfoKiosk = true;
			Assert.True (buildTest.HasInfoKiosk);

			buildTest.HasAccessibility = true;
			Assert.True (buildTest.HasAccessibility);
		}

		[Test ()]
		public void TestToString ()
		{
			Building buildTest = new Building ();

			buildTest.Name = "Henry Hall";
			buildTest.Code = "SGW";
			buildTest.Address = "Sherbrooke";


			Assert.Equals ("[Building: Code = SGW, Name = Henry Hall, Address = Sherbrooke]", buildTest.ToString());
		}
	}
}