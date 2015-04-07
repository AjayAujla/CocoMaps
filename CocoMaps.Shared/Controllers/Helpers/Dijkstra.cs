using System;
using System.Collections.Generic;

namespace CocoMaps.Indoor
{
	
	class Dijkstra
	{

		public Vertex Start;
		public Vertex End;

		public List<Vertex> Path;

		// Constructor
		public Dijkstra ()
		{

			Path = new List<Vertex> (); // Holds the Vertices

		}

		// FIND SMALLEST FIRST, ETC

		// Dijkstra calculation algorithm
		public void Execute (Vertex start, Vertex end)
		{

			if (Start == null)
				Start = start;
			
			Console.WriteLine (start);

			foreach (Vertex adjacent in start.AdjacentVertices) {

				start.Cost = 0;

				if (adjacent == end)
					return;

				double costFromStart = start.Cost + start.DistanceFrom (adjacent);

				if (adjacent.Cost == -1 || adjacent.Cost > costFromStart)
					adjacent.Cost = costFromStart;

				if (!adjacent.id.Equals (End.id))
					Execute (adjacent, end);
//				else
//					GetPath ();
			}

		}

		//		List<Vertex> GetPath ()
		//		{
		//
		//			foreach (Vertex v in Start.AdjacentVertices) {
		//
		//			}
		//
		//		}

	}

}