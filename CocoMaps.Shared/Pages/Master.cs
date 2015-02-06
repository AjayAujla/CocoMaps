using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;


namespace CocoMaps.Shared.Pages
{
	public class MasterPage : ContentPage
	{
		ConcordiaMap map;

		public MasterPage(MenuOptions menuItem)
		{
			var viewModel = new MasterViewModel();
			BindingContext = viewModel;

			this.SetValue(Page.TitleProperty, menuItem.Title);
			this.SetValue(Page.IconProperty, menuItem.Icon);

			map = new ConcordiaMap() 
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var position = new Position(45.495774,-73.578252); // Latitude, Longitude

			var pin = new Pin 
			{
				Type = PinType.Place,
				Position = position,
				Label = "Custom pin",
				Address = "I'm in love with the Coco"
			};

			map.Pins.Add(pin);

			var street = new Button { Text = "Street" };
			var hybrid = new Button { Text = "Hybrid" };
			var satellite = new Button { Text = "Satellite" };

			street.Clicked += HandleClicked;
			hybrid.Clicked += HandleClicked;
			satellite.Clicked += HandleClicked;


			var segments = new StackLayout 
			{ 
				Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = {street, hybrid, satellite}
			};


			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			stack.Children.Add (segments);
			Content = stack;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) 
			{
			case "Street":
				map.MapType = MapType.Street;
				break;
			case "Hybrid":
				map.MapType = MapType.Hybrid;
				break;
			case "Satellite":
				map.MapType = MapType.Satellite;
				break;
			}
		}
	}

}