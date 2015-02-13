using System;

[assembly: Xamarin.Forms.Dependency (typeof (CocoMaps.Android.ConcordiaMap_Android))]

namespace CocoMaps.Android
{
	public class ConcordiaMap_Android : CocoMaps.Shared.IConcordiaMap
	{
		public ConcordiaMap_Android ()
		{
		}
	}
}