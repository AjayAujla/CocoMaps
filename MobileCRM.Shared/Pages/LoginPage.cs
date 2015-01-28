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

			Image concordia_logo = new Image
			{
				Source = ImageSource.FromFile("concordia_logo.png"),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			layout.Children.Add(concordia_logo);

//            var username = new Entry { Placeholder = "Username" };
//            username.SetBinding(Entry.TextProperty, LoginViewModel.UsernamePropertyName);
//            layout.Children.Add(username);
//
//            var password = new Entry { Placeholder = "Password", IsPassword = true };
//            password.SetBinding(Entry.TextProperty, LoginViewModel.PasswordPropertyName);
//            layout.Children.Add(password);
            
			var directionsButton = new Button { Text = "Continue", BackgroundColor = Color.White, TextColor = Color.Black };
			directionsButton.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);
			layout.Children.Add(directionsButton);

            Content = new ScrollView { Content = layout };
        }
    }
}
