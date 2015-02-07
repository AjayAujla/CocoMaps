using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using CocoMaps.Shared;
using System.Drawing;
using System.Collections.Generic;
using CocoMaps.Models;

[assembly: ExportRenderer (typeof(CocoMaps.ConcordiaMap), typeof(CocoMapsAndroid.ConcordiaMapRenderer))]

namespace CocoMapsAndroid
{

	public class ConcordiaMapRenderer : MapRenderer
	{
		bool _isDrawnDone;
		Button bt;


		public void WriteConsole() {
			Console.WriteLine("EVENT TRIGGERED!!!");
		}


		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var androidMapView = (MapView)Control;
			var formsMap = (CocoMaps.ConcordiaMap)sender;

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {

				//androidMapView.Map.Clear ();
				androidMapView.Map.MyLocationEnabled = formsMap.IsShowingUser;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MyLocationButtonEnabled = false;
				androidMapView.Map.UiSettings.CompassEnabled = true;
				androidMapView.Map.UiSettings.MapToolbarEnabled = true;
				androidMapView.Map.UiSettings.ZoomControlsEnabled = false;


				Campus SGW = new Campus () {
					Code = "SGW",
					Name = "Sir George Williams",
					SGWBuildingsList = new List<Building>()

				};

				Campus LOY = new Campus () {
					Code = "LOY",
					Name = "Loyola",
					LOYBuildingsList = new List<Building>()

				};

				Building B = new Building () {
					Code = "B",
					Name = "B",
					Address = "2160 Bishop",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49792300709727f, Y = -73.57949629426003f },
						new PointF { X = 45.49775004181796f, Y = -73.57966259121895f },
						new PointF { X = 45.497714790676845f, Y = -73.57958950102329f },
						new PointF { X = 45.49788634602265f, Y = -73.57942119240761f },
						new PointF { X = 45.49792300709727f, Y = -73.57949629426003f }
					}
				};
				SGW.SGWBuildingsList.Add(B);

				Building CB = new Building () {
					Code = "CB",
					Name = "CB",
					Address = "1425 René Lévesque W.",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.495461491948106f, Y = -73.57426129281521f },
						new PointF { X = 45.495081703057934f, Y = -73.57463613152504f },
						new PointF { X = 45.49504927047214f, Y = -73.57456907629967f },
						new PointF { X = 45.495077942759096f, Y = -73.57453688979149f },
						new PointF { X = 45.49495714302504f, Y = -73.57426799833775f },
						new PointF { X = 45.49502999892679f, Y = -73.57419557869434f },
						new PointF { X = 45.4950624315237f, Y = -73.57426464557648f },
						new PointF { X = 45.495120716143674f, Y = -73.57420563697815f },
						new PointF { X = 45.495091103803965f, Y = -73.57413992285728f },
						new PointF { X = 45.49516677975225f, Y = -73.57406683266163f },
						new PointF { X = 45.49519639205217f, Y = -73.57412919402122f },
						new PointF { X = 45.49525467653348f, Y = -73.57407420873642f },
						new PointF { X = 45.495226004336494f, Y = -73.57400983572006f },
						new PointF { X = 45.49530544038742f, Y = -73.57393339276314f },
						new PointF { X = 45.49535855437077f, Y = -73.57403799891472f },
						new PointF { X = 45.49536419479084f, Y = -73.5740339756012f },
						new PointF { X = 45.49538440629147f, Y = -73.57407823204994f },
						new PointF { X = 45.495376885733954f, Y = -73.5740802437067f },
						new PointF { X = 45.495461491948106f, Y = -73.57426129281521f }
					}
				};
				SGW.SGWBuildingsList.Add(CB);

				Building CI = new Building () {
					Code = "CI",
					Name = "CI",
					Address = "2149 Mackay",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49752255406562f, Y = -73.57993818819523f },
						new PointF { X = 45.497410689916435f, Y = -73.58004614710808f },
						new PointF { X = 45.497367918271266f, Y = -73.57995696365833f },
						new PointF { X = 45.49747884247076f, Y = -73.57984632253647f },
						new PointF { X = 45.49752255406562f, Y = -73.57993818819523f }
					}
				};
				SGW.SGWBuildingsList.Add(CI);

				Building CL = new Building () {
					Code = "CL",
					Name = "CL",
					Address = "1665 St. St-Catherine W.",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.4944781718791f, Y = -73.57927232980728f },
						new PointF { X = 45.4941707633251f, Y = -73.57964850962162f },
						new PointF { X = 45.493989325684645f, Y = -73.57934206724167f },
						new PointF { X = 45.49398603535935f, Y = -73.57932060956955f },
						new PointF { X = 45.4939930860562f, Y = -73.57928641140461f },
						new PointF { X = 45.49401470818766f, Y = -73.57924215495586f },
						new PointF { X = 45.49404103077127f, Y = -73.57920661568642f },
						new PointF { X = 45.49426900263261f, Y = -73.57892297208309f },
						new PointF { X = 45.4944781718791f, Y = -73.57927232980728f }
					}
				};
				SGW.SGWBuildingsList.Add(CL);

				Building D = new Building () {
					Code = "D",
					Name = "D",
					Address = "2140 Bishop",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49784545479588f, Y = -73.57933402061462f },
						new PointF { X = 45.49767859948234f, Y = -73.57949495315552f },
						new PointF { X = 45.49764945850363f, Y = -73.57943192124367f },
						new PointF { X = 45.497814903859954f, Y = -73.57927031815052f },
						new PointF { X = 45.49784545479588f, Y = -73.57933402061462f }
					}
				};
				SGW.SGWBuildingsList.Add(D);

				Building K = new Building () {
					Code = "K",
					Name = "K",
					Address = "2150 Bishop",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.497884935980856f, Y = -73.5794198513031f },
						new PointF { X = 45.49763159789631f, Y = -73.57966527342796f },
						new PointF { X = 45.4975925865501f, Y = -73.57958480715752f },
						new PointF { X = 45.49784733485295f, Y = -73.57933804392815f },
						new PointF { X = 45.497884935980856f, Y = -73.5794198513031f }
					}
				};
				SGW.SGWBuildingsList.Add(K);

				Building M = new Building () {
					Code = "M",
					Name = "M",
					Address = "2135 Mackay",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49743278075342f, Y = -73.57976384460926f },
						new PointF { X = 45.497325146593596f, Y = -73.57987113296986f },
						new PointF { X = 45.497288015110826f, Y = -73.57979737222195f },
						new PointF { X = 45.497397059395695f, Y = -73.57968874275684f },
						new PointF { X = 45.49743278075342f, Y = -73.57976384460926f }
					}
				};
				SGW.SGWBuildingsList.Add(M);

				Building MI = new Building () {
					Code = "MI",
					Name = "MI",
					Address = "2130 Bishop",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49781302380185f, Y = -73.5792676359415f },
						new PointF { X = 45.497646638408106f, Y = -73.5794285684824f },
						new PointF { X = 45.49760198687696f, Y = -73.57933536171913f },
						new PointF { X = 45.497769312432425f, Y = -73.57917308807373f },
						new PointF { X = 45.49781302380185f, Y = -73.5792676359415f }
					}
				};
				SGW.SGWBuildingsList.Add(MI);

				Building MU = new Building () {
					Code = "MU",
					Name = "MU",
					Address = "2170 Bishop",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.497963428254415f, Y = -73.57957072556019f },
						new PointF { X = 45.497789053055065f, Y = -73.57973903417587f },
						new PointF { X = 45.49775380193838f, Y = -73.57966527342796f },
						new PointF { X = 45.49792911727405f, Y = -73.57949763536453f },
						new PointF { X = 45.497963428254415f, Y = -73.57957072556019f }
					}
				};
				SGW.SGWBuildingsList.Add(MU);

				Building H = new Building () {
					Code = "H",
					Name = "Henry F. Hall",
					Address = "1455 De Maisonneuve W.",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.497705860384244f, Y = -73.57903495430946f },
						new PointF { X = 45.49716628007782f, Y = -73.57953920960426f },
						new PointF { X = 45.49683162488575f, Y = -73.57884854078293f },
						new PointF { X = 45.497373088471846f, Y = -73.57834294438362f },
						new PointF { X = 45.497705860384244f, Y = -73.57903495430946f }
					}
				};
				SGW.SGWBuildingsList.Add(H);

				Building LB = new Building () {
					Code = "LB",
					Name = "McConnel Library",
					Address = "1400 De Maisonneuve W.",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49725511377648f, Y = -73.5780693590641f },
						new PointF { X = 45.49701869362308f, Y = -73.5782953351736f },
						new PointF { X = 45.49700177285834f, Y = -73.5782577842474f },
						new PointF { X = 45.496964641162315f, Y = -73.57829332351685f },
						new PointF { X = 45.49694067005441f, Y = -73.57824705541134f },
						new PointF { X = 45.49688943765232f, Y = -73.57829667627811f },
						new PointF { X = 45.49690964860552f, Y = -73.57834227383137f },
						new PointF { X = 45.496872516848754f, Y = -73.57837848365307f },
						new PointF { X = 45.49688943765232f, Y = -73.57841469347477f },
						new PointF { X = 45.49672069941128f, Y = -73.57858903706074f },
						new PointF { X = 45.4967004883903f, Y = -73.57854880392551f },
						new PointF { X = 45.49667322700165f, Y = -73.5785736143589f },
						new PointF { X = 45.49655572086505f, Y = -73.57832685112953f },
						new PointF { X = 45.496579222111976f, Y = -73.57830137014389f },
						new PointF { X = 45.496492737474895f, Y = -73.57811562716961f },
						new PointF { X = 45.496465475985666f, Y = -73.57813976705074f },
						new PointF { X = 45.4962807555472f, Y = -73.57775151729584f },
						new PointF { X = 45.49627135499978f, Y = -73.57775822281837f },
						new PointF { X = 45.49624738359674f, Y = -73.57770927250385f },
						new PointF { X = 45.49648803721908f, Y = -73.57747256755829f },
						new PointF { X = 45.49659943317651f, Y = -73.57771195471287f },
						new PointF { X = 45.49666100637487f, Y = -73.5776549577713f },
						new PointF { X = 45.49662105430725f, Y = -73.57756644487381f },
						new PointF { X = 45.49669437808019f, Y = -73.57749335467815f },
						new PointF { X = 45.496691557936856f, Y = -73.57748866081238f },
						new PointF { X = 45.49688473742963f, Y = -73.5773029178381f },
						new PointF { X = 45.49699895273038f, Y = -73.57754565775394f },
						new PointF { X = 45.49697827178774f, Y = -73.57756778597832f },
						new PointF { X = 45.49699895273038f, Y = -73.57761807739735f },
						new PointF { X = 45.49699143238848f, Y = -73.57762813568115f },
						new PointF { X = 45.49699143238848f, Y = -73.57762813568115f },
						new PointF { X = 45.49699895273038f, Y = -73.57764288783073f },
						new PointF { X = 45.49703984457186f, Y = -73.57760332524776f },
						new PointF { X = 45.497113637819865f, Y = -73.57775621116161f },
						new PointF { X = 45.49707462611481f, Y = -73.57779912650585f },
						new PointF { X = 45.49708261646624f, Y = -73.5778172314167f },
						new PointF { X = 45.497090136795975f, Y = -73.57781052589417f },
						new PointF { X = 45.49711410784025f, Y = -73.57785813510418f },
						new PointF { X = 45.49713948893482f, Y = -73.57783399522305f },
						new PointF { X = 45.49725511377648f, Y = -73.5780693590641f }
					}
				};
				SGW.SGWBuildingsList.Add(LB);

				Building S = new Building () {
					Code = "S",
					Name = "S",
					Address = "2145 Mackay",
					ShapeCoords = new PointF[] {
						new PointF { X = 45.49748636274756f, Y = -73.57983492314816f },
						new PointF { X = 45.497366038198194f, Y = -73.57995428144932f },
						new PointF { X = 45.49732796670521f, Y = -73.57987381517887f },
						new PointF { X = 45.49742620050501f, Y = -73.57977792620659f },
						new PointF { X = 45.497434660824254f, Y = -73.57979267835617f },
						new PointF { X = 45.49745722166936f, Y = -73.57977122068405f },
						new PointF { X = 45.49748636274756f, Y = -73.57983492314816f }
					}
				};
				SGW.SGWBuildingsList.Add(S);
				// Hall Building Shape
				PolygonOptions shape = new PolygonOptions ();

				foreach (Building b in SGW.SGWBuildingsList){

					shape = new PolygonOptions ();
					// 3F -> transparency to ~25%  // 932439 -> Concordia's red color
					shape.InvokeFillColor(0x3F932439);
					shape.InvokeStrokeColor (0x00932439);

					foreach (System.Drawing.PointF p in b.ShapeCoords) {
						shape.Add (new LatLng(p.X, p.Y));
					}

					Console.WriteLine ("Shaping " + b.Name);
					androidMapView.Map.AddPolygon (shape);

				};
					


				_isDrawnDone = true;

			}

		}

	}
}