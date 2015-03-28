using System;

namespace CocoMaps.Indoor
{

	public class Edge
	{

		public Vertex Vertex1;
		// Vertex one

		public Vertex Vertex2;
		// Vertex two

		public double Distance;
		// DIstance or similar

		public double Cost;
		// Cost or multiplier factor

		// Contructor

		public Edge (Vertex v1, Vertex v2)
		{

			this.Vertex1 = Vertex1;

			this.Vertex2 = Vertex2;

			this.Distance = EdgeDistance (v1, v2);

		}

		public double EdgeDistance (Vertex v1, Vertex v2)
		{

			// Using Pythagore to calculate distance between coordinates
			double XDist = Math.Abs (v1.x - v2.x);
			double YDist = Math.Abs (v1.y - v2.y);
			double XDist2 = Math.Pow (XDist, 2);
			double YDist2 = Math.Pow (YDist, 2);

			return Math.Sqrt (XDist2 + YDist2);

		}

	}

}