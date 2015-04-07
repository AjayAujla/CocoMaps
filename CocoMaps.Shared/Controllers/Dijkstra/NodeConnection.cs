using System.Diagnostics;

namespace Dijkstra
{
	[DebuggerDisplay ("-> {Target.Name} ({Distance})")]
	class NodeConnection
	{
		internal Node Target { get; private set; }

		internal double Distance { get; private set; }

		internal NodeConnection (Node target, double distance)
		{
			Target = target;
			Distance = distance;
		}
	}
}