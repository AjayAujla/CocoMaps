using System;
using CocoMaps.Shared;
using System.Collections.Generic;

namespace CocoMaps.Shared
{
	public class BuildingRepository
	{
		private static BuildingRepository repository;
		List<Campus> CampusList = new List<Campus> ();

		public static BuildingRepository Repository {
			get {
				if (repository == null) {
					repository = new BuildingRepository ();
				}
				return repository;
			}
		}

		private BuildingRepository ()
		{
			Campus SGW = new Campus () {
				Code = "SGW",
				Name = "Sir George Williams",
				Address = "1455 De Maisonneuve Blvd. W.",
				Buildings = new List<Building> ()
			};
			CampusList.Add (SGW);

			Campus LOY = new Campus () {
				Code = "LOY",
				Name = "Loyola",
				Address = "7141 Sherbrooke Street W.",
				Buildings = new List<Building> ()

			};
			CampusList.Add (LOY);


			/*****************************
			 *****************************
			 ******* SGW BUILDINGS *******
			 *****************************
			 *****************************/

			Building B = new Building () {
				Code = "B",
				Name = "B",
				Campus = SGW,
				Address = "2160 Bishop",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49792300709727, -73.57949629426003),
					new Tuple<double, double> (45.49775004181796, -73.57966259121895),
					new Tuple<double, double> (45.497714790676845, -73.57958950102329),
					new Tuple<double, double> (45.49788634602265, -73.57942119240761),
					new Tuple<double, double> (45.49792300709727, -73.57949629426003)
				},
			};
			SGW.Buildings.Add (B);

