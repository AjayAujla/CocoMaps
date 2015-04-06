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
					new Service("CPE Les P'tits Profs Daycare","B","http://lesptitsprofs.wordpress.com")
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
					new Department ("School of Community and Public Affairs","http://scpa-eapc.concordia.ca/en")
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
					new Service ("The Centre for Continuing Education","CL","http://cce.concordia.ca")
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
					new Department ("Theological Studies","http://concordia.ca/content/concordia/en/artsci/theology.html")
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
					new Service ("Translation Services","EN","http://web2.concordia.ca/translation"),
					new Service ("Career and Planning Services","EN","http://concordia.ca/content/concordia/en/students/careers/planning.html")
				},
				Departments = new List<Department> {
					new Department ("Education","http://doe.concordia.ca")
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
					new Service ("LeGym","EV-S2.206","http://concordia.ca/content/concordia/en/campus-life/recreation/facilities/le-gym.html"),
					new Service ("FOFA Gallery","EV-2.781","http://concordia.ca/content/concordia/en/finearts/facilities/fofa-gallery.html"),
					new Service ("Performing Arts Facilities","EV-2.781","http://concordia.ca/content/concordia/en/finearts/facilities/performing-arts")
				},
				Departments = new List<Department> {
					new Department ("Engineering and Computer Science","http://concordia.ca/content/concordia/en/encs.html"),
					new Department ("Building, Civil and Environmental Engineering","http://www.bcee.concordia.ca"),
					new Department ("Electrical and Computer Engineering","http://www.ece.concordia.ca"),
					new	Department ("Computer Science and Software Engineering","http://www.cs.concordia.ca"),
					new	Department ("Mechanical and Industrial Engineering","http://www.me.concordia.ca"),
					new Department ("Design and Computation Arts","http://design.concordia.ca"),
					new Department ("Faculty of Fine Arts","http://concordia.ca/content/concordia/en/finearts.html"),
					new Department ("Studio Arts","http://concordia.ca/content/concordia/en/finearts/studio-arts.html"),
					new Department ("Art Education","http://art-education.concordia.ca"),
					new Department ("Art History","http://concordia.ca/content/concordia/en/finearts/art-history"),
					new Department ("Comtemporary Dance","http://dance.concordia.ca/en"),
					new Department ("Recreation and Athletics","http://athletics.concordia.ca/"),
					new Department ("Zero Energy Building Studies","http://concordia.ca/content/concordia/en/research/zero-energy-building")				
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
					new Department ("Religion", "http://religion.concordia.ca")
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
					new Service ("School of Extended Learning","FB-131.1","http://www.concordia.ca/extended-learning"),
					new Service ("Student Transition Centre","FB-117.3","http://concordia.ca/content/concordia/en/extended-learning/advising.html"),
					new Service ("Centre for Teaching and Learning","FB-620","http://concordia.ca/content/concordia/en/extended-learning/advising.html"),
					new Service ("Human Resources","FB-1130","http://www.concordia.ca/hr")
				},
				Departments = new List<Department> {
					new Department ("Cinema","http://cinema.concordia.ca")
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
					new Service ("Classrooms","FG", "")
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
					new Service ("Office of the President","GM","http://concordia.ca/content/concordia/en/about/administration-governance/president.html"),
					new Service ("Office of the VP, Institutional Relations and Secretary General","GM-801","http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-development-external-relations-secretary-general.html"),
					new Service ("Office of the Provost","GM-806.00","http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"),
					new Service ("Office of Rights and Responsibilities", "GM","http://concordia.ca/content/concordia/en/students/rights.html"),
					new Service ("Ombuds Office","GM-1005","http://concordia.ca/content/concordia/en/campus-life/ombuds.html"),
					new Service ("Institute for Co-operative Education","GM-430","http://concordia.ca/content/concordia/en/academics/co-op.html"),
					new Service ("Office of the VP, Research & Graduate Studies","GM-900.00","http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"),
					new Service ("Office of the Chief Communications Officer","GM-900.00","http://concordia.ca/content/concordia/en/about/administration-governance/office-vp-research-graduate-studies.html"),
					new Service ("Financial Aid & Awards Office","GM-230.00","http://concordia.ca/content/concordia/en/offices/faao.html"),
					new Service ("Health Services","GM-200","http://concordia.ca/content/concordia/en/students/health.html"),
					new Service ("Environmental Health and Safety","GM","http://concordia.ca/content/concordia/en/campus-life/safety"),
					new Service ("Facilities Management","GM-1100","http://concordia.ca/content/concordia/en/offices/facilities"),
					new Service ("Music","GM-500.01","http://concordia.ca/content/concordia/en/finearts/music"),
					new Service ("Theatre","GM-500.01","http://concordia.ca/content/concordia/en/finearts/theatre"),
					new Service ("Contemporary Dance","GM-500.01","http://concordia.ca/content/concordia/en/finearts/dance"),
					new Service ("Graduate Studies","GM-930.01","http://concordia.ca/content/concordia/en/offices/sgs.html")
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
					new Service ("Dean of Students","H-637","http://concordia.ca/content/concordia/en/offices/dean-students"),
					new Service ("Aboriginal Student Resource Center","H-641","http://concordia.ca/content/concordia/en/offices/asrc"),
					new Service ("International Students Office","H-653","http://concordia.ca/content/concordia/en/offices/iso"),
					new Service ("IT Services","H-925","http://concordia.ca/content/concordia/en/it"),
					new Service ("Security Department","H-118","http://concordia.ca/content/concordia/en/campus-life/security"),
					new Service ("Counselling and Development","H-440","http://concordia.ca/content/concordia/en/offices/cdev.html"),
					new Service ("Archives","H-1015","http://archives.concordia.ca/"),
					new Service ("Access Centre for Students with Disabilities","H-580","http://concordia.ca/content/concordia/en/offices/acsd"),
					new Service ("Concordia Student Union","H-711","http://csu.concordia.ca"),
					new Service ("Computer Store","H","http://retail.concordia.ca/ccs/"),
					new Service ("D. B. Clarke Theatre\\","H","http://concordia.ca/content/concordia/en/arts/venues/db-clarke-theatre")
				},

				Departments = new List<Department> {
					new Department ("Classics, Modern Languages and Linguistics","http://concordia.ca/content/concordia/en/artsci/cmll"),
					new Department ("Geography", "Planning and Environment"),
					new Department ("Political Science, Sociology and Anthropology, Economics","http://concordia.ca/content/concordia/en/artsci/academics/departments.html")
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
					new Service ("Theological Studies", "K","http://concordia.ca/content/concordia/en/artsci/theology.html")
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
					new Service ("J.A. DeSève Cinema","LB-125","http://concordia.ca/content/concordia/en/it/services/cinemas"),
					new Service ("Birks Student Service Centre","LB-185","http://concordia.ca/content/concordia/en/students/birks"),
					new Service ("Bookstore","LB-103","http://retail.concordia.ca/"),
					new Service ("Computer Store","LB-103","http://retail.concordia.ca/ccs/"),
					new Service ("Birks Student Service Centre","LB-185","http://concordia.ca/content/concordia/en/students/birks"),
					new Service ("Campus Corner","LB-119", ""),
					new Service ( "Digital Store","LB-115","http://retail.concordia.ca"),
					new Service ("DPrint Administration","LB-018" , ""),
					new Service ("Welcome Centre","LB-187","http://concordia.ca/content/concordia/en/students/birks/welcome-centre"),
					new Service ("R. Howard Webster Library","LB","http://concordia.ca/content/concordia/en/library"),
					new Service ("Leonard and Bina Ellen Art Gallery","LB","http://ellengallery.concordia.ca"),
					new Service ("Birks Student Service Centre","LB-185","http://concordia.ca/content/concordia/en/library"),
					new Service ("Office of the Registrar","LB-700","http://concordia.ca/content/concordia/en/offices/registrar")
				},
				Departments = new List<Department> {
					new Department ("English","http://english.concordia.ca"),
					new Department ("History","http://history.concordia.ca"),
					new Department ("Etudes francaises","http://concordia.ca/content/concordia/en/artsci/francais"),
					new Department ("Mathematics and Statistics","http://www.mathstat.concordia.ca"),
					new Department ("Education","http://doe.concordia.ca/"),
					new Department ("Centre for Interdisciplinary Studies in Society and Culture (CISSC)","http://concordia.ca/content/concordia/en/artsci/cissc.html")
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
					new Service ("Career Management Services","MB-4.301","http://concordia.ca/content/concordia/en/jmsb/services/career"),
					new Service ("John Molson Executive Centre","MB-11.115","http://concordia.ca/content/concordia/en/jmsb/programs/executive-centre"),

				},
				Departments = new List<Department> {
					new Department ("Supply Chain & Business Technology Management","http://concordia.ca/content/concordia/en/jmsb/about/departments/supply-chain-business-technology-management"),
					new Department ("Finance","http://concordia.ca/content/concordia/en/jmsb/about/departments/finance"),
					new Department ("Management","http://concordia.ca/content/concordia/en/jmsb/about/departments/management"),
					new Department ("Marketing","http://concordia.ca/content/concordia/en/jmsb/about/departments/marketing"),
					new Department ("Goodman Institute of Investment Management","http://concordia.ca/content/concordia/en/jmsb/programs/graduate/mba-cfa"),
					new Department ("Executive MBA Program","http://concordia.ca/content/concordia/en/jmsb/programs/graduate/emba"),
					new Department ("Music","http://music.concordia.ca"),
					new Department ("Theatre","http://theatre.concordia.ca")
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
					new Service ("ACUMAE","MI","http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#acumae"),
					new Service ("SCOMM","MI", "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#scomm-sgw"),
					new Service ("CUSSU","MI","http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cussu"),
					new Service ("CUUSS-TS","MI", "http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cuuss-ts"),
					new Service ("CULEU","MI","http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#culeu"),
					new Service ("CUPEU","MI","http://www.concordia.ca/hr/dept/employee-labour-relations/labour-agreements.html#cupeu"),
					new Service ("CUCEPTFU","MI" , "" )
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
					new Service ("Simone de Beauvoir Institute","MU","http://concordia.ca/content/concordia/en/artsci/sdbi")
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
					new Department ("Philosophy","http://concordia.ca/content/concordia/en/artsci/philosophy"),
					new Department ("Liberal Arts College","http://liberalartscollege.concordia.ca")
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
					new Service ("Ethnic Students' Association","Q", "http://www.ieacconcordia.ca/about-us.html")
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
					new Department ("Religion","http://religion.concordia.ca")
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
					new Department ("Liberal Arts College","http://concordia.ca/content/concordia/en/artsci/liberal-arts-college")
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
					new Service ("Graduate Students Association","T","http://gsaconcordia.ca")
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
					new Service ("Concordia International","X","http://concordia.ca/content/concordia/en/offices/ci.html")
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
					new Service ("Multi-Faith Chaplaincy","Z","http://concordia.ca/content/concordia/en/offices/chaplaincy.html"),
					new Service ("Sustainable Concordia","Z-204.1","http://sustainableconcordia.ca")
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
					new Service ("Loyola International College","AD-502","http://loyc.concordia.ca"),
					new Service ("Centre for Teaching & Learning","AD","http://concordia.ca/content/concordia/en/offices/ctl.html"),
					new Service ("Provost and Vice-President","AD","http://concordia.ca/content/concordia/en/about/administration-governance/office-provost-vp-academic-affairs.html"),
					new Service ("Dean of Students","AD-121","http://concordia.ca/content/concordia/en/offices/dean-students.html"),
					new Service ( "Concordia Multi-Faith Chaplaincy","AD-103.10","http://concordia.ca/content/concordia/en/offices/chaplaincy.html"),
					new Service ("Advocacy & Support Services","AD","http://concordia.ca/content/concordia/en/offices/advocacy.html"),
					new Service ("Access Centre for Students with Disabilities","AD-130","http://concordia.ca/content/concordia/en/offices/acsd.html"),
					new Service ("Counselling and Development","AD-103","http://concordia.ca/content/concordia/en/offices/cdev.html"),
					new Service ("Health Services","AD-131","http://concordia.ca/content/concordia/en/students/health.html")
				},
				Departments = new List<Department> {
					new Department ("Faculty of Arts & Science","http://concordia.ca/content/concordia/en/artsci.html")
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
					new Service ("CPE Les P'tits Profs Daycare","BH","http://lesptitsprofs.wordpress.com")
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
					new Service ("Concordia Student Union","CC-116","http://csu.concordia.ca")
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
					new Service ("Campus Retail Stores","CJ","http://retail.concordia.ca"),
				},
				Departments = new List<Department> {
					new Department ("Communication Studies","http://coms.concordia.ca"),
					new Department ("Journalism","http://journalism.concordia.ca")
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
					new Service ("F.C. Smith Auditorium","FC","http://concordia.ca/content/concordia/en/arts/venues/fc-smith-auditorium"),
					new Service ("Cazalet Theater","FC","http://concordia.ca/content/concordia/en/arts/venues/cazalet")
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
					new Service ( "Genomic Centre","GE","http://concordia.ca/content/concordia/en/research/genomics")
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
					new Service ( "Student Residence","HA","http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html")
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
					new Service ("Student Residence","HB","http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html"),
					new Service ("CUFA","HB","http://www.cufa.net")
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
					new Service ("Student Residence","HC","http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html")
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
					new Service ("Student Residence","JR","http://concordia.ca/content/concordia/en/campus-life/residences/hingston-hall.html")
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
					new Service ("PERFORM Centre","PC","http://concordia.ca/content/concordia/en/research/perform.html")
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
					new Service ("Environmental Health and Safety","PS","http://concordia.ca/content/concordia/en/campus-life/safety"),
					new Service ("Facilities Management","PS","http://concordia.ca/content/concordia/en/offices/facilities")
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
					new Service ("Concert Hall","PT","http://concordia.ca/content/concordia/en/arts/venues/oscar-peterson.html")
				},
				Departments = new List<Department> {
					new Department ("Oscar Peterson Concert Hall","http://concordia.ca/content/concordia/en/arts/venues/oscar-peterson.html")
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
					new Department ("Psychology","http://psychology.concordia.ca")
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
					new Service ("Ed Meagher Arena","RA","http://athletics.concordia.ca/campus/facilities.shtml"),
					new Service ("Gymnasium","RA","http://athletics.concordia.ca/campus/facilities.shtml"),
					new Service ("Indoor running track","RA","http://athletics.concordia.ca/campus/facilities.shtml"),
					new Service ("Café","RA" ,"")
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
					new Service ( "Loyola Jesuit Hall and Conference Centre","RF-120", "http://concordia.ca/content/concordia/en/hospitality/hospitality-venues/loyola-jesuit-hall-conference-centre.html"),
					new Service ( "Conference services","RF","http://concordia.ca/content/concordia/en/hospitality.html")
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
					new Service ("Campus Centre","SC", ""),
					new Service ("Food Services","SC","http://concordia.ca/content/concordia/en/campus-life/residences/admissions/meal-plan.html"),
					new Service ("Cafeteria","SC", ""),
					new Service ("Café","SC", "")
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
					new Service ("Science College","SP","http://concordia.ca/content/concordia/en/artsci/science-college"),
					new Service ("Technical Centre","SP","http://concordia.ca/content/concordia/en/artsci/services/technical-centre.html"),
					new Service ( "Animal Care Facilities","SP", ""),
					new Service ( "Security Office","SP", ""),
					new Service ("Café","SP", "")
				},
				Departments = new List<Department> {
					new Department ("Psychology","http://psychology.concordia.ca"),
					new Department ("Physics","http://concordia.ca/content/concordia/en/artsci/physics"),
					new Department ("Biology","http://concordia.ca/content/concordia/en/artsci/biology"),
					new Department ( "Chemistry and Biochemistry","http://concordia.ca/content/concordia/en/artsci/chemistry"),
					new Department ("Exercise Science","http://concordia.ca/content/concordia/en/artsci/exercise-science"),
					new Department ("Centre for Biological Applications of Mass Spectrometry","http://concordia.ca/content/concordia/en/research/mass-spec"),
					new Department ("Centre for NanoScience Research","http://concordia.ca/content/concordia/en/research/nanoscience"),
					new Department ( "Center for Studies in Behavioral Neurobiology","http://concordia.ca/content/concordia/en/research/neuroscience")
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
					new Service ( "Library", "VE", "http://library.concordia.ca/index.php")
				},
				Departments = new List<Department> {
					new Department ("Applied Human Sciences", "http://ahsc.concordia.ca")
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
					new Service ("Library","VL","http://concordia.ca/content/concordia/en/library")
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