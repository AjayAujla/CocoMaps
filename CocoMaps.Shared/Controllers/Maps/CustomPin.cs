using System;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	public class CustomPin
	{
		public string Label { get; set; }

		public string Address { get; set; }

		public string PinIcon { get; set; }

		public Xamarin.Forms.Maps.Position Position { get; set; }

	}
}