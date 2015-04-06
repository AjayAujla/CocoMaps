using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using CocoMaps.Shared;

namespace CocoMaps.Shared.Pages
{
	public class ConcordiaServices : ContentPage
	{
		// Refactoring inspired by: http://www.trsneed.com/using-xamarin-forms-to-create-a-sortable-list-view/

		SearchBar searchBar;
		readonly List<Service> AllServices = new List<Service> ();
		ObservableCollection<Service> _services = new ObservableCollection<Service> ();

		public ObservableCollection<Service> Services {
			get { return _services; }
			set {
				_services = value;
				OnPropertyChanged ("Servicess");
			}
		}

		public ConcordiaServices (IMenuOptions menuItem)
		{
			SetValue (Page.TitleProperty, menuItem.Title);
			SetValue (Page.IconProperty, menuItem.Icon);

			BuildingRepository buildingRepo = BuildingRepository.getInstance;

			// Populating the whole service list
			foreach (Building building in buildingRepo.BuildingList.Values) {
				if (building.Services != null && building.Services.Count > 0) {
					foreach (Service service in building.Services.OrderBy(s=>s.Name)) {
						Services.Add (service);
					}
				}
			}
			AllServices = Services.ToList ();

			// Search bar
			searchBar = new SearchBar {
				Placeholder = "Search for a Concordia Service..."
			};
			searchBar.TextChanged += (sender, e) => FilterServices (searchBar.Text);

			// TO-DO: Use a custom ViewCell to display icons for Directions and for Visit Website, if any,
			// As well as support binding of Details under the text
			ListView servicesListView = new ListView ();
			servicesListView.ItemsSource = Services;
			var cell = new DataTemplate (typeof(TextCell));

			// Binding the cell's "Text" property with its Service "Name" property, etc
			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetValue (TextCell.TextColorProperty, Helpers.Color.Navy.ToFormsColor ());
			cell.SetBinding (TextCell.DetailProperty, "RoomNumber");
			cell.SetValue (TextCell.DetailColorProperty, Color.Gray);
			cell.SetBinding (TextCell.CommandParameterProperty, "URI");

			servicesListView.ItemTemplate = cell;

			// Open service website on click
			servicesListView.ItemSelected += HandleItemSelected;

			Content = new StackLayout {
				Children = {
					searchBar, 
					new ScrollView { Content = servicesListView,
						VerticalOptions = LayoutOptions.FillAndExpand,
					},
				}
			};
		}

		public void FilterServices (string text)
		{
			Services.Clear ();
			AllServices.Where (s => s.Name.ToLower ().Contains (text.ToLower ())).ToList ().ForEach (Services.Add);
		}

		private async void HandleItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			Service selectedItem = (Service)((ListView)sender).SelectedItem as Service;

			if (selectedItem != null) {
				Uri uri;
				if (!String.IsNullOrEmpty (selectedItem.URI)) {
					// Service's URI
					uri = new Uri (selectedItem.URI);
				} else {
					// Concordia Services Web Page
					uri = new Uri ("http://www.concordia.ca/students/campus-services.html");
				}

				// Display alert to let user decide to open the Service's web page on Concordia's website, to retrieve directions, or to cancel operation.
				var serviceClickedInput = await DisplayActionSheet (selectedItem.Name, "Cancel", null, "Go to Web Page", "Get Directions");
				if (serviceClickedInput.Equals ("Go to Web Page")) {
					Device.OpenUri (uri);
				}
				if (serviceClickedInput.Equals ("Get Directions")) {
					/*

					// Failing for "H ", "H-".
					// Can easily make a function to get the right building info, but not important right now.
					string selectedServiceBuildingCode = selectedItem.RoomNumber.Substring(0, 2);
					Building selectedServiceBuilding = BuildingRepository.getInstance.GetBuildingByCode (selectedServiceBuildingCode);

					Console.WriteLine (selectedServiceBuilding.ToString ());*/

					// TODO: Optimized once completed COCO-55: Explore solution to push and pop different pages on the app on a stack.
					/*RootPage menu = this.Parent as RootPage;

						DirectionsViewModel directionsViewModel = DirectionsViewModel.getInstance;
						directionsViewModel.Expand ();

						Navigation.PushModalAsync (menu.pMaster);

						//MenuPage.campusMenuOption.Selected = true;
						//menu.NavigateTo (MenuPage.campusMenuOption);*/
				}
			}
			// de-select the item
			((ListView)sender).SelectedItem = null; 
		}
	}
}