﻿using Android.Telephony;
using Android.Content;
using Xamarin.Forms;
using Android.Net;
using System.Threading.Tasks;
using CocoMaps.Shared;

[assembly: Dependency (typeof(CocoMapsAndroid.PhoneService))]

namespace CocoMapsAndroid
{
	public class PhoneService : IPhoneService
	{
		/// <summary>
		/// Gets the telephony manager for Android.
		/// </summary>
		/// <value>
		/// The manager.
		/// </value>
		public static TelephonyManager Manager {
			get {
				return Android.App.Application.Context.GetSystemService (Context.TelephonyService) as TelephonyManager;
			}
		}

		/// <summary>
		/// Gets the connectivity manager.
		/// </summary>
		/// <value>
		/// The connectivity manager.
		/// </value>
		public static ConnectivityManager ConnectivityManager {
			get {
				return Android.App.Application.Context.GetSystemService (Context.ConnectivityService) as ConnectivityManager;
			}
		}

		#region IPhone implementation

		/// <summary>
		/// Gets the cellular provider.
		/// </summary>
		/// <value>
		/// The cellular provider.
		/// </value>
		public string CellularProvider {
			get {
				return Manager.NetworkOperatorName;
			}
		}

		/// <summary>
		/// Gets the ISO Country Code.
		/// </summary>
		/// <value>
		/// The ISO Country Code.
		/// </value>
		public string ICC {
			get {
				return Manager.SimCountryIso;
			}
		}

		/// <summary>
		/// Gets the Mobile Country Code.
		/// </summary>
		/// <value>
		/// The Mobile Country Code.
		/// </value>
		public string MCC {
			get {
				return Manager.NetworkOperator.Remove (3, 3);
			}
		}

		/// <summary>
		/// Gets the Mobile Network Code.
		/// </summary>
		/// <value>
		/// The Mobile Network Code.
		/// </value>
		public string MNC {
			get {
				return Manager.NetworkOperator.Remove (0, 3);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has cellular data enabled.
		/// </summary>
		/// <value>
		/// Null if value cannot be determined, otherwise the status of cellular data.
		/// </value>
		/// <remarks>
		/// This feature will require the following Android permissions:
		///     - android.permission.INTERNET
		///     - android.permission.ACCESS_NETWORK_STATE 
		/// Please set them in the AndroidManifest.xml file.
		/// </remarks>
		public bool? IsCellularDataEnabled {
			get {
				// TODO: determine if mobile network actually indicates mobile data capability,
				// most likely this is not accurate way of getting the information and while this info
				// is provided by WP8 we might want to mark this as unsupported feature
				var mobileNetworkInfo = ConnectivityManager.GetNetworkInfo (ConnectivityType.Mobile);
				return mobileNetworkInfo != null && mobileNetworkInfo.IsConnected;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has cellular data roaming enabled.
		/// </summary>
		/// <value>
		/// Null if value cannot be determined, otherwise the status of cellular data roaming.
		/// </value>
		public bool? IsCellularDataRoamingEnabled {
			get {
				return null;
			}
		}

		/// <summary>
		/// Gets a value indicating whether network is available.
		/// </summary>
		/// <value>
		/// The network availability.
		/// </value>
		/// <remarks>
		/// This feature will require the following Android permissions:
		///     - android.permission.INTERNET
		///     - android.permission.ACCESS_NETWORK_STATE 
		/// Please set them in the AndroidManifest.xml file.
		/// </remarks>
		public bool? IsNetworkAvailable {
			get {
				var activeNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
				return activeNetworkInfo != null && activeNetworkInfo.IsConnected;
			}
		}

		public bool CanSendSMS {
			get {
				return SmsManager.Default != null;
			}
		}




		#endregion

		/// <summary>
		/// Opens native dialog to dial the specified number.
		/// </summary>
		/// <param name="number">Number to dial.</param>
		public void DialNumber (string number)
		{
			number.StartActivity (new Intent (Intent.ActionDial, Uri.Parse ("tel:" + number)));
		}

		public void OpenBrowser (string url)
		{
			Uri uri = Uri.Parse (url);
			var intent = new Intent (Intent.ActionView);
			intent.SetData (uri);

			Intent chooser = Intent.CreateChooser (intent, "Open with");

			this.StartActivity (chooser);
		}

		public void SendSMS (string to, string body)
		{
			SmsManager.Default.SendTextMessage (to, null, body, null, null);
		}

		public void ShareText (string text)
		{
			var sendIntent = new Intent ();
			sendIntent.SetAction (Intent.ActionSend);
			sendIntent.PutExtra (Intent.ExtraText, text);
			sendIntent.SetType ("text/plain");
			this.StartActivity (sendIntent);
		}

		public void LaunchMap (string address)
		{
			var geoUri = Uri.Parse (string.Format ("geo:0,0?q={0}", address));

			StartActivity (geoUri);
		}

		public async Task LaunchNavigationAsync (NavigationModel navigationModel)
		{
			var uri = Uri.Parse ("google.navigation:q=" + navigationModel.DestinationAddress);

			StartActivity (uri);		
		}

		void StartActivity (Uri uri)
		{
			var intent = new Intent (Intent.ActionView, uri);
			this.StartActivity (intent);
		}
	}
}