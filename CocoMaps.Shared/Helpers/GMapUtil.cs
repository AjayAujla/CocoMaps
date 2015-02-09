//using System.Convert;
using System.Collections.Generic;
using CocoMaps.Shared.Helpers;
using System.Xml;
using Android.Gms.Maps.Model;
using System;
using System.Net;
using System.Text.RegularExpressions;
using Org.Apache.Http.Cookies;
using Android.Gms.Maps;
using Android.Gms.Common.Data;


public class GMapUtil
{

	public static List<DirectionSteps> GetDirections (string origin, string destination)
	{
		var requestUrl = string.Format ("http://maps.google.com/maps/api/directions/xml?origin={0}&destination={1}&mode=walking&sensor=false", origin, destination);
 		
		var client = new WebClient ();
		var result = client.DownloadString (requestUrl);
		return ParseDirectionResults (result);

	}

	private static List<DirectionSteps> ParseDirectionResults (string result)
	{
		var directionStepsList = new List<DirectionSteps> ();
		var xmlDoc = new XmlDocument { InnerXml = result };
		if (xmlDoc.HasChildNodes) {
			var directionsResponseNode = xmlDoc.SelectSingleNode ("DirectionsResponse");
			if (directionsResponseNode != null) {
				var statusNode = directionsResponseNode.SelectSingleNode ("status");
				if (statusNode != null && statusNode.InnerText.Equals ("OK")) {
					var legs = directionsResponseNode.SelectNodes ("route/leg");

					foreach (XmlNode leg in legs) {					
						int stepCount = 1;
						var stepNodes = leg.SelectNodes ("step");
						var steps = new List<DirectionStep> ();

						foreach (XmlNode stepNode in stepNodes) {
							var directionStep = new DirectionStep ();
							directionStep.Index = stepCount++;
							directionStep.Distance = stepNode.SelectSingleNode ("distance/text").InnerText;
							directionStep.Duration = stepNode.SelectSingleNode ("duration/text").InnerText;

							directionStep.Description = Regex.Replace (stepNode.SelectSingleNode ("html_instructions").InnerText, "<[^<]+?>", "");


							var StartLatCoord = stepNode.SelectSingleNode ("start_location/lat");
							var StartLngCoord = stepNode.SelectSingleNode ("start_location/lng");
							var EndLatCoord = stepNode.SelectSingleNode ("end_location/lat");
							var EndLngCoord = stepNode.SelectSingleNode ("end_location/lng");

							directionStep.StartLatLon = new LatLng (System.Convert.ToDouble (StartLatCoord.InnerText), System.Convert.ToDouble (StartLngCoord.InnerText));
							directionStep.EndLatLon = new LatLng (System.Convert.ToDouble (EndLatCoord.InnerText), System.Convert.ToDouble (EndLngCoord.InnerText));

							steps.Add (directionStep);

						}

						var directionSteps = new DirectionSteps ();
						directionSteps.OriginAddress = leg.SelectSingleNode ("start_address").InnerText;
						directionSteps.DestinationAddress = leg.SelectSingleNode ("end_address").InnerText;
						directionSteps.TotalDistance = leg.SelectSingleNode ("distance/text").InnerText;
						directionSteps.TotalDuration = leg.SelectSingleNode ("duration/text").InnerText;
						var encodedPolyline = directionsResponseNode.SelectSingleNode ("route/overview_polyline").InnerText;
						directionSteps.DecodedPolyline = GooglePoints.Decode (encodedPolyline);

						directionSteps.Steps = steps;

						directionStepsList.Add (directionSteps);
					}
				}
			}
		}
		return directionStepsList;
	}
}