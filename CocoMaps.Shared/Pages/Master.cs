using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;

namespace CocoMaps.Shared.Pages
{
	public class MasterPage : TabbedPage
	{
		public MapPage Map { get; private set; }

		public MasterPage(MenuOptions menuItem)
		{
			var viewModel = new MapViewModel();
			BindingContext = viewModel;

			this.SetValue(Page.TitleProperty, menuItem.Title);
			this.SetValue(Page.IconProperty, menuItem.Icon);

			Map = new MapPage(viewModel);

			this.Children.Add(Map);
		}
	}

}