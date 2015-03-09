using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Json;
using HtmlAgilityPack;
using System.Net.Http;

namespace CocoMaps.Shared
{
	public class RequestShuttleBusSchedule
	{
		private static RequestShuttleBusSchedule requestShuttleBusSchedule;

		public List<String> NonFridayLOYDepartures = new List<String> {
			"7:45",
			"8:00",
			"8:15",
			"8:30",
			"8:45",
			"9:00",
			"9:15",
			"9:30",
			"9:45",
			"10:00",
			"10:15",
			"10:30",
			"10:55",
			"11:15",
			"11:30",
			"12:00",
			"12:30",
			"13:00",
			"13:30",
			"14:00",
			"14:30",
			"15:00",
			"15:30",
			"16:00",
			"16:30",
			"17:00",
			"17:30",
			"18:00",
			"18:30",
			"19:00",
			"19:30",
			"20:00",
			"20:15",
			"20:30",
			"20:45",
			"21:10",
			"21:35",
			"22:00",
			"22:30",
			"23:00"
		};
		public List<String> NonFridaySGWDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:30",
			"8:45",
			"9:00",
			"9:15",
			"9:30",
			"9:45",
			"10:00",
			"10:15",
			"10:30",
			"11:00",
			"11:15",
			"11:45",
			"12:00",
			"12:30",
			"13:00",
			"13:30",
			"14:00",
			"14:30",
			"15:00",
			"15:30",
			"16:00",
			"16:30",
			"17:00",
			"17:30",
			"18:00",
			"18:30",
			"19:00",
			"19:30",
			"19:45",
			"20:00",
			"20:15",
			"20:45",
			"21:00",
			"21:10",
			"21:35",
			"22:00",
			"22:00",
			"23:30"
		};

