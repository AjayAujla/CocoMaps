﻿using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using CocoMaps.Models;
using CocoMaps.Shared.CustomViews;


namespace CocoMaps.Shared.Pages
{

	public class MenuPage : ContentPage
	{
		readonly List<MenuOptions> OptionItems = new List<MenuOptions>();

		public ListView Menu { get; set; }

		public MenuPage ()
		{
			OptionItems.Add(new Location_MenuOption());
			OptionItems.Add(new Campus_MenuOption());
			OptionItems.Add(new pInterest_MenuOption());
			OptionItems.Add(new bDirections_MenuOption());
			OptionItems.Add(new iDirections_MenuOption());
			OptionItems.Add(new Calendar_MenuOption());
			OptionItems.Add(new Settings_MenuOption());

			BackgroundColor = Color.FromHex("333333");

			var layout = new StackLayout { Spacing = 0, VerticalOptions = LayoutOptions.FillAndExpand };

			var label = new ContentView {
				Padding = new Thickness(10, 36, 0, 5),
				Content = new Xamarin.Forms.Label {
					TextColor = Color.FromHex("AAAAAA"),
					Text = "MENU", 
				}
			};

			Device.OnPlatform (
				iOS: () => ((Xamarin.Forms.Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Micro),
				Android: () => ((Xamarin.Forms.Label)label.Content).Font = Font.SystemFontOfSize (NamedSize.Medium)
			);

			layout.Children.Add(label);

			Menu = new ListView {
				ItemsSource = OptionItems,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent,
			};

			var cell = new DataTemplate(typeof(DarkTextCell));
			cell.SetBinding(TextCell.TextProperty, "Title");
			cell.SetBinding(TextCell.DetailProperty, "Count");
			cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
			cell.SetValue(VisualElement.BackgroundColorProperty, Color.Transparent);

			Menu.ItemTemplate = cell;

			layout.Children.Add(Menu);

			Content = layout;
		}
	}

}
