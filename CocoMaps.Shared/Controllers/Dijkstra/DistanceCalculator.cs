using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
	public class DistanceCalculator
	{
		public IDictionary<string, double> CalculateDistances (Graph graph, string startingNode)
		{
			if (!graph.Nodes.Any (n => n.Key == startingNode))
				throw new ArgumentException ("Starting node must be in graph.");

			InitialiseGraph (graph, startingNode);
			ProcessGraph (graph);
			return ExtractDistances (graph);
		}

		void InitialiseGraph (Graph graph, string startingNode)
		{
			foreach (Node node in graph.Nodes.Values) {
				node.DistanceFromStart = double.PositiveInfinity;
				node.PathFromStart.Clear ();
			}
			graph.Nodes [startingNode].DistanceFromStart = 0;
			graph.Nodes [startingNode].PathFromStart.Add (graph.Nodes [startingNode]);
		}

		void ProcessGraph (Graph graph)
		{
			bool finished = false;
			var queue = graph.Nodes.Values.ToList ();
			while (!finished) {
				Node nextNode = queue.OrderBy (n => n.DistanceFromStart).FirstOrDefault (n => !double.IsPositiveInfinity (n.DistanceFromStart));
				if (nextNode != null) {
					ProcessNode (nextNode, queue);
					queue.Remove (nextNode);
				} else {
					finished = true;
				}
			}
		}

		void ProcessNode (Node node, List<Node> queue)
		{
			var connections = node.Connections.Where (c => queue.Contains (c.Target));
			foreach (var connection in connections) {
				double distance = node.DistanceFromStart + connection.Distance;

				if (distance < connection.Target.DistanceFromStart) {
					connection.Target.DistanceFromStart = distance;

					connection.Target.PathFromStart.Clear ();

					foreach (Node n in node.PathFromStart)
						connection.Target.PathFromStart.Add (n);

					connection.Target.PathFromStart.Add (connection.Target);

				}
			}
		}

		IDictionary<string, double> ExtractDistances (Graph graph)
		{
			return graph.Nodes.ToDictionary (n => n.Key, n => n.Value.DistanceFromStart);
		}
	}
}