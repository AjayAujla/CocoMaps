using Xamarin.Forms;

namespace CocoMaps.Shared
{

	public static class ActivityLoading
	{
		static ActivityIndicator loader;

		static ActivityLoading ()
		{
		}

		public static ActivityIndicator getInstance ()
		{
			if (loader == null)
				loader = new ActivityIndicator {
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Color = Color.White,
					IsVisible = false 
				};
			return loader;
		}

		public static void Show (ActivityIndicator loader)
		{
			loader.IsVisible = true;
			loader.IsRunning = true;
		}

		public static void Hide (ActivityIndicator loader)
		{
			loader.IsVisible = false;
			loader.IsRunning = false;
		}

	}
}