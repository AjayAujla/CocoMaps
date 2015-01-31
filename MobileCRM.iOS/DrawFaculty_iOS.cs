using System;
using MobileCRM.Shared;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (MobileCRM.iOS.DrawFaculty_iOS))]

namespace MobileCRM.iOS
{
	public class DrawFaculty_iOS : MobileCRM.IDrawFaculty
	{
		public DrawFaculty_iOS() {}

		public void Draw() {
			Console.WriteLine("Using iOS DrawFaculty() Implementation");
		}
	}
}