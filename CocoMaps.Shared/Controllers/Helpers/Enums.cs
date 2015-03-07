namespace CocoMaps.Shared
{

	public enum TravelMode
	{
		walking,
		driving,
		transit,
		bicycling,
		shuttle
	}

	public enum Orientation
	{
		/// <summary>
		/// The none
		/// </summary>
		None = 0,
		/// <summary>
		/// The portrait
		/// </summary>
		Portrait = 1,
		/// <summary>
		/// The landscape
		/// </summary>
		Landscape = 2,
		/// <summary>
		/// The portrait up
		/// </summary>
		PortraitUp = 5,
		/// <summary>
		/// The portrait down
		/// </summary>
		PortraitDown = 9,
		/// <summary>
		/// The landscape left
		/// </summary>
		LandscapeLeft = 18,
		/// <summary>
		/// The landscape right
		/// </summary>
		LandscapeRight = 34,
	}

	public enum NetworkStatus
	{
		/// <summary>
		/// Network not reachable.
		/// </summary>
		NotReachable,

		/// <summary>
		/// Network reachable via carrier data network.
		/// </summary>
		ReachableViaCarrierDataNetwork,

		/// <summary>
		/// Network reachable via WiFi network.
		/// </summary>
		ReachableViaWiFiNetwork,

		/// <summary>
		/// Network reachable via an unknown network
		/// </summary>
		ReachableViaUnknownNetwork
	}

	public enum ImageOrientation
	{
		/// <summary>
		/// The image to left
		/// </summary>
		ImageToLeft = 0,
		/// <summary>
		/// The image on top
		/// </summary>
		ImageOnTop = 1,
		/// <summary>
		/// The image to right
		/// </summary>
		ImageToRight = 2,
		/// <summary>
		/// The image on bottom
		/// </summary>
		ImageOnBottom = 3
	}
	
	/// <summary>
	/// Enum GeolocationError
	/// </summary>
	public enum GeolocationError
	{
		/// <summary>
		/// The provider was unable to retrieve any position data.
		/// </summary>
		PositionUnavailable,

		/// <summary>
		/// The app is not, or no longer, authorized to receive location data.
		/// </summary>
		Unauthorized
	}

}