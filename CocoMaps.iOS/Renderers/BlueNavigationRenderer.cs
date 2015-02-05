using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CocoMaps.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;


//[assembly: ExportRenderer(typeof(NavigationRenderer), typeof(BlueNavigationRenderer))]
namespace CocoMaps.iOS.Renderers
{
  public class BlueNavigationRenderer : NavigationRenderer
  {
    public BlueNavigationRenderer()
    {
      


    }
    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      this.NavigationBar.TintColor = UIColor.White;
      this.NavigationBar.BarTintColor = CocoMaps.Shared.Helpers.Color.Blue.ToUIColor();
      this.NavigationBar.BarStyle = UIBarStyle.Black;
    }
  }
}