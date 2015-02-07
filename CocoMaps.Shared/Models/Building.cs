using System.Drawing;
using System;

namespace CocoMaps.Shared
{
	public class Building
	{
	
		public Building ()
		{
		}

		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public Tuple<double, double> Pos {
			get;
			set;
		}

		public Tuple<double, double>[] ShapeCoords {
			get;
			set;
		}

	}
}

