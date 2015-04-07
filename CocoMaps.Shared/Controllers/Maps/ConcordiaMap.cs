using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{

	public class ConcordiaMap : Map
	{

		static ConcordiaMap instance;

		public static ConcordiaMap getInstance {
			get {
				if (instance == null)
					instance = new ConcordiaMap ();
				return instance;
			}
		}

		ConcordiaMap ()
		{
		}

		public ConcordiaMap (MapSpan mapSpan) : base (mapSpan)
		{
		}

	}
}