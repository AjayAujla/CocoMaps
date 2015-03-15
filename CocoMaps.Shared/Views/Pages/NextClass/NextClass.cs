using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CocoMaps.Shared
{
	public class NextClass : ContentPage
	{
		public NextClass (IMenuOptions menuItem ,BaseCalendar BC)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "Next Class");
			SetValue (Page.IconProperty, menuItem.Icon);


			//finalizing



		}


		public string getClassLocation (string dest)
		{
			string destination = dest.Trim ().ToUpper ();

			string[] destination_array = destination.Split ('-');

			string campusLoc = destination_array [0];

			string roomLoc = destination_array [1];


			BuildingRepository BR = BuildingRepository.getInstance;

			Campus campus = BR.GetCampusByCode (campusLoc);

			Building building;
			BR.BuildingList.TryGetValue (roomLoc, out building);
			return building.Address;

		}

		static void HandleNextClassButton (string start, string end)
		{
			RequestDirections RD;

			//Task<Directions> GDirections = RD.getDirections(start , end , TravelMode.walking);

		}

	}

}