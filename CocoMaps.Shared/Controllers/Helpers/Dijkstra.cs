using System;
using System.Collections.Generic;

namespace CocoMaps.Indoor
{
	
	class Dijkstra
	{

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
			Console.WriteLine (start);

			foreach (Vertex adjacent in start.AdjacentVertices) {

				start.Cost = 0;

				if (adjacent == end)
					return;

				double cost = start.Cost + start.DistanceFrom (adjacent);

				if (adjacent.Cost == -1 || adjacent.Cost > cost)
					adjacent.Cost = cost;
				

				Execute (adjacent, end);

			}

		}

	}

}