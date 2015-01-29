using MobileCRM.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileCRM.Shared.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel(Navigation);

			BackgroundColor = Color.FromHex ("#932439");
            var layout = new StackLayout { Padding = 10 };

			// TODO: Make the logo appear... this does not work :(
			Image concordia_logo = new Image
			{
				Source = ImageSource.FromFile("concordia_logo.png"),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			layout.Children.Add(concordia_logo);
            
			var continueButton = new Button { Text = "Continue", BackgroundColor = Color.White, TextColor = Color.Black };

			DependencyService.Get<IDrawFaculty>().Draw();

			continueButton.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);
			layout.Children.Add(continueButton);

            Content = new ScrollView { Content = layout };
        }
    }
}
