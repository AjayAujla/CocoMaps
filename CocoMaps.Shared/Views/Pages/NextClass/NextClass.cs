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
	public class NextClass : ContentPage
	{
		public NextClass (IMenuOptions menuItem)
		{

			string startLocation;
			string destination;

			// Test

			string testClass = "SGW-FG-965";
			startLocation = "7141 Sherbrooke Street W.";

			destination = getClassLocation (testClass);

			startLocation = startLocation + " Montreal QC";
			destination = destination + " Montreal QC";


			Label label0 = new Label
			{
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Next Class : "
			};


			Label label1 = new Label
			{
				Text = testClass ,

				Font = Font.SystemFontOfSize(NamedSize.Large) 
			};

			Label label2 = new Label
			{
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Destination : "
			};

			Label label3 = new Label
			{
				Text = destination ,

				Font = Font.SystemFontOfSize(NamedSize.Large)
			};

			Label label4 = new Label
			{
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				Text = "Current Location : "
			};

			Label label5 = new Label
			{
				Text = startLocation ,

				Font = Font.SystemFontOfSize(NamedSize.Large)
			};

			this.Content = new StackLayout
			{
				Children =
				{
					label0,
					label1,
					label2,
					label3,
					label4,
					label5
				}
				};



		}


		public string getClassLocation(string dest)
		{
			string destination = dest.Trim().ToUpper();

			string[] destination_array = destination.Split('-');

			string campusLoc = destination_array [0];

			string roomLoc = destination_array [1];


			BuildingRepository BR = new BuildingRepository();

			Campus campus = BR.GetCampusByCode(campusLoc);

			Building building = campus.GetBuildingByCode(roomLoc);


			return building.Address;

		}



	}
}

