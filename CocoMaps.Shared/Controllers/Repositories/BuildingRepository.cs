using System;
using CocoMaps.Shared;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{
	
	public class BuildingRepository
	{
		
		static BuildingRepository repository;
		readonly List<Campus> CampusList = new List<Campus> ();

		// holding buildings with their code being their 'ID' (e.g. <"H", [H-Building]> )
		// so we can easily iterate through the whole building list
		// and easily retrieve a building by its code.
		public SortedDictionary<String, Building> BuildingList = new SortedDictionary<String, Building> ();

		public static BuildingRepository getInstance {
			get {
				if (repository == null)
					repository = new BuildingRepository ();
				return repository;
			}
		}

		BuildingRepository ()
		{
			
			Campus SGW = new Campus {
				Code = "SGW",
				Name = "Sir George Williams",
				Address = "1455 De Maisonneuve Blvd. W.",
				Position = Campus.SGWPosition
			};
			CampusList.Add (SGW);

			Campus LOY = new Campus {
				Code = "LOY",
				Name = "Loyola",
				Address = "7141 Sherbrooke Street W.",
				Position = Campus.LOYPosition
			};
			CampusList.Add (LOY);


			/*****************************
			 *****************************
			 ******* SGW BUILDINGS *******
			 *****************************
			 *****************************/

			Building B = new Building {
				Code = "B",
				Name = "B",
				Campus = SGW,
				Address = "2160 Bishop",
				Position = new Position (45.4978008, -73.57955262),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49792300709727, -73.57949629426003),
					new Position (45.49788775606442, -73.57942052185535),
					new Position (45.497714790676845, -73.57958815991879),
					new Position (45.49775004181796, -73.57966259121895),
					new Position (45.49792300709727, -73.57949629426003)
				},
				Services = new List<Service> {
					new Service {
						Name = "CPE Les P'tits Profs Daycare",
						URI = "http://lesptitsprofs.wordpress.com"
					}
				}
			};
			BuildingList.Add (B.Code, B);

			Building CB = new Building {
				Code = "CB",
				Name = "CB",
				Campus = SGW,
				Address = "1425 René Lévesque W.",
				Position = new Position (45.49519498, -73.57429147),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.495461491948106, -73.57426129281521),
					new Position (45.495081703057934, -73.57463613152504),
					new Position (45.49504927047214, -73.57456907629967),
					new Position (45.495077942759096, -73.57453688979149),
					new Position (45.49495714302504, -73.57426799833775),
					new Position (45.49502999892679, -73.57419557869434),
					new Position (45.4950624315237, -73.57426464557648),
					new Position (45.495120716143674, -73.57420563697815),
					new Position (45.495091103803965, -73.57413992285728),
					new Position (45.49516677975225, -73.57406683266163),
					new Position (45.49519639205217, -73.57412919402122),
					new Position (45.49525467653348, -73.57407420873642),
					new Position (45.495226004336494, -73.57400983572006),
					new Position (45.49530544038742, -73.57393339276314),
					new Position (45.49535855437077, -73.57403799891472),
					new Position (45.49536419479084, -73.5740339756012),
					new Position (45.49538440629147, -73.57407823204994),
					new Position (45.495376885733954, -73.5740802437067),
					new Position (45.495461491948106, -73.57426129281521)
				}
			};
			BuildingList.Add (CB.Code, CB);

			Building CI = new Building {
				Code = "CI",
				Name = "CI",
				Campus = SGW,
				Address = "2149 Mackay",
				Position = new Position (45.49744312, -73.57994959),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49752255406562, -73.57993818819523),
					new Position (45.497410689916435, -73.58004614710808),
					new Position (45.497367918271266, -73.57995696365833),
					new Position (45.49747884247076, -73.57984632253647),
					new Position (45.49752255406562, -73.57993818819523)
				},
				Departments = new List<Department> {
					new Department {
						Name = "School of Community and Public Affairs",
						URI = "http://scpa-eapc.concordia.ca/en"
					}
				}
			};
			BuildingList.Add (CI.Code, CI);

			Building CL = new Building {
				Code = "CL",
				Name = "CL",
				Campus = SGW,
				Address = "1665 St. Catherine W.",
				Position = new Position (45.4942173, -73.57929111),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.4944781718791, -73.57927232980728),
					new Position (45.4941707633251, -73.57964850962162),
					new Position (45.493989325684645, -73.57934206724167),
					new Position (45.49398603535935, -73.57932060956955),
					new Position (45.4939930860562, -73.57928641140461),
					new Position (45.49401470818766, -73.57924215495586),
					new Position (45.49404103077127, -73.57920661568642),
					new Position (45.49426900263261, -73.57892297208309),
					new Position (45.4944781718791, -73.57927232980728)
				},
				Services = new List<Service> {
					new Service {
						Name = "The Centre for Continuing Education",
						URI = "http://cce.concordia.ca"
					}
				}
			};
			BuildingList.Add (CL.Code, CL);

			Building D = new Building {
				Code = "D",
				Name = "D",
				Campus = SGW,
				Address = "2140 Bishop",
				Position = new Position (45.49773641, -73.57939035),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.4978449847816, -73.57933469116688),
					new Position (45.49781584388899, -73.57927098870277),
					new Position (45.497649928519515, -73.57943125069141),
					new Position (45.497680009529304, -73.57949495315552),
					new Position (45.49784545479588, -73.57933402061462)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Theological Studies",
						URI = "http://concordia.ca/content/concordia/en/artsci/theology.html"
					}
				}
			};
			BuildingList.Add (D.Code, D);

			Building EN = new Building {
				Code = "EN",
				Name = "EN",
				Campus = SGW,
				Address = "2070 Mackay",
				Position = new Position (45.49684385, -73.57963711),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49693737990155, -73.57957743108273),
					new Position (45.496918109002365, -73.57953786849976),
					new Position (45.496906828472945, -73.5795445740223),
					new Position (45.49689178776354, -73.57951641082764),
					new Position (45.4967954331236, -73.5796096175909),
					new Position (45.49680295349169, -73.57963241636753),
					new Position (45.49667181692945, -73.57976652681828),
					new Position (45.496699078318784, -73.57981882989407),
					new Position (45.49693737990155, -73.57957743108273)
				},
				Services = new List<Service> {
					new Service {
						Name = "Translation Services",
						URI = "http://web2.concordia.ca/translation"
					},
					new Service {
						Name = "Career and Planning Services",
						URI = "http://concordia.ca/content/concordia/en/students/careers/planning.html"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Education",
						URI = "http://doe.concordia.ca"
					}
				}
			};
			BuildingList.Add (EN.Code, EN);

			Building EV = new Building {
				Code = "EV",
				Name = "Computer Science, Engineering and Visual Arts Integrated Complex",
				Campus = SGW,
				Address = "1515 St. Catherine W.",
				Position = new Position (45.49561989, -73.5783577),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.49518840143307, -73.57789903879166),
					new Position (45.49526266714314, -73.57805728912354),
					new Position (45.495279588430456, -73.57813641428947),
					new Position (45.49536137458087, -73.57844084501266),
					new Position (45.49556348927069, -73.57885926961899),
					new Position (45.49565185546529, -73.57885658740997),
					new Position (45.49592447370251, -73.57858031988144),
					new Position (45.49559169126274, -73.57787892222404),
					new Position (45.495592631328904, -73.57780382037163),
					new Position (45.495522126323436, -73.57765629887581),
					new Position (45.495429059581035, -73.5776549577713),
					new Position (45.49518840143307, -73.57789903879166)
				},
				Services = new List<Service> {
					new Service {
						Name = "LeGym",
						URI = "http://concordia.ca/content/concordia/en/campus-life/recreation/facilities/le-gym.html",
					},
					new Service {
						Name = "FOFA Gallery",
						URI = "http://concordia.ca/content/concordia/en/finearts/facilities/fofa-gallery.html"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Engineering and Computer Science",
						URI = "http://concordia.ca/content/concordia/en/encs.html"
					},
					new Department {
						Name = "Building, Civil and Environmental Engineering",
						URI = "http://www.bcee.concordia.ca"
					},
					new Department {
						Name = "Electrical and Computer Engineering",
						URI = "http://www.ece.concordia.ca"
					},
					new Department {
						Name = "Computer Science and Software Engineering",
						URI = "http://www.cs.concordia.ca"
					},
					new Department {
						Name = "Mechanical and Industrial Engineering",
						URI = "http://www.me.concordia.ca"
					},
					new Department {
						Name = "Design and Computation Arts",
						URI = "http://design.concordia.ca"
					},
					new Department {
						Name = "Faculty of Fine Arts",
						URI = "http://concordia.ca/content/concordia/en/finearts.html"
					},
					new Department {
						Name = "Studio Arts",
						URI = "http://concordia.ca/content/concordia/en/finearts/studio-arts.html"
					},
					new Department {
						Name = "Art Education",
						URI = "http://art-education.concordia.ca"
					},
					new Department {
						Name = "Art History",
						URI = "http://concordia.ca/content/concordia/en/finearts/art-history"
					},
					new Department {
						Name = "Comtemporary Dance",
						URI = "http://dance.concordia.ca/en"
					},
					new Department {
						Name = "Recreation and Athletics",
						URI = "http://athletics.concordia.ca/"
					},
					new Department {
						Name = "Zero Energy Building Studies",
						URI = "http://concordia.ca/content/concordia/en/research/zero-energy-building"
					}
				}
			};
			BuildingList.Add (EV.Code, EV);

			Building FA = new Building {
				Code = "FA",
				Name = "FA",
				Campus = SGW,
				Address = "2060 Mackay",
				Position = new Position (45.49679496, -73.57951775),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.496864056445034, -73.57952110469341),
					new Position (45.49682739468098, -73.57944399118423),
					new Position (45.496742790518965, -73.57953317463398),
					new Position (45.49678039238446, -73.57960693538189),
					new Position (45.496864056445034, -73.57952110469341)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Religion",
						URI = "http://religion.concordia.ca"
					}
				}
			};
			BuildingList.Add (FA.Code, FA);

			Building FB = new Building {
				Code = "FB",
				Name = "Faubourg Tower",
				Campus = SGW,
				Address = "1250 Guy",
				Position = new Position (45.49458957, -73.57759595),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.494912019322506, -73.57778571546078),
					new Position (45.49487065589675, -73.57771262526512),
					new Position (45.494876296365675, -73.57770457863808),
					new Position (45.49483681307125, -73.57763350009918),
					new Position (45.49484104342554, -73.57762679457664),
					new Position (45.49480014998734, -73.57755102217197),
					new Position (45.49480626050299, -73.57754096388817),
					new Position (45.49476395691957, -73.57746586203575),
					new Position (45.49477335771863, -73.57745379209518),
					new Position (45.494692040754835, -73.57730962336063),
					new Position (45.49469956140383, -73.57729889452457),
					new Position (45.49465443749489, -73.57721976935863),
					new Position (45.49439779457518, -73.5775201767683),
					new Position (45.494696741160546, -73.57803918421268),
					new Position (45.494912019322506, -73.57778571546078)
				},
				Services = new List<Service> {
					new Service {
						Name = "School of Extended Learning",
						URI = "http://www.concordia.ca/extended-learning"
					},
					new Service {
						Name = "Student Transition Centre",
						URI = "http://concordia.ca/content/concordia/en/extended-learning/advising.html"
					},
					new Service {
						Name = "Human Resources",
						URI = "http://www.concordia.ca/hr"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Cinema",
						URI = "http://cinema.concordia.ca"
					}
				}
			};
			BuildingList.Add (FB.Code, FB);

			Building FG = new Building {
				Code = "FG",
				Name = "FG",
				Campus = SGW,
				Address = "1616 St. Catherine W.",
				Position = new Position (45.49386382, -73.57871711),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.494694390957754, -73.57803918421268),
					new Position (45.494451849499804, -73.57761606574059),
					new Position (45.49438933379967, -73.57769183814526),
					new Position (45.49442693723663, -73.57776291668415),
					new Position (45.494391684015206, -73.57780314981937),
					new Position (45.49437194220157, -73.57776828110218),
					new Position (45.49418721489572, -73.57798755168915),
					new Position (45.494203666461544, -73.57801638543606),
					new Position (45.49411153763108, -73.57812702655792),
					new Position (45.49410495699457, -73.57811562716961),
					new Position (45.493911767965706, -73.57834227383137),
					new Position (45.493922579048075, -73.57836373150349),
					new Position (45.4938924960311, -73.57839927077293),
					new Position (45.493883095084975, -73.57838585972786),
					new Position (45.49383656037867, -73.57844151556492),
					new Position (45.49384925166602, -73.57846297323704),
					new Position (45.493625978600626, -73.57873052358627),
					new Position (45.4938224589449, -73.57906647026539),
					new Position (45.49429579514127, -73.5785112529993),
					new Position (45.49430190571165, -73.57852131128311),
					new Position (45.49436818185533, -73.57844218611717),
					new Position (45.49436348142216, -73.57842944562435),
					new Position (45.494694390957754, -73.57803918421268)
				},
				Services = new List<Service> {
					new Service {
						Name = "Classrooms"
					},
				}
			};
			BuildingList.Add (FG.Code, FG);

			Building GM = new Building {
				Code = "GM",
				Name = "Guy-Metro",
				Campus = SGW,
				Address = "1550 De Maisonneuve W.",
				Position = new Position (45.49586619, -73.57887805),
				HasAtm = false,
				HasBikeRack = true,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.49611248551097, -73.57887402176857),
					new Position (45.49594797521289, -73.57851728796959),
					new Position (45.4956208333064, -73.57884049415588),
					new Position (45.49579380512591, -73.57919186353683),
					new Position (45.49611248551097, -73.57887402176857)
				},
				Services = new List<Service> {
					new Service {
						Name = "Office of the President",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/president.html"
					},
					new Service {
						Name = "Office of the VP, Institutional Relations and Secretary General",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-development-external-relations-secretary-general.html"
					},
					new Service {
						Name = "Office of the Provost",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"
					},
					new Service {
						Name = "Office of Rights and Responsibilities",
						URI = "http://concordia.ca/content/concordia/en/students/rights.html"
					},
					new Service {
						Name = "Ombuds Office",
						URI = "http://concordia.ca/content/concordia/en/campus-life/ombuds.html"
					},
					new Service {
						Name = "Institute for Co-operative Education",
						URI = "http://concordia.ca/content/concordia/en/academics/co-op.html"
					},
					new Service {
						Name = "Office of the VP, Research & Graduate Studies",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"
					},
					new Service {
						Name = "Office of the Chief Communications Officer",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"
					},
					new Service {
						Name = "Financial Aid & Awards Office",
						URI = "http://concordia.ca/content/concordia/en/offices/faao.html"
					},
					new Service {
						Name = "Health Services",
						URI = "http://concordia.ca/content/concordia/en/students/health.html"
					},
					new Service {
						Name = "Environmental Health and Safety",
						URI = "http://concordia.ca/content/concordia/en/campus-life/safety"
					},
					new Service {
						Name = "Facilities Management",
						URI = "http://concordia.ca/content/concordia/en/offices/facilities"
					},
					new Service {
						Name = "Music",
						URI = "http://concordia.ca/content/concordia/en/finearts/music"
					},
					new Service {
						Name = "Theatre",
						URI = "http://concordia.ca/content/concordia/en/finearts/theatre"
					},
					new Service {
						Name = "Contemporary Dance",
						URI = "http://concordia.ca/content/concordia/en/finearts/dance"
					},
					new Service {
						Name = "Graduate Studies",
						URI = "http://concordia.ca/content/concordia/en/offices/sgs.html"
					},
				}
			};
			BuildingList.Add (GM.Code, GM);

			Building H = new Building {
				Code = "H",
				Name = "Henry F. Hall",
				Campus = SGW,
				Address = "1455 De Maisonneuve W.",
				Position = new Position (45.4972443, -73.57890487),
				HasAtm = true,
				HasBikeRack = true,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.497705860384244, -73.57903495430946),
					new Position (45.49716628007782, -73.57953920960426),
					new Position (45.49683162488575, -73.57884854078293),
					new Position (45.497373088471846, -73.57834294438362),
					new Position (45.497705860384244, -73.57903495430946)
				},
				Services = new List<Service> {
					new Service {
						Name = "Dean of Students",
						RoomNumber = "H-637",
						URI = "http://concordia.ca/content/concordia/en/offices/dean-students"
					},
					new Service {
						Name = "Aboriginal Student Resource Center",
						RoomNumber = "H-641",
						URI = "http://concordia.ca/content/concordia/en/offices/asrc"
					},
					new Service {
						Name = "International Students Office",
						RoomNumber = "H-653",
						URI = "http://concordia.ca/content/concordia/en/offices/iso"
					},
					new Service {
						Name = "IT Services",
						RoomNumber = "H-925",
						URI = "http://concordia.ca/content/concordia/en/it"
					},
					new Service {
						Name = "Security Department",
						RoomNumber = "H-118",
						URI = "http://concordia.ca/content/concordia/en/campus-life/security"
					},
					new Service {
						Name = "Counselling and Development",
						RoomNumber = "H-440",
						URI = "http://concordia.ca/content/concordia/en/offices/cdev.html"
					},
					new Service {
						Name = "Mail Services",
						URI = "http://concordia.ca/content/concordia/en/offices/facilities.html"
					},
					new Service {
						Name = "Archives",
						URI = "http://archives.concordia.ca/"
					},
					new Service {
						Name = "Access Centre for Students with Disabilities",
						RoomNumber = "H-580",
						URI = "http://concordia.ca/content/concordia/en/offices/acsd"
					},
					new Service {
						Name = "Concordia Student Union",
						URI = "http://csu.concordia.ca"
					},
					new Service {
						Name = "Computer Store",
						URI = "http://retail.concordia.ca/ccs/"
					},
					new Service {
						Name = "D. B. Clarke Theatre\\",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/db-clarke-theatre"
					}
				},

				Departments = new List<Department> {
					new Department {
						Name = "Classics, Modern Languages and Linguistics",
						URI = "http://concordia.ca/content/concordia/en/artsci/cmll"
					},
					new Department {
						Name = "Geography, Planning and Environment"
					},
					new Department {
						Name = "Political Science, Sociology and Anthropology, Economics",
						URI = "http://concordia.ca/content/concordia/en/artsci/academics/departments.html"
					}
				}
			};
			BuildingList.Add (H.Code, H);

			Building K = new Building {
				Code = "K",
				Name = "K",
				Campus = SGW,
				Address = "2150 Bishop",
				Position = new Position (45.49776837, -73.57947282),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.497884935980856, -73.5794198513031),
					new Position (45.49763159789631, -73.57966527342796),
					new Position (45.4975925865501, -73.57958480715752),
					new Position (45.49784733485295, -73.57933804392815),
					new Position (45.497884935980856, -73.5794198513031)
				},
				Services = new List<Service> {
					new Service {
						Name = "Theological Studies",
						URI = "http://concordia.ca/content/concordia/en/artsci/theology.html"
					}
				}
			};
			BuildingList.Add (K.Code, K);

			Building LB = new Building {
				Code = "LB",
				Name = "McConnel Library",
				Campus = SGW,
				Address = "1400 De Maisonneuve W.",
				Position = new Position (45.49674232, -73.57807606),
				HasAtm = true,
				HasBikeRack = true,
				HasInfoKiosk = true,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49725511377648, -73.5780693590641),
					new Position (45.49701869362308, -73.5782953351736),
					new Position (45.49700177285834, -73.5782577842474),
					new Position (45.496964641162315, -73.57829332351685),
					new Position (45.49694067005441, -73.57824705541134),
					new Position (45.49688943765232, -73.57829667627811),
					new Position (45.49690964860552, -73.57834227383137),
					new Position (45.496872516848754, -73.57837848365307),
					new Position (45.49688943765232, -73.57841469347477),
					new Position (45.49672069941128, -73.57858903706074),
					new Position (45.4967004883903, -73.57854880392551),
					new Position (45.49667322700165, -73.5785736143589),
					new Position (45.49655572086505, -73.57832685112953),
					new Position (45.496579222111976, -73.57830137014389),
					new Position (45.496492737474895, -73.57811562716961),
					new Position (45.496465475985666, -73.57813976705074),
					new Position (45.4962807555472, -73.57775151729584),
					new Position (45.49627135499978, -73.57775822281837),
					new Position (45.49624738359674, -73.57770927250385),
					new Position (45.49648803721908, -73.57747256755829),
					new Position (45.49659943317651, -73.57771195471287),
					new Position (45.49666100637487, -73.5776549577713),
					new Position (45.49662105430725, -73.57756644487381),
					new Position (45.49669437808019, -73.57749335467815),
					new Position (45.496691557936856, -73.57748866081238),
					new Position (45.49688473742963, -73.5773029178381),
					new Position (45.49699895273038, -73.57754565775394),
					new Position (45.49697827178774, -73.57756778597832),
					new Position (45.49699895273038, -73.57761807739735),
					new Position (45.49699143238848, -73.57762813568115),
					new Position (45.49699143238848, -73.57762813568115),
					new Position (45.49699895273038, -73.57764288783073),
					new Position (45.49703984457186, -73.57760332524776),
					new Position (45.497113637819865, -73.57775621116161),
					new Position (45.49707462611481, -73.57779912650585),
					new Position (45.49708261646624, -73.5778172314167),
					new Position (45.497090136795975, -73.57781052589417),
					new Position (45.49711410784025, -73.57785813510418),
					new Position (45.49713948893482, -73.57783399522305),
					new Position (45.49725511377648, -73.5780693590641)
				},
				Services = new List<Service> {
					new Service {
						Name = "J.A. DeSève Cinema",
						RoomNumber = "LB-125",
						URI = "http://concordia.ca/content/concordia/en/it/services/cinemas"
					},
					new Service {
						Name = "Birks Student Service Centre",
						RoomNumber = "LB-185",
						URI = "http://concordia.ca/content/concordia/en/students/birks"
					},
					new Service {
						Name = "Bookstore",
						RoomNumber = "LB-103",
						URI = "http://retail.concordia.ca/"
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
						Name = "Digital Store",
						RoomNumber = "LB-115",
						URI = "http://retail.concordia.ca"
					},
					new Service {
						Name = "DPrint Administration",
						RoomNumber = "LB-018"
					},
					new Service {
						Name = "Welcome Centre",
						RoomNumber = "LB-187",
						URI = "http://concordia.ca/content/concordia/en/students/birks/welcome-centre"
					},
					new Service {
						Name = "R. Howard Webster Library",
						URI = "http://concordia.ca/content/concordia/en/library"
					},
					new Service {
						Name = "Leonard and Bina Ellen Art Gallery",
						URI = "http://ellengallery.concordia.ca"
					},
					new Service {
						Name = "Birks Student Service Centre",
						URI = "http://concordia.ca/content/concordia/en/library"
					},
					new Service {
						Name = "Office of the Registrar",
						URI = "http://concordia.ca/content/concordia/en/offices/registrar"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "English",
						URI = "http://english.concordia.ca"
					},
					new Department {
						Name = "History",
						URI = "http://history.concordia.ca"
					},
					new Department {
						Name = "Etudes francaises",
						URI = "http://concordia.ca/content/concordia/en/artsci/francais"
					},
					new Department {
						Name = "Mathematics and Statistics",
						URI = "http://www.mathstat.concordia.ca"
					},
					new Department {
						Name = "Education",
						URI = "http://doe.concordia.ca/"
					},
					new Department {
						Name = "Centre for Interdisciplinary Studies in Society and Culture (CISSC)",
						URI = "http://concordia.ca/content/concordia/en/artsci/cissc.html"
					}
				}
			};
			BuildingList.Add (LB.Code, LB);

			Building M = new Building {
				Code = "M",
				Name = "M",
				Campus = SGW,
				Address = "2135 Mackay",
				Position = new Position (45.49735382, -73.57977659),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49743278075342, -73.57976384460926),
					new Position (45.497325146593596, -73.57987113296986),
					new Position (45.497288015110826, -73.57979737222195),
					new Position (45.497397059395695, -73.57968874275684),
					new Position (45.49743278075342, -73.57976384460926)
				}
			};
			BuildingList.Add (M.Code, M);

			Building MB = new Building {
				Code = "MB",
				Name = "John Molson School of Business",
				Campus = SGW,
				Address = "1450 Guy",
				Position = new Position (45.49527019, -73.57901216),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.495200152343095, -73.57926495373249),
					new Position (45.49513857754739, -73.57933603227139),
					new Position (45.495276298180556, -73.57959017157555),
					new Position (45.49531484109607, -73.57958883047104),
					new Position (45.495384876326256, -73.57951506972313),
					new Position (45.49539662719529, -73.57953518629074),
					new Position (45.4956288238641, -73.57927702367306),
					new Position (45.49525843682053, -73.57851393520832),
					new Position (45.49522130397495, -73.57851259410381),
					new Position (45.49506384163618, -73.57868760824203),
					new Position (45.495092983952986, -73.5787446051836),
					new Position (45.49507136223551, -73.57876606285572),
					new Position (45.495066191823575, -73.57875868678093),
					new Position (45.49502670866229, -73.57875600457191),
					new Position (45.494963723561966, -73.57882641255856),
					new Position (45.495200152343095, -73.57926495373249)
				},
				Services = new List<Service> {
					new Service {
						Name = "Career Management Services",
						URI = "http://concordia.ca/content/concordia/en/jmsb/services/career"
					},
					new Service {
						Name = "John Molson Executive Centre",
						URI = "http://concordia.ca/content/concordia/en/jmsb/programs/executive-centre"
					},
					new Service {
						Name = "Performing Arts Facilities",
						URI = "http://concordia.ca/content/concordia/en/finearts/facilities/performing-arts"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Supply Chain & Business Technology Management",
						URI = "http://concordia.ca/content/concordia/en/jmsb/about/departments/supply-chain-business-technology-management"
					},
					new Department {
						Name = "Finance",
						URI = "http://concordia.ca/content/concordia/en/jmsb/about/departments/finance"
					},
					new Department {
						Name = "Management",
						URI = "http://concordia.ca/content/concordia/en/jmsb/about/departments/management"
					},
					new Department {
						Name = "Marketing",
						URI = "http://concordia.ca/content/concordia/en/jmsb/about/departments/marketing"
					},
					new Department {
						Name = "Goodman Institute of Investment Management",
						URI = "http://concordia.ca/content/concordia/en/jmsb/programs/graduate/mba-cfa"
					},
					new Department {
						Name = "Executive MBA Program",
						URI = "http://concordia.ca/content/concordia/en/jmsb/programs/graduate/emba"
					},
					new Department {
						Name = "Music",
						URI = "http://music.concordia.ca"
					},
					new Department {
						Name = "Theatre",
						URI = "http://theatre.concordia.ca"
					}
				}
			};
			BuildingList.Add (MB.Code, MB);

			Building MI = new Building {
				Code = "MI",
				Name = "MI",
				Campus = SGW,
				Address = "2130 Bishop",
				Position = new Position (45.49769458, -73.57930586),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49781302380185, -73.5792676359415),
					new Position (45.497646638408106, -73.5794285684824),
					new Position (45.49760198687696, -73.57933536171913),
					new Position (45.497769312432425, -73.57917308807373),
					new Position (45.49781302380185, -73.5792676359415)
				},
				Services = new List<Service> {
					new Service {
						Name = "ACUMAE",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#acumae"
					},
					new Service {
						Name = "SCOMM",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#scomm-sgw"
					},
					new Service {
						Name = "CUSSU",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cussu"
					},
					new Service {
						Name = "CUUSS-TS",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cuuss-ts"
					},
					new Service {
						Name = "CULEU",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#culeu"
					},
					new Service {
						Name = "CUPEU",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cupeu"
					},
					new Service {
						Name = "CUCEPTFU",
					}
				}
			};
			BuildingList.Add (MI.Code, MI);

			Building MU = new Building {
				Code = "MU",
				Name = "MU",
				Campus = SGW,
				Address = "2170 Bishop",
				Position = new Position (45.49786379, -73.57961833),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.497963428254415, -73.57957072556019),
					new Position (45.497789053055065, -73.57973903417587),
					new Position (45.49775380193838, -73.57966527342796),
					new Position (45.49792911727405, -73.57949763536453),
					new Position (45.497963428254415, -73.57957072556019)
				},
				Services = new List<Service> {
					new Service {
						Name = "Simone de Beauvoir Institute",
						URI = "http://concordia.ca/content/concordia/en/artsci/sdbi"
					}
				}
			};
			BuildingList.Add (MU.Code, MU);

			Building P = new Building {
				Code = "P",
				Name = "P",
				Campus = SGW,
				Address = "2020 Mackay",
				Position = new Position (45.49664738, -73.57920662),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49671787926927, -73.57919186353683),
					new Position (45.496680747386044, -73.57911810278893),
					new Position (45.49658204226096, -73.57921734452248),
					new Position (45.49661823416025, -73.57929177582264),
					new Position (45.49671787926927, -73.57919186353683)
				}
			};
			BuildingList.Add (P.Code, P);

			Building PR = new Building {
				Code = "PR",
				Name = "PR",
				Campus = SGW,
				Address = "2100 Mackay",
				Position = new Position (45.49690025, -73.57993349),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.497031384193306, -73.5798691213131),
					new Position (45.496987672217166, -73.57978396117687),
					new Position (45.49679778323874, -73.57997439801693),
					new Position (45.4968386752263, -73.58006224036217),
					new Position (45.497031384193306, -73.5798691213131)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Philosophy",
						URI = "http://concordia.ca/content/concordia/en/artsci/philosophy"
					},
					new Department {
						Name = "Liberal Arts College",
						URI = "http://liberalartscollege.concordia.ca"
					}
				}
			};
			BuildingList.Add (PR.Code, PR);

			Building Q = new Building {
				Code = "Q",
				Name = "Q",
				Campus = SGW,
				Address = "2010 Mackay",
				Position = new Position (45.49661118, -73.57913285),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.496680277362046, -73.57911005616188),
					new Position (45.496651135866685, -73.57905372977257),
					new Position (45.49654961053924, -73.5791576653719),
					new Position (45.496576871987735, -73.57921533286572),
					new Position (45.496680277362046, -73.57911005616188)
				},
				Services = new List<Service> {
					new Service {
						Name = "Ethnic Students' Association",
						URI = "http://www.ieacconcordia.ca/about-us.html"
					}
				}
			};
			BuildingList.Add (Q.Code, Q);

			Building R = new Building {
				Code = "R",
				Name = "R",
				Campus = SGW,
				Address = "2050 Mackay",
				Position = new Position (45.49675877, -73.57944332),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.496825514589865, -73.57944063842297),
					new Position (45.49678462259274, -73.57935816049576),
					new Position (45.496699078318784, -73.5794473439455),
					new Position (45.49673668021346, -73.57952781021595),
					new Position (45.496825514589865, -73.57944063842297)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Religion",
						URI = "http://religion.concordia.ca"
					}
				}
			};
			BuildingList.Add (R.Code, R);

			Building RR = new Building {
				Code = "RR",
				Name = "RR",
				Campus = SGW,
				Address = "2040 Mackay",
				Position = new Position (45.49670284, -73.57937157),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49678227247707, -73.5793574899435),
					new Position (45.49674044040154, -73.57927367091179),
					new Position (45.49661212384121, -73.57940509915352),
					new Position (45.496651135866685, -73.57948824763298),
					new Position (45.49678227247707, -73.5793574899435)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Liberal Arts College",
						URI = "http://concordia.ca/content/concordia/en/artsci/liberal-arts-college"
					}
				}
			};
			BuildingList.Add (RR.Code, RR);

			Building S = new Building {
				Code = "S",
				Name = "S",
				Campus = SGW,
				Address = "2145 Mackay",
				Position = new Position (45.49740176, -73.57986242),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49748636274756, -73.57983492314816),
					new Position (45.497366038198194, -73.57995428144932),
					new Position (45.49732796670521, -73.57987381517887),
					new Position (45.49742620050501, -73.57977792620659),
					new Position (45.497434660824254, -73.57979267835617),
					new Position (45.49745722166936, -73.57977122068405),
					new Position (45.49748636274756, -73.57983492314816)
				}
			};
			BuildingList.Add (S.Code, S);

			Building T = new Building {
				Code = "T",
				Name = "T",
				Campus = SGW,
				Address = "2030 Mackay",
				Position = new Position (45.4966784, -73.57928306),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49673056990727, -73.57928305864334),
					new Position (45.49669672819955, -73.57921868562698),
					new Position (45.496621054307276, -73.57929311692715),
					new Position (45.49665348598783, -73.57935816049576),
					new Position (45.49673056990727, -73.57928305864334)
				},
				Services = new List<Service> {
					new Service {
						Name = "raduate Students Association",
						URI = "http://gsaconcordia.ca"
					}
				}
			};
			BuildingList.Add (T.Code, T);

			Building V = new Building {
				Code = "V",
				Name = "V",
				Campus = SGW,
				Address = "2110 Mackay",
				Position = new Position (45.49702151, -73.57995696),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49708825671362, -73.57994019985199),
					new Position (45.49698485208852, -73.58004547655582),
					new Position (45.49694443022887, -73.57996232807636),
					new Position (45.497031384193306, -73.5798704624176),
					new Position (45.4970337342986, -73.57987381517887),
					new Position (45.49705018503282, -73.5798617452383),
					new Position (45.497088726734205, -73.57994019985199)
				}
			};
			BuildingList.Add (V.Code, V);

			Building X = new Building {
				Code = "X",
				Name = "X",
				Campus = SGW,
				Address = "2080 Mackay",
				Position = new Position (45.49687957, -73.57969075),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.496943020163485, -73.57969343662262),
					new Position (45.496904948384476, -73.57961632311344),
					new Position (45.49682175440746, -73.5796994715929),
					new Position (45.49685794615269, -73.57977390289307),
					new Position (45.496943020163485, -73.57969343662262)
				},
				Services = new List<Service> {
					new Service {
						Name = "Concordia International",
						URI = "http://concordia.ca/content/concordia/en/offices/ci.html"
					}
				}
			};
			BuildingList.Add (X.Code, X);

			Building Z = new Building {
				Code = "Z",
				Name = "Z",
				Campus = SGW,
				Address = "2090 Mackay",
				Position = new Position (45.49691717, -73.57978061),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.49699049234569, -73.57977591454983),
					new Position (45.49694725035956, -73.57969142496586),
					new Position (45.49685841617521, -73.57977993786335),
					new Position (45.496899778140914, -73.57986576855183),
					new Position (45.49699049234569, -73.57977591454983)
				},
				Services = new List<Service> {
					new Service {
						Name = "Multi-Faith Chaplaincy",
						URI = "http://concordia.ca/content/concordia/en/offices/chaplaincy.html"
					},
					new Service {
						Name = "Sustainable Concordia",
						URI = "http://sustainableconcordia.ca"
					}
				}
			};
			BuildingList.Add (Z.Code, Z);





			/******************************
			 ******************************
			 ****** LOYOLA BUILDINGS ******
			 ******************************
			 ******************************/


			Building AD = new Building {
				Code = "AD",
				Name = "Administration",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.4580762, -73.63981247),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45828033335741, -73.63981448113918),
					new Position (45.45821495544604, -73.63986544311047),
					new Position (45.45818861612217, -73.63980107009411),
					new Position (45.45807432212794, -73.63989226520061),
					new Position (45.45808137731947, -73.639917075634),
					new Position (45.45806209312717, -73.63993182778358),
					new Position (45.45808466974189, -73.63998547196388),
					new Position (45.45805362689433, -73.64001229405403),
					new Position (45.45802916888118, -73.63995261490345),
					new Position (45.45800847363098, -73.63996803760529),
					new Position (45.45799906669659, -73.6399445682764),
					new Position (45.457867369450064, -73.64004984498024),
					new Position (45.45789464961923, -73.64012025296688),
					new Position (45.45783209334964, -73.64017456769943),
					new Position (45.457719209680036, -73.63987818360329),
					new Position (45.457779414331945, -73.63982923328876),
					new Position (45.45781657185847, -73.63992109894753),
					new Position (45.4579407436682, -73.63982386887074),
					new Position (45.45793415880639, -73.6398084461689),
					new Position (45.45799906669659, -73.63975681364536),
					new Position (45.45800800328433, -73.63977022469044),
					new Position (45.45815051814984, -73.63965958356857),
					new Position (45.458114771880766, -73.63956771790981),
					new Position (45.45816792093052, -73.63952614367008),
					new Position (45.45828033335741, -73.63981179893017),
					new Position (45.45828033335741, -73.63981448113918)
				},
				Services = new List<Service> {
					new Service {
						Name = "Loyola International College",
						URI = "http://loyc.concordia.ca"
					},
					new Service {
						Name = "Centre for Teaching & Learning",
						URI = "http://concordia.ca/content/concordia/en/offices/ctl.html"
					},
					new Service {
						Name = "Provost and Vice-President",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"
					},
					new Service {
						Name = "Dean of Students",
						URI = "http://concordia.ca/content/concordia/en/offices/dean-students.html"
					},
					new Service {
						Name = "Concordia Multi-Faith Chaplaincy",
						URI = "http://concordia.ca/content/concordia/en/offices/chaplaincy.html"
					},
					new Service {
						Name = "Advocacy & Support Services",
						URI = "http://concordia.ca/content/concordia/en/offices/advocacy.html"
					},
					new Service {
						Name = "Access Centre for Students with Disabilities",
						URI = "http://concordia.ca/content/concordia/en/offices/acsd.html"
					},
					new Service {
						Name = "Counselling and Development",
						URI = "http://concordia.ca/content/concordia/en/offices/cdev.html"
					},
					new Service {
						Name = "Health Services",
						URI = "http://concordia.ca/content/concordia/en/students/health.html"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Faculty of Arts & Science",
						URI = "http://concordia.ca/content/concordia/en/artsci.html"
					}
				}
			};
			BuildingList.Add (AD.Code, AD);

			Building BB = new Building {
				Code = "BB",
				Name = "BB",
				Campus = LOY,
				Address = "3502 Belmore",
				Position = new Position (45.45984844, -73.63939941),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45985549479686, -73.63937325775623),
					new Position (45.45984608817059, -73.6393390595913),
					new Position (45.45983197822826, -73.63934844732285),
					new Position (45.459838562868455, -73.63937795162201),
					new Position (45.459838562868455, -73.63937795162201),
					new Position (45.45985549479686, -73.63937325775623)
				}
			};
			BuildingList.Add (BB.Code, BB);

			Building BH = new Building {
				Code = "BH",
				Name = "BH",
				Campus = LOY,
				Address = "3500 Belmore",
				Position = new Position (45.45971675, -73.63914192),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.459817397950786, -73.63918080925941),
					new Position (45.45975672514275, -73.63903127610683),
					new Position (45.45966124764598, -73.63911174237728),
					new Position (45.459720509559546, -73.63926060497761),
					new Position (45.45981833861395, -73.63918013870716),
					new Position (45.459817397950786, -73.63918080925941)
				},
				Services = new List<Service> {
					new Service {
						Name = "CPE Les P'tits Profs Daycare",
						URI = "http://lesptitsprofs.wordpress.com"
					}
				}
			};
			BuildingList.Add (BH.Code, BH);

			Building CC = new Building {
				Code = "CC",
				Name = "Central",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45823236, -73.64041328),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.45844871640609, -73.64071905612946),
					new Position (45.45829444368806, -73.64083774387836),
					new Position (45.45808843251011, -73.64030197262764),
					new Position (45.45809125458613, -73.64029727876186),
					new Position (45.45800000739008, -73.64005520939827),
					new Position (45.458142522275836, -73.63994389772415),
					new Position (45.45823659130999, -73.64018328487873),
					new Position (45.45824223544704, -73.64017590880394),
					new Position (45.45844871640609, -73.64071905612946)
				},
				Services = new List<Service> {
					new Service {
						Name = "Concordia Student Union",
						URI = "http://csu.concordia.ca"
					}
				}
			};
			BuildingList.Add (CC.Code, CC);

			Building CJ = new Building {
				Code = "CJ",
				Name = "Communication and Journalism",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45745911, -73.64041328),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.457333051751476, -73.64075526595116),
					new Position (45.457305771310594, -73.6406908929348),
					new Position (45.45728225367856, -73.6407096683979),
					new Position (45.457175013152096, -73.6404387652874),
					new Position (45.457423359323684, -73.6402416229248),
					new Position (45.45737350203607, -73.64011287689209),
					new Position (45.457306712015665, -73.64007532596588),
					new Position (45.45730106778496, -73.64009141921997),
					new Position (45.45723145555987, -73.64004448056221),
					new Position (45.45722298920231, -73.63996803760529),
					new Position (45.45722863344083, -73.63990902900696),
					new Position (45.45725121038923, -73.63986074924469),
					new Position (45.45727190591733, -73.6398258805275),
					new Position (45.457307652720715, -73.63979905843735),
					new Position (45.457350925136616, -73.63978430628777),
					new Position (45.45739796033361, -73.63978698849678),
					new Position (45.45744029197736, -73.63980576395988),
					new Position (45.457461928138585, -73.63982185721397),
					new Position (45.4574732165672, -73.63983929157257),
					new Position (45.4574732165672, -73.63984867930412),
					new Position (45.45745440251823, -73.6399693787098),
					new Position (45.45744311408582, -73.63995999097824),
					new Position (45.45743652916589, -73.6400619149208),
					new Position (45.45748826780188, -73.64019066095352),
					new Position (45.45762278803329, -73.64009007811546),
					new Position (45.45771873933096, -73.64033281803131),
					new Position (45.45775636724623, -73.64030197262764),
					new Position (45.45783444509036, -73.64048838615417),
					new Position (45.45765665321582, -73.64063456654549),
					new Position (45.457621847333485, -73.64056348800659),
					new Position (45.457549413401395, -73.64062249660492),
					new Position (45.457532480780465, -73.64059031009674),
					new Position (45.457335873865276, -73.64074990153313),
					new Position (45.457335873865276, -73.64075258374214),
					new Position (45.45733399245609, -73.64075124263763),
					new Position (45.457333051751476, -73.64075526595116)
				},
				Services = new List<Service> {
					new Service {
						Name = "Campus Retail Stores",
						URI = "http://retail.concordia.ca"
					},
				},
				Departments = new List<Department> {
					new Department {
						Name = "Communication Studies",
						URI = "http://coms.concordia.ca"
					},
					new Department {
						Name = "Journalism",
						URI = "http://journalism.concordia.ca"
					}
				}
			};
			BuildingList.Add (CJ.Code, CJ);

			Building DO = new Building {
				Code = "DO",
				Name = "Stinger Dome",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45792569, -73.63487184),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.4579407436682, -73.6347833275795),
					new Position (45.45791252282638, -73.63459825515747),
					new Position (45.457850436924595, -73.63460898399353),
					new Position (45.4578579624921, -73.63478064537048),
					new Position (45.4579407436682, -73.6347833275795)
				}
			};
			BuildingList.Add (DO.Code, DO);

			Building FC = new Building {
				Code = "FC",
				Name = "F.C. Smith",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45847506, -73.63938332),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.45865660763283, -73.63962672650814),
					new Position (45.45865990002167, -73.6395824700594),
					new Position (45.45863685329585, -73.63951809704304),
					new Position (45.458644378758365, -73.63950937986374),
					new Position (45.45861333621894, -73.63943092525005),
					new Position (45.458619450659874, -73.63942623138428),
					new Position (45.45851174233407, -73.63915398716927),
					new Position (45.45852208986775, -73.63914392888546),
					new Position (45.45852538226442, -73.63913655281067),
					new Position (45.45852773397625, -73.6391231417656),
					new Position (45.45852773397625, -73.63911308348179),
					new Position (45.45852303055254, -73.63909631967545),
					new Position (45.45852067884054, -73.63909028470516),
					new Position (45.45851550507381, -73.63908156752586),
					new Position (45.458507509251554, -73.63907352089882),
					new Position (45.45849716171521, -73.63907150924206),
					new Position (45.458489165890356, -73.63907352089882),
					new Position (45.458333952595076, -73.63918483257294),
					new Position (45.458349003599984, -73.63922372460365),
					new Position (45.4583395967224, -73.63923110067844),
					new Position (45.45834947394385, -73.63926060497761),
					new Position (45.45835699944471, -73.63925591111183),
					new Position (45.458424258564314, -73.63942623138428),
					new Position (45.45839321590369, -73.63945171236992),
					new Position (45.458421436504956, -73.63952413201332),
					new Position (45.45845106812107, -73.63949932157993),
					new Position (45.45850139479848, -73.6396186798811),
					new Position (45.45851174233407, -73.63961063325405),
					new Position (45.4585409035605, -73.63968171179295),
					new Position (45.458574297849665, -73.63969512283802),
					new Position (45.45865660763283, -73.63962672650814)
				},
				Services = new List<Service> {
					new Service {
						Name = "F.C. Smith Auditorium",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/fc-smith-auditorium"
					},
					new Service {
						Name = "Concordia Multi-Faith Chaplaincy",
						URI = "http://concordia.ca/content/concordia/en/students/multifaith"
					},
					new Service {
						Name = "Cazalet Theater",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/cazalet"
					}
				}
			};
			BuildingList.Add (FC.Code, FC);

			Building GE = new Building {
				Code = "GE",
				Name = "Centre for Structural and Functional Genomics",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45690973, -73.64037037),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.456970879305665, -73.6404401063919),
					new Position (45.45696053148731, -73.64037171006203),
					new Position (45.45693607300003, -73.64037975668907),
					new Position (45.45694359868957, -73.64043742418289),
					new Position (45.456970879305665, -73.6404401063919)
				},
				Services = new List<Service> {
					new Service {
						Name = "Genomic Centre",
						URI = "http://concordia.ca/content/concordia/en/research/genomics"
					}
				}
			};
			BuildingList.Add (GE.Code, GE);

			Building HA = new Building {
				Code = "HA",
				Name = "Hingston Wing A",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45944395, -73.64125818),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.45967018397027, -73.6413835734129),
					new Position (45.459646667324336, -73.64132322371006),
					new Position (45.459656073983886, -73.641312494874),
					new Position (45.45952343993943, -73.64096380770206),
					new Position (45.45951168158709, -73.64097453653812),
					new Position (45.45948675387204, -73.64091485738754),
					new Position (45.45946511848779, -73.64093229174614),
					new Position (45.45946088547685, -73.6409255862236),
					new Position (45.459266636966476, -73.6410778015852),
					new Position (45.45926992931969, -73.64108987152576),
					new Position (45.45924970486122, -73.6411052942276),
					new Position (45.45927039965584, -73.64116497337818),
					new Position (45.45925628956943, -73.641177713871),
					new Position (45.45939033524782, -73.64153042435646),
					new Position (45.45940256396051, -73.64151902496815),
					new Position (45.45942749171276, -73.6415746808052),
					new Position (45.4596715949687, -73.64138290286064),
					new Position (45.45967018397027, -73.6413835734129)
				},
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (HA.Code, HA);


			Building HB = new Building {
				Code = "HB",
				Name = "Hingston Wing B",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45915987, -73.64200652),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.459342831377185, -73.64217348396778),
					new Position (45.45932166627344, -73.64211715757847),
					new Position (45.45934471271938, -73.6420963704586),
					new Position (45.45934047969938, -73.64208430051804),
					new Position (45.45950509690873, -73.64195622503757),
					new Position (45.45953002461565, -73.64201724529266),
					new Position (45.45955071930737, -73.64199712872505),
					new Position (45.45938845390715, -73.6415746808052),
					new Position (45.4594166740103, -73.64155322313309),
					new Position (45.459405385970726, -73.64151567220688),
					new Position (45.45937481418557, -73.64153981208801),
					new Position (45.45936305580224, -73.64151768386364),
					new Position (45.45895386253506, -73.64184021949768),
					new Position (45.458975027776894, -73.64189721643925),
					new Position (45.4589557438902, -73.64191196858883),
					new Position (45.45895762524529, -73.64192672073841),
					new Position (45.45895009982458, -73.6419340968132),
					new Position (45.459083205555444, -73.64228814840317),
					new Position (45.45909543433475, -73.64227943122387),
					new Position (45.45910295973607, -73.64229150116444),
					new Position (45.45912224357238, -73.64227004349232),
					new Position (45.4591467011114, -73.6423310637474),
					new Position (45.45934236104165, -73.64217482507229),
					new Position (45.459341420370514, -73.64217147231102),
					new Position (45.45934236104165, -73.64217482507229),
					new Position (45.45934236104165, -73.64217482507229),
					new Position (45.45934236104165, -73.64217482507229),
					new Position (45.459341420370514, -73.64217147231102),
					new Position (45.45934330171276, -73.64217549562454),
					new Position (45.459342831377185, -73.64217348396778)
				},
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					},
					new Service {
						Name = "CUFA",
						URI = "http://www.cufa.net"
					}
				}
			};
			BuildingList.Add (HB.Code, HB);

			Building HC = new Building {
				Code = "HC",
				Name = "Hingston Wing C",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45965278, -73.64208162),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45988606632139, -73.64201992750168),
					new Position (45.45981786828236, -73.64184357225895),
					new Position (45.45970639958576, -73.64193007349968),
					new Position (45.45969228960846, -73.64189520478249),
					new Position (45.45951920693287, -73.642034009099),
					new Position (45.459617036336525, -73.64228144288063),
					new Position (45.45978729672083, -73.64214397966862),
					new Position (45.45977647908741, -73.64211179316044),
					new Position (45.45988606632139, -73.64201992750168)
				},
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (HC.Code, HC);

			Building JR = new Building {
				Code = "JR",
				Name = "Jesuit Residence",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45846, -73.64318132),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.458539022191516, -73.64337980747223),
					new Position (45.45850844993658, -73.64330671727657),
					new Position (45.458526793291526, -73.64329263567924),
					new Position (45.45848681417695, -73.64319205284119),
					new Position (45.45847646663678, -73.64320278167725),
					new Position (45.458443072289704, -73.64312700927258),
					new Position (45.458389923499304, -73.64317126572132),
					new Position (45.45839509727755, -73.64318668842316),
					new Position (45.458384279377015, -73.64319540560246),
					new Position (45.458371580099836, -73.64316791296005),
					new Position (45.4583019691963, -73.64322692155838),
					new Position (45.45833066018724, -73.64329800009727),
					new Position (45.45831184642434, -73.64331677556038),
					new Position (45.4583527663506, -73.64341199398041),
					new Position (45.45836734700681, -73.64340126514435),
					new Position (45.458398860025085, -73.64346966147423),
					new Position (45.4584628266946, -73.6434193700552),
					new Position (45.458470352180356, -73.64343479275703),
					new Position (45.458539022191516, -73.64337980747223)
				},
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (JR.Code, JR);

			Building PC = new Building {
				Code = "PC",
				Name = "PERFORM Center",
				Campus = LOY,
				Address = "7200 Sherbrooke St. W.",
				Position = new Position (45.45706025, -73.63715708),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.457082823764566, -73.63702297210693),
					new Position (45.45703014404687, -73.63684058189392),
					new Position (45.456962412908965, -73.63687813282013),
					new Position (45.45698122712211, -73.637033700943),
					new Position (45.45698122712211, -73.637033700943),
					new Position (45.45698122712211, -73.637033700943),
					new Position (45.457082823764566, -73.63702297210693)
				},
				Services = new List<Service> {
					new Service {
						Name = "PERFORM Centre",
						URI = "http://concordia.ca/content/concordia/en/research/perform.html"
					}
				}
			};
			BuildingList.Add (PC.Code, PC);

			Building PS = new Building {
				Code = "PS",
				Name = "Physical Services",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45962644, -73.63981247),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45994250601546, -73.6400619149208),
					new Position (45.45966030698017, -73.63932967185974),
					new Position (45.45962268033541, -73.63936051726341),
					new Position (45.459565299653825, -73.63922774791718),
					new Position (45.45927839536991, -73.63945305347443),
					new Position (45.459330132315905, -73.6395911872387),
					new Position (45.45939691993959, -73.63954022526741),
					new Position (45.459443012760495, -73.6396461725235),
					new Position (45.45941479267053, -73.63967299461365),
					new Position (45.45960857033717, -73.64017054438591),
					new Position (45.45963020566638, -73.64014774560928),
					new Position (45.4597026369255, -73.64032745361328),
					new Position (45.4598503211526, -73.64021614193916),
					new Position (45.45982868590784, -73.64015713334084),
					new Position (45.45994250601546, -73.6400619149208)
				},
				Services = new List<Service> {
					new Service {
						Name = "Environmental Health and Safety",
						URI = "http://concordia.ca/content/concordia/en/campus-life/safety"
					},
					new Service {
						Name = "Facilities Management",
						URI = "http://concordia.ca/content/concordia/en/offices/facilities"
					}
				}
			};
			BuildingList.Add (PS.Code, PS);

			Building PT = new Building {
				Code = "PT",
				Name = "Oscar Peterson Concert Hall",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45933295, -73.63897026),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.45948957587806, -73.6391332000494),
					new Position (45.459457593134786, -73.63905608654022),
					new Position (45.45944818644213, -73.63906346261501),
					new Position (45.45931131888648, -73.63871075212955),
					new Position (45.4593211959377, -73.63870203495026),
					new Position (45.4593141409013, -73.63868124783039),
					new Position (45.45916175189937, -73.63880127668381),
					new Position (45.45914764178576, -73.63876909017563),
					new Position (45.45905968866471, -73.63883882761002),
					new Position (45.45910625209883, -73.63895751535892),
					new Position (45.45915046380878, -73.63892331719398),
					new Position (45.459173039987725, -73.63897696137428),
					new Position (45.459196086494394, -73.63895952701569),
					new Position (45.459305674856424, -73.63923847675323),
					new Position (45.459351767751954, -73.63920293748379),
					new Position (45.45936352613763, -73.63923110067844),
					new Position (45.45948957587806, -73.6391332000494)
				},
				Services = new List<Service> {
					new Service {
						Name = "Concert Hall",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/oscar-peterson.html"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Oscar Peterson Concert Hall",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/oscar-peterson.html"
					}
				}
			};
			BuildingList.Add (PT.Code, PT);

			Building PY = new Building {
				Code = "PY",
				Name = "Psychology",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45886638, -73.64049911),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.45916880695485, -73.64045888185501),
					new Position (45.45914576043701, -73.64039584994316),
					new Position (45.45913635369235, -73.64040121436119),
					new Position (45.45904369717341, -73.64016383886337),
					new Position (45.45895292185747, -73.64023357629776),
					new Position (45.458956684567774, -73.64024631679058),
					new Position (45.45892140914885, -73.64027515053749),
					new Position (45.458913413384145, -73.64025503396988),
					new Position (45.458696586627035, -73.64042401313782),
					new Position (45.458697997649836, -73.64043205976486),
					new Position (45.45865190421989, -73.64046961069107),
					new Position (45.45879488779811, -73.6408444494009),
					new Position (45.45910060804824, -73.6406110972166),
					new Position (45.459121302897586, -73.64066138863564),
					new Position (45.45921066693252, -73.6405923217535),
					new Position (45.45916316291055, -73.64046223461628),
					new Position (45.45916880695485, -73.64045888185501)
				},
				HoleShapeCoords = new List<Position> {
					new Position (45.45899195996461, -73.6403576284647),
					new Position (45.45873327320852, -73.64055745303631),
					new Position (45.4587539681927, -73.64061243832111),
					new Position (45.45877278180807, -73.64059835672379),
					new Position (45.4587680784048, -73.64058695733547),
					new Position (45.45882734125715, -73.64054068922997),
					new Position (45.45885697265996, -73.64061579108238),
					new Position (45.45901453620701, -73.64049442112446),
					new Position (45.45899290064157, -73.64043273031712),
					new Position (45.45900842180892, -73.64039987325668),
					new Position (45.45899195996461, -73.6403576284647)
				},
				Departments = new List<Department> {
					new Department {
						Name = "Psychology",
						URI = "http://psychology.concordia.ca"
					}
				}
			};
			BuildingList.Add (PY.Code, PY);

			Building RA = new Building {
				Code = "RA",
				Name = "Recreational and Athletic Complex",
				Campus = LOY,
				Address = "7200 Sherbrooke W.",
				Position = new Position (45.45670278, -73.63763452),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45672064971158, -73.6371074616909),
					new Position (45.45638575423165, -73.63737165927887),
					new Position (45.456689606113095, -73.63814815878868),
					new Position (45.45679026256728, -73.63806769251823),
					new Position (45.45683917965772, -73.63819375634193),
					new Position (45.45677050757642, -73.63825008273125),
					new Position (45.45679872898983, -73.63832250237465),
					new Position (45.45676674472025, -73.63835200667381),
					new Position (45.45679590684914, -73.63843649625778),
					new Position (45.45683071324125, -73.63841906189919),
					new Position (45.45688245243312, -73.63855987787247),
					new Position (45.457016033399846, -73.63845929503441),
					new Position (45.45702261836891, -73.63848477602005),
					new Position (45.457054602493365, -73.63847136497498),
					new Position (45.457016033399846, -73.63845929503441),
					new Position (45.45703766972384, -73.63843381404877),
					new Position (45.45715619900361, -73.63833993673325),
					new Position (45.457036729014284, -73.63803550601006),
					new Position (45.45700004132896, -73.63805830478668),
					new Position (45.45696805717357, -73.63796576857567),
					new Position (45.45695394651102, -73.63793089985847),
					new Position (45.457023088723815, -73.63787725567818),
					new Position (45.45672064971158, -73.6371074616909)
				},
				Services = new List<Service> {
					new Service {
						Name = "Ed Meagher Arena",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Gymnasium",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Indoor running track",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Café"
					}
				}
			};
			BuildingList.Add (RA.Code, RA);

			Building RF = new Building {
				Code = "RF",
				Name = "Loyola Jesuit Hall and Conference Centre",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45846753, -73.64106774),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.458657548315394, -73.64098593592644),
					new Position (45.45861098451073, -73.64086791872978),
					new Position (45.458521619525364, -73.64093899726868),
					new Position (45.45845671223667, -73.64077337086201),
					new Position (45.4584336654278, -73.6407894641161),
					new Position (45.45841532204255, -73.6407458782196),
					new Position (45.45835558841338, -73.6407908052206),
					new Position (45.45837299113078, -73.64084109663963),
					new Position (45.45832736777916, -73.64087462425232),
					new Position (45.45836452494461, -73.64097252488136),
					new Position (45.45838333868993, -73.64095710217953),
					new Position (45.458410618609484, -73.64102147519588),
					new Position (45.458299617475085, -73.64111334085464),
					new Position (45.45835229600679, -73.64124678075314),
					new Position (45.45841579238582, -73.64119783043861),
					new Position (45.45845294949301, -73.64128768444061),
					new Position (45.4583974489948, -73.6413299292326),
					new Position (45.458421436504956, -73.64139765501022),
					new Position (45.45857994195292, -73.64127226173878),
					new Position (45.458552191773144, -73.6411964893341),
					new Position (45.45857806058521, -73.64117704331875),
					new Position (45.45857241648178, -73.64115424454212),
					new Position (45.45860251836028, -73.6411240696907),
					new Position (45.45857570887552, -73.64104695618153),
					new Position (45.45865613729157, -73.64098459482193),
					new Position (45.45865613729157, -73.64098459482193),
					new Position (45.45865613729157, -73.64098459482193),
					new Position (45.45865613729157, -73.64098459482193),
					new Position (45.45865613729157, -73.64098459482193),
					new Position (45.458657548315394, -73.64098593592644)
				},
				Services = new List<Service> {
					new Service {
						Name = "Loyola Jesuit Hall and Conference Centre",
						URI = "http://concordia.ca/content/concordia/en/hospitality/hospitality-venues/loyola-jesuit-hall-conference-centre.html"
					},
					new Service {
						Name = "Conference services",
						URI = "http://concordia.ca/content/concordia/en/hospitality.html"
					}
				}
			};
			BuildingList.Add (RF.Code, RF);

			Building SC = new Building {
				Code = "SC",
				Name = "Student Center",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45910719, -73.63915265),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.459295797802504, -73.63932028412819),
					new Position (45.45925675990571, -73.63921903073788),
					new Position (45.45927933604209, -73.63919824361801),
					new Position (45.45919138312644, -73.63897293806076),
					new Position (45.45915046380878, -73.63900646567345),
					new Position (45.459131179982116, -73.63896287977695),
					new Position (45.45907662082703, -73.63900646567345),
					new Position (45.459090730958394, -73.63904938101768),
					new Position (45.4589938413185, -73.63912783563137),
					new Position (45.4591043707487, -73.63940745592117),
					new Position (45.45921866265506, -73.63931961357594),
					new Position (45.459237005778974, -73.63936588168144),
					new Position (45.459295797802504, -73.63932028412819)
				},
				Services = new List<Service> {
					new Service {
						Name = "Campus Centre"
					},
					new Service {
						Name = "Food Services",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/admissions/meal-plan.html"
					},
					new Service {
						Name = "Cafeteria"
					},
					new Service {
						Name = "Café"
					}
				}
			};
			BuildingList.Add (SC.Code, SC);

			Building SH = new Building {
				Code = "SH",
				Name = "Solar House",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45955871, -73.6425671),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45961515500344, -73.64266633987427),
					new Position (45.4595737656597, -73.64253222942352),
					new Position (45.459509800250494, -73.64258050918579),
					new Position (45.4595436642997, -73.64267706871033),
					new Position (45.45961515500344, -73.64266633987427)
				}
			};
			BuildingList.Add (SH.Code, SH);

			Building SI = new Building {
				Code = "SI",
				Name = "Saint-Ignatius of Loyola Church",
				Campus = LOY,
				Address = "4455 BroadWay",
				Position = new Position (45.45779776, -73.64239812),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45815239953178, -73.6425456404686),
					new Position (45.4581025428888, -73.64241823554039),
					new Position (45.45808278835767, -73.64242762327194),
					new Position (45.45802352472279, -73.6422760784626),
					new Position (45.45803669442482, -73.64225059747696),
					new Position (45.45798307490449, -73.64210441708565),
					new Position (45.45795485408384, -73.64209368824959),
					new Position (45.45792569255432, -73.64202529191971),
					new Position (45.45786360666706, -73.64206552505493),
					new Position (45.457842911356124, -73.64201322197914),
					new Position (45.45780904628545, -73.64203199744225),
					new Position (45.45781469046532, -73.6420588195324),
					new Position (45.45775260445583, -73.6421138048172),
					new Position (45.45776201143137, -73.64214062690735),
					new Position (45.45770933234819, -73.6421862244606),
					new Position (45.45771591723629, -73.64221572875977),
					new Position (45.45766511950827, -73.642258644104),
					new Position (45.45767452649837, -73.64228010177612),
					new Position (45.4576293729315, -73.64231765270233),
					new Position (45.457654771817325, -73.64240348339081),
					new Position (45.45757104952074, -73.64246383309364),
					new Position (45.45761902523398, -73.64259794354439),
					new Position (45.45770651025306, -73.64252954721451),
					new Position (45.45771591723629, -73.64254429936409),
					new Position (45.45776201143137, -73.64251211285591),
					new Position (45.457770477707996, -73.6425268650055),
					new Position (45.45782033464461, -73.6424933373928),
					new Position (45.457827860216106, -73.64251211285591),
					new Position (45.45788618336125, -73.64247187972069),
					new Position (45.457923811164804, -73.64255905151367),
					new Position (45.45790593796126, -73.6425818502903),
					new Position (45.45794826922365, -73.6427092552185),
					new Position (45.45815239953178, -73.6425456404686)
				}
			};
			BuildingList.Add (SI.Code, SI);

			Building SP = new Building {
				Code = "SP",
				Name = "Richard J. Renaud Science Complex",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45777894, -73.64159614),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = new List<Position> {
					new Position (45.4582060188911, -73.64157870411873),
					new Position (45.458193789918894, -73.64154785871506),
					new Position (45.45832172365064, -73.6414486169815),
					new Position (45.458275629913096, -73.64133730530739),
					new Position (45.45820225613072, -73.64139899611473),
					new Position (45.45816839127586, -73.6413212120533),
					new Position (45.45824552786007, -73.64126488566399),
					new Position (45.458201315440576, -73.64113345742226),
					new Position (45.45810160219698, -73.64121526479721),
					new Position (45.45808372904977, -73.64118307828903),
					new Position (45.45802822818814, -73.64123001694679),
					new Position (45.457976490047606, -73.64110261201859),
					new Position (45.45788994614272, -73.64116698503494),
					new Position (45.45793133672251, -73.64127695560455),
					new Position (45.45787395431969, -73.64133462309837),
					new Position (45.4578325636978, -73.64125952124596),
					new Position (45.45752213306519, -73.64150628447533),
					new Position (45.45742053721423, -73.64124745130539),
					new Position (45.45740924877505, -73.6412501335144),
					new Position (45.45723898120996, -73.6408169567585),
					new Position (45.45719006446636, -73.64085718989372),
					new Position (45.457133622017146, -73.64072307944298),
					new Position (45.456970879305665, -73.64084780216217),
					new Position (45.457018855529554, -73.64096850156784),
					new Position (45.45698875280561, -73.64099130034447),
					new Position (45.457014151979976, -73.64104762673378),
					new Position (45.45703108475655, -73.6410328745842),
					new Position (45.45716090254131, -73.64135205745697),
					new Position (45.45715149546551, -73.64135608077049),
					new Position (45.45717125032289, -73.6414110660553),
					new Position (45.45716654678606, -73.64142313599586),
					new Position (45.457180657395405, -73.64146068692207),
					new Position (45.45720229365624, -73.64143654704094),
					new Position (45.457442173383036, -73.64202797412872),
					new Position (45.45755129480341, -73.64194482564926),
					new Position (45.457595507732584, -73.64204674959183),
					new Position (45.45767358579943, -73.64198371767998),
					new Position (45.45766794160546, -73.64195823669434),
					new Position (45.45799624461596, -73.64170342683792),
					new Position (45.458011295711025, -73.6417356133461),
					new Position (45.4582060188911, -73.64157870411873)
				},
				Services = new List<Service> {
					new Service {
						Name = "Science College",
						URI = "http://concordia.ca/content/concordia/en/artsci/science-college"
					},
					new Service {
						Name = "science Technical Centre",
						URI = "http://concordia.ca/content/concordia/en/artsci/services/technical-centre.html"
					},
					new Service {
						Name = "Animal Care Facilities"
					},
					new Service {
						Name = "Security Office"
					},
					new Service {
						Name = "Café"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Psychology",
						URI = "http://psychology.concordia.ca"
					},
					new Department {
						Name = "Physics",
						URI = "http://concordia.ca/content/concordia/en/artsci/physics"
					},
					new Department {
						Name = "Biology",
						URI = "http://concordia.ca/content/concordia/en/artsci/biology"
					},
					new Department {
						Name = "Chemistry and Biochemistry",
						URI = "http://concordia.ca/content/concordia/en/artsci/chemistry"
					},
					new Department {
						Name = "Exercise Science",
						URI = "http://concordia.ca/content/concordia/en/artsci/exercise-science"
					},
					new Department {
						Name = "Centre for Biological Applications of Mass Spectrometry",
						URI = "http://concordia.ca/content/concordia/en/research/mass-spec"
					},
					new Department {
						Name = "Centre for NanoScience Research",
						URI = "http://concordia.ca/content/concordia/en/research/nanoscience"
					},
					new Department {
						Name = "Center for Studies in Behavioral Neurobiology",
						URI = "http://concordia.ca/content/concordia/en/research/neuroscience"
					}
				}
			};
			BuildingList.Add (SP.Code, SP);

			Building TA = new Building {
				Code = "TA",
				Name = "Terrebonne",
				Campus = LOY,
				Address = "7079 Terrebonne",
				Position = new Position (45.45999895, -73.64088535),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.46007984236839, -73.64090614020824),
					new Position (45.46004174567388, -73.64080622792244),
					new Position (45.45993498072619, -73.64089272916317),
					new Position (45.459971666501936, -73.64099264144897),
					new Position (45.46007984236839, -73.64090614020824)
				}
			};
			BuildingList.Add (TA.Code, TA);

			Building VE = new Building {
				Code = "VE",
				Name = "Vanier Extension",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45880618, -73.63862693),
				HasAtm = false,
				HasBikeRack = true,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45907473947591, -73.63879054784775),
					new Position (45.458865438772186, -73.63825008273125),
					new Position (45.45881746411941, -73.63828629255295),
					new Position (45.45881229037992, -73.63827757537365),
					new Position (45.45878171827317, -73.63829970359802),
					new Position (45.458787362355665, -73.63831244409084),
					new Position (45.45869282389937, -73.63838821649551),
					new Position (45.45868482810228, -73.63838016986847),
					new Position (45.458658488997926, -73.63840095698833),
					new Position (45.458675891621816, -73.63844856619835),
					new Position (45.45862039134304, -73.63849617540836),
					new Position (45.45881746411941, -73.63900244235992),
					new Position (45.45883251499527, -73.6389883607626),
					new Position (45.45884474382895, -73.63901652395725),
					new Position (45.4588884854046, -73.63898500800133),
					new Position (45.458898832869146, -73.63901518285275),
					new Position (45.4590168878984, -73.63891795277596),
					new Position (45.45900654045553, -73.6388897895813),
					new Position (45.459025824324826, -73.63887503743172),
					new Position (45.45901500654529, -73.63884083926678),
					new Position (45.45907473947591, -73.63879054784775)
				},
				Services = new List<Service> {
					new Service {
						Name = "Library",
						URI = "http://library.concordia.ca/index.php"
					}
				},
				Departments = new List<Department> {
					new Department {
						Name = "Applied Human Sciences",
						URI = "http://ahsc.concordia.ca"
					}
				}
			};
			BuildingList.Add (VE.Code, VE);

			Building VL = new Building {
				Code = "VL",
				Name = "Vanier Library",
				Campus = LOY,
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45904699, -73.6383909),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = new List<Position> {
					new Position (45.45931272989392, -73.63867320120335),
					new Position (45.45916363324759, -73.63878920674324),
					new Position (45.4591467011114, -73.63875299692154),
					new Position (45.459080853866794, -73.63880261778831),
					new Position (45.45885038790514, -73.6382058262825),
					new Position (45.45887249386474, -73.63818906247616),
					new Position (45.45885509130154, -73.63813944160938),
					new Position (45.45888895574394, -73.63811664283276),
					new Position (45.45887202352528, -73.63807439804077),
					new Position (45.459090730958394, -73.63790474832058),
					new Position (45.45907803184032, -73.63787457346916),
					new Position (45.45909872669793, -73.63785780966282),
					new Position (45.45912600627139, -73.63792352378368),
					new Position (45.459117069860845, -73.63793224096298),
					new Position (45.459126946946114, -73.63795302808285),
					new Position (45.45914387908821, -73.63796442747116),
					new Position (45.459217251645285, -73.63815754652023),
					new Position (45.4591245952593, -73.63823264837265),
					new Position (45.45913259099403, -73.63825343549252),
					new Position (45.45914999347161, -73.63824538886547),
					new Position (45.4592614632682, -73.63853976130486),
					new Position (45.45925581923316, -73.63854646682739),
					new Position (45.459275103017205, -73.63859139382839),
					new Position (45.45927933604209, -73.63858871161938),
					new Position (45.45931272989392, -73.63867320120335)
				},
				Services = new List<Service> {
					new Service {
						Name = "Library",
						URI = "http://concordia.ca/content/concordia/en/library"
					}
				}
			};
			BuildingList.Add (VL.Code, VL);

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

		public Building GetBuildingByCode (String code)
		{
			Building building;
			return BuildingList.TryGetValue (code, out building) ? building : null;
		}


	}

}