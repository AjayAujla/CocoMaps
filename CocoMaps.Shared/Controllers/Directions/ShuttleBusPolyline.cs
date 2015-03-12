using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Java.IO;

namespace CocoMaps.Shared
{
	public class ShuttleBusPolyline
	{

		static ShuttleBusPolyline shuttleBusPolyline;

		public static ShuttleBusPolyline getInstance {
			get {
				if (shuttleBusPolyline == null) {
					shuttleBusPolyline = new ShuttleBusPolyline ();
					shuttleBusPolyline.Init ();
				}
				return shuttleBusPolyline;
			}
		}

		List<Position> _points = new List<Position> ();

		public List<Position> ShuttleBusPoints {
			get { return _points; }
		}

		ShuttleBusPolyline ()
		{
		}

		void Init ()
		{
			
			//SHUTTLE BUS POLYLINE POINTS

			_points.Add (new Position (45.49712, -73.57840));
			_points.Add (new Position (45.4967, -73.57881));
			_points.Add (new Position (45.49652, -73.57889));
			_points.Add (new Position (45.49627, -73.57902));
			_points.Add (new Position (45.4957, -73.57935));
			_points.Add (new Position (45.49546, -73.57957));
			_points.Add (new Position (45.49457, -73.58058));
			_points.Add (new Position (45.49313, -73.58226));
			_points.Add (new Position (45.49266, -73.58282));
			_points.Add (new Position (45.49261, -73.58273));
			_points.Add (new Position (45.49132, -73.58059));
			_points.Add (new Position (45.491, -73.57999));
			_points.Add (new Position (45.49096, -73.57985));
			_points.Add (new Position (45.49087, -73.57972));
			_points.Add (new Position (45.4903, -73.57868));
			_points.Add (new Position (45.49008, -73.57831));
			_points.Add (new Position (45.4899, -73.57808));
			_points.Add (new Position (45.48967, -73.57792));
			_points.Add (new Position (45.48953, -73.57788));
			_points.Add (new Position (45.48939, -73.57788));
			_points.Add (new Position (45.48922, -73.57793));
			_points.Add (new Position (45.489, -73.57806));
			_points.Add (new Position (45.48879, -73.57831));
			_points.Add (new Position (45.488, -73.5794));
			_points.Add (new Position (45.48666, -73.58132));
			_points.Add (new Position (45.48631, -73.58183));
			_points.Add (new Position (45.48529, -73.58339));
			_points.Add (new Position (45.48524, -73.58342));
			_points.Add (new Position (45.48514, -73.58344));
			_points.Add (new Position (45.48474, -73.58407));
			_points.Add (new Position (45.48443, -73.58457));
			_points.Add (new Position (45.48435, -73.5847));
			_points.Add (new Position (45.47995, -73.59176));
			_points.Add (new Position (45.4795, -73.59245));
			_points.Add (new Position (45.47911, -73.59309));
			_points.Add (new Position (45.47882, -73.59351));
			_points.Add (new Position (45.47844, -73.59394));
			_points.Add (new Position (45.47802, -73.59435));
			_points.Add (new Position (45.47784, -73.5945));
			_points.Add (new Position (45.47782, -73.5946));
			_points.Add (new Position (45.4778, -73.59465));
			_points.Add (new Position (45.47767, -73.59477));
			_points.Add (new Position (45.47733, -73.59502));
			_points.Add (new Position (45.47692, -73.59524));
			_points.Add (new Position (45.47595, -73.59569));
			_points.Add (new Position (45.47552, -73.59592));
			_points.Add (new Position (45.47511, -73.59618));
			_points.Add (new Position (45.47493, -73.59634));
			_points.Add (new Position (45.4747, -73.59665));
			_points.Add (new Position (45.47449, -73.59696));
			_points.Add (new Position (45.47433, -73.59713));
			_points.Add (new Position (45.4739, -73.59752));
			_points.Add (new Position (45.47365, -73.59778));
			_points.Add (new Position (45.47342, -73.5981));
			_points.Add (new Position (45.47305, -73.59868));
			_points.Add (new Position (45.47271, -73.59923));
			_points.Add (new Position (45.47263, -73.59927));
			_points.Add (new Position (45.47245, -73.59957));
			_points.Add (new Position (45.47222, -73.5999));
			_points.Add (new Position (45.47127, -73.60115));
			_points.Add (new Position (45.47027, -73.60248));
			_points.Add (new Position (45.47003, -73.60283));
			_points.Add (new Position (45.46974, -73.60329));
			_points.Add (new Position (45.46952, -73.60365));
			_points.Add (new Position (45.46945, -73.60376));
			_points.Add (new Position (45.46934, -73.60397));
			_points.Add (new Position (45.46915, -73.60449));
			_points.Add (new Position (45.46905, -73.60459));
			_points.Add (new Position (45.4688, -73.60512));
			_points.Add (new Position (45.46869, -73.60535));
			_points.Add (new Position (45.4677, -73.60679));
			_points.Add (new Position (45.46752, -73.60708));
			_points.Add (new Position (45.4674, -73.60732));
			_points.Add (new Position (45.46731, -73.60754));
			_points.Add (new Position (45.46693, -73.60886));
			_points.Add (new Position (45.46663, -73.60991));
			_points.Add (new Position (45.46636, -73.61049));
			_points.Add (new Position (45.46585, -73.61161));
			_points.Add (new Position (45.46583, -73.61173));
			_points.Add (new Position (45.46577, -73.6118));
			_points.Add (new Position (45.46568, -73.61197));
			_points.Add (new Position (45.46558, -73.61229));
			_points.Add (new Position (45.46555, -73.61252));
			_points.Add (new Position (45.46555, -73.61276));
			_points.Add (new Position (45.4656, -73.61332));
			_points.Add (new Position (45.46559, -73.61363));
			_points.Add (new Position (45.46557, -73.6138));
			_points.Add (new Position (45.46551, -73.61398));
			_points.Add (new Position (45.46502, -73.61487));
			_points.Add (new Position (45.46438, -73.61571));
			_points.Add (new Position (45.46433, -73.61577));
			_points.Add (new Position (45.46424, -73.61581));
			_points.Add (new Position (45.46398, -73.61627));
			_points.Add (new Position (45.46355, -73.61711));
			_points.Add (new Position (45.46345, -73.6173));
			_points.Add (new Position (45.46336, -73.61756));
			_points.Add (new Position (45.46318, -73.61809));
			_points.Add (new Position (45.46304, -73.61866));
			_points.Add (new Position (45.46246, -73.62178));
			_points.Add (new Position (45.46234, -73.62228));
			_points.Add (new Position (45.46218, -73.62275));
			_points.Add (new Position (45.4618, -73.62361));
			_points.Add (new Position (45.46179, -73.62375));
			_points.Add (new Position (45.4616, -73.62409));
			_points.Add (new Position (45.46166, -73.6242));
			_points.Add (new Position (45.46174, -73.62432));
			_points.Add (new Position (45.46222, -73.62546));
			_points.Add (new Position (45.46272, -73.62658));
			_points.Add (new Position (45.46369, -73.62875));
			_points.Add (new Position (45.46374, -73.6289));
			_points.Add (new Position (45.46369, -73.62899));
			_points.Add (new Position (45.46271, -73.63086));
			_points.Add (new Position (45.46166, -73.63283));
			_points.Add (new Position (45.46093, -73.63425));
			_points.Add (new Position (45.46055, -73.63496));
			_points.Add (new Position (45.46041, -73.63518));
			_points.Add (new Position (45.46002, -73.63599));
			_points.Add (new Position (45.45979, -73.6364));
			_points.Add (new Position (45.45968, -73.63658));
			_points.Add (new Position (45.45921, -73.63722));
			_points.Add (new Position (45.45837, -73.63822));
			_points.Add (new Position (45.45834, -73.63826));
		
		}
	}
}