using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;

using CocoMaps.Shared.Helpers;
using CocoMaps.Models;


namespace CocoMaps.Shared.Pages
{
	public class ConcordiaServices : ContentPage
	{
		SearchBar searchBar;
		Label resultsLabel;
		Label serviceLabel;
		Label indoorAddressLabel;
		Button directionsButton;
		Button toServiceWebsiteButton;

		public ConcordiaServices (IMenuOptions menuItem)
		{
			this.SetValue (Page.TitleProperty, menuItem.Title);
			this.SetValue (Page.IconProperty, menuItem.Icon);


			// Search bar
			this.searchBar = new SearchBar {
				Placeholder = "Search for a Concordia Service",
			};
			this.searchBar.SearchButtonPressed += HandleSearchButtonPressed;
			//this.searchBar.TextChanged += HandleTextChanged;
			//this.searchBar.Unfocused += HandleUnfocused;

			// Service information labels
			this.resultsLabel = new Label ();
			this.serviceLabel = new Label {
				FontAttributes = FontAttributes.Bold,
			};
			this.indoorAddressLabel = new Label ();


			/*// Buttons
			this.directionsButton = new Button {
				Text = "Directions",
				BorderWidth = 0,
				//HorizontalOptions = LayoutOptions.Start,
			};
			this.directionsButton.Clicked += HandleDirectionsClicked;

			this.toServiceWebsiteButton = new Button {
				Text = "Website",
				BorderWidth = 0,
				//HorizontalOptions = LayoutOptions.End,
			};
			this.toServiceWebsiteButton.Clicked += HandleServiceWebsiteClicked;*/


			// Building the interface
			this.Padding = new Thickness (10, Device.OnPlatform (20, 20, 0), 10, 5);
		
			this.Content = new StackLayout { 
				Children = {
					this.searchBar,
					new ScrollView { Content = this.resultsLabel,
						VerticalOptions = LayoutOptions.FillAndExpand,
					},
					//this.serviceLabel,
					//this.indoorAddressLabel,
					//this.directionsButton,
					//this.toServiceWebsiteButton
				}
			};
		}

		/**
		 * Extracts query from search box
		 * Searches against Concordia Services
		 * Returns a list of matches, if any.
		 */
		void SearchQuery (object sender, EventArgs e)
		{
			SearchBar searchBar = (SearchBar)sender;
			string searchText = searchBar.Text;

			var resultsList = new List<Building> ();
			this.resultsLabel.Text = "";
			this.serviceLabel.Text = "";
			this.indoorAddressLabel.Text = "";


			/******************************************************
			BuildingRepository code is simply for testing purposes.
			******************************************************/
			BuildingRepository br = new BuildingRepository ();
			List<Campus> c = br.getCampusList ();


			// Check for a matching query to the search criteria
			foreach (Building building in c.ElementAt (0).Buildings) {
				if (building.Name.IndexOf (searchText, StringComparison.OrdinalIgnoreCase) >= 0) {
					resultsList.Add (building);
				}
			}
			foreach (Building building in c.ElementAt (1).Buildings) {
				if (building.Name.IndexOf (searchText, StringComparison.OrdinalIgnoreCase) >= 0) {
					resultsList.Add (building);
				}
			}


			// Displaying the results, if any
			if (resultsList.Count == 0) {
				this.serviceLabel.Text = String.Format ("\"" + searchText + "\" was not found at Concordia University.");
			} else {
				foreach (Building building in resultsList) {
					this.serviceLabel.Text += String.Format ("Service Name\n");
					this.indoorAddressLabel.Text += String.Format ("Campus " + building.Code + building.Address);

					if (building != resultsList.Last ()) {
						this.serviceLabel.Text += "\n";
					}

					this.serviceLabel.Text += ".";
				}
			}
		}


		void HandleSearchButtonPressed (object sender, EventArgs e)
		{
			SearchQuery (sender, e);
		}

		void HandleTextChanged (object sender, TextChangedEventArgs e)
		{
			SearchQuery (sender, e);
		}

		void HandleUnfocused (object sender, FocusEventArgs e)
		{
			SearchQuery (sender, e);
		}

		void HandleDirectionsClicked (object sender, EventArgs e)
		{

		}

		void HandleServiceWebsiteClicked (object sender, EventArgs e)
		{
			// Supposedly only works for Android. 
			Device.OpenUri (new Uri ("https://www.xamarin.com"));
		}

		void PopulateResultsInList (ref List<Building> resultsList)
		{

		}
	}
}