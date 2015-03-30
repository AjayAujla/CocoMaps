using System;
using Xamarin.Forms;
using CocoMaps.Shared.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using System.Collections;

namespace CocoMaps.Shared
{
	public class FAQpage : ContentPage
	{
		public FAQpage (string Que , string Ans)
		{

			var viewModel = new MasterViewModel ();
			BindingContext = viewModel;

			SetValue (Page.TitleProperty, "F.A.Q");
			SetValue (Page.IconProperty, "fav_icon");


			Label question = new Label {
				Text = "\r\n" + Que,
				FontSize = 20,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};

			Label answer = new Label
			{
				Text = Ans,
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center
			};

			this.Content = new StackLayout
			{
				Children = 
				{
					question,
					answer
				}
			};
		}
	}
}