		public List<String> FridayLOYDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:45",
			"9:00",
			"9:15",
			"9:45",
			"10:00",
			"10:15",
			"11:00",
			"11:15",
			"11:45",
			"12:00",
			"12:15",
			"12:45",
			"13:15",
			"13:30",
			"13:45",
			"14:15",
			"14:30",
			"14:45",
			"15:15",
			"15:30",
			"15:45",
			"16:15",
			"16:30",
			"16:45",
			"17:15",
			"18:15",
			"18:45",
			"19:15",
			"19:45"
		};
		public List<String> FridaySGWDepartures = new List <String> {
			"7:45",
			"8:15",
			"8:45",
			"9:15",
			"9:30",
			"9:45",
			"10:15",
			"10:30",
			"10:45",
			"11:30",
			"11:45",
			"12:15",
			"12:45",
			"13:00",
			"13:15",
			"13:45",
			"14:00",
			"14:15",
			"14:45",
			"15:00",
			"15:15",
			"15:45",
			"16:00",
			"16:15",
			"16:45",
			"17:15",
			"17:45",
			"18:15",
			"18:45",
			"19:15",
			"19:45"
		};

		public /*async Task*/List<String> getLOYSchedule ()
		{
			//String uri = "https://www.concordia.ca/maps/shuttle-bus.html";
			//HtmlDocument doc = await (new HtmlWeb ()).LoadFromWebAsync (uri);

			HtmlDocument doc = new HtmlDocument ();
			string filePath = "C:\\Users\\Ajayveer Singh Aujla\\Desktop\\SB.html";
			doc.Load (new MemoryStream (Encoding.UTF8.GetBytes (filePath)));

			StreamWriter sw = new StreamWriter ("C:\\a.html");
			doc.Save (sw);
			sw.Close ();

			/*
			HtmlDocument doc = new HtmlDocument ();
			HttpClient client = new HttpClient ();
			HttpResponseMessage response = client.GetAsync (uri).Result;
			response.EnsureSuccessStatusCode ();
			string responseBody = response.Content.ReadAsStringAsync ().Result;
			doc.LoadHtml (responseBody);
			*/

			//HtmlWeb web = new HtmlWeb ();
			//HtmlDocument doc = async web.LoadFromWebAsync (uri);

			var node = doc.DocumentNode.Descendants ("div").Where (d => d.Attributes.Contains ("class") && d.Attributes ["class"].Value.Contains ("concordia-table   horizontalLines verticalLines table-striped"));


			var table1 = doc.DocumentNode.DescendantsAndSelf ();
			var tableDiv = doc.DocumentNode.DescendantsAndSelf ("table");
			var tableConu = doc.DocumentNode.DescendantsAndSelf ("div").Where (d => d.Attributes ["class"] != null && d.Attributes ["class"].Value == "concordia-table   horizontalLines verticalLines table-striped");
			var tableDivConu = doc.DocumentNode.DescendantsAndSelf ("div").Where (d => d.Attributes ["class"] != null);


			Console.WriteLine ("node.Count () " + node.Count ());
			Console.WriteLine ("table1.Count () " + table1.Count ());
			Console.WriteLine ("tableDiv.Count () " + tableDiv.Count ());
			Console.WriteLine ("tableConu.Count () " + tableConu.Count ());
			Console.WriteLine ("tableDivConu.Count () " + tableDivConu.Count ());

			foreach (HtmlNode n in table1) {
				//Console.WriteLine ("n.InnerText " + n.Attributes ["class"].Value);
			}
			foreach (var m in tableDiv) {
				//Console.WriteLine ("m.InnerText " + m.Attributes ["value"].Value);
			}











			var mondayToThursdayTable1 = doc.DocumentNode.Descendants ("div").Where (d => d.Attributes ["class"] != null && d.Attributes ["class"].Value == "concordia-table   horizontalLines verticalLines table-striped");
			var mondayToThursdayTable2 = doc.DocumentNode.Descendants ("div").Where (d => d.Attributes ["class"] != null && d.Attributes ["class"].Value == "concordia-table   horizontalLines verticalLines table-striped");
			//var fridayTable = doc.DocumentNode.Descendants ("div");//.Where (d => d.Attributes ["class"].Value == "concordia-table   horizontalLines verticalLines table-striped");

			var fridayTable = from div in doc.DocumentNode.Descendants ("div").Where (div => div.Attributes ["class"].Value == "concordia-table   horizontalLines verticalLines table-striped")
			                  select div;

			var table = doc.DocumentNode.Descendants ();//.Where (o => o.Attributes ["class"] != null && o.Attributes ["class"].Value.Contains ("concordia-table"));
			//HtmlNodeCollection rows = doc.DocumentNode.Descendants ("tr");
			//HtmlNodeCollection headers = rows [0].Descendants ("th");

			Console.WriteLine ("fridayTable.ElementAt(0) " + fridayTable.Count ());

			List<String> LOYtimes = new List<String> (0);
			List<String> SGWtimes = new List<String> (0);
			Console.WriteLine ("LOYtimes.Count " + LOYtimes.Count);
			Console.WriteLine ("SGWtimes.Count " + SGWtimes.Count);


			if (table != null) {
				foreach (var cell in table) {
					LOYtimes.Add (cell.InnerText);
					SGWtimes.Add (cell.InnerText);

					Console.WriteLine ("LOYtimes.Count " + LOYtimes.Count);
					Console.WriteLine ("SGWtimes.Count " + SGWtimes.Count);
				}
			}

			/*
			for (int i = 0; i < rows.Count; ++i) {
				HtmlNodeCollection columns = rows [i].Descendants ("td");

				LOYtimes.Add (columns [0].InnerHtml);
				SGWtimes.Add (columns [1].InnerText);

				Console.WriteLine (LOYtimes [i]);
				Console.WriteLine (SGWtimes [i]);
			}
			*/

			return new List<String> { "11:45" };
		}

		RequestShuttleBusSchedule ()
		{

		}

		public static RequestShuttleBusSchedule getInstance {
			get {
				if (requestShuttleBusSchedule == null) {
					requestShuttleBusSchedule = new RequestShuttleBusSchedule ();
				}
				return requestShuttleBusSchedule;
			}
		}
	}
}