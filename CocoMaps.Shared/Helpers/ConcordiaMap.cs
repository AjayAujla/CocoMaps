using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class ConcordiaMap : Xamarin.Forms.Maps.Map
	{
		public ConcordiaMap ()
		{
		}

		public ConcordiaMap (MapSpan mapSpan) : base (mapSpan)
		{
		}

		public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<ConcordiaMap, CustomPin> (x => x.SelectedPin, new CustomPin{ Label = "test123" });

		public CustomPin SelectedPin {
			get{ return (CustomPin)base.GetValue (SelectedPinProperty); }
			set{ base.SetValue (SelectedPinProperty, value); }
		}

		public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create<ConcordiaMap, List<CustomPin>> (x => x.CustomPins, new List<CustomPin> (){ new CustomPin (){ Label = "test123" } });

		public List<CustomPin> CustomPins {
			get{ return (List<CustomPin>)base.GetValue (CustomPinsProperty); }
			set{ base.SetValue (CustomPinsProperty, value); }
		}
	}
}