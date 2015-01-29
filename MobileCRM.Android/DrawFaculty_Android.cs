using System;
using MobileCRM.Shared;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (MobileCRMAndroid.DrawFaculty_Android))]

namespace MobileCRMAndroid
{
	public class DrawFaculty_Android : MobileCRM.IDrawFaculty
	{
		public DrawFaculty_Android() {}

		public void Draw() {
			Console.WriteLine("Using ANDROID DrawFaculty() Implementation");
		}
	}
}