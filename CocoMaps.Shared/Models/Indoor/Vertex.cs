namespace CocoMaps.Indoor
{

	public class Vertex
	{

		public string id;
		// Label

		public double x;
		// Horizontal location on screen

		public double y;
		// Vertical location on screen

		// Construcutor

		public Vertex (string id, double x, double y)
		{

			this.id = id;

			this.x = x;

			this.y = y;

		}

		public override string ToString ()
		{

			return (id + " – " + x + " – " + y);

		}

	}

}