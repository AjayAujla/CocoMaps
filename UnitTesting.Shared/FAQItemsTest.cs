using NUnit.Framework;
using System;
using CocoMaps.Shared;
namespace UnitTesting.Shared
{
	[TestFixture ()]
	public class FAQItemsTest
	{
		[Test ()]
		public void TestSetandGetMethods()
		{
			FAQItems faqItemTest = new FAQItems ();

			faqItemTest.Question = "Test Question";
			Assert.Equals ("Test Question", faqItemTest.Question);

			faqItemTest.Answer = "Test Answer";
			Assert.Equals ("Test Answer", faqItemTest.Answer);


		}
	}
}

