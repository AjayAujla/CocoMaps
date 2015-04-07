using System;
using System.Collections.Generic;

namespace CocoMaps.Indoor
{

	public class Vertex
	{

		// Label
		public string id {
			get;
			set;
		}

		// Vertical location on screen
		public double lat {
			get;
			set;
		}

		// Horizontal location on screen
		public double lon {
			get;
			set;
		}

		// distance it costs to arrive to this vertex, starting from first one
		public double Cost {
			get;
			set;
		}

		// All waypoints connected to that vertex
		public List<Vertex> AdjacentVertices {
			get;
			set;
		}

		// Construcutor
		public Vertex (string id, double lat, double lon)
		{

			this.id = id;

			this.lat = lat;

			this.lon = lon;

			Cost = -1;

			AdjacentVertices = new List<Vertex> ();

		}

		public double DistanceFrom (Vertex v)
		{

			// Using Pythagore to calculate distance between coordinates
			double XDist = Math.Abs (lat - v.lat);
			double YDist = Math.Abs (lon - v.lon);
			double XDist2 = Math.Pow (XDist, 2);
			double YDist2 = Math.Pow (YDist, 2);

			return Math.Sqrt (XDist2 + YDist2);

		}

		public override string ToString ()
		{

			return ("Vertex:" + id + " – " + lat + ", " + lon);

		}

	}

}