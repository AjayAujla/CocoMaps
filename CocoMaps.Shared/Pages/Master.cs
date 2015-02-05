using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using CocoMaps.Shared.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared.Pages
{
	public class MasterPage : ContentPage
	{
		public MapPage Map { get; private set; }

		public MasterPage(MenuOptions menuItem)
		{
			var viewModel = new MapViewModel();
			BindingContext = viewModel;

			this.SetValue(Page.TitleProperty, menuItem.Title);
			this.SetValue(Page.IconProperty, menuItem.Icon);

			var map = new ConcordiaMap() 
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
				Label = "Custom pin",
				Address = "I'm in love with the Coco"
			};

			map.Pins.Add(pin);
		}
	}

}

