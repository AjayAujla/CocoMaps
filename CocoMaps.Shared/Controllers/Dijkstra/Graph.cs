using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Dijkstra
{
	[DebuggerDisplay ("Graph ({_nodes.Count} nodes)")]
	public class Graph
	{
		internal IDictionary<string, Node> Nodes { get; private set; }

		public Graph ()
		{
			Nodes = new Dictionary<string, Node> ();
		}

		public void AddNode (string name, double lat, double lon)
		{
			var node = new Node (name, lat, lon);
			Nodes.Add (name, node);
		}

		public void AddConnection (string fromNode, string toNode, bool twoWay = true)
		{
			
			double distance = ConnectionDistance (Nodes [fromNode], Nodes [toNode]);
			Nodes [fromNode].AddConnection (Nodes [toNode], distance, twoWay);
		}

		double ConnectionDistance (Node n1, Node n2)
		{

			// Using Pythagore to calculate distance between coordinates
			double XDist = Math.Abs (n1.Lat - n2.Lat);
			double YDist = Math.Abs (n1.Lon - n2.Lon);
			double XDist2 = Math.Pow (XDist, 2);
			double YDist2 = Math.Pow (YDist, 2);

			return Math.Sqrt (XDist2 + YDist2);

		}
	}
}