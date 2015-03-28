using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Android.Support.V7.Media;
using Newtonsoft.Json;

namespace CocoMaps.Shared
{
	public class ShuttleBusPolyline
	{

		static ShuttleBusPolyline shuttleBusPolyline;

		public static Position SGWShuttleBusPosition = new Position (45.49712, -73.5784);
		public static Position LOYShuttleBusPosition = new Position (45.45834, -73.63826);

		public Directions ShuttleBusDirections;

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
			// Shuttle Bus directions JSON string ready to Deserialize
			// Generated from Google's API and modified for app
			const string shuttleJson = "{   'routes' : [      {         'bounds' : {            'northeast' : {               'lat' : 45.4971213,               'lng' : -73.5778816            },            'southwest' : {               'lat' : 45.4583389,               'lng' : -73.63825799999999            }         },         'copyrights' : 'Map data ©2015 Google',         'legs' : [            {               'distance' : {                  'text' : '7.4 km',                  'value' : 7441               },               'duration' : {                  'text' : '20 mins',                  'value' : 1200               },               'end_address' : 'Concordia University',               'end_location' : {                  'lat' : 45.4583389,                  'lng' : -73.63825799999999               },               'start_address' : 'Concordia University',               'start_location' : {                  'lat' : 45.4971213,                  'lng' : -73.57840270000001               },               'steps' : [                  {                     'distance' : {                        'text' : '7.4 km',                        'value' : 7441                     },                     'duration' : {                        'text' : '20 min',                        'value' : 1200                     },                     'end_location' : {                        'lat' : 45.4583389,                        'lng' : -73.63825799999999                     },                     'html_instructions' : 'Embark Shuttle Bus. Student ID Card is required.',                     'polyline' : {                        'points' : '_dutG~wa`MrApAb@Np@XpB`An@j@pDhE~GnI|AnBHQ`GkL~@wBF[PYpBoEj@iAb@m@l@_@ZGZ?`@Hj@Xh@p@|CxEjG~JdAdBjEvHHDRBnA|B|@bBNXnZbk@xAhClA~Bx@rAjAtArApAb@\\\\BRBHXVbAp@pAj@`ExAtAl@pAr@b@^l@|@h@|@^`@tAlAp@r@l@~@hArBbAlBNFb@z@l@`A|DxFfEhGn@dAx@zAj@fALTTh@d@fBRRp@hBTl@dE~Gb@x@Vn@Pj@jAfGz@pEt@rBdB~EBVJLP`@R~@Dl@?n@InB@|@B`@Jb@`BpD~BfDHJPFr@zAtAfDRd@Pr@b@hBZpBrBnRVbB^|AjAjD@Zd@bAKTOV_BbFcB~EaEpLI\\\\HPbEtJpEhKpCzGjAlCZj@lA`Dl@pATb@|A~BfDfEDF'                     },                     'start_location' : {                        'lat' : 45.4971213,                        'lng' : -73.57840270000001                     },                     'travel_mode' : 'SHUTTLE'                  }               ],               'via_waypoint' : []            }         ],         'overview_polyline' : {            'points' : '_dutG~wa`MrApAb@Np@XpB`An@j@pDhE~GnI|AnBHQ`GkL~@wBF[PYpBoEj@iAb@m@l@_@ZGZ?`@Hj@Xh@p@|CxEjG~JdAdBjEvHHDRBnA|B|@bBNXnZbk@xAhClA~Bx@rAjAtArApAb@\\\\BRBHXVbAp@pAj@`ExAtAl@pAr@b@^l@|@h@|@^`@tAlAp@r@l@~@hArBbAlBNFb@z@l@`A|DxFfEhGn@dAx@zAj@fALTTh@d@fBRRp@hBTl@dE~Gb@x@Vn@Pj@jAfGz@pEt@rBdB~EBVJLP`@R~@Dl@?n@InB@|@B`@Jb@`BpD~BfDHJPFr@zAtAfDRd@Pr@b@hBZpBrBnRVbB^|AjAjD@Zd@bAKTOV_BbFcB~EaEpLI\\\\HPbEtJpEhKpCzGjAlCZj@lA`Dl@pATb@|A~BfDfEDF'         },         'summary' : 'Shuttle Bus',         'warnings' : [],         'waypoint_order' : []      }   ],   'status' : 'SHUTTLE'}";

			ShuttleBusDirections = JsonConvert.DeserializeObject<Directions> (shuttleJson);

			ShuttleBusDirections.routes [0].overview_polyline.decodedPoints = GoogleUtil.Decode (ShuttleBusDirections.routes [0].overview_polyline.points);

		}
	}
}