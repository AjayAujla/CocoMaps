using System;
using System.Collections.Generic;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;

namespace CocoMaps.Shared
{
	public class ShuttleBus : ContentPage
	{
		private Grid headers;
		private Grid schedule;

		public ShuttleBus (IMenuOptions menuItem, String pageName)
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

			PopulateDepartures (pageName);

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

		/*	
		 * 	Populate list of departures the currently selected tab
		 */
		public void PopulateDepartures (String pageName)
		{
			RequestShuttleBusSchedule shuttleBusSchedule = RequestShuttleBusSchedule.getInstance;

			if (pageName != "Friday") {
				PopulateDayDepartures (pageName, shuttleBusSchedule.NonFridayLOYDepartures, shuttleBusSchedule.NonFridaySGWDepartures);
			}
			if (pageName == "Friday") {
				PopulateDayDepartures (pageName, shuttleBusSchedule.FridayLOYDepartures, shuttleBusSchedule.FridaySGWDepartures);
			}
		}

		/*
		 * 	Populate list of departures for both campuses
		 */
		public void PopulateDayDepartures (String pageName, List<String> LOYdepartures, List<String> SGWdepartures)
		{
			int maximumRows = LOYdepartures.Count > SGWdepartures.Count ? LOYdepartures.Count : SGWdepartures.Count;
			int row = 0;

			for (int i = 0; i < maximumRows; ++i) {

				DateTime LOYtime = Convert.ToDateTime (LOYdepartures [i]);
				DateTime SGWtime = Convert.ToDateTime (SGWdepartures [i]);
				TimeSpan now = DateTime.Now.TimeOfDay;

				// Skipping this iteration to display the departure time if departure time has already passed current time
				if (LOYtime.TimeOfDay < now && SGWtime.TimeOfDay < now) {
					continue;
				}

				this.schedule.RowDefinitions.Add (
					new RowDefinition { 
						Height = GridLength.Auto,
					}
				);

				Label LOYTimeLabel = new Label {
					Text = LOYdepartures [i],
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};

				Label SGWTimeLabel = new Label {
					Text = SGWdepartures [i],
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
				};

				TimeSpan end = new TimeSpan (now.Hours + 1, now.Minutes, 0);

				// Highlighting next upcoming departures within the hour
				if (pageName == DateTime.Now.DayOfWeek.ToString ()) {
					if (LOYtime.TimeOfDay >= now && LOYtime.TimeOfDay < end) {
						LOYTimeLabel.TextColor = Color.Blue;
					}
					if (SGWtime.TimeOfDay >= now && SGWtime.TimeOfDay < end) {
						SGWTimeLabel.TextColor = Color.Blue;
					}
				}

				LOYTimeLabel.SetValue (Grid.RowProperty, row);
				LOYTimeLabel.SetValue (Grid.ColumnProperty, 0);
				this.schedule.Children.Add (LOYTimeLabel);

				SGWTimeLabel.SetValue (Grid.RowProperty, row);
				SGWTimeLabel.SetValue (Grid.ColumnProperty, 1);
				this.schedule.Children.Add (SGWTimeLabel);

				++row;
			}
		}
	}
}
