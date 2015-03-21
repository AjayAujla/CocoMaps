using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;


namespace CocoMaps.Shared
{
	public class BookmarkItems
	{
		public BookmarkItems (string name , string address, double lat , double lon )
		{
			this.bName = name;
			this.bAddress = address;
			this.bLat = lat;
			this.bLon = lon;
			//this.BoxColor = bcolor;
		}

		public string bName { private set; get; }

		public string bAddress { private set; get; }

		public double bLat { private set; get; }

		public double bLon { private set; get; }

		//public Color BoxColor { private set; get; }


	}
}
