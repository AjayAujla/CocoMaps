using Xamarin.Forms;

namespace CocoMaps.Shared
{

	public class LoaderViewModel : RelativeLayout
	{

		static LoaderViewModel loaderViewModel;
		static ActivityIndicator loader;


		static LoaderViewModel ()
		{
		}

		public static LoaderViewModel getInstance {
			get {
				if (loaderViewModel == null) {
					loaderViewModel = new LoaderViewModel {
						BackgroundColor = Color.Black,
						WidthRequest = 100,
						HeightRequest = 75,
						Opacity = 1,
						IsVisible = false,
					};

					loader = new ActivityIndicator {
						IsRunning = false,
						WidthRequest = 50,
						HeightRequest = 50
					};

					loaderViewModel.Children.Add (loader,
						Constraint.RelativeToParent (parent => parent.Width / 2 - loader.WidthRequest / 2), 
						Constraint.RelativeToParent (parent => parent.Height / 2 - loader.HeightRequest / 2));
				}
				return loaderViewModel;
			}
		}

		public void Show ()
		{
			loaderViewModel.IsVisible = true;
			loader.IsRunning = true;
		}

		public void Hide ()
		{
			loaderViewModel.IsVisible = false;
			loader.IsRunning = false;
		}

	}
}