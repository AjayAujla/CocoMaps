using System.Collections.Generic;
using System;
using System.Text;
using Xamarin.Forms.Maps;
using CocoMaps.Shared;

/// <summary>
/// See https://developers.google.com/maps/documentation/utilities/polylinealgorithm
/// </summary>
public static class GoogleUtil
{

	public static Building PointInBuilding (double testX, double testY)
	{
		int i, j;
		BuildingRepository buildingRepo = BuildingRepository.getInstance;

		foreach (Building building in buildingRepo.BuildingList.Values) {

			var latlnglist = new List<Position> ();
			bool c = false;

			foreach (Position point in building.ShapeCoords)
				latlnglist.Add (new Position (point.Latitude, point.Longitude));

			for (i = 0, j = latlnglist.Count - 1; i < latlnglist.Count - 1; j = i++) {
				if ((latlnglist [i].Longitude > testY) != (latlnglist [j].Longitude > testY) &&
				    (testX < (latlnglist [j].Latitude - latlnglist [i].Latitude) * (testY - latlnglist [i].Longitude) / (latlnglist [j].Longitude - latlnglist [i].Longitude) + latlnglist [i].Latitude))
					c = !c;
			}
			if (c)
				return building;


		}
		return null;

	}

	/// <summary>
	/// Decode google style polyline coordinates.
	/// </summary>
	/// <param name="encodedPoints"></param>
	/// <returns></returns>
	public static IEnumerable<Position> Decode (string encodedPoints)
	{
		if (string.IsNullOrEmpty (encodedPoints)) {
			Console.WriteLine ("ENCODED POINTS NULL OR EMPTY");
			yield break;
		}
		char[] polylineChars = encodedPoints.ToCharArray ();
		int index = 0;

		int currentLat = 0;
		int currentLng = 0;
		int next5bits;
		int sum;
		int shifter;

		while (index < polylineChars.Length) {
			// calculate next latitude
			sum = 0;
			shifter = 0;
			do {
				next5bits = (int)polylineChars [index++] - 63;
				sum |= (next5bits & 31) << shifter;
				shifter += 5;
			} while (next5bits >= 32 && index < polylineChars.Length);

			if (index >= polylineChars.Length)
				break;

			currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

			//calculate next longitude
			sum = 0;
			shifter = 0;
			do {
				next5bits = (int)polylineChars [index++] - 63;
				sum |= (next5bits & 31) << shifter;
				shifter += 5;
			} while (next5bits >= 32 && index < polylineChars.Length);

			if (index >= polylineChars.Length && next5bits >= 32)
				break;

			currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

			yield return new Position ((Convert.ToDouble (currentLat) / 1E5), (Convert.ToDouble (currentLng) / 1E5));

		}
	}