			Building CB = new Building () {
				Code = "CB",
				Name = "CB",
				Campus = SGW,
				Address = "1425 René Lévesque W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.495461491948106, -73.57426129281521),
					new Tuple<double, double> (45.495081703057934, -73.57463613152504),
					new Tuple<double, double> (45.49504927047214, -73.57456907629967),
					new Tuple<double, double> (45.495077942759096, -73.57453688979149),
					new Tuple<double, double> (45.49495714302504, -73.57426799833775),
					new Tuple<double, double> (45.49502999892679, -73.57419557869434),
					new Tuple<double, double> (45.4950624315237, -73.57426464557648),
					new Tuple<double, double> (45.495120716143674, -73.57420563697815),
					new Tuple<double, double> (45.495091103803965, -73.57413992285728),
					new Tuple<double, double> (45.49516677975225, -73.57406683266163),
					new Tuple<double, double> (45.49519639205217, -73.57412919402122),
					new Tuple<double, double> (45.49525467653348, -73.57407420873642),
					new Tuple<double, double> (45.495226004336494, -73.57400983572006),
					new Tuple<double, double> (45.49530544038742, -73.57393339276314),
					new Tuple<double, double> (45.49535855437077, -73.57403799891472),
					new Tuple<double, double> (45.49536419479084, -73.5740339756012),
					new Tuple<double, double> (45.49538440629147, -73.57407823204994),
					new Tuple<double, double> (45.495376885733954, -73.5740802437067),
					new Tuple<double, double> (45.495461491948106, -73.57426129281521)
				}
			};
			SGW.Buildings.Add (CB);

			Building CI = new Building () {
				Code = "CI",
				Name = "CI",
				Campus = SGW,
				Address = "2149 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49752255406562, -73.57993818819523),
					new Tuple<double, double> (45.497410689916435, -73.58004614710808),
					new Tuple<double, double> (45.497367918271266, -73.57995696365833),
					new Tuple<double, double> (45.49747884247076, -73.57984632253647),
					new Tuple<double, double> (45.49752255406562, -73.57993818819523)
				}
			};
			SGW.Buildings.Add (CI);

			Building CL = new Building () {
				Code = "CL",
				Name = "CL",
				Campus = SGW,
				Address = "1665 St. St. Catherine W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.4944781718791, -73.57927232980728),
					new Tuple<double, double> (45.4941707633251, -73.57964850962162),
					new Tuple<double, double> (45.493989325684645, -73.57934206724167),
					new Tuple<double, double> (45.49398603535935, -73.57932060956955),
					new Tuple<double, double> (45.4939930860562, -73.57928641140461),
					new Tuple<double, double> (45.49401470818766, -73.57924215495586),
					new Tuple<double, double> (45.49404103077127, -73.57920661568642),
					new Tuple<double, double> (45.49426900263261, -73.57892297208309),
					new Tuple<double, double> (45.4944781718791, -73.57927232980728)
				}
			};
			SGW.Buildings.Add (CL);

			Building D = new Building () {
				Code = "D",
				Name = "D",
				Campus = SGW,
				Address = "2140 Bishop",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49784545479588, -73.57933402061462),
					new Tuple<double, double> (45.49767859948234, -73.57949495315552),
					new Tuple<double, double> (45.49764945850363, -73.57943192124367),
					new Tuple<double, double> (45.497814903859954, -73.57927031815052),
					new Tuple<double, double> (45.49784545479588, -73.57933402061462)
				}
			};
			SGW.Buildings.Add (D);

			Building EN = new Building () {
				Code = "EN",
				Name = "EN",
				Campus = SGW,
				Address = "2070 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49693737990155, -73.57957743108273),
					new Tuple<double, double> (45.496918109002365, -73.57953786849976),
					new Tuple<double, double> (45.496906828472945, -73.5795445740223),
					new Tuple<double, double> (45.49689178776354, -73.57951641082764),
					new Tuple<double, double> (45.4967954331236, -73.5796096175909),
					new Tuple<double, double> (45.49680295349169, -73.57963241636753),
					new Tuple<double, double> (45.49667181692945, -73.57976652681828),
					new Tuple<double, double> (45.496699078318784, -73.57981882989407),
					new Tuple<double, double> (45.49693737990155, -73.57957743108273)
				}
			};
			SGW.Buildings.Add (EN);

			Building EV = new Building () {
				Code = "EV",
				Name = "Computer Science, Engineering and Visual Arts Integrated Complex",
				Campus = SGW,
				Address = "1515 St. Catherine W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49518840143307, -73.57789903879166),
					new Tuple<double, double> (45.49526266714314, -73.57805728912354),
					new Tuple<double, double> (45.495279588430456, -73.57813641428947),
					new Tuple<double, double> (45.49536137458087, -73.57844084501266),
					new Tuple<double, double> (45.49556348927069, -73.57885926961899),
					new Tuple<double, double> (45.49565185546529, -73.57885658740997),
					new Tuple<double, double> (45.49592447370251, -73.57858031988144),
					new Tuple<double, double> (45.49559169126274, -73.57787892222404),
					new Tuple<double, double> (45.495592631328904, -73.57780382037163),
					new Tuple<double, double> (45.495522126323436, -73.57765629887581),
					new Tuple<double, double> (45.495429059581035, -73.5776549577713),
					new Tuple<double, double> (45.49518840143307, -73.57789903879166)
				}
			};
			SGW.Buildings.Add (EV);

			Building FA = new Building () {
				Code = "FA",
				Name = "FA",
				Campus = SGW,
				Address = "2060 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.496864056445034, -73.57952110469341),
					new Tuple<double, double> (45.49682739468098, -73.57944399118423),
					new Tuple<double, double> (45.496742790518965, -73.57953317463398),
					new Tuple<double, double> (45.49678039238446, -73.57960693538189),
					new Tuple<double, double> (45.496864056445034, -73.57952110469341)
				}
			};
			SGW.Buildings.Add (FA);


			Building FB = new Building () {
				Code = "FB",
				Name = "Faubourg Tower",
				Campus = SGW,
				Address = "1250 Guy",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.494912019322506, -73.57778571546078),
					new Tuple<double, double> (45.49487065589675, -73.57771262526512),
					new Tuple<double, double> (45.494876296365675, -73.57770457863808),
					new Tuple<double, double> (45.49483681307125, -73.57763350009918),
					new Tuple<double, double> (45.49484104342554, -73.57762679457664),
					new Tuple<double, double> (45.49480014998734, -73.57755102217197),
					new Tuple<double, double> (45.49480626050299, -73.57754096388817),
					new Tuple<double, double> (45.49476395691957, -73.57746586203575),
					new Tuple<double, double> (45.49477335771863, -73.57745379209518),
					new Tuple<double, double> (45.494692040754835, -73.57730962336063),
					new Tuple<double, double> (45.49469956140383, -73.57729889452457),
					new Tuple<double, double> (45.49465443749489, -73.57721976935863),
					new Tuple<double, double> (45.49439779457518, -73.5775201767683),
					new Tuple<double, double> (45.494696741160546, -73.57803918421268),
					new Tuple<double, double> (45.494912019322506, -73.57778571546078)
				}
			};
			SGW.Buildings.Add (FB);

			Building FG = new Building () {
				Code = "FG",
				Name = "Faubourg Tower",
				Campus = SGW,
				Address = "1616 St. Catherine W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.494694390957754, -73.57803918421268),
					new Tuple<double, double> (45.494451849499804, -73.57761606574059),
					new Tuple<double, double> (45.49438933379967, -73.57769183814526),
					new Tuple<double, double> (45.49442693723663, -73.57776291668415),
					new Tuple<double, double> (45.494391684015206, -73.57780314981937),
					new Tuple<double, double> (45.49437194220157, -73.57776828110218),
					new Tuple<double, double> (45.49418721489572, -73.57798755168915),
					new Tuple<double, double> (45.494203666461544, -73.57801638543606),
					new Tuple<double, double> (45.49411153763108, -73.57812702655792),
					new Tuple<double, double> (45.49410495699457, -73.57811562716961),
					new Tuple<double, double> (45.493911767965706, -73.57834227383137),
					new Tuple<double, double> (45.493922579048075, -73.57836373150349),
					new Tuple<double, double> (45.4938924960311, -73.57839927077293),
					new Tuple<double, double> (45.493883095084975, -73.57838585972786),
					new Tuple<double, double> (45.49383656037867, -73.57844151556492),
					new Tuple<double, double> (45.49384925166602, -73.57846297323704),
					new Tuple<double, double> (45.493625978600626, -73.57873052358627),
					new Tuple<double, double> (45.4938224589449, -73.57906647026539),
					new Tuple<double, double> (45.49429579514127, -73.5785112529993),
					new Tuple<double, double> (45.49430190571165, -73.57852131128311),
					new Tuple<double, double> (45.49436818185533, -73.57844218611717),
					new Tuple<double, double> (45.49436348142216, -73.57842944562435),
					new Tuple<double, double> (45.494694390957754, -73.57803918421268)
				}
			};
			SGW.Buildings.Add (FG);

			Building GM = new Building () {
				Code = "GM",
				Name = "Guy-Metro",
				Campus = SGW,
				Address = "1550 De Maisonneuve W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49579286506311, -73.5791952162981),
					new Tuple<double, double> (45.49611483565458, -73.57887402176857),
					new Tuple<double, double> (45.49594703515268, -73.5785186290741),
					new Tuple<double, double> (45.495619893240686, -73.57884116470814),
					new Tuple<double, double> (45.49579286506311, -73.5791952162981)
				}
			};
			SGW.Buildings.Add (GM);

			Building H = new Building () {
				Code = "H",
				Name = "Henry F. Hall",
				Campus = SGW,
				Address = "1455 De Maisonneuve W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.497705860384244, -73.57903495430946),
					new Tuple<double, double> (45.49716628007782, -73.57953920960426),
					new Tuple<double, double> (45.49683162488575, -73.57884854078293),
					new Tuple<double, double> (45.497373088471846, -73.57834294438362),
					new Tuple<double, double> (45.497705860384244, -73.57903495430946)
				},
				Services = new List<Service> {
					new Service {
						Name = "Dean of Students",
						RoomNumber = "H-637"
					},
					new Service {
						Name = "Aboriginal Student Resource Center",
						RoomNumber = "H-641"
					},
					new Service {
						Name = "International Students Office",
						RoomNumber = "H-653"
					},
					new Service {
						Name = "IT Services",
						RoomNumber = "H-925"
					},
					new Service {
						Name = "Security Department",
						RoomNumber = "H-118"
					},
					new Service {
						Name = "Counselling and Development",
						RoomNumber = "H-440"
					},
					new Service {
						Name = "Access Centre for Students with Disabilities",
						RoomNumber = "H-580"
					}
				}
			};
			SGW.Buildings.Add (H);

			Building K = new Building () {
				Code = "K",
				Name = "K",
				Campus = SGW,
				Address = "2150 Bishop",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.497884935980856, -73.5794198513031),
					new Tuple<double, double> (45.49763159789631, -73.57966527342796),
					new Tuple<double, double> (45.4975925865501, -73.57958480715752),
					new Tuple<double, double> (45.49784733485295, -73.57933804392815),
					new Tuple<double, double> (45.497884935980856, -73.5794198513031)
				}
			};
			SGW.Buildings.Add (K);

			Building LB = new Building () {
				Code = "LB",
				Name = "McConnel Library",
				Campus = SGW,
				Address = "1400 De Maisonneuve W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49725511377648, -73.5780693590641),
					new Tuple<double, double> (45.49701869362308, -73.5782953351736),
					new Tuple<double, double> (45.49700177285834, -73.5782577842474),
					new Tuple<double, double> (45.496964641162315, -73.57829332351685),
					new Tuple<double, double> (45.49694067005441, -73.57824705541134),
					new Tuple<double, double> (45.49688943765232, -73.57829667627811),
					new Tuple<double, double> (45.49690964860552, -73.57834227383137),
					new Tuple<double, double> (45.496872516848754, -73.57837848365307),
					new Tuple<double, double> (45.49688943765232, -73.57841469347477),
					new Tuple<double, double> (45.49672069941128, -73.57858903706074),
					new Tuple<double, double> (45.4967004883903, -73.57854880392551),
					new Tuple<double, double> (45.49667322700165, -73.5785736143589),
					new Tuple<double, double> (45.49655572086505, -73.57832685112953),
					new Tuple<double, double> (45.496579222111976, -73.57830137014389),
					new Tuple<double, double> (45.496492737474895, -73.57811562716961),
					new Tuple<double, double> (45.496465475985666, -73.57813976705074),
					new Tuple<double, double> (45.4962807555472, -73.57775151729584),
					new Tuple<double, double> (45.49627135499978, -73.57775822281837),
					new Tuple<double, double> (45.49624738359674, -73.57770927250385),
					new Tuple<double, double> (45.49648803721908, -73.57747256755829),
					new Tuple<double, double> (45.49659943317651, -73.57771195471287),
					new Tuple<double, double> (45.49666100637487, -73.5776549577713),
					new Tuple<double, double> (45.49662105430725, -73.57756644487381),
					new Tuple<double, double> (45.49669437808019, -73.57749335467815),
					new Tuple<double, double> (45.496691557936856, -73.57748866081238),
					new Tuple<double, double> (45.49688473742963, -73.5773029178381),
					new Tuple<double, double> (45.49699895273038, -73.57754565775394),
					new Tuple<double, double> (45.49697827178774, -73.57756778597832),
					new Tuple<double, double> (45.49699895273038, -73.57761807739735),
					new Tuple<double, double> (45.49699143238848, -73.57762813568115),
					new Tuple<double, double> (45.49699143238848, -73.57762813568115),
					new Tuple<double, double> (45.49699895273038, -73.57764288783073),
					new Tuple<double, double> (45.49703984457186, -73.57760332524776),
					new Tuple<double, double> (45.497113637819865, -73.57775621116161),
					new Tuple<double, double> (45.49707462611481, -73.57779912650585),
					new Tuple<double, double> (45.49708261646624, -73.5778172314167),
					new Tuple<double, double> (45.497090136795975, -73.57781052589417),
					new Tuple<double, double> (45.49711410784025, -73.57785813510418),
					new Tuple<double, double> (45.49713948893482, -73.57783399522305),
					new Tuple<double, double> (45.49725511377648, -73.5780693590641)
				},
				Services = new List<Service> {
					new Service {
						Name = "J.A. DeSève Cinema",
						RoomNumber = "LB-125"
					},
					new Service {
						Name = "Birks Student Service Centre",
						RoomNumber = "LB-185"
					},
					new Service {
						Name = "Bookstore",
						RoomNumber = "LB-103"
					},
					new Service {
						Name = "Computer Store",
						RoomNumber = "LB-103"
					},
					new Service {
						Name = "Campus Corner",
						RoomNumber = "LB-119"
					},
					new Service {
						Name = "Print Store",
						RoomNumber = "LB-115"
					},
					new Service {
						Name = "DPrint Administration",
						RoomNumber = "LB-018"
					},
					new Service {
						Name = "Welcome Centre",
						RoomNumber = "LB-187"
					}
				}
			};
			SGW.Buildings.Add (LB);

			Building M = new Building () {
				Code = "M",
				Name = "M",
				Campus = SGW,
				Address = "2135 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49743278075342, -73.57976384460926),
					new Tuple<double, double> (45.497325146593596, -73.57987113296986),
					new Tuple<double, double> (45.497288015110826, -73.57979737222195),
					new Tuple<double, double> (45.497397059395695, -73.57968874275684),
					new Tuple<double, double> (45.49743278075342, -73.57976384460926)
				}
			};
			SGW.Buildings.Add (M);

			Building MB = new Building () {
				Code = "MB",
				Name = "John Molson School of Business",
				Campus = SGW,
				Address = "1450 Guy",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49781302380185, -73.5792676359415),
					new Tuple<double, double> (45.497646638408106, -73.5794285684824),
					new Tuple<double, double> (45.49760198687696, -73.57933536171913),
					new Tuple<double, double> (45.497769312432425, -73.57917308807373),
					new Tuple<double, double> (45.49781302380185, -73.5792676359415)
				}
			};
			SGW.Buildings.Add (MB);

			Building MI = new Building () {
				Code = "MI",
				Name = "MI",
				Campus = SGW,
				Address = "2130 Bishop",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.495200152343095, -73.57926495373249),
					new Tuple<double, double> (45.49513857754739, -73.57933603227139),
					new Tuple<double, double> (45.495276298180556, -73.57959017157555),
					new Tuple<double, double> (45.49531484109607, -73.57958883047104),
					new Tuple<double, double> (45.495384876326256, -73.57951506972313),
					new Tuple<double, double> (45.49539662719529, -73.57953518629074),
					new Tuple<double, double> (45.4956288238641, -73.57927702367306),
					new Tuple<double, double> (45.49525843682053, -73.57851393520832),
					new Tuple<double, double> (45.49522130397495, -73.57851259410381),
					new Tuple<double, double> (45.49506384163618, -73.57868760824203),
					new Tuple<double, double> (45.495092983952986, -73.5787446051836),
					new Tuple<double, double> (45.49507136223551, -73.57876606285572),
					new Tuple<double, double> (45.495066191823575, -73.57875868678093),
					new Tuple<double, double> (45.49502670866229, -73.57875600457191),
					new Tuple<double, double> (45.494963723561966, -73.57882641255856),
					new Tuple<double, double> (45.495200152343095, -73.57926495373249)
				}
			};
			SGW.Buildings.Add (MI);

			Building MU = new Building () {
				Code = "MU",
				Name = "MU",
				Campus = SGW,
				Address = "2170 Bishop",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.497963428254415, -73.57957072556019),
					new Tuple<double, double> (45.497789053055065, -73.57973903417587),
					new Tuple<double, double> (45.49775380193838, -73.57966527342796),
					new Tuple<double, double> (45.49792911727405, -73.57949763536453),
					new Tuple<double, double> (45.497963428254415, -73.57957072556019)
				}
			};
			SGW.Buildings.Add (MU);

			Building P = new Building () {
				Code = "P",
				Name = "P",
				Campus = SGW,
				Address = "2020 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49671787926927, -73.57919186353683),
					new Tuple<double, double> (45.496680747386044, -73.57911810278893),
					new Tuple<double, double> (45.49658204226096, -73.57921734452248),
					new Tuple<double, double> (45.49661823416025, -73.57929177582264),
					new Tuple<double, double> (45.49671787926927, -73.57919186353683)
				}
			};
			SGW.Buildings.Add (P);

			Building PR = new Building () {
				Code = "PR",
				Name = "PR",
				Campus = SGW,
				Address = "2100 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.497031384193306, -73.5798691213131),
					new Tuple<double, double> (45.496987672217166, -73.57978396117687),
					new Tuple<double, double> (45.49679778323874, -73.57997439801693),
					new Tuple<double, double> (45.4968386752263, -73.58006224036217),
					new Tuple<double, double> (45.497031384193306, -73.5798691213131)
				}
			};
			SGW.Buildings.Add (PR);

			Building Q = new Building () {
				Code = "Q",
				Name = "Q",
				Campus = SGW,
				Address = "2010 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.496680277362046, -73.57911005616188),
					new Tuple<double, double> (45.496651135866685, -73.57905372977257),
					new Tuple<double, double> (45.49654961053924, -73.5791576653719),
					new Tuple<double, double> (45.496576871987735, -73.57921533286572),
					new Tuple<double, double> (45.496680277362046, -73.57911005616188)
				}
			};
			SGW.Buildings.Add (Q);

			Building R = new Building () {
				Code = "R",
				Name = "R",
				Campus = SGW,
				Address = "2050 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.496825514589865, -73.57944063842297),
					new Tuple<double, double> (45.49678462259274, -73.57935816049576),
					new Tuple<double, double> (45.496699078318784, -73.5794473439455),
					new Tuple<double, double> (45.49673668021346, -73.57952781021595),
					new Tuple<double, double> (45.496825514589865, -73.57944063842297)
				}
			};
			SGW.Buildings.Add (R);

			Building RR = new Building () {
				Code = "RR",
				Name = "RR",
				Campus = SGW,
				Address = "2040 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49678227247707, -73.5793574899435),
					new Tuple<double, double> (45.49674044040154, -73.57927367091179),
					new Tuple<double, double> (45.49661212384121, -73.57940509915352),
					new Tuple<double, double> (45.496651135866685, -73.57948824763298),
					new Tuple<double, double> (45.49678227247707, -73.5793574899435)
				}
			};
			SGW.Buildings.Add (RR);

			Building S = new Building () {
				Code = "S",
				Name = "S",
				Campus = SGW,
				Address = "2145 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49748636274756, -73.57983492314816),
					new Tuple<double, double> (45.497366038198194, -73.57995428144932),
					new Tuple<double, double> (45.49732796670521, -73.57987381517887),
					new Tuple<double, double> (45.49742620050501, -73.57977792620659),
					new Tuple<double, double> (45.497434660824254, -73.57979267835617),
					new Tuple<double, double> (45.49745722166936, -73.57977122068405),
					new Tuple<double, double> (45.49748636274756, -73.57983492314816)
				}
			};
			SGW.Buildings.Add (S);

			Building T = new Building () {
				Code = "T",
				Name = "T",
				Campus = SGW,
				Address = "2030 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49673056990727, -73.57928305864334),
					new Tuple<double, double> (45.49669672819955, -73.57921868562698),
					new Tuple<double, double> (45.496621054307276, -73.57929311692715),
					new Tuple<double, double> (45.49665348598783, -73.57935816049576),
					new Tuple<double, double> (45.49673056990727, -73.57928305864334)
				}
			};
			SGW.Buildings.Add (T);

			Building V = new Building () {
				Code = "V",
				Name = "V",
				Campus = SGW,
				Address = "2110 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.497088726734205, -73.57994019985199),
					new Tuple<double, double> (45.49704877497009, -73.5798604041338),
					new Tuple<double, double> (45.4970337342986, -73.57987314462662),
					new Tuple<double, double> (45.497030444151186, -73.57986845076084),
					new Tuple<double, double> (45.496941140076245, -73.5799589753151),
					new Tuple<double, double> (45.49698532210997, -73.58004480600357),
					new Tuple<double, double> (45.497088726734205, -73.57994019985199)
				}
			};
			SGW.Buildings.Add (V);

			Building X = new Building () {
				Code = "X",
				Name = "X",
				Campus = SGW,
				Address = "2080 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.496943020163485, -73.57969343662262),
					new Tuple<double, double> (45.496904948384476, -73.57961632311344),
					new Tuple<double, double> (45.49682175440746, -73.5796994715929),
					new Tuple<double, double> (45.49685794615269, -73.57977390289307),
					new Tuple<double, double> (45.496943020163485, -73.57969343662262)
				}
			};
			SGW.Buildings.Add (X);

			Building Z = new Building () {
				Code = "Z",
				Name = "Z",
				Campus = SGW,
				Address = "2090 Mackay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.49699049234569, -73.57977591454983),
					new Tuple<double, double> (45.49694725035956, -73.57969142496586),
					new Tuple<double, double> (45.49685841617521, -73.57977993786335),
					new Tuple<double, double> (45.496899778140914, -73.57986576855183),
					new Tuple<double, double> (45.49699049234569, -73.57977591454983)
				}
			};
			SGW.Buildings.Add (Z);





			/******************************
			 ******************************
			 ****** LOYOLA BUILDINGS ******
			 ******************************
			 ******************************/

			Building AD = new Building () {
				Code = "AD",
				Name = "Administration",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45828033335741, -73.63981448113918),
					new Tuple<double, double> (45.45821495544604, -73.63986544311047),
					new Tuple<double, double> (45.45818861612217, -73.63980107009411),
					new Tuple<double, double> (45.45807432212794, -73.63989226520061),
					new Tuple<double, double> (45.45808137731947, -73.639917075634),
					new Tuple<double, double> (45.45806209312717, -73.63993182778358),
					new Tuple<double, double> (45.45808466974189, -73.63998547196388),
					new Tuple<double, double> (45.45805362689433, -73.64001229405403),
					new Tuple<double, double> (45.45802916888118, -73.63995261490345),
					new Tuple<double, double> (45.45800847363098, -73.63996803760529),
					new Tuple<double, double> (45.45799906669659, -73.6399445682764),
					new Tuple<double, double> (45.457867369450064, -73.64004984498024),
					new Tuple<double, double> (45.45789464961923, -73.64012025296688),
					new Tuple<double, double> (45.45783209334964, -73.64017456769943),
					new Tuple<double, double> (45.457719209680036, -73.63987818360329),
					new Tuple<double, double> (45.457779414331945, -73.63982923328876),
					new Tuple<double, double> (45.45781657185847, -73.63992109894753),
					new Tuple<double, double> (45.4579407436682, -73.63982386887074),
					new Tuple<double, double> (45.45793415880639, -73.6398084461689),
					new Tuple<double, double> (45.45799906669659, -73.63975681364536),
					new Tuple<double, double> (45.45800800328433, -73.63977022469044),
					new Tuple<double, double> (45.45815051814984, -73.63965958356857),
					new Tuple<double, double> (45.458114771880766, -73.63956771790981),
					new Tuple<double, double> (45.45816792093052, -73.63952614367008),
					new Tuple<double, double> (45.45828033335741, -73.63981179893017),
					new Tuple<double, double> (45.45828033335741, -73.63981448113918)
				}
			};
			LOY.Buildings.Add (AD);

			Building BB = new Building () {
				Code = "BB",
				Name = "BB",
				Campus = LOY,
				Address = "3502 Belmore",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45985549479686, -73.63937325775623),
					new Tuple<double, double> (45.45984608817059, -73.6393390595913),
					new Tuple<double, double> (45.45983197822826, -73.63934844732285),
					new Tuple<double, double> (45.459838562868455, -73.63937795162201),
					new Tuple<double, double> (45.459838562868455, -73.63937795162201),
					new Tuple<double, double> (45.45985549479686, -73.63937325775623)
				}
			};
			LOY.Buildings.Add (BB);

			Building BH = new Building () {
				Code = "BH",
				Name = "BH",
				Campus = LOY,
				Address = "3500 Belmore",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.459817397950786, -73.63918080925941),
					new Tuple<double, double> (45.45975672514275, -73.63903127610683),
					new Tuple<double, double> (45.45966124764598, -73.63911174237728),
					new Tuple<double, double> (45.459720509559546, -73.63926060497761),
					new Tuple<double, double> (45.45981833861395, -73.63918013870716),
					new Tuple<double, double> (45.459817397950786, -73.63918080925941)
				}
			};
			LOY.Buildings.Add (BH);

			Building CC = new Building () {
				Code = "CC",
				Name = "Central",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45844871640609, -73.64071905612946),
					new Tuple<double, double> (45.45829444368806, -73.64083774387836),
					new Tuple<double, double> (45.45808843251011, -73.64030197262764),
					new Tuple<double, double> (45.45809125458613, -73.64029727876186),
					new Tuple<double, double> (45.45800000739008, -73.64005520939827),
					new Tuple<double, double> (45.458142522275836, -73.63994389772415),
					new Tuple<double, double> (45.45823659130999, -73.64018328487873),
					new Tuple<double, double> (45.45824223544704, -73.64017590880394),
					new Tuple<double, double> (45.45844871640609, -73.64071905612946)
				}
			};
			LOY.Buildings.Add (CC);

			Building CJ = new Building () {
				Code = "CJ",
				Name = "Communication and Journalism",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.457333051751476, -73.64075526595116),
					new Tuple<double, double> (45.457305771310594, -73.6406908929348),
					new Tuple<double, double> (45.45728225367856, -73.6407096683979),
					new Tuple<double, double> (45.457175013152096, -73.6404387652874),
					new Tuple<double, double> (45.457423359323684, -73.6402416229248),
					new Tuple<double, double> (45.45737350203607, -73.64011287689209),
					new Tuple<double, double> (45.457306712015665, -73.64007532596588),
					new Tuple<double, double> (45.45730106778496, -73.64009141921997),
					new Tuple<double, double> (45.45723145555987, -73.64004448056221),
					new Tuple<double, double> (45.45722298920231, -73.63996803760529),
					new Tuple<double, double> (45.45722863344083, -73.63990902900696),
					new Tuple<double, double> (45.45725121038923, -73.63986074924469),
					new Tuple<double, double> (45.45727190591733, -73.6398258805275),
					new Tuple<double, double> (45.457307652720715, -73.63979905843735),
					new Tuple<double, double> (45.457350925136616, -73.63978430628777),
					new Tuple<double, double> (45.45739796033361, -73.63978698849678),
					new Tuple<double, double> (45.45744029197736, -73.63980576395988),
					new Tuple<double, double> (45.457461928138585, -73.63982185721397),
					new Tuple<double, double> (45.4574732165672, -73.63983929157257),
					new Tuple<double, double> (45.4574732165672, -73.63984867930412),
					new Tuple<double, double> (45.45745440251823, -73.6399693787098),
					new Tuple<double, double> (45.45744311408582, -73.63995999097824),
					new Tuple<double, double> (45.45743652916589, -73.6400619149208),
					new Tuple<double, double> (45.45748826780188, -73.64019066095352),
					new Tuple<double, double> (45.45762278803329, -73.64009007811546),
					new Tuple<double, double> (45.45771873933096, -73.64033281803131),
					new Tuple<double, double> (45.45775636724623, -73.64030197262764),
					new Tuple<double, double> (45.45783444509036, -73.64048838615417),
					new Tuple<double, double> (45.45765665321582, -73.64063456654549),
					new Tuple<double, double> (45.457621847333485, -73.64056348800659),
					new Tuple<double, double> (45.457549413401395, -73.64062249660492),
					new Tuple<double, double> (45.457532480780465, -73.64059031009674),
					new Tuple<double, double> (45.457335873865276, -73.64074990153313),
					new Tuple<double, double> (45.457335873865276, -73.64075258374214),
					new Tuple<double, double> (45.45733399245609, -73.64075124263763),
					new Tuple<double, double> (45.457333051751476, -73.64075526595116)
				}
			};
			LOY.Buildings.Add (CJ);

			Building DO = new Building () {
				Code = "DO",
				Name = "Stinger Dome",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.4579407436682, -73.6347833275795),
					new Tuple<double, double> (45.45791252282638, -73.63459825515747),
					new Tuple<double, double> (45.457850436924595, -73.63460898399353),
					new Tuple<double, double> (45.4578579624921, -73.63478064537048),
					new Tuple<double, double> (45.4579407436682, -73.6347833275795)
				}
			};
			LOY.Buildings.Add (DO);

			Building FC = new Building () {
				Code = "FC",
				Name = "F.C. Smith",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45865801865666, 73.63962337374687),
					new Tuple<double, double> (45.45865942968043, 73.6395824700594),
					new Tuple<double, double> (45.45863591261296, 73.63951876759529),
					new Tuple<double, double> (45.458646260123835, 73.63950870931149),
					new Tuple<double, double> (45.45861333621894, 73.63943293690681),
					new Tuple<double, double> (45.458620861684615, 73.63942556083202),
					new Tuple<double, double> (45.45851221267656, 73.63915733993053),
					new Tuple<double, double> (45.45852067884054, 73.63914124667645),
					new Tuple<double, double> (45.45852538226445, 73.63913387060165),
					new Tuple<double, double> (45.458526793291526, 73.6391231417656),
					new Tuple<double, double> (45.458526793291526, 73.6391144245863),
					new Tuple<double, double> (45.45852538226445, 73.63910503685474),
					new Tuple<double, double> (45.45852303055254, 73.63909363746643),
					new Tuple<double, double> (45.458519738155715, 73.6390869319439),
					new Tuple<double, double> (45.45851456438889, 73.6390782147646),
					new Tuple<double, double> (45.45850844993658, 73.63907486200333),
					new Tuple<double, double> (45.458501865141045, 73.6390694975853),
					new Tuple<double, double> (45.45849575068736, 73.6390694975853),
					new Tuple<double, double> (45.458491987946324, 73.63907150924206),
					new Tuple<double, double> (45.458488695547686, 73.63907285034657),
					new Tuple<double, double> (45.458483992120726, 73.63907486200333),
					new Tuple<double, double> (45.4584802293789, 73.63907754421234),
					new Tuple<double, double> (45.45847693697958, 73.6390795558691),
					new Tuple<double, double> (45.45847458526564, 73.63908223807812),
					new Tuple<double, double> (45.458470352180356, 73.63908559083939),
					new Tuple<double, double> (45.458459063951324, 73.63909162580967),
					new Tuple<double, double> (45.45845247915003, 73.63909967243671),
					new Tuple<double, double> (45.45844354263275, 73.63910235464573),
					new Tuple<double, double> (45.458333952595076, 73.63918215036392),
					new Tuple<double, double> (45.45834947394385, 73.63922238349915),
					new Tuple<double, double> (45.458338656034556, 73.6392317712307),
					new Tuple<double, double> (45.458348062912314, 73.63926127552986),
					new Tuple<double, double> (45.458348062912314, 73.63926127552986),
					new Tuple<double, double> (45.458361702882286, 73.63925389945507),
					new Tuple<double, double> (45.458425669593936, 73.63942354917526),
					new Tuple<double, double> (45.45839133452977, 73.63945037126541),
					new Tuple<double, double> (45.45841955513198, 73.63952279090881),
					new Tuple<double, double> (45.458450597778075, 73.63949865102768),
					new Tuple<double, double> (45.45849951342818, 73.6396186798811),
					new Tuple<double, double> (45.458513623703965, 73.63960795104504),
					new Tuple<double, double> (45.458539492533774, 73.63968171179295),
					new Tuple<double, double> (45.4585719461398, 73.63969579339027),
					new Tuple<double, double> (45.45865801865666, 73.63962538540363),
					new Tuple<double, double> (45.45865990002167, 73.63962471485138),
					new Tuple<double, double> (45.45865895933916, 73.63962471485138),
					new Tuple<double, double> (45.45865801865666, 73.63962337374687)
				}
			};
			LOY.Buildings.Add (FC);

			Building GE = new Building () {
				Code = "GE",
				Name = "Centre for Structural and Functional Genomics",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.456970879305665, -73.6404401063919),
					new Tuple<double, double> (45.45696053148731, -73.64037171006203),
					new Tuple<double, double> (45.45693607300003, -73.64037975668907),
					new Tuple<double, double> (45.45694359868957, -73.64043742418289),
					new Tuple<double, double> (45.456970879305665, -73.6404401063919)
				}
			};
			LOY.Buildings.Add (GE);

			Building HA = new Building () {
				Code = "HA",
				Name = "Hingston Wing A",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45967018397027, -73.6413835734129),
					new Tuple<double, double> (45.459646667324336, -73.64132322371006),
					new Tuple<double, double> (45.459656073983886, -73.641312494874),
					new Tuple<double, double> (45.45952343993943, -73.64096380770206),
					new Tuple<double, double> (45.45951168158709, -73.64097453653812),
					new Tuple<double, double> (45.45948675387204, -73.64091485738754),
					new Tuple<double, double> (45.45946511848779, -73.64093229174614),
					new Tuple<double, double> (45.45946088547685, -73.6409255862236),
					new Tuple<double, double> (45.459266636966476, -73.6410778015852),
					new Tuple<double, double> (45.45926992931969, -73.64108987152576),
					new Tuple<double, double> (45.45924970486122, -73.6411052942276),
					new Tuple<double, double> (45.45927039965584, -73.64116497337818),
					new Tuple<double, double> (45.45925628956943, -73.641177713871),
					new Tuple<double, double> (45.45939033524782, -73.64153042435646),
					new Tuple<double, double> (45.45940256396051, -73.64151902496815),
					new Tuple<double, double> (45.45942749171276, -73.6415746808052),
					new Tuple<double, double> (45.4596715949687, -73.64138290286064),
					new Tuple<double, double> (45.45967018397027, -73.6413835734129)
				}
			};
			LOY.Buildings.Add (HA);


			Building HB = new Building () {
				Code = "HB",
				Name = "Hingston Wing B",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.459342831377185, -73.64217348396778),
					new Tuple<double, double> (45.45932166627344, -73.64211715757847),
					new Tuple<double, double> (45.45934471271938, -73.6420963704586),
					new Tuple<double, double> (45.45934047969938, -73.64208430051804),
					new Tuple<double, double> (45.45950509690873, -73.64195622503757),
					new Tuple<double, double> (45.45953002461565, -73.64201724529266),
					new Tuple<double, double> (45.45955071930737, -73.64199712872505),
					new Tuple<double, double> (45.45938845390715, -73.6415746808052),
					new Tuple<double, double> (45.4594166740103, -73.64155322313309),
					new Tuple<double, double> (45.459405385970726, -73.64151567220688),
					new Tuple<double, double> (45.45937481418557, -73.64153981208801),
					new Tuple<double, double> (45.45936305580224, -73.64151768386364),
					new Tuple<double, double> (45.45895386253506, -73.64184021949768),
					new Tuple<double, double> (45.458975027776894, -73.64189721643925),
					new Tuple<double, double> (45.4589557438902, -73.64191196858883),
					new Tuple<double, double> (45.45895762524529, -73.64192672073841),
					new Tuple<double, double> (45.45895009982458, -73.6419340968132),
					new Tuple<double, double> (45.459083205555444, -73.64228814840317),
					new Tuple<double, double> (45.45909543433475, -73.64227943122387),
					new Tuple<double, double> (45.45910295973607, -73.64229150116444),
					new Tuple<double, double> (45.45912224357238, -73.64227004349232),
					new Tuple<double, double> (45.4591467011114, -73.6423310637474),
					new Tuple<double, double> (45.45934236104165, -73.64217482507229),
					new Tuple<double, double> (45.459341420370514, -73.64217147231102),
					new Tuple<double, double> (45.45934236104165, -73.64217482507229),
					new Tuple<double, double> (45.45934236104165, -73.64217482507229),
					new Tuple<double, double> (45.45934236104165, -73.64217482507229),
					new Tuple<double, double> (45.459341420370514, -73.64217147231102),
					new Tuple<double, double> (45.45934330171276, -73.64217549562454),
					new Tuple<double, double> (45.459342831377185, -73.64217348396778)
				}
			};
			LOY.Buildings.Add (HB);

			Building HC = new Building () {
				Code = "HC",
				Name = "Hingston Wing C",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45978776705269, -73.64214397966862),
					new Tuple<double, double> (45.4597750680916, -73.64210911095142),
					new Tuple<double, double> (45.45988606632139, -73.64201992750168),
					new Tuple<double, double> (45.45981692761919, -73.64184089004993),
					new Tuple<double, double> (45.459705929253246, -73.64193007349968),
					new Tuple<double, double> (45.4596904082779, -73.64189453423023),
					new Tuple<double, double> (45.459517795930594, -73.64203467965126),
					new Tuple<double, double> (45.45961609566999, -73.64228144288063),
					new Tuple<double, double> (45.45978729672083, -73.64214465022087),
					new Tuple<double, double> (45.459788237384515, -73.64214263856411),
					new Tuple<double, double> (45.45978729672083, -73.64214465022087),
					new Tuple<double, double> (45.45978776705269, -73.64214397966862)
				}
			};
			LOY.Buildings.Add (HC);

			Building JR = new Building () {
				Code = "JR",
				Name = "Jesuit Residence",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.458539022191516, -73.64337980747223),
					new Tuple<double, double> (45.45850844993658, -73.64330671727657),
					new Tuple<double, double> (45.458526793291526, -73.64329263567924),
					new Tuple<double, double> (45.45848681417695, -73.64319205284119),
					new Tuple<double, double> (45.45847646663678, -73.64320278167725),
					new Tuple<double, double> (45.458443072289704, -73.64312700927258),
					new Tuple<double, double> (45.458389923499304, -73.64317126572132),
					new Tuple<double, double> (45.45839509727755, -73.64318668842316),
					new Tuple<double, double> (45.458384279377015, -73.64319540560246),
					new Tuple<double, double> (45.458371580099836, -73.64316791296005),
					new Tuple<double, double> (45.4583019691963, -73.64322692155838),
					new Tuple<double, double> (45.45833066018724, -73.64329800009727),
					new Tuple<double, double> (45.45831184642434, -73.64331677556038),
					new Tuple<double, double> (45.4583527663506, -73.64341199398041),
					new Tuple<double, double> (45.45836734700681, -73.64340126514435),
					new Tuple<double, double> (45.458398860025085, -73.64346966147423),
					new Tuple<double, double> (45.4584628266946, -73.6434193700552),
					new Tuple<double, double> (45.458470352180356, -73.64343479275703),
					new Tuple<double, double> (45.458539022191516, -73.64337980747223)
				}
			};
			LOY.Buildings.Add (JR);

			Building PC = new Building () {
				Code = "PC",
				Name = "PERFORM Center",
				Campus = LOY,
				Address = "7200 Sherbrooke St. W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.457082823764566, -73.63702297210693),
					new Tuple<double, double> (45.45703014404687, -73.63684058189392),
					new Tuple<double, double> (45.456962412908965, -73.63687813282013),
					new Tuple<double, double> (45.45698122712211, -73.637033700943),
					new Tuple<double, double> (45.45698122712211, -73.637033700943),
					new Tuple<double, double> (45.45698122712211, -73.637033700943),
					new Tuple<double, double> (45.457082823764566, -73.63702297210693)
				}
			};
			LOY.Buildings.Add (PC);

			Building PS = new Building () {
				Code = "PS",
				Name = "Physical Services",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45994250601546, -73.6400619149208),
					new Tuple<double, double> (45.45966030698017, -73.63932967185974),
					new Tuple<double, double> (45.45962268033541, -73.63936051726341),
					new Tuple<double, double> (45.459565299653825, -73.63922774791718),
					new Tuple<double, double> (45.45927839536991, -73.63945305347443),
					new Tuple<double, double> (45.459330132315905, -73.6395911872387),
					new Tuple<double, double> (45.45939691993959, -73.63954022526741),
					new Tuple<double, double> (45.459443012760495, -73.6396461725235),
					new Tuple<double, double> (45.45941479267053, -73.63967299461365),
					new Tuple<double, double> (45.45960857033717, -73.64017054438591),
					new Tuple<double, double> (45.45963020566638, -73.64014774560928),
					new Tuple<double, double> (45.4597026369255, -73.64032745361328),
					new Tuple<double, double> (45.4598503211526, -73.64021614193916),
					new Tuple<double, double> (45.45982868590784, -73.64015713334084),
					new Tuple<double, double> (45.45994250601546, -73.6400619149208)
				}
			};
			LOY.Buildings.Add (PS);

			Building PT = new Building () {
				Code = "PT",
				Name = "Oscar Peterson Concert Hall",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45948957587806, -73.6391332000494),
					new Tuple<double, double> (45.459457593134786, -73.63905608654022),
					new Tuple<double, double> (45.45944818644213, -73.63906346261501),
					new Tuple<double, double> (45.45931131888648, -73.63871075212955),
					new Tuple<double, double> (45.4593211959377, -73.63870203495026),
					new Tuple<double, double> (45.4593141409013, -73.63868124783039),
					new Tuple<double, double> (45.45916175189937, -73.63880127668381),
					new Tuple<double, double> (45.45914764178576, -73.63876909017563),
					new Tuple<double, double> (45.45905968866471, -73.63883882761002),
					new Tuple<double, double> (45.45910625209883, -73.63895751535892),
					new Tuple<double, double> (45.45915046380878, -73.63892331719398),
					new Tuple<double, double> (45.459173039987725, -73.63897696137428),
					new Tuple<double, double> (45.459196086494394, -73.63895952701569),
					new Tuple<double, double> (45.459305674856424, -73.63923847675323),
					new Tuple<double, double> (45.459351767751954, -73.63920293748379),
					new Tuple<double, double> (45.45936352613763, -73.63923110067844),
					new Tuple<double, double> (45.45948957587806, -73.6391332000494)
				}
			};
			LOY.Buildings.Add (PT);

			Building PY = new Building () {
				Code = "PY",
				Name = "Psychology",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45901453620701, -73.64049308001995),
					new Tuple<double, double> (45.4589938413185, -73.64043205976486),
					new Tuple<double, double> (45.45900795147058, -73.64039786159992),
					new Tuple<double, double> (45.45899007861069, -73.64035628736019),
					new Tuple<double, double> (45.45873233252727, -73.64055544137955),
					new Tuple<double, double> (45.45875349785223, -73.6406097561121),
					new Tuple<double, double> (45.45877090044683, -73.64059768617153),
					new Tuple<double, double> (45.458767608064456, -73.64058561623096),
					new Tuple<double, double> (45.458826400577436, -73.6405386775732),
					new Tuple<double, double> (45.45885744299957, -73.64061646163464),
					new Tuple<double, double> (45.45901453620701, -73.64049308001995)
				}
			};
			LOY.Buildings.Add (PY);

			Building RA = new Building () {
				Code = "RA",
				Name = "Recreational and Athletic Complex",
				Campus = LOY,
				Address = "7200 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45672064971158, -73.6371074616909),
					new Tuple<double, double> (45.45638575423165, -73.63737165927887),
					new Tuple<double, double> (45.456689606113095, -73.63814815878868),
					new Tuple<double, double> (45.45679026256728, -73.63806769251823),
					new Tuple<double, double> (45.45683917965772, -73.63819375634193),
					new Tuple<double, double> (45.45677050757642, -73.63825008273125),
					new Tuple<double, double> (45.45679872898983, -73.63832250237465),
					new Tuple<double, double> (45.45676674472025, -73.63835200667381),
					new Tuple<double, double> (45.45679590684914, -73.63843649625778),
					new Tuple<double, double> (45.45683071324125, -73.63841906189919),
					new Tuple<double, double> (45.45688245243312, -73.63855987787247),
					new Tuple<double, double> (45.457016033399846, -73.63845929503441),
					new Tuple<double, double> (45.45702261836891, -73.63848477602005),
					new Tuple<double, double> (45.457054602493365, -73.63847136497498),
					new Tuple<double, double> (45.457016033399846, -73.63845929503441),
					new Tuple<double, double> (45.45703766972384, -73.63843381404877),
					new Tuple<double, double> (45.45715619900361, -73.63833993673325),
					new Tuple<double, double> (45.457036729014284, -73.63803550601006),
					new Tuple<double, double> (45.45700004132896, -73.63805830478668),
					new Tuple<double, double> (45.45696805717357, -73.63796576857567),
					new Tuple<double, double> (45.45695394651102, -73.63793089985847),
					new Tuple<double, double> (45.457023088723815, -73.63787725567818),
					new Tuple<double, double> (45.45672064971158, -73.6371074616909)
				}
			};
			LOY.Buildings.Add (RA);

			Building RF = new Building () {
				Code = "RF",
				Name = "Loyola Jesuit Hall and Conference Centre",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.458657548315394, -73.64098593592644),
					new Tuple<double, double> (45.45861098451073, -73.64086791872978),
					new Tuple<double, double> (45.458521619525364, -73.64093899726868),
					new Tuple<double, double> (45.45845671223667, -73.64077337086201),
					new Tuple<double, double> (45.4584336654278, -73.6407894641161),
					new Tuple<double, double> (45.45841532204255, -73.6407458782196),
					new Tuple<double, double> (45.45835558841338, -73.6407908052206),
					new Tuple<double, double> (45.45837299113078, -73.64084109663963),
					new Tuple<double, double> (45.45832736777916, -73.64087462425232),
					new Tuple<double, double> (45.45836452494461, -73.64097252488136),
					new Tuple<double, double> (45.45838333868993, -73.64095710217953),
					new Tuple<double, double> (45.458410618609484, -73.64102147519588),
					new Tuple<double, double> (45.458299617475085, -73.64111334085464),
					new Tuple<double, double> (45.45835229600679, -73.64124678075314),
					new Tuple<double, double> (45.45841579238582, -73.64119783043861),
					new Tuple<double, double> (45.45845294949301, -73.64128768444061),
					new Tuple<double, double> (45.4583974489948, -73.6413299292326),
					new Tuple<double, double> (45.458421436504956, -73.64139765501022),
					new Tuple<double, double> (45.45857994195292, -73.64127226173878),
					new Tuple<double, double> (45.458552191773144, -73.6411964893341),
					new Tuple<double, double> (45.45857806058521, -73.64117704331875),
					new Tuple<double, double> (45.45857241648178, -73.64115424454212),
					new Tuple<double, double> (45.45860251836028, -73.6411240696907),
					new Tuple<double, double> (45.45857570887552, -73.64104695618153),
					new Tuple<double, double> (45.45865613729157, -73.64098459482193),
					new Tuple<double, double> (45.45865613729157, -73.64098459482193),
					new Tuple<double, double> (45.45865613729157, -73.64098459482193),
					new Tuple<double, double> (45.45865613729157, -73.64098459482193),
					new Tuple<double, double> (45.45865613729157, -73.64098459482193),
					new Tuple<double, double> (45.458657548315394, -73.64098593592644)
				}
			};
			LOY.Buildings.Add (RF);

			Building SC = new Building () {
				Code = "SC",
				Name = "Student Center",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.459295797802504, -73.63932028412819),
					new Tuple<double, double> (45.45925675990571, -73.63921903073788),
					new Tuple<double, double> (45.45927933604209, -73.63919824361801),
					new Tuple<double, double> (45.45919138312644, -73.63897293806076),
					new Tuple<double, double> (45.45915046380878, -73.63900646567345),
					new Tuple<double, double> (45.459131179982116, -73.63896287977695),
					new Tuple<double, double> (45.45907662082703, -73.63900646567345),
					new Tuple<double, double> (45.459090730958394, -73.63904938101768),
					new Tuple<double, double> (45.4589938413185, -73.63912783563137),
					new Tuple<double, double> (45.4591043707487, -73.63940745592117),
					new Tuple<double, double> (45.45921866265506, -73.63931961357594),
					new Tuple<double, double> (45.459237005778974, -73.63936588168144),
					new Tuple<double, double> (45.459295797802504, -73.63932028412819)
				}
			};
			LOY.Buildings.Add (SC);

			Building SH = new Building () {
				Code = "SH",
				Name = "Solar House",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45961515500344, -73.64266633987427),
					new Tuple<double, double> (45.4595737656597, -73.64253222942352),
					new Tuple<double, double> (45.459509800250494, -73.64258050918579),
					new Tuple<double, double> (45.4595436642997, -73.64267706871033),
					new Tuple<double, double> (45.45961515500344, -73.64266633987427)
				}
			};
			LOY.Buildings.Add (SH);

			Building SI = new Building () {
				Code = "SI",
				Name = "Saint-Ignatius of Loyola Church",
				Campus = LOY,
				Address = "4455 BroadWay",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45815239953178, -73.6425456404686),
					new Tuple<double, double> (45.4581025428888, -73.64241823554039),
					new Tuple<double, double> (45.45808278835767, -73.64242762327194),
					new Tuple<double, double> (45.45802352472279, -73.6422760784626),
					new Tuple<double, double> (45.45803669442482, -73.64225059747696),
					new Tuple<double, double> (45.45798307490449, -73.64210441708565),
					new Tuple<double, double> (45.45795485408384, -73.64209368824959),
					new Tuple<double, double> (45.45792569255432, -73.64202529191971),
					new Tuple<double, double> (45.45786360666706, -73.64206552505493),
					new Tuple<double, double> (45.457842911356124, -73.64201322197914),
					new Tuple<double, double> (45.45780904628545, -73.64203199744225),
					new Tuple<double, double> (45.45781469046532, -73.6420588195324),
					new Tuple<double, double> (45.45775260445583, -73.6421138048172),
					new Tuple<double, double> (45.45776201143137, -73.64214062690735),
					new Tuple<double, double> (45.45770933234819, -73.6421862244606),
					new Tuple<double, double> (45.45771591723629, -73.64221572875977),
					new Tuple<double, double> (45.45766511950827, -73.642258644104),
					new Tuple<double, double> (45.45767452649837, -73.64228010177612),
					new Tuple<double, double> (45.4576293729315, -73.64231765270233),
					new Tuple<double, double> (45.457654771817325, -73.64240348339081),
					new Tuple<double, double> (45.45757104952074, -73.64246383309364),
					new Tuple<double, double> (45.45761902523398, -73.64259794354439),
					new Tuple<double, double> (45.45770651025306, -73.64252954721451),
					new Tuple<double, double> (45.45771591723629, -73.64254429936409),
					new Tuple<double, double> (45.45776201143137, -73.64251211285591),
					new Tuple<double, double> (45.457770477707996, -73.6425268650055),
					new Tuple<double, double> (45.45782033464461, -73.6424933373928),
					new Tuple<double, double> (45.457827860216106, -73.64251211285591),
					new Tuple<double, double> (45.45788618336125, -73.64247187972069),
					new Tuple<double, double> (45.457923811164804, -73.64255905151367),
					new Tuple<double, double> (45.45790593796126, -73.6425818502903),
					new Tuple<double, double> (45.45794826922365, -73.6427092552185),
					new Tuple<double, double> (45.45815239953178, -73.6425456404686)
				}
			};
			LOY.Buildings.Add (SI);

			Building SP = new Building () {
				Code = "SP",
				Name = "Richard J. Renaud Science Complex",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.4582060188911, -73.64157870411873),
					new Tuple<double, double> (45.458193789918894, -73.64154785871506),
					new Tuple<double, double> (45.45832172365064, -73.6414486169815),
					new Tuple<double, double> (45.458275629913096, -73.64133730530739),
					new Tuple<double, double> (45.45820225613072, -73.64139899611473),
					new Tuple<double, double> (45.45816839127586, -73.6413212120533),
					new Tuple<double, double> (45.45824552786007, -73.64126488566399),
					new Tuple<double, double> (45.458201315440576, -73.64113345742226),
					new Tuple<double, double> (45.45810160219698, -73.64121526479721),
					new Tuple<double, double> (45.45808372904977, -73.64118307828903),
					new Tuple<double, double> (45.45802822818814, -73.64123001694679),
					new Tuple<double, double> (45.457976490047606, -73.64110261201859),
					new Tuple<double, double> (45.45788994614272, -73.64116698503494),
					new Tuple<double, double> (45.45793133672251, -73.64127695560455),
					new Tuple<double, double> (45.45787395431969, -73.64133462309837),
					new Tuple<double, double> (45.4578325636978, -73.64125952124596),
					new Tuple<double, double> (45.45752213306519, -73.64150628447533),
					new Tuple<double, double> (45.45742053721423, -73.64124745130539),
					new Tuple<double, double> (45.45740924877505, -73.6412501335144),
					new Tuple<double, double> (45.45723898120996, -73.6408169567585),
					new Tuple<double, double> (45.45719006446636, -73.64085718989372),
					new Tuple<double, double> (45.457133622017146, -73.64072307944298),
					new Tuple<double, double> (45.456970879305665, -73.64084780216217),
					new Tuple<double, double> (45.457018855529554, -73.64096850156784),
					new Tuple<double, double> (45.45698875280561, -73.64099130034447),
					new Tuple<double, double> (45.457014151979976, -73.64104762673378),
					new Tuple<double, double> (45.45703108475655, -73.6410328745842),
					new Tuple<double, double> (45.45716090254131, -73.64135205745697),
					new Tuple<double, double> (45.45715149546551, -73.64135608077049),
					new Tuple<double, double> (45.45717125032289, -73.6414110660553),
					new Tuple<double, double> (45.45716654678606, -73.64142313599586),
					new Tuple<double, double> (45.457180657395405, -73.64146068692207),
					new Tuple<double, double> (45.45720229365624, -73.64143654704094),
					new Tuple<double, double> (45.457442173383036, -73.64202797412872),
					new Tuple<double, double> (45.45755129480341, -73.64194482564926),
					new Tuple<double, double> (45.457595507732584, -73.64204674959183),
					new Tuple<double, double> (45.45767358579943, -73.64198371767998),
					new Tuple<double, double> (45.45766794160546, -73.64195823669434),
					new Tuple<double, double> (45.45799624461596, -73.64170342683792),
					new Tuple<double, double> (45.458011295711025, -73.6417356133461),
					new Tuple<double, double> (45.4582060188911, -73.64157870411873)
				}
			};
			LOY.Buildings.Add (SP);

			Building TA = new Building () {
				Code = "TA",
				Name = "Terrebonne",
				Campus = LOY,
				Address = "7079 Terrebonne",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45989735426473, -73.64107847213745),
					new Tuple<double, double> (45.45986537175274, -73.64095240831375),
					new Tuple<double, double> (45.45979952534742, -73.64097118377686),
					new Tuple<double, double> (45.45980705065481, -73.64107310771942),
					new Tuple<double, double> (45.45989735426473, -73.64107847213745)
				}
			};
			LOY.Buildings.Add (TA);

			Building VE = new Building () {
				Code = "VE",
				Name = "Vanier Extension",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45907473947591, -73.63879054784775),
					new Tuple<double, double> (45.458865438772186, -73.63825008273125),
					new Tuple<double, double> (45.45881746411941, -73.63828629255295),
					new Tuple<double, double> (45.45881229037992, -73.63827757537365),
					new Tuple<double, double> (45.45878171827317, -73.63829970359802),
					new Tuple<double, double> (45.458787362355665, -73.63831244409084),
					new Tuple<double, double> (45.45869282389937, -73.63838821649551),
					new Tuple<double, double> (45.45868482810228, -73.63838016986847),
					new Tuple<double, double> (45.458658488997926, -73.63840095698833),
					new Tuple<double, double> (45.458675891621816, -73.63844856619835),
					new Tuple<double, double> (45.45862039134304, -73.63849617540836),
					new Tuple<double, double> (45.45881746411941, -73.63900244235992),
					new Tuple<double, double> (45.45883251499527, -73.6389883607626),
					new Tuple<double, double> (45.45884474382895, -73.63901652395725),
					new Tuple<double, double> (45.4588884854046, -73.63898500800133),
					new Tuple<double, double> (45.458898832869146, -73.63901518285275),
					new Tuple<double, double> (45.4590168878984, -73.63891795277596),
					new Tuple<double, double> (45.45900654045553, -73.6388897895813),
					new Tuple<double, double> (45.459025824324826, -73.63887503743172),
					new Tuple<double, double> (45.45901500654529, -73.63884083926678),
					new Tuple<double, double> (45.45907473947591, -73.63879054784775)
				}
			};
			LOY.Buildings.Add (VE);

			Building VL = new Building () {
				Code = "VL",
				Name = "Vanier Library",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				ShapeCoords = new Tuple<double, double>[] {
					new Tuple<double, double> (45.45931272989392, -73.63867320120335),
					new Tuple<double, double> (45.45916363324759, -73.63878920674324),
					new Tuple<double, double> (45.4591467011114, -73.63875299692154),
					new Tuple<double, double> (45.459080853866794, -73.63880261778831),
					new Tuple<double, double> (45.45885038790514, -73.6382058262825),
					new Tuple<double, double> (45.45887249386474, -73.63818906247616),
					new Tuple<double, double> (45.45885509130154, -73.63813944160938),
					new Tuple<double, double> (45.45888895574394, -73.63811664283276),
					new Tuple<double, double> (45.45887202352528, -73.63807439804077),
					new Tuple<double, double> (45.459090730958394, -73.63790474832058),
					new Tuple<double, double> (45.45907803184032, -73.63787457346916),
					new Tuple<double, double> (45.45909872669793, -73.63785780966282),
					new Tuple<double, double> (45.45912600627139, -73.63792352378368),
					new Tuple<double, double> (45.459117069860845, -73.63793224096298),
					new Tuple<double, double> (45.459126946946114, -73.63795302808285),
					new Tuple<double, double> (45.45914387908821, -73.63796442747116),
					new Tuple<double, double> (45.459217251645285, -73.63815754652023),
					new Tuple<double, double> (45.4591245952593, -73.63823264837265),
					new Tuple<double, double> (45.45913259099403, -73.63825343549252),
					new Tuple<double, double> (45.45914999347161, -73.63824538886547),
					new Tuple<double, double> (45.4592614632682, -73.63853976130486),
					new Tuple<double, double> (45.45925581923316, -73.63854646682739),
					new Tuple<double, double> (45.459275103017205, -73.63859139382839),
					new Tuple<double, double> (45.45927933604209, -73.63858871161938),
					new Tuple<double, double> (45.45931272989392, -73.63867320120335)
				}
			};
			LOY.Buildings.Add (VL);

		}

		public List<Campus> getCampusList ()
		{
			return CampusList;
		}

		public Campus GetCampusByCode (string code)
		{
			foreach (Campus c in CampusList) {
				if (c.Code.Equals (code))
					return c;
			}
			return null;
		}
	}
}