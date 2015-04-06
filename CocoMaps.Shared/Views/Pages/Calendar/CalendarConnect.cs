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

#if __ANDROID__
using CocoMaps.Android;
#endif
namespace CocoMaps.Shared
{
	public class CalendarConnect : AuthBasePage
	{

		public CalendarViewModel ViewModel
		{
			get { return BindingContext as CalendarViewModel; }
			set { BindingContext = value; }
		}

		public BaseCalendar gCalendarPage;
		public BaseCalendar lCalendarPage;

		private Button CalButton;
		private Button LocalCalButton;
		private Button CalSimButton;

		private ActivityIndicator cAI = new ActivityIndicator();

		public CalendarListRootObject CLRO = new CalendarListRootObject();

		public CalendarRootObject CRO = new CalendarRootObject();

		public CalendarRootObject LCRO = new CalendarRootObject();

		private Label CalendarNameText;
		private string CalendarIDText;

		public bool gCalendarFound = false;

		public CalendarConnect (IMenuOptions menuItem)
		{

			MessagingCenter.Subscribe<App> (this, "Authenticated", (senderr) => {

				ViewModel = new CalendarViewModel();

				this.SetValue (Page.TitleProperty, "Calendar");
				this.SetValue (Page.IconProperty, menuItem.Icon);



				CalendarNameText = new Label {
					Text = "\r\n" + "Searching for Calendars",
					FontSize = 20,
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				};


				CalButton = new Button
				{
					Text = "Load Google Calendar",
					TextColor = Color.Red,
					IsVisible = false
				};

				LocalCalButton = new Button
				{
					Text = "Load Local Calendar",
					TextColor = Color.Red,
					IsVisible = false
				};


				CalSimButton = new Button
				{
					Text = "Button Simulator",
					TextColor = Color.Red,
					IsVisible = false
				};

				CalSimButton.PropertyChanged += async (sender, args) =>
				{
					await GetCalendarListData();

					if(gCalendarFound)
					{
						await GetCalendarData(CalendarIDText);
					}

				};

				CalButton.Clicked += async (sender, args) =>
				{

					if ((gCalendarPage == null)) 
					{
						gCalendarPage= new BaseCalendar(menuItem , CRO);
					}

					Navigation.PushModalAsync (gCalendarPage);
				};

				LocalCalButton.Clicked += async (sender, args) =>
				{
					ProcessCalendarJson();

					if ((lCalendarPage == null)) 
					{
						lCalendarPage= new BaseCalendar(menuItem , LCRO);
					}

					Navigation.PushModalAsync (lCalendarPage);
				};

				// SIMULATE BUTTON FUNCTION - DO NOT REMOVE
				/**/if(CalSimButton.TextColor == Color.Black)
				/**/{
				/**/	CalSimButton.TextColor = Color.Red;
				/**/}
				/**/else
				/**/{
				/**/	CalSimButton.TextColor = Color.Black;
				/**/}
				// DO NOT REMOVE THE ABOVE CODE

				this.Content = new StackLayout
				{
					Padding = 10,
					Spacing = 10,

					Children =
					{ 
						CalendarNameText,
						cAI,
						CalButton,
						LocalCalButton
					}
					};




			});
		}

		private async Task GetCalendarListData()
		{
			cAI.IsRunning = true;

			CLRO = await ViewModel.GetCalendarListResult ();

			string calName = "";
			string calID = "";

			foreach (CalendarListItem OCI in CLRO.items) 
			{
				string[] CalListSummary = OCI.summary.ToLower ().Split ('-');

				if (CalListSummary [0] == (("@ConcordiaCalendar").ToLower())) 
				{
					calName = OCI.summary;
					calID = OCI.id;
				}
			}

			if(calName != "")
			{
				calName = "Google Calendar Found : " + "\r\n" + calName;

				CalButton.IsVisible = true;
				LocalCalButton.IsVisible = true;

				gCalendarFound = true;
			}
			else
			{
				calName = "No Valid Calendar Found : " + "\r\n" + "Please view the FAQ how to set it up";
				LocalCalButton.IsVisible = true;
			}


			CalendarNameText.Text = calName;
			CalendarIDText = calID;

			cAI.IsRunning = false;

		}


		private async Task GetCalendarData(string CalID)
		{
			cAI.IsRunning = true;

			CRO = await ViewModel.GetCalendarResult (CalID);

			cAI.IsRunning = false;

		}

		public string GetLocalCalendar ()
		{
			string CalJsonText = "";

			Assembly assembly = Assembly.GetExecutingAssembly ();
			string[] resources = assembly.GetManifestResourceNames ();

			foreach (string resource in resources) {
				if (resource.Equals ("CocoMaps.Android.LocalCalendar.json")) {
					Stream stream = assembly.GetManifestResourceStream (resource);
					if (stream != null) {
						using (var reader = new System.IO.StreamReader (stream)) {
							CalJsonText = reader.ReadToEnd ();
						}
					}
				}
			}

			return CalJsonText;
		}


		public void ProcessCalendarJson ()
		{
			LCRO = JsonConvert.DeserializeObject<CalendarRootObject> (GetLocalCalendar ());
		}



	}
}
