﻿using System;
using CocoMaps.Models;
using CocoMaps.Shared.ViewModels;
using Xamarin.Forms;
using Android.Gms.Maps.Model;

namespace CocoMaps.Shared
{
	public class Settings : ContentPage
	{

		// TIP: Use this page for DIY: http://iosapi.xamarin.com/?link=T%3aXamarin.Forms.Cell
		// TO-DO: Save user's preferences in a file on his device

		static public TravelMode TravelMode = TravelMode.walking;

		static public bool useDeviceMap = false;

		static public int poiRadius = 800;

		// as set by Google's API
		int poiRadiusLimit = 50000;

		public Settings (IMenuOptions menuItem)
		{

			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, menuItem.Title);
			SetValue (Page.IconProperty, menuItem.Icon);


			SwitchCell useGoogleMapsCell = new SwitchCell {
				Text = "Use Google Maps App"
			};

			useGoogleMapsCell.OnChanged += (sender, e) => {
				// toggle bool
				useDeviceMap = !useDeviceMap;
				Console.WriteLine ("Use Google Maps? " + useDeviceMap);
			};


			EntryCell poiRadiusCell = new EntryCell {
				Label = "Points of Interest Radius:",
				Placeholder = "meters",
				Text = poiRadius.ToString (),
				Keyboard = Keyboard.Numeric
			};

			poiRadiusCell.Completed += (sender, e) => {
				int radius;
				if (Int32.TryParse (poiRadiusCell.Text, out radius)) {
					if (radius > 0 && radius < poiRadiusLimit)
						poiRadius = radius;
					else {
						DisplayAlert ("Heads Up!", "Maximum radius is 50,000 meters", "OK");
					}
				}
				poiRadiusCell.Text = poiRadius.ToString ();
				Console.WriteLine ("Points of Interest Radius: " + poiRadius);
			};


			Content = new TableView {
				Root = new TableRoot ("Settings") {
					new TableSection ("Map Settings") {

						useGoogleMapsCell,

						poiRadiusCell
					}
				}
			};
		}
	}
}

//						new TextCell {
//							Text = "TextCell Text",
//							Detail = "TextCell Detail"
//						},
//						new ImageCell {
//							Text = "ImageCell Text",
//							Detail = "ImageCell Detail",
//							ImageSource = "http://xamarin.com/images/index/ide-xamarin-studio.png"
//						},
//						new EntryCell {
//							Label = "EntryCell:",
//							Placeholder = "default keyboard",
//							Keyboard = Keyboard.Default
//						}
//					},
//					new TableSection ("Section 2 Title") {
//						new EntryCell {
//							Label = "Another EntryCell:",
//							Placeholder = "phone keyboard",
//							Keyboard = Keyboard.Telephone
//						},
//						new SwitchCell {
//							Text = "SwitchCell:"
//						},
//						new ViewCell {
//							View = new StackLayout {
//								Orientation = StackOrientation.Horizontal,
//								Children = {
//									new Label {
//										Text = "Custom Slider View:"
//									},
//									new Slider {
//										Minimum = 0,
//										Maximum = 100
//									}
//								}
//							}
//						}
//					}
//				}
//			};