	/// <summary>
	/// Encode it
	/// </summary>
	/// <param name="points"></param>
	/// <returns></returns>
	public static string Encode (IEnumerable<Position> points)
	{
		var str = new StringBuilder ();

		var encodeDiff = (Action<int>)(diff => {
			int shifted = diff << 1;
			if (diff < 0)
				shifted = ~shifted;

			int rem = shifted;

			while (rem >= 0x20) {
				str.Append ((char)((0x20 | (rem & 0x1f)) + 63));

				rem >>= 5;
			}

			str.Append ((char)(rem + 63));
		});

		int lastLat = 0;
		int lastLng = 0;

		foreach (var point in points) {
			int lat = (int)Math.Round (point.Latitude * 1E5);
			int lng = (int)Math.Round (point.Longitude * 1E5);

			encodeDiff (lat - lastLat);
			encodeDiff (lng - lastLng);

			lastLat = lat;
			lastLng = lng;
		}

		return str.ToString ();
	}
	//
	//	public static Directions AddDirections (Directions directions1, Directions directions2)
	//	{
	//
	//		Console.WriteLine ("CHECKPOINT 4");
	//
	//		Console.WriteLine ("FROM DIRECTIONS 1 BEFORE: "
	//		+ directions1.routes [0].legs [0].distance.value + " " + directions1.routes [0].legs [0].distance.text + " "
	//		+ directions1.routes [0].legs [0].duration.value + " " + directions1.routes [0].legs [0].duration.text);
	//		directions1.routes [0].legs [0].distance.value += directions2.routes [0].legs [0].distance.value;
	//		directions1.routes [0].legs [0].distance.text = DistanceValueToText (directions1.routes [0].legs [0].distance.value);
	//
	//		directions1.routes [0].legs [0].duration.value += directions2.routes [0].legs [0].duration.value;
	//		directions1.routes [0].legs [0].duration.text = DurationValueToText (directions1.routes [0].legs [0].duration.value);
	//
	//
	//		Console.WriteLine ("CHECKPOINT 5");
	//
	//		Console.WriteLine ("FROM DIRECTIONS 1 AFTER: "
	//		+ directions1.routes [0].legs [0].distance.value + " " + directions1.routes [0].legs [0].distance.text + " "
	//		+ directions1.routes [0].legs [0].duration.value + " " + directions1.routes [0].legs [0].duration.text);
	//		foreach (Step step in directions1.routes[0].legs[0].steps)
	//			Console.WriteLine (step.html_instructions);
	//
	//		Console.WriteLine ("CHECKPOINT 6");
	//
	//		Console.WriteLine ("FROM DIRECTIONS 2 AFTER: "
	//		+ directions2.routes [0].legs [0].distance.value + " " + directions2.routes [0].legs [0].distance.text + " "
	//		+ directions2.routes [0].legs [0].duration.value + " " + directions2.routes [0].legs [0].duration.text);
	//		foreach (Step step in directions2.routes[0].legs[0].steps)
	//			Console.WriteLine (step.html_instructions);
	//
	//		directions1.routes [0].legs [0].end_address = directions2.routes [0].legs [0].end_address;
	//		directions1.routes [0].legs [0].end_location = directions2.routes [0].legs [0].end_location;
	//
	//		return directions1;
	//
	//	}

	public static Directions SumDirections (List<Directions> directions)
	{
		
		if (directions.Count == 1)
			return directions [0];

		// extracting first item from the list
		Directions firstDirections = directions [0];
		directions.RemoveAt (0);

		foreach (Directions direction in directions) {
			
			firstDirections.routes [0].legs [0].duration.value += direction.routes [0].legs [0].duration.value;
			firstDirections.routes [0].legs [0].distance.value += direction.routes [0].legs [0].distance.value;

			foreach (Step step in direction.routes[0].legs[0].steps)
				firstDirections.routes [0].legs [0].steps.Add (step);
			
		}

		firstDirections.routes [0].legs [0].end_address = directions [directions.Count - 1].routes [0].legs [0].end_address;
		firstDirections.routes [0].legs [0].end_location = directions [directions.Count - 1].routes [0].legs [0].end_location;

		firstDirections.routes [0].legs [0].duration.text = DurationValueToText (firstDirections.routes [0].legs [0].duration.value);
		firstDirections.routes [0].legs [0].distance.text = DistanceValueToText (firstDirections.routes [0].legs [0].distance.value);

		return firstDirections;

	}

	public static string DistanceValueToText (int meters)
	{
		
		if (meters < 100)
			return meters + " m";
		else
			return String.Format ("{0:0.0}", meters / 1000m) + " km";

	}

	public static string DurationValueToText (int seconds)
	{
		string time = "";
		TimeSpan t = TimeSpan.FromSeconds (seconds);

		if (t.Hours > 0) {
			time += t.Hours + " hour";
			if (t.Hours > 1)
				time += "s";
		}
		time += " " + t.Minutes + " min";
		if (t.Minutes > 1)
			time += "s";

		return time;

	}

}