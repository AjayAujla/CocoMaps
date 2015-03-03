using Xamarin.Forms;

namespace CocoMaps.Shared
{

	public class LoaderViewModel : RelativeLayout
	{

		static LoaderViewModel loaderViewModel;
		static ActivityIndicator loader = new ActivityIndicator {
			IsVisible = true,
			IsRunning = true,
			WidthRequest = 50,
			HeightRequest = 50
		};

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
						Opacity = 0.8,

						IsVisible = false,
					};
					loaderViewModel.Children.Add (loader, Constraint.RelativeToParent ((parent) => loaderViewModel.Width / 2 - loader.Width / 2), Constraint.RelativeToParent ((parent) => loaderViewModel.Height / 2 - loader.Height / 2));
				}
				return loaderViewModel;
			}
		}

		public void Show ()
		{
			loaderViewModel.IsVisible = true;
		}

		public void Hide ()
		{
			loaderViewModel.IsVisible = false;
		}

	}
}