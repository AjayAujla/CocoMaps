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

		public Calendar (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, "CocoMaps");
			this.SetValue (Page.IconProperty, menuItem.Icon);

			// content://com.android.calendar/calendars
			var calendarsUri = CalendarContract.Calendars.ContentUri;

			string[] calendarsProjection = {
				CalendarContract.Calendars.InterfaceConsts.Id,
				CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
				CalendarContract.Calendars.InterfaceConsts.AccountName
			};

			//var cursor = ManagedQuery (calendarsUri, calendarsProjection, null, null, null);

			Label header = new Label
			{
				Text = "Calendar Events",
				Font = Font.BoldSystemFontOfSize(40),
				HorizontalOptions = LayoutOptions.Center
			};

			// Define some data.
			List<CalendarItems> CalItems = new List<CalendarItems>
			{
				new CalendarItems("SOEN-341","Lecture","Monday","H-431","13:15","14:30", Color.Maroon),
				new CalendarItems("COMP-345","Laboratory","Wednesday","H-807","08:15","10:30", Color.Maroon),
				new CalendarItems("ENCS-282","Tutorial","Thursday","FG-B050","18:15","20:30", Color.Maroon),
				new CalendarItems("COMP-232","Lecture","Friday","H-420","08:15","10:30", Color.Maroon),
				new CalendarItems("COMP-232","Tutorial","Friday","H-420","10:45","12:30", Color.Maroon),
				// ...etc.,...
				//new Person(CalendarContract.Calendars.ContentUri.ToString(), new DateTime(1988, 2, 5), Color.Red)
			};

			// Create the ListView.
			ListView listView = new ListView
			{
				// Source of data items.
				ItemsSource = CalItems,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate(() =>
					{
						// Create views with bindings for displaying each property.
						Label t1Label = new Label();
						t1Label.SetBinding(Label.TextProperty, "Title1");

						Label t2Label = new Label();
						t2Label.SetBinding(Label.TextProperty, "Title2");


						BoxView boxView = new BoxView();
						boxView.SetBinding(BoxView.ColorProperty, "BoxColor");

						// Return an assembled ViewCell.
						return new ViewCell
						{
							View = new StackLayout
							{
								Padding = new Thickness(0, 5),
								Orientation = StackOrientation.Horizontal,
								Children = 
								{
									boxView,
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Spacing = 0,
										Children = 
										{
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
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children = 
				{
					header,
					listView
				}
				};


		}
	}
}



