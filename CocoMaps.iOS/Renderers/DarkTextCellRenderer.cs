using Xamarin.Forms.Platform.iOS;
using CocoMaps.Shared.CustomViews;
using Xamarin.Forms;
using UIKit;
using CocoMaps.iOS;

[assembly: ExportCell (typeof (DarkTextCell), typeof (DarkTextCellRenderer))]

namespace CocoMaps.iOS
{

    public class DarkTextCellRenderer : ImageCellRenderer
    {
		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cellView = base.GetCell (item, reusableCell, tv);

            cellView.BackgroundColor = Color.Transparent.ToUIColor();
            cellView.TextLabel.TextColor = Color.FromHex("FFFFFF").ToUIColor();
            cellView.DetailTextLabel.TextColor = Color.FromHex("AAAAAA").ToUIColor();

            tv.SeparatorColor = Color.FromHex("444444").ToUIColor();

            return cellView;
        }
    }
    
}
