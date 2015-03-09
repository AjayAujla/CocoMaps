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

		public override int MenuNum { get { return 1; } }
	}

	public class Campus_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Campus Maps"; } }

		public override string Icon { get { return "campusIcon.png"; } }

		public override int MenuNum { get { return 2; } }
	}

	public class pInterest_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Points of Interest"; } }

		public override string Icon { get { return "poiIcon.png"; } }

		public override int MenuNum { get { return 3; } }
	}

	public class ConcordiaServices_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Concordia Services"; } }

		public override string Icon { get { return "poiIcon.png"; } }

		public override int MenuNum { get { return 4; } }

	}

	public class NextClass_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Next Class"; } }

		public override string Icon { get { return "classIcon.png"; } }

		public override int MenuNum { get { return 5; } }
	}

	public class bDirections_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Building Directions"; } }

		public override string Icon { get { return "buildingIcon.png"; } }

		public override int MenuNum { get { return 6; } }
	}

	public class iDirections_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Indoor Directions"; } }

		public override string Icon { get { return "classIcon.png"; } }

		public override int MenuNum { get { return 7; } }

	}

	public class Calendar_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Calendar"; } }

		public override string Icon { get { return "calendarIcon.png"; } }

		public override int MenuNum { get { return 8; } }
	}

	/*public class Bookmark_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Bookmarks"; } }

		public override string Icon { get { return "calendarIcon.png"; } }

		public override int MenuNum { get { return 9; } }
	} */
	public class Settings_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Settings"; } }

		public override string Icon { get { return "settingsIcon.png"; } }

		public override int MenuNum { get { return 9; } }
	}

	public abstract class IMenuOptions
	{
		public virtual string Title { get { return Title; } }

		public virtual int Count { get; set; }

		public virtual bool Selected { get; set; }

		public virtual string Icon { get { return Icon; } }

		public virtual int MenuNum { get { return MenuNum; } }

		public ImageSource IconSource { get { return ImageSource.FromFile (Icon); } }
	}
		
}