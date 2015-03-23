using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	[Table ("BookmarksTable")]
	public class BookmarkItems
	{

		public BookmarkItems ()
		{

		}

		public BookmarkItems (string name, string address, Position position, string icon)
		{
			this.bName = name;
			this.bAddress = address;
			this.bLatitude = position.Latitude;
			this.bLongitude = position.Longitude;
			this.IconSource = ImageSource.FromFile (icon);
		}

		[PrimaryKey, AutoIncrement, Column ("_Id")]
		public int ID {
			get;
			set;
		}

		public string bName { 
			set; 
			get; 
		}

		public string bAddress { 
			get; 
			set;
		}

		public double bLatitude {
			get;
			set;
		}

		public double bLongitude {
			get;
			set;
		}

		[Ignore]
		public ImageSource IconSource { 
			set; 
			get;
		}

		//public Color BoxColor { private set; get; }

		public override string ToString ()
		{
			return string.Format ("[BookmarkItems: ID={0}, Address={1}, Latitude={2}, Longitude={3}", ID, bAddress, bLatitude, bLongitude);
		}
	}
}