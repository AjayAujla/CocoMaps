using System;
using System.Threading.Tasks;

namespace CocoMaps.Shared
{
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

	/// <summary>
	/// Interface INetwork
	/// </summary>
	public interface INetwork
	{
		/// <summary>
		/// Determines whether the specified host is reachable.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="timeout">The timeout.</param>
		Task<bool> IsReachable (string host, TimeSpan timeout);

		/// <summary>
		/// Determines whether [is reachable by wifi] [the specified host].
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="timeout">The timeout.</param>
		Task<bool> IsReachableByWifi (string host, TimeSpan timeout);

		/// <summary>
		/// Internets the connection status.
		/// </summary>
		/// <returns>NetworkStatus.</returns>
		NetworkStatus InternetConnectionStatus ();

		/// <summary>
		/// Occurs when [reachability changed].
		/// </summary>
		event Action<NetworkStatus> ReachabilityChanged;
	}
}