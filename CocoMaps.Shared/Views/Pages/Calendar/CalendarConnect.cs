using System.IO;
using System.Threading;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace CocoMaps.Shared
{
	public class CalendarConnect
	{


		public CalendarConnect ()
		{

			/*
			UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
				new ClientSecrets
				{
					ClientId = "The id of my public website",
					ClientSecret = "The secret of my public website",
				},
				new[] { CalendarService.Scope.Calendar },
				"user",
				CancellationToken.None).Result;

			// Create the service.
			var service = new CalendarService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential
				});

			return service.Events.List("primary").Execute().Items;
			*/



		}
	}
}

