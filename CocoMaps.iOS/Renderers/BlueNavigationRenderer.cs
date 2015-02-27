using UIKit;
using CocoMaps.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;


[assembly: ExportRenderer (typeof(NavigationRenderer), typeof(BlueNavigationRenderer))]

namespace CocoMaps.iOS
{
	public class BlueNavigationRenderer : NavigationRenderer
	{


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationBar.TintColor = UIColor.White;
			NavigationBar.BarTintColor = CocoMaps.Shared.Helpers.Color.Blue.ToUIColor ();
			NavigationBar.BarStyle = UIBarStyle.Black;
		}
	}
}