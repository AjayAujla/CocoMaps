using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class FAQItem
	{
		public string Question { get; set; }
		public string Answer { get; set; }
	}

	public class FAQRootObject
	{
		public string summary { get; set; }
		public List<FAQItem> items { get; set; }
	}
}

