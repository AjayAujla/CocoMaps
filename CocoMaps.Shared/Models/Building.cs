using System;
using System.Collections.Generic;

namespace CocoMaps.Shared
{

	public class Building
	{
	
		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public Campus Campus {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public Tuple<double, double> Position {
			get;
			set;
		}

		public Tuple<double, double>[] ShapeCoords {
			get;
			set;
		}

		public Tuple<double, double>[] HoleShapeCoords {
			get;
			set;
		}

		public List<Service> Services {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[Building: Code = {0}, Name = {1}, Address = {2}]", Code, Name, Address);
		}
	}
}