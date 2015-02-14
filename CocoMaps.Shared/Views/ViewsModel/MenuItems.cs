using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CocoMaps.Models
{

	public class Location_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Current Location"; } }

		public override string Icon { get { return "locationIcon.png"; } }
	}

	public class Campus_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Campus Maps"; } }

		public override string Icon { get { return "campusIcon.png"; } }
	}

	public class pInterest_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Points of Interest"; } }

		public override string Icon { get { return "poiIcon.png"; } }
	}

	public class ConcordiaServices_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Concordia Services"; } }

		public override string Icon { get { return "poiIcon.png"; } }
	}

	public class bDirections_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Building Directions"; } }

		public override string Icon { get { return "buildingIcon.png"; } }
	}

	public class iDirections_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Indoor Directions"; } }

		public override string Icon { get { return "classIcon.png"; } }
	}

	public class Calendar_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Calendar"; } }

		public override string Icon { get { return "calendarIcon.png"; } }
	}

	public class Settings_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Settings"; } }

		public override string Icon { get { return "settingsIcon.png"; } }
	}

	public abstract class IMenuOptions
	{
		public virtual string Title { get { return Title; } }

		public virtual int Count { get; set; }

		public virtual bool Selected { get; set; }

		public virtual string Icon { get { return Icon; } }

		public ImageSource IconSource { get { return ImageSource.FromFile (Icon); } }
	}
		
}

