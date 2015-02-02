using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocoMaps.Models;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;


namespace CocoMaps.Shared.Pages
{
	public class MapPage : ContentPage
	{

		private MapViewModel ViewModel
		{
			get { return BindingContext as MapViewModel; }
		}

		public MapPage (MapViewModel viewModel)
		{

			BindingContext = viewModel;

			this.SetBinding(Page.TitleProperty, "Title");
			this.SetBinding(Page.IconProperty, "Icon");

			var map = new Map(MapSpan.FromCenterAndRadius(new Position(45.495774,-73.578252), Distance.FromMiles(0.3))) 
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			Content = stack;

			var position = new Position(45.495774,-73.578252); // Latitude, Longitude

			var pin = new Pin 
			{
				Type = PinType.Place,
				Position = position,
				Label = "custom pin",
				Address = "custom detail info"
			};

			map.Pins.Add(pin);
		}
	}
}

