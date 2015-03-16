namespace CocoMaps.Shared
{
	public class NavRootPage : NavRootBasePage
	{
		public NavRootPage ()
		{
			Navigation.PushModalAsync (new RootPage ());
		}
	}
}

