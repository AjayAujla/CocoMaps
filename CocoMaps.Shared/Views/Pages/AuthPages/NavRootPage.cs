namespace CocoMaps.Shared
{
	public class NavRootPage : NavRootBasePage
	{
		public NavRootPage ()
		{
			RootPage RP = new RootPage();

			Navigation.PushModalAsync(RP.pushMasterPage());
		}
	}
}

