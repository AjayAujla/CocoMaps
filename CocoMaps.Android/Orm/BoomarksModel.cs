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

		public BookmarkItems (string name, string address, Position position, string bicon)
		{
			this.bName = name;
			this.bAddress = address;
			this.bPosition = position;
			this.IconSource = ImageSource.FromFile (bicon);
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

		public Position bPosition {
			get;
			set;
		}

		public ImageSource IconSource { 
			set; 
			get;
		}

		//public Color BoxColor { private set; get; }

		public override string ToString ()
		{
			return string.Format ("[BookmarkItems: ID={0}, Address={1}", ID, bAddress);
		}
	}
}