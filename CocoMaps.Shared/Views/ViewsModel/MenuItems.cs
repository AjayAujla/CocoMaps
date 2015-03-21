using Xamarin.Forms;

namespace CocoMaps.Shared
{
	public class Campus_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Campus Maps"; } }

		public override string Icon { get { return "ic_menu_maps.png"; } }
	}

	public class ConcordiaServices_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Concordia Services"; } }

		public override string Icon { get { return "ic_menu_services.png"; } }
	}
	public class Bookmarks_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Bookmarks"; } }

		public override string Icon { get { return "ic_menu_bookmark.png"; } }
	}

	public class IndoorDirections_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Indoor Directions"; } }

		public override string Icon { get { return "ic_menu_indoor.png"; } }
	}

	public class Calendar_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Calendar"; } }

		public override string Icon { get { return "ic_menu_calendar.png"; } }
	}

	public class ShuttleBus_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Shuttle Bus"; } }

		public override string Icon { get { return "ic_menu_shuttleschedule.png"; } }
	}

	public class ShuttleBusTracker_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Shuttle Bus Tracker"; } }

		public override string Icon { get { return "ic_menu_shuttletracker.png"; } }
	}

	public class Settings_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Settings"; } }

		public override string Icon { get { return "ic_menu_settings.png"; } }
	}



	public class Exit_MenuOption : IMenuOptions
	{
		public override string Title { get { return "Exit Application"; } }

		public override string Icon { get { return "ic_menu_exit.png"; } }
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