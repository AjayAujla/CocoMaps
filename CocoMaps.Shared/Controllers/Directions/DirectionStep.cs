using Android.Gms.Maps.Model;

public class DirectionStep
{
	public int Index { get; set; }

	public string Description { get; set; }

	public string Distance { get; set; }

	public string Duration { get; set; }

	public LatLng StartLatLon { get; set; }

	public LatLng EndLatLon { get; set; }
}