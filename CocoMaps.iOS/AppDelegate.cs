using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin;
using CocoMaps.Shared.CustomViews;
using CocoMaps.Shared.Pages;
using Xamarin.Forms.Platform.iOS;

namespace CocoMaps.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            window = new UIWindow (UIScreen.MainScreen.Bounds);
            
			CocoMapsApp.Init(typeof(CocoMapsApp).Assembly);
            Forms.Init();
            FormsMaps.Init();


            UINavigationBar.Appearance.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
			UINavigationBar.Appearance.TintColor = CocoMaps.Shared.Helpers.Color.Blue.ToUIColor();
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White
            });

			LoadApplication (new App ());

			return base.FinishedLaunching (app,options);
        }
    }
}

