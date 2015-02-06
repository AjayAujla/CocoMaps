using System.Drawing;

namespace CocoMaps.Shared
{
	public class Building
	{

		private readonly string code;
		private readonly string name;
		private readonly string address;
		private readonly PointF pos;
		private readonly PointF[] shapeCoords;


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

		public PointF Pos {
			get;
			set;
		}

		public PointF[] ShapeCoords {
			get;
			set;
		}

	}
}

