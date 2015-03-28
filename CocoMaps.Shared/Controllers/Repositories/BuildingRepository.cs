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
				Campus = "SGW",
				Address = "2160 Bishop",
				Position = new Position (45.4978008, -73.57955262),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "_iutGz~a`MDOb@`@GLa@_@",
				Services = new List<Service> {
					new Service {
						Name = "CPE Les P'tits Profs Daycare",
						RoomNumber = "B",
						URI = "http://lesptitsprofs.wordpress.com"
					}
				}
			};
			BuildingList.Add (B.Code, B);

			Building CB = new Building {
				Code = "CB",
				Name = "CB",
				Campus = "SGW",
				Address = "1425 René Lévesque W.",
				Position = new Position (45.49519498, -73.57429147),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "syttGb~``MjAjADMEEVu@MMEJKIDMOMEJIKBKOOIT?ACH??Ob@"
			};
			BuildingList.Add (CB.Code, CB);

			Building CI = new Building {
				Code = "CI",
				Name = "CI",
				Campus = "SGW",
				Address = "2149 Mackay",
				Position = new Position (45.49744312, -73.57994959),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ofutGrab`MTTFQUUGP",
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
				Campus = "SGW",
				Address = "1665 St. Catherine W.",
				Position = new Position (45.4942173, -73.57929111),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "osttGl}a`M|@jAb@}@?C?ECIEEm@y@i@dA",
				Services = new List<Service> {
					new Service {
						Name = "The Centre for Continuing Education",
						RoomNumber = "CL",
						URI = "http://cce.concordia.ca"
					}
				}
			};
			BuildingList.Add (CL.Code, CL);

			Building D = new Building {
				Code = "D",
				Name = "D",
				Campus = "SGW",
				Address = "2140 Bishop",
				Position = new Position (45.49773641, -73.57939035),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ohutGx}a`MBK`@^EL",
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
				Campus = "SGW",
				Address = "2070 Mackay",
				Position = new Position (45.49684385, -73.57963711),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "{butGj_b`MBG@?BCPP?BXZEHo@o@",
				Services = new List<Service> {
					new Service {
						Name = "Translation Services",
						RoomNumber = "EN",
						URI = "http://web2.concordia.ca/translation"
					},
					new Service {
						Name = "Career and Planning Services",
						RoomNumber = "EN",
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
				Campus = "SGW",
				Address = "1515 St. Catherine W.",
				Position = new Position (45.49561989, -73.5783577),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "}wttGzta`MM^CNOz@g@rAQ?u@w@`AkC?OL[PAn@p@",
				Services = new List<Service> {
					new Service {
						Name = "LeGym",
						RoomNumber = "EV-S2.206",
						URI = "http://concordia.ca/content/concordia/en/campus-life/recreation/facilities/le-gym.html",
					},
					new Service {
						Name = "FOFA Gallery",
						RoomNumber = "EV-2.781",
						URI = "http://concordia.ca/content/concordia/en/finearts/facilities/fofa-gallery.html"
					},
					new Service {
						Name = "Performing Arts Facilities",
						RoomNumber = "EV-2.781",
						URI = "http://concordia.ca/content/concordia/en/finearts/facilities/performing-arts"
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
				Campus = "SGW",
				Address = "2060 Mackay",
				Position = new Position (45.49679496, -73.57951775),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "kbutG~~a`MDOPPGNOQ",
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
				Campus = "SGW",
				Address = "1250 Guy",
				Position = new Position (45.49458957, -73.57759595),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "evttGdta`MFOAAFM??FOAAHMACN[AAHOp@z@{@fBi@q@",
				Services = new List<Service> {
					new Service {
						Name = "School of Extended Learning",
						RoomNumber = "FB-131.1",
						URI = "http://www.concordia.ca/extended-learning"
					},
					new Service {
						Name = "Student Transition Centre",
						RoomNumber = "FB-117.3",
						URI = "http://concordia.ca/content/concordia/en/extended-learning/advising.html"
					},
					new Service {
						Name = "Centre for Teaching and Learning",
						RoomNumber = "FB-620",
						URI = "http://concordia.ca/content/concordia/en/extended-learning/advising.html"
					},
					new Service {
						Name = "Human Resources",
						RoomNumber = "FB-1130",
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
				Campus = "SGW",
				Address = "1616 St. Catherine W.",
				Position = new Position (45.49386382, -73.57871711),
				HasAtm = true,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "ytttGvua`Mn@sAJLGLFFBEb@j@ADPT@Ad@j@ABDF@AFHABj@t@e@bA_BoB?@MO@AaAmA",
				Services = new List<Service> {
					new Service {
						Name = "Classrooms",
						RoomNumber = "FG"
					},
				}
			};
			BuildingList.Add (FG.Code, FG);

			Building GM = new Building {
				Code = "GM",
				Name = "Guy-Metro",
				Campus = "SGW",
				Address = "1550 De Maisonneuve W.",
				Position = new Position (45.49586619, -73.57887805),
				HasAtm = false,
				HasBikeRack = true,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "u}ttG|za`M^eA`A~@a@dA_A_A",
				Services = new List<Service> {
					new Service {
						Name = "Office of the President",
						RoomNumber = "GM",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/president.html"
					},
					new Service {
						Name = "Office of the VP, Institutional Relations and Secretary General",
						RoomNumber = "GM-801",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-development-external-relations-secretary-general.html"
					},
					new Service {
						Name = "Office of the Provost",
						RoomNumber = "GM-806.00",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"
					},
					new Service {
						Name = "Office of Rights and Responsibilities",
						RoomNumber = "GM",
						URI = "http://concordia.ca/content/concordia/en/students/rights.html"
					},
					new Service {
						Name = "Ombuds Office",
						RoomNumber = "GM-1005",
						URI = "http://concordia.ca/content/concordia/en/campus-life/ombuds.html"
					},
					new Service {
						Name = "Institute for Co-operative Education",
						RoomNumber = "GM-430",
						URI = "http://concordia.ca/content/concordia/en/academics/co-op.html"
					},
					new Service {
						Name = "Office of the VP, Research & Graduate Studies",
						RoomNumber = "GM-900.00",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"
					},
					new Service {
						Name = "Office of the Chief Communications Officer",
						RoomNumber = "GM-900.00",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"
					},
					new Service {
						Name = "Financial Aid & Awards Office",
						RoomNumber = "GM-230.00",
						URI = "http://concordia.ca/content/concordia/en/offices/faao.html"
					},
					new Service {
						Name = "Health Services",
						RoomNumber = "GM-200",
						URI = "http://concordia.ca/content/concordia/en/students/health.html"
					},
					new Service {
						Name = "Environmental Health and Safety",
						RoomNumber = "GM",
						URI = "http://concordia.ca/content/concordia/en/campus-life/safety"
					},
					new Service {
						Name = "Facilities Management",
						RoomNumber = "GM-1100",
						URI = "http://concordia.ca/content/concordia/en/offices/facilities"
					},
					new Service {
						Name = "Music",
						RoomNumber = "GM-500.01",
						URI = "http://concordia.ca/content/concordia/en/finearts/music"
					},
					new Service {
						Name = "Theatre",
						RoomNumber = "GM-500.01",
						URI = "http://concordia.ca/content/concordia/en/finearts/theatre"
					},
					new Service {
						Name = "Contemporary Dance",
						RoomNumber = "GM-500.01",
						URI = "http://concordia.ca/content/concordia/en/finearts/dance"
					},
					new Service {
						Name = "Graduate Studies",
						RoomNumber = "GM-930.01",
						URI = "http://concordia.ca/content/concordia/en/offices/sgs.html"
					},
				}
			};
			BuildingList.Add (GM.Code, GM);

			Building H = new Building {
				Code = "H",
				Name = "Henry F. Hall",
				Campus = "SGW",
				Address = "1455 De Maisonneuve W.",
				Position = new Position (45.4972443, -73.57890487),
				HasAtm = true,
				HasBikeRack = true,
				HasInfoKiosk = true,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "ugutG|{a`MjBdBbAiCkBeBcAhC",
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
						Name = "Archives",
						RoomNumber = "H-1015",
						URI = "http://archives.concordia.ca/"
					},
					new Service {
						Name = "Access Centre for Students with Disabilities",
						RoomNumber = "H-580",
						URI = "http://concordia.ca/content/concordia/en/offices/acsd"
					},
					new Service {
						Name = "Concordia Student Union",
						RoomNumber = "H-711",
						URI = "http://csu.concordia.ca"
					},
					new Service {
						Name = "Computer Store",
						RoomNumber = "H",
						URI = "http://retail.concordia.ca/ccs/"
					},
					new Service {
						Name = "D. B. Clarke Theatre\\",
						RoomNumber = "H",
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
				Campus = "SGW",
				Address = "2150 Bishop",
				Position = new Position (45.49776837, -73.57947282),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "whutGj~a`Mp@p@FQs@o@EN",
				Services = new List<Service> {
					new Service {
						Name = "Theological Studies",
						RoomNumber = "K",
						URI = "http://concordia.ca/content/concordia/en/artsci/theology.html"
					}
				}
			};
			BuildingList.Add (K.Code, K);

			Building LB = new Building {
				Code = "LB",
				Name = "McConnel Library",
				Campus = "SGW",
				Address = "1400 De Maisonneuve W.",
				Position = new Position (45.49674232, -73.57807606),
				HasAtm = true,
				HasBikeRack = true,
				HasInfoKiosk = true,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "{dutG|ua`Mn@l@BGFDBGHHCFFFCD`@b@BGDBTo@CEPc@BBd@mA@@BIo@o@Un@KKFOMO??e@e@Wp@BBCH@@??A@GGM^FFABAACHEEWn@",
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
						RoomNumber = "LB-103",
						URI = "http://retail.concordia.ca/ccs/"
					},
					new Service {
						Name = "Birks Student Service Centre",
						RoomNumber = "LB-185",
						URI = "http://concordia.ca/content/concordia/en/students/birks"
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
						RoomNumber = "LB",
						URI = "http://concordia.ca/content/concordia/en/library"
					},
					new Service {
						Name = "Leonard and Bina Ellen Art Gallery",
						RoomNumber = "LB",
						URI = "http://ellengallery.concordia.ca"
					},
					new Service {
						Name = "Birks Student Service Centre",
						RoomNumber = "LB-185",
						URI = "http://concordia.ca/content/concordia/en/library"
					},
					new Service {
						Name = "Office of the Registrar",
						RoomNumber = "LB-700",
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
				Campus = "SGW",
				Address = "2135 Mackay",
				Position = new Position (45.49735382, -73.57977659),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "}eutGn`b`MRTFMUUEL"
			};
			BuildingList.Add (M.Code, M);

			Building MB = new Building {
				Code = "MB",
				Name = "John Molson School of Business",
				Campus = "SGW",
				Address = "1450 Guy",
				Position = new Position (45.49527019, -73.57901216),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "_xttGj}a`MJN[p@E?MMCBm@s@hAyCF?^b@EHBD?AF?LLo@tA",
				Services = new List<Service> {
					new Service {
						Name = "Career Management Services",
						RoomNumber = "MB-4.301",
						URI = "http://concordia.ca/content/concordia/en/jmsb/services/career"
					},
					new Service {
						Name = "John Molson Executive Centre",
						RoomNumber = "MB-11.115",
						URI = "http://concordia.ca/content/concordia/en/jmsb/programs/executive-centre"
					},

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
				Campus = "SGW",
				Address = "2130 Bishop",
				Position = new Position (45.49769458, -73.57930586),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ihutGl}a`M^^HQa@a@GR",
				Services = new List<Service> {
					new Service {
						Name = "ACUMAE",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#acumae"
					},
					new Service {
						Name = "SCOMM",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#scomm-sgw"
					},
					new Service {
						Name = "CUSSU",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cussu"
					},
					new Service {
						Name = "CUUSS-TS",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cuuss-ts"
					},
					new Service {
						Name = "CULEU",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#culeu"
					},
					new Service {
						Name = "CUPEU",
						RoomNumber = "MI",
						URI = "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cupeu"
					},
					new Service {
						Name = "CUCEPTFU",
						RoomNumber = "MI"
					}
				}
			};
			BuildingList.Add (MI.Code, MI);

			Building MU = new Building {
				Code = "MU",
				Name = "MU",
				Campus = "SGW",
				Address = "2170 Bishop",
				Position = new Position (45.49786379, -73.57961833),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "giutGh_b`M`@`@FMc@a@EL",
				Services = new List<Service> {
					new Service {
						Name = "Simone de Beauvoir Institute",
						RoomNumber = "MU",
						URI = "http://concordia.ca/content/concordia/en/artsci/sdbi"
					}
				}
			};
			BuildingList.Add (MU.Code, MU);

			Building P = new Building {
				Code = "P",
				Name = "P",
				Campus = "SGW",
				Address = "2020 Mackay",
				Position = new Position (45.49664738, -73.57920662),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "oautG||a`MFMRRGLSS"
			};
			BuildingList.Add (P.Code, P);

			Building PR = new Building {
				Code = "PR",
				Name = "PR",
				Campus = "SGW",
				Address = "2100 Mackay",
				Position = new Position (45.49690025, -73.57993349),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "mcutGdab`MFQd@d@GPe@e@",
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
				Campus = "SGW",
				Address = "2010 Mackay",
				Position = new Position (45.49661118, -73.57913285),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "gautGl|a`MDKRTEJSU",
				Services = new List<Service> {
					new Service {
						Name = "Ethnic Students' Association",
						RoomNumber = "Q",
						URI = "http://www.ieacconcordia.ca/about-us.html"
					}
				}
			};
			BuildingList.Add (Q.Code, Q);

			Building R = new Building {
				Code = "R",
				Name = "R",
				Campus = "SGW",
				Address = "2050 Mackay",
				Position = new Position (45.49675877, -73.57944332),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ebutGn~a`MHONPGNQQ",
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
				Campus = "SGW",
				Address = "2040 Mackay",
				Position = new Position (45.49670284, -73.57937157),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "{autG~}a`MFQXZGNYY",
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
				Campus = "SGW",
				Address = "2145 Mackay",
				Position = new Position (45.49740176, -73.57986242),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ifutG|`b`MVVFOSQ?@ECEJ"
			};
			BuildingList.Add (S.Code, S);

			Building T = new Building {
				Code = "T",
				Name = "T",
				Campus = "SGW",
				Address = "2030 Mackay",
				Position = new Position (45.4966784, -73.57928306),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "qautGn}a`MDKNLELOO",
				Services = new List<Service> {
					new Service {
						Name = "Graduate Students Association",
						RoomNumber = "T",
						URI = "http://gsaconcordia.ca"
					}
				}
			};
			BuildingList.Add (T.Code, T);

			Building V = new Building {
				Code = "V",
				Name = "V",
				Campus = "SGW",
				Address = "2110 Mackay",
				Position = new Position (45.49702151, -73.57995696),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ycutGrab`MTTFQQQ??CAGN"
			};
			BuildingList.Add (V.Code, V);

			Building X = new Building {
				Code = "X",
				Name = "X",
				Campus = "SGW",
				Address = "2080 Mackay",
				Position = new Position (45.49687957, -73.57969075),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "{butG``b`MFMNNGLOO",
				Services = new List<Service> {
					new Service {
						Name = "Concordia International",
						RoomNumber = "X",
						URI = "http://concordia.ca/content/concordia/en/offices/ci.html"
					}
				}
			};
			BuildingList.Add (X.Code, X);

			Building Z = new Building {
				Code = "Z",
				Name = "Z",
				Campus = "SGW",
				Address = "2090 Mackay",
				Position = new Position (45.49691717, -73.57978061),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ecutGr`b`MFQPPGPQQ",
				Services = new List<Service> {
					new Service {
						Name = "Multi-Faith Chaplaincy",
						RoomNumber = "Z",
						URI = "http://concordia.ca/content/concordia/en/offices/chaplaincy.html"
					},
					new Service {
						Name = "Sustainable Concordia",
						RoomNumber = "Z-204.1",
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
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.4580762, -73.63981247),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "gqmtGxwm`MLJBMVPADB@CJDBBKBB@EXTCLJHTy@KIGPWS@AMIA@[UFQKGUv@??",
				Services = new List<Service> {
					new Service {
						Name = "Loyola International College",
						RoomNumber = "AD-502",
						URI = "http://loyc.concordia.ca"
					},
					new Service {
						Name = "Centre for Teaching & Learning",
						RoomNumber = "AD",
						URI = "http://concordia.ca/content/concordia/en/offices/ctl.html"
					},
					new Service {
						Name = "Provost and Vice-President",
						RoomNumber = "AD",
						URI = "http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"
					},
					new Service {
						Name = "Dean of Students",
						RoomNumber = "AD-121",
						URI = "http://concordia.ca/content/concordia/en/offices/dean-students.html"
					},
					new Service {
						Name = "Concordia Multi-Faith Chaplaincy",
						RoomNumber = "AD-103.10",
						URI = "http://concordia.ca/content/concordia/en/offices/chaplaincy.html"
					},
					new Service {
						Name = "Advocacy & Support Services",
						RoomNumber = "AD",
						URI = "http://concordia.ca/content/concordia/en/offices/advocacy.html"
					},
					new Service {
						Name = "Access Centre for Students with Disabilities",
						RoomNumber = "AD-130",
						URI = "http://concordia.ca/content/concordia/en/offices/acsd.html"
					},
					new Service {
						Name = "Counselling and Development",
						RoomNumber = "AD-103",
						URI = "http://concordia.ca/content/concordia/en/offices/cdev.html"
					},
					new Service {
						Name = "Health Services",
						RoomNumber = "AD-131",
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
				Campus = "LOY",
				Address = "3502 Belmore",
				Position = new Position (45.45984844, -73.63939941),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "c{mtG`um`M@EB@AD??CA"
			};
			BuildingList.Add (BB.Code, BB);

			Building BH = new Building {
				Code = "BH",
				Name = "BH",
				Campus = "LOY",
				Address = "3500 Belmore",
				Position = new Position (45.45971675, -73.63914192),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "{zmtGzsm`MJ]RNK\\SO??",
				Services = new List<Service> {
					new Service {
						Name = "CPE Les P'tits Profs Daycare",
						RoomNumber = "BH",
						URI = "http://lesptitsprofs.wordpress.com"
					}
				}
			};
			BuildingList.Add (BH.Code, BH);

			Building CC = new Building {
				Code = "CC",
				Name = "Central",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45823236, -73.64041328),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "irmtGn}m`M^Vf@kB??Po@[WSn@??i@jB",
				Services = new List<Service> {
					new Service {
						Name = "Concordia Student Union",
						RoomNumber = "CC-116",
						URI = "http://csu.concordia.ca"
					}
				}
			};
			BuildingList.Add (CC.Code, CC);

			Building CJ = new Building {
				Code = "CJ",
				Name = "Communication and Journalism",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45745911, -73.64041328),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "ikmtGv}m`MBMDBRu@o@g@HYJE@@LI@MAKCICEGEGCI@GBC@AB?@BV@A?RIXYSSn@GEMd@`@ZFMLJBEd@^??@??@",
				Services = new List<Service> {
					new Service {
						Name = "Campus Retail Stores",
						RoomNumber = "CJ",
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
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45792569, -73.63487184),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "comtGjxl`MDc@J@A`@O?"
			};
			BuildingList.Add (DO.Code, DO);

			Building FC = new Building {
				Code = "FC",
				Name = "F.C. Smith",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45847506, -73.63938332),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "ssmtGtvm`M?IBK?ADOA?Tw@AAA??C?A@A?A?A@A@?@?^TCF@@ADA?K`@DBELECIVAAELEBQM",
				Services = new List<Service> {
					new Service {
						Name = "F.C. Smith Auditorium",
						RoomNumber = "FC",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/fc-smith-auditorium"
					},
					new Service {
						Name = "Cazalet Theater",
						RoomNumber = "FC",
						URI = "http://concordia.ca/content/concordia/en/arts/venues/cazalet"
					}
				}
			};
			BuildingList.Add (FC.Code, FC);

			Building GE = new Building {
				Code = "GE",
				Name = "Centre for Structural and Functional Genomics",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45690973, -73.64037037),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "gjmtGv|m`M`@yAh@b@Sr@DBEJCAGT",
				Services = new List<Service> {
					new Service {
						Name = "Genomic Centre",
						RoomNumber = "GE",
						URI = "http://concordia.ca/content/concordia/en/research/genomics"
					}
				}
			};
			BuildingList.Add (GE.Code, GE);

			Building HA = new Building {
				Code = "HA",
				Name = "Hingston Wing A",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45944395, -73.64125818),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = true,
				ShapeCoords = "}ymtGran`MBKAAZeA@@BKBB@?d@\\?@BBCH@BYdAAAEHo@e@??",
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						RoomNumber = "HA",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (HA.Code, HA);


			Building HB = new Building {
				Code = "HB",
				Name = "Hingston Wing B",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45915987, -73.64200652),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = true,
				ShapeCoords = "eymtGnen`M^sAEEBEDB@CpA~@CJ@@?B@@YdACA?@CAEHe@_@BIEC@Aa@YCJ",
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						RoomNumber = "HB",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					},
					new Service {
						Name = "CUFA",
						RoomNumber = "HB",
						URI = "http://www.cufa.net"
					}
				}
			};
			BuildingList.Add (HB.Code, HB);

			Building HC = new Building {
				Code = "HC",
				Name = "Hingston Wing C",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45965278, -73.64208162),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "i{mtGren`MLc@TPBE`@XSp@a@[@EUQ",
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						RoomNumber = "HC",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (HC.Code, HC);

			Building JR = new Building {
				Code = "JR",
				Name = "Jesuit Residence",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45846, -73.64318132),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "{rmtGbnn`MDMCCFS@@FMHFABB@@ELJELBBGPCAELKIA@MI",
				Services = new List<Service> {
					new Service {
						Name = "Student Residence",
						RoomNumber = "JR",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"
					}
				}
			};
			BuildingList.Add (JR.Code, JR);

			Building PC = new Building {
				Code = "PC",
				Name = "PERFORM Center",
				Campus = "LOY",
				Address = "7200 Sherbrooke St. W.",
				Position = new Position (45.457048958237415, -73.6374306678772),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = true,
				HasParkingLot = true,
				HasAccessibility = true,
				ShapeCoords = "qgmtG|fm`M{@vCk@g@r@yC",
				Services = new List<Service> {
					new Service {
						Name = "PERFORM Centre",
						RoomNumber = "PC",
						URI = "http://concordia.ca/content/concordia/en/research/perform.html"
					}
				}
			};
			BuildingList.Add (PC.Code, PC);

			Building PS = new Building {
				Code = "PS",
				Name = "Physical Services",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45962644, -73.63981247),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "s{mtGjym`Mv@qCFDHYx@j@IZMIGTDBg@bBCCMb@]UBKUS",
				Services = new List<Service> {
					new Service {
						Name = "Environmental Health and Safety",
						RoomNumber = "PS",
						URI = "http://concordia.ca/content/concordia/en/campus-life/safety"
					},
					new Service {
						Name = "Facilities Management",
						RoomNumber = "PS",
						URI = "http://concordia.ca/content/concordia/en/offices/facilities"
					}
				}
			};
			BuildingList.Add (PS.Code, PS);

			Building PT = new Building {
				Code = "PT",
				Name = "Oscar Peterson Concert Hall",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45933295, -73.63897026),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "yxmtGpsm`MDM@?ZeAAA@C\\V@EPLIVGGCJECUv@GGADYS",
				Services = new List<Service> {
					new Service {
						Name = "Concert Hall",
						RoomNumber = "PT",
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
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45886638, -73.64049911),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "yvmtGz{m`MBK@?Ro@PLABFD@Ch@^?@HF[hA}@m@CHQMHYA?",
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
				Campus = "LOY",
				Address = "7200 Sherbrooke W.",
				Position = new Position (45.45670278, -73.63763452),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "ogmtG|fm`M`Ar@{@zCSOIVLJELDDEPECIZ[S?BEADACEWQV{@FBDQBGMIz@yC",
				Services = new List<Service> {
					new Service {
						Name = "Ed Meagher Arena",
						RoomNumber = "RA",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Gymnasium",
						RoomNumber = "RA",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Indoor running track",
						RoomNumber = "RA",
						URI = "http://athletics.concordia.ca/campus/facilities.shtml"
					},
					new Service {
						Name = "Café",
						RoomNumber = "RA"
					}
				}
			};
			BuildingList.Add (RA.Code, RA);

			Building RF = new Building {
				Code = "RF",
				Name = "Loyola Jesuit Hall and Conference Centre",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45846753, -73.64106774),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "csmtG|`n`MDMEE@CGCDOOKHWPLJa@DB@IJHAHFFGPCACLTNIZMIEPHFCJ",
				Services = new List<Service> {
					new Service {
						Name = "Loyola Jesuit Hall and Conference Centre",
						RoomNumber = "RF-120",
						URI = "http://concordia.ca/content/concordia/en/hospitality/hospitality-venues/loyola-jesuit-hall-conference-centre.html"
					},
					new Service {
						Name = "Conference services",
						RoomNumber = "RF",
						URI = "http://concordia.ca/content/concordia/en/hospitality.html"
					}
				}
			};
			BuildingList.Add (RF.Code, RF);

			Building SC = new Building {
				Code = "SC",
				Name = "Student Center",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45910719, -73.63915265),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "swmtGvtm`MFSCCPm@FFBIHHAFRNUv@WQCHKI",
				Services = new List<Service> {
					new Service {
						Name = "Campus Centre",
						RoomNumber = "SC"
					},
					new Service {
						Name = "Food Services",
						RoomNumber = "SC",
						URI = "http://concordia.ca/content/concordia/en/campus-life/residences/admissions/meal-plan.html"
					},
					new Service {
						Name = "Cafeteria",
						RoomNumber = "SC"
					},
					new Service {
						Name = "Café",
						RoomNumber = "SC"
					}
				}
			};
			BuildingList.Add (SC.Code, SC);

			Building SH = new Building {
				Code = "SH",
				Name = "Solar House",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45929909, -73.64247322),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "ewmtGpgn`MCz@UA@{@"
			};
			BuildingList.Add (SH.Code, SH);

			Building SI = new Building {
				Code = "SI",
				Name = "Saint-Ignatius of Loyola Church",
				Campus = "LOY",
				Address = "4455 BroadWay",
				Position = new Position (45.45779776, -73.64239812),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "mpmtG|hn`MHYB@J]CEJ]DABKLFBKDB?DJHADHHADHF?BFFCNNJIZQMA@GEABIGABKGEP@BGXg@_@"
			};
			BuildingList.Add (SI.Code, SI);

			Building SP = new Building {
				Code = "SP",
				Name = "Richard J. Renaud Science Complex",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45777894, -73.64159614),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = true,
				ShapeCoords = "ypmtGzbn`MBEYSFUNJDOOKHYRPBGHHHYPLGTJHFM|@p@Rs@@?`@uAHFJ[^XIVDBCJCCY~@@@CH?@AFCCo@tBUQITMM?CaAs@AFg@_@",
				Services = new List<Service> {
					new Service {
						Name = "Science College",
						RoomNumber = "SP",
						URI = "http://concordia.ca/content/concordia/en/artsci/science-college"
					},
					new Service {
						Name = "Technical Centre",
						RoomNumber = "SP",
						URI = "http://concordia.ca/content/concordia/en/artsci/services/technical-centre.html"
					},
					new Service {
						Name = "Animal Care Facilities",
						RoomNumber = "SP"
					},
					new Service {
						Name = "Security Office",
						RoomNumber = "SP"
					},
					new Service {
						Name = "Café",
						RoomNumber = "SP"
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
				Campus = "LOY",
				Address = "7079 Terrebonne",
				Position = new Position (45.45999895, -73.64088535),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = true,
				HasAccessibility = false,
				ShapeCoords = "o|mtGt~m`MFSTNGRUO"
			};
			BuildingList.Add (TA.Code, TA);

			Building VE = new Building {
				Code = "VE",
				Name = "Vanier Extension",
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45880618, -73.63862693),
				HasAtm = false,
				HasBikeRack = true,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "evmtGlqm`Mf@kBHF@ADBA@RN@ABBCHJHg@bBAAADIEADWS@ECA@GII",
				Services = new List<Service> {
					new Service {
						Name = "Library",
						RoomNumber = "VE",
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
				Campus = "LOY",
				Address = "7141 Sherbrooke W.",
				Position = new Position (45.45904699, -73.6383909),
				HasAtm = false,
				HasBikeRack = false,
				HasInfoKiosk = false,
				HasParkingLot = false,
				HasAccessibility = false,
				ShapeCoords = "uwmtGtpm`M\\V@GLHl@uBCC@IECBIk@a@@ECAEJ@@ABA@Of@RLABC?Ux@?@CF??EN",
				Services = new List<Service> {
					new Service {
						Name = "Library",
						RoomNumber = "VL",
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

		public int GetBuildingIndex (Building building)
		{
			int counter = 0;
			foreach (Building b in BuildingList.Values) {
				if (b == building)
					return counter;
				++counter;
			}
			return -1;
		}

	}

}