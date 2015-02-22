using System;
using Android.Content;
using CocoMaps.Shared;
using Android.App;

namespace CocoMaps.Android
{

	/// <summary>
	/// Broadcast monitor.
	/// </summary>
	public abstract class BroadcastMonitor : BroadcastReceiver
	{
		/// <summary>
		///  Start monitoring. 
		/// </summary>
		public virtual bool Start ()
		{
			var intent = BroadcastReceiverExtensions.RegisterReceiver (this, Filter);
			if (intent == null) {
				return false;
			}

			return true;
		}

		/// <summary>
		///  Stop monitoring. 
		/// </summary>
		public virtual void Stop ()
		{
			BroadcastReceiverExtensions.UnregisterReceiver (this);
		}

		/// <summary>
		/// Gets the intent filter to use for monitoring.
		/// </summary>
		protected abstract IntentFilter Filter { get; }
	}

	public static class BroadcastReceiverExtensions
	{
		/// <summary>
		/// Registers the receiver using <see cref="Application.Context"/>.
		/// </summary>
		/// <returns>The receiver intent.</returns>
		/// <param name="receiver">Receiver.</param>
		/// <param name="intentFilter">Intent filter.</param>
		public static Intent RegisterReceiver (this BroadcastReceiver receiver, IntentFilter intentFilter)
		{
			return Application.Context.RegisterReceiver (receiver, intentFilter);
		}

		/// <summary>
		/// Unregisters the receiver using <see cref="Application.Context"/>.
		/// </summary>
		/// <param name="receiver">Receiver to unregister.</param>
		public static void UnregisterReceiver (this BroadcastReceiver receiver)
		{
			Application.Context.UnregisterReceiver (receiver);
		}
	}
}