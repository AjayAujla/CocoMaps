using System.Collections.Generic;
using System.Linq;
using CocoMaps.Models;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared.ViewModels
{
	public class MapViewModel : MasterViewModel
	{
		public static readonly Position NullPosition = new Position(0, 0);

		public MapViewModel()
		{
			Title = "Map";
			Icon = "map.png";
		}
			
	}
}
