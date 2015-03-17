using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using CocoMaps.Shared;
using CocoMaps.Shared.CustomViews;
using Java.Net;

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
			foreach (Building building in buildingRepo.BuildingList.Values)
				if (building.Services != null && building.Services.Count > 0)
					foreach (Service service in building.Services.OrderBy(s=>s.Name))
						Services.Add (service);
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
			servicesListView.ItemSelected += (sender, e) => {
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
					Device.OpenUri (uri);
				}
				((ListView)sender).SelectedItem = null; // de-select the row
			};

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
	}
}