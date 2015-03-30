using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CocoMaps.Shared;
using CocoMaps.Shared.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Json;
using System.Linq;

namespace CocoMaps.Shared
{
	public class FAQ : ContentPage
	{

		public FAQRootObject FAQObj = null;

		public static List<FAQItems> FAQList = new List<FAQItems>{ };

		public FAQ (IMenuOptions menuItem)
		{
			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, menuItem.Title);
			SetValue (Page.IconProperty, menuItem.Icon);

			setFAQList ();

			Label header = new Label {
				Text = "\r\n" + "Frequently Asked Questions",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			// Create the ListView.
			ListView listView = new ListView {
				// Source of data items.
				ItemsSource = FAQList,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate (() => {
					// Create views with bindings for displaying each property.
					Label t1Label = new Label ();
					t1Label.SetBinding (Label.TextProperty, "Question");


					Image icon = new Image ();
					icon.SetBinding (Image.SourceProperty, "IconSource");


					// Return an assembled ViewCell.
					return new ViewCell {
						View = new StackLayout {
							Padding = new Thickness (0, 5),
							Orientation = StackOrientation.Horizontal,
							Children = {
								icon,
								new StackLayout {
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,
									Children = {
										t1Label

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

			listView.ItemSelected += HandleItemSelected;
		}

		async void HandleItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				
				FAQItems eFAQ = e.SelectedItem as FAQItems;

				await Navigation.PushModalAsync(new FAQpage(eFAQ.Question,eFAQ.Answer));
				// de-select the item
				((ListView)sender).SelectedItem = null; 
			}
		}

		public string GetFAQJson ()
		{
			string FAQJsonText = "";

			Assembly assembly = Assembly.GetExecutingAssembly ();
			string[] resources = assembly.GetManifestResourceNames ();

			foreach (string resource in resources) {
				if (resource.Equals ("CocoMaps.Android.FAQ.json")) {
					Stream stream = assembly.GetManifestResourceStream (resource);
					if (stream != null) {
						using (var reader = new System.IO.StreamReader (stream)) {
							FAQJsonText = reader.ReadToEnd ();
						}
					}
				}
			}

			return FAQJsonText;
		}

		public void ProcessFAQJson ()
		{
			FAQObj = JsonConvert.DeserializeObject<FAQRootObject> (GetFAQJson());
		}

		public FAQRootObject getFAQRootObj ()
		{
			if ((FAQObj == null)) {
				ProcessFAQJson();
			}

			return FAQObj;
		}

		public void setFAQList ()
		{
			FAQRootObject FRO = getFAQRootObj ();

			foreach (FAQItem FI in FRO.items) 
			{
				FAQList.Add (new FAQItems (FI.Question,FI.Answer,"faq_icon"));
			}

		}

	}
}