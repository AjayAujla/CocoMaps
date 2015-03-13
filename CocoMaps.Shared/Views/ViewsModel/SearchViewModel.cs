using System;
using Xamarin.Forms;
using CocoMaps.Shared;

namespace CocoMaps.Shared
{
	public class SearchViewModel : RelativeLayout
	{

		enum ViewState
		{
			Expanded,
			Minimized,
			Hidden
		}


		static SearchViewModel instance;
		static ViewState viewState;

		BuildingRepository buildingRepo = BuildingRepository.getInstance;


		public Picker FromSearchPicker {
			get;
			set;
		}

		public Picker ToPicker {
			get;
			set;
		}

		public static SearchViewModel getInstance {
			get {
				if (instance == null) {
					instance = new SearchViewModel {
						BackgroundColor = Helpers.Color.LightGray.ToFormsColor ()
					};
					instance.Init ();

				}
				return instance;
			}
		}

		SearchViewModel ()
		{
		}

		public void Init ()
		{
			FromSearchPicker = new Picker ();
			ToPicker = new Picker ();
			foreach (Building building in buildingRepo.BuildingList.Values) {
				FromSearchPicker.Items.Add (building.Code);
				ToPicker.Items.Add (building.Code);
			}

		}


		public void Minimize ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Minimized;
		}

		public void Expand ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height / 3;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Expanded;
		}

		public void Hide ()
		{
			double currentPos = instance.Y;
			double desiredPos = ParentView.Bounds.Height;
			instance.TranslateTo (0, desiredPos - currentPos);
			viewState = ViewState.Hidden;
		}

		public void Toggle ()
		{
			if (viewState == ViewState.Minimized) {
				Expand ();
			} else if (viewState == ViewState.Expanded) {
				Minimize ();
			}
		}

	}
}