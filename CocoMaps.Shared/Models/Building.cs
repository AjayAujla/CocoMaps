using System;
using System.Collections.Generic;
using System.Drawing;
using SQLite;

namespace CocoMaps.Shared
{

	public class Building
	{
	
		public Building ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID {
			get;
			set;
		}

		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		[Ignore]
		public Campus Campus {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		[Ignore]
		public Tuple<double, double> Pos {
			get;
			set;
		}

		[Ignore]
		public Tuple<double, double>[] ShapeCoords {
			get;
			set;
		}

		[Ignore]
		public Tuple<double, double>[] HoleShapeCoords {
			get;
			set;
		}

		[Ignore]
		public List<Service> Services {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[Building: Code={0}, Name={1}, Address={2}]", Code, Name, Address);
		}
	}
}