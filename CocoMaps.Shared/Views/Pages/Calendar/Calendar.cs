using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared.ViewModels;
using CocoMaps.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Collections.Generic;

using Android.Provider;

namespace CocoMaps.Shared
{
	public class Calendar : ContentPage
	{

		public Calendar (IMenuOptions menuItem, String pageName, List<CalendarItems> CalItems)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, pageName);
			this.SetValue (Page.IconProperty, menuItem.Icon);

			// content://com.android.calendar/calendars
			var calendarsUri = CalendarContract.Calendars.ContentUri;

			string[] calendarsProjection = {
				CalendarContract.Calendars.InterfaceConsts.Id,
				CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
				CalendarContract.Calendars.InterfaceConsts.AccountName
			};


			Label header = new Label {
				Text = "Classes",
				Font = Font.BoldSystemFontOfSize (30),
				HorizontalOptions = LayoutOptions.Center
			};

			// Create the ListView.
			ListView listView = new ListView {
				// Source of data items.
				ItemsSource = CalItems,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate (() => {
					// Create views with bindings for displaying each property.
					Label t1Label = new Label ();
					t1Label.SetBinding (Label.TextProperty, "Title1");

					Label t2Label = new Label ();
					t2Label.SetBinding (Label.TextProperty, "Title2");


					BoxView boxView = new BoxView ();
					boxView.SetBinding (BoxView.ColorProperty, "BoxColor");

					// Return an assembled ViewCell.
					return new ViewCell {
						View = new StackLayout {
							Padding = new Thickness (0, 5),
							Orientation = StackOrientation.Horizontal,
							Children = {
								boxView,
								new StackLayout {
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,
									Children = {
										t1Label,
										t2Label,

									}
								}
							}
						}
					};
				})
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				Children = {
					header,
					listView
				}
			};


		}
	}
}



