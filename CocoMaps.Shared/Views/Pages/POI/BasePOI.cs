using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class BasePOI : TabbedPage
	{
		public BasePOI (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "Points Of Interest");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			var foodPOI = new POI (menuItem,"Food");
			var cafePOI = new POI (menuItem,"Coffee");
			var libPOI = new POI (menuItem,"Library");

			this.Children.Add(foodPOI);
			this.Children.Add(cafePOI);
			this.Children.Add(libPOI);

		}
	}
}

