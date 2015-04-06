using NUnit.Framework;
using System;
using CocoMaps.Shared;

namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class BoomarksModelTest
	{
		[Test ()]
		public void TestSetandGetMethods(){
			BookmarkItems bookMarkItemTest = new BookmarkItems ();

			bookMarkItemTest.ID = 500;
			Assert.Equals (500, bookMarkItemTest.ID);

			bookMarkItemTest.bName = "This is a test";
			Assert.Equals ("This is a test", bookMarkItemTest.bName);

			bookMarkItemTest.bAddress = "Test Address";
			Assert.Equals ("Test Address", bookMarkItemTest.bAddress);

			bookMarkItemTest.bLatitude = 4000;
			Assert.Equals (4000, bookMarkItemTest.bLatitude);

			bookMarkItemTest.bLongitude = 500;
			Assert.Equals (500, bookMarkItemTest.bLongitude);
		}

		[Test ()]
		public void TestToStringMethod(){
			BookmarkItems bookMarkItemTest = new BookmarkItems ();
			bookMarkItemTest.ID = 1000;
			bookMarkItemTest.bAddress = "123 fake street";
			bookMarkItemTest.bLatitude = 100;
			bookMarkItemTest.bLongitude = 200;

			Assert.Equals ("[BookmarkItems: ID=1000, Address=123 fake street, Latitude=100, Longitude=200", bookMarkItemTest.ToString ());
		
		}
	}
}

