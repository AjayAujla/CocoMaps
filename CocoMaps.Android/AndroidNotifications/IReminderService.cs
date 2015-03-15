using System;
using System.Collections.Generic;
using System.Text;

namespace CocoMaps.Android
{
	public interface IReminderService
	{
		void Remind(DateTime dateTime, string title, string message);
	}
}