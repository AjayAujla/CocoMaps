using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CocoMaps.Shared
{

	public class ConcordiaMap : Map
	{
		public ConcordiaMap ()
		{
		}

		public ConcordiaMap (MapSpan mapSpan) : base (mapSpan)
		{
		}

		public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<ConcordiaMap, CustomPin> (x => x.SelectedPin, new CustomPin{ Label = "test123" });

		public CustomPin SelectedPin {
			get{ return (CustomPin)GetValue (SelectedPinProperty); }
			set{ SetValue (SelectedPinProperty, value); }
		}

		public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create<ConcordiaMap, List<CustomPin>> (x => x.CustomPins, new List<CustomPin> (){ new CustomPin (){ Label = "test123" } });

		public List<CustomPin> CustomPins {
			get{ return (List<CustomPin>)GetValue (CustomPinsProperty); }
			set{ SetValue (CustomPinsProperty, value); }
		}
	}
}