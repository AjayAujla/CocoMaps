using System;
using Xamarin.Forms;

namespace CocoMaps.Shared
{
	public class FAQItems
	{
		public FAQItems (){}

		public FAQItems (string question, string answer,string icon)
		{
			this.Question = question;
			this.Answer = answer;
			this.IconSource = ImageSource.FromFile (icon);
		}


		public string Question { 
			set; 
			get; 
		}

		public string Answer { 
			set; 
			get; 
		}

		public ImageSource IconSource { 
			set; 
			get;
		}

	}
}

