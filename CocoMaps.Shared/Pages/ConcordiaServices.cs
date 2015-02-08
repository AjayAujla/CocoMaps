﻿using System;
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

		public ConcordiaServices (IMenuOptions menuItem)
		{
			this.SetValue (Page.TitleProperty, menuItem.Title);
			this.SetValue (Page.IconProperty, menuItem.Icon);

			this.searchBar = new SearchBar {
				Placeholder = "Search for a Concordia Service",
			};

			this.searchBar.SearchButtonPressed += HandleSearchButtonPressed;
			//this.searchBar.TextChanged += HandleTextChanged;
			//this.searchBar.Unfocused += HandleUnfocused;

			this.resultsLabel = new Label ();

			this.Padding = new Thickness (10, Device.OnPlatform (20, 20, 0), 10, 5);

			this.Content = new StackLayout { 
				Children = {
					this.searchBar,
					new ScrollView { Content = resultsLabel,
						VerticalOptions = LayoutOptions.FillAndExpand
					}
				}
			};
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

		/**
		 * Extracts query from search box
		 * Searches against Concordia Services
		 * Returns a list of matches, if any.
		 */
		void SearchQuery (object sender, EventArgs e)
		{
			SearchBar searchBar = (SearchBar)sender;
			string searchText = searchBar.Text;

			var list = new List<Tuple<string, string>> ();
			this.resultsLabel.Text = "";

			/******************************************************
			BuildingRepository code is simply for testing purposes.
			******************************************************/
			BuildingRepository br = new BuildingRepository ();
			List<Campus> c = br.getCampusList ();

			foreach (Building building in c.ElementAt (0).Buildings) {
				if (building.Name.IndexOf (searchText, StringComparison.OrdinalIgnoreCase) >= 0) {
					list.Add (Tuple.Create<string, string> (building.Name, building.Code));
				}
			}

			if (list.Count == 0) {
				this.resultsLabel.Text = String.Format ("\"" + searchText + "\" was not found as a Concordia Service.");
			} else {
				this.resultsLabel.Text = String.Format ("Found the Services\n");

				foreach (Tuple<string, string> tuple in list) {
					this.resultsLabel.Text += String.Format ("\n" + tuple.Item2 + ": " + tuple.Item1);

					if (tuple != list.Last ()) {
						this.resultsLabel.Text += ", ";
					}

					this.resultsLabel.Text += ".";
				}
			}
		}
	}
}