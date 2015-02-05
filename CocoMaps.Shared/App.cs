using System;
using Xamarin.Forms;
using CocoMaps.Shared.Pages;
using CocoMaps.Shared;
using System.Drawing;

namespace CocoMaps
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new RootPage();

<<<<<<< HEAD
			DependencyService.Get<ITextToSpeech>().Speak("Welcome to CocoMaps");
=======
			DependencyService.Get<ITextToSpeech>().Speak("Welcome to CocoMaps, Charlie!");

>>>>>>> origin/master
		}
	}
}

