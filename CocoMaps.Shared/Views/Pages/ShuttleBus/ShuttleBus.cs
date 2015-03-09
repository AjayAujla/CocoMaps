using System;

using Xamarin.Forms;

using CocoMaps.Models;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class ShuttleBus : ContentPage
	{
		private Grid headers;
		private Grid schedule;

		public ShuttleBus (IMenuOptions menuItem, string pageName)
		{
			var viewModel = new MasterViewModel ();
			this.BindingContext = viewModel;

			this.SetValue (Page.TitleProperty, pageName);
			this.SetValue (Page.IconProperty, menuItem.Icon);

			this.headers = new Grid {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition {
						Height = GridLength.Auto,
					},
					new RowDefinition {
						Height = GridLength.Auto,
					}
				},
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength (100, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (100, GridUnitType.Star)
					}
				},
			};

			this.headers.Children.Add (new Label {
				Text = pageName + " Shuttle Bus Schedule",
				FontAttributes = FontAttributes.Bold,
				FontSize = 30,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			}, 0, 2, 0, 1);

			this.headers.Children.Add (new Label {
				Text = "Departures from LOY",
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			}, 0, 1);

			this.headers.Children.Add (new Label {
				Text = "Departures from SGW",
				FontAttributes = FontAttributes.Bold,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			}, 1, 1);

			this.schedule = new Grid {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = new GridLength (100, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (100, GridUnitType.Star)
					}
				},
			};

			RetrieveSchedule ();
			PopulateScheduleWithTimes ("SGW");

			// Building the interface
			this.Padding = new Thickness (10, Device.OnPlatform (20, 20, 0), 10, 5);

			this.Content = new StackLayout {
				Children = {
					this.headers,
					new ScrollView {
						Content = this.schedule,
						VerticalOptions = LayoutOptions.FillAndExpand,
					}
				}
			};
		}

		public /*async*/ void RetrieveSchedule ()
		{
			Console.WriteLine ("Before getSchedule");
			//List<String> LOYSchedule = /*await*/ RequestShuttleBusSchedule.getInstance.getLOYSchedule ();
			Console.WriteLine ("After getSchedule");
		}

		public void PopulateFridayLOYDepartures ()
		{
			PopulateScheduleWithTimes ("LOY", RequestShuttleBusSchedule.getInstance.FridayLOYDepartures);
		}

		public void PopulateScheduleWithTimes (string campus, List<String> departures)
		{
			//RequestShuttleBusSchedule.getInstance.NonFridayLOYDepartures;
			//RequestShuttleBusSchedule.getInstance.NonFridaySGWDepartures;
			//RequestShuttleBusSchedule.getInstance.FridaySGWDepartures;

			DateTime times = DateTime.Now;

			for (int i = 2; i < 50; ++i) {

				this.schedule.RowDefinitions.Add (
					new RowDefinition { 
						Height = GridLength.Auto,
					}
				);

				Label time = new Label {
					Text = times.ToShortTimeString (),
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};

				TimeSpan now = DateTime.Now.TimeOfDay;
				TimeSpan end = new TimeSpan (now.Hours + 1, now.Minutes, 0);

				if (times.TimeOfDay >= now && times.TimeOfDay < end) {
					time.TextColor = Color.Blue;
				}

				times = times.AddMinutes (15);

				time.SetValue (Grid.RowProperty, i);
				switch (campus) {
				case "LOY":
					time.SetValue (Grid.ColumnProperty, 0);
					break;
				case "SGW":
					time.SetValue (Grid.ColumnProperty, 1);
					break;
				}

				this.schedule.Children.Add (time);
			}
		}

		public void HighlightNextDepartures ()
		{
			//time.BackgroundColor = Color.FromRgb (220, 220, 220);
		}
	}
}