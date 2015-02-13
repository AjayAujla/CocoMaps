using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared;

namespace CocoMaps
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new RootPage ();
		
			//DependencyService.Get<ITextToSpeech>().Speak("Welcome to CocoMaps!");
		}

	}
}