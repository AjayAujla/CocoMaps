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
	public class CalendarViewModel : MasterViewModel
	{

		public async Task<CalendarListRootObject> GetCalendarListResult()
		{
			try
			{
				string token = App.Instance.Token;

				var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/users/me/calendarList?access_token={0}", token);

				JsonValue CalListJson = await JsonUtil.FetchJsonAsync (requestUrl);

				return JsonConvert.DeserializeObject<CalendarListRootObject> (CalListJson.ToString ());

			}
			catch (System.Exception exception)
			{
				return null;
			}

		}


		public async Task<CalendarRootObject> GetCalendarResult(string CalID)
		{
			try
			{
				string token = App.Instance.Token;

				var requestUrl = string.Format ("https://www.googleapis.com/calendar/v3/calendars/{0}/events?alwaysIncludeEmail=false&singleEvents=false&fields=description%2Cetag%2Citems(description%2Cend%2Cetag%2Cid%2Clocation%2Cstart%2Csummary)%2Csummary&access_token={1}", CalID, token);

				JsonValue OnlineCalJson = await JsonUtil.FetchJsonAsync (requestUrl);

				return JsonConvert.DeserializeObject<CalendarRootObject> (OnlineCalJson.ToString ());

			}
			catch (System.Exception exception)
			{
				return null;
			}

		}


	}
}

