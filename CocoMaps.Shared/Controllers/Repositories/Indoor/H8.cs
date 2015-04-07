using Dijkstra;
using System;

namespace CocoMaps.Shared
{
	public class H
	{

		static H instance;

		public static H getInstance {
			get {
				if (instance == null)
					instance = new H ();
				return instance;
			}
		}

		public Graph graph {
			get;
			internal set;
		}

		public H ()
		{

			Console.WriteLine ("CHECKPOINT 0");
			graph = new Graph ();
			Console.WriteLine ("CHECKPOINT 1");
			graph.AddNode ("801", 45.49734395, -73.57855484);
			graph.AddNode ("803", 45.49729413, -73.57859373);
			graph.AddNode ("805", 45.4972396, -73.57864469);
			graph.AddNode ("807", 45.49718226, -73.57870102);
			graph.AddNode ("806", 45.49717474, -73.57881501);
			graph.AddNode ("806_807_811", 45.49714184, -73.57874662);
			graph.AddNode ("811", 45.49708732, -73.57878819);
			graph.AddNode ("813", 45.49703749, -73.57883379);
			graph.AddNode ("815", 45.49699519, -73.57887067);
			graph.AddNode ("817", 45.49698485, -73.5788881);
			graph.AddNode ("819", 45.49699049, -73.57891224);
			graph.AddNode ("821", 45.49701963, -73.57897326);
			graph.AddNode ("823", 45.49704172, -73.57902322);
			graph.AddNode ("820_1", 45.49705771, -73.57903797);
			graph.AddNode ("820_2", 45.49708779, -73.57911609);
			graph.AddNode ("825", 45.49709719, -73.57913319);
			graph.AddNode ("827", 45.49711834, -73.57918046);
			graph.AddNode ("829", 45.49716158, -73.57927166);
			graph.AddNode ("831", 45.49719824, -73.57934073);
			graph.AddNode ("832", 45.49730212, -73.57923612);
			graph.AddNode ("833", 45.49721845, -73.57931156);
			graph.AddNode ("835", 45.49725464, -73.57927904);
			graph.AddNode ("837", 45.49730212, -73.57923612);
			graph.AddNode ("837_838_841", 45.49735476, -73.57918583);
			graph.AddNode ("838", 45.49732562, -73.57911609);
			graph.AddNode ("841", 45.49740223, -73.57913688);
			graph.AddNode ("843", 45.4974544, -73.57908793);
			graph.AddNode ("845", 45.49750516, -73.579043);
			graph.AddNode ("847", 45.49754088, -73.57900947);
			graph.AddNode ("849", 45.49755593, -73.57899372);
			graph.AddNode ("851", 45.4975611, -73.57899472);
			graph.AddNode ("852", 45.49750234, -73.5788824);
			graph.AddNode ("853", 45.49752208, -73.57891627);
			graph.AddNode ("854", 45.4974967, -73.57886363);
			graph.AddNode ("855", 45.49748025, -73.57882842);
			graph.AddNode ("857", 45.49744453, -73.57875668);
			graph.AddNode ("859", 45.4974121, -73.57868828);
			graph.AddNode ("860", 45.49736322, -73.57873254);
			graph.AddNode ("861", 45.49739001, -73.57863531);
			graph.AddNode ("862", 45.49730729, -73.57878819);
			graph.AddNode ("863", 45.49735805, -73.57857294);
			graph.AddNode ("865", 45.49735335, -73.57855819);
			graph.AddNode ("867", 45.49734959, -73.57854344);
			graph.AddNode ("806_838_862", 45.49721046, -73.57888877);

			Console.WriteLine ("CHECKPOINT 2");

			graph.AddConnection ("801", "803");
			graph.AddConnection ("803", "805");
			graph.AddConnection ("805", "807");
			graph.AddConnection ("806", "806_807_811");
			graph.AddConnection ("807", "806_807_811");
			graph.AddConnection ("811", "806_807_811");
			graph.AddConnection ("811", "813");
			graph.AddConnection ("813", "815");
			graph.AddConnection ("815", "817");
			graph.AddConnection ("817", "819");
			graph.AddConnection ("819", "821");
			graph.AddConnection ("821", "823");
			graph.AddConnection ("820_1", "821");
			graph.AddConnection ("820_1", "823");
			graph.AddConnection ("820_1", "825");
			graph.AddConnection ("820_2", "823");
			graph.AddConnection ("820_2", "825");
			graph.AddConnection ("823", "825");
			graph.AddConnection ("825", "827");
			graph.AddConnection ("827", "829");
			graph.AddConnection ("829", "831");
			graph.AddConnection ("831", "833");
			graph.AddConnection ("832", "835");
			graph.AddConnection ("833", "835");
			graph.AddConnection ("835", "837");
			graph.AddConnection ("837", "837_838_841");
			graph.AddConnection ("838", "837_838_841");
			graph.AddConnection ("841", "837_838_841");
			graph.AddConnection ("841", "843");
			graph.AddConnection ("843", "845");
			graph.AddConnection ("845", "847");
			graph.AddConnection ("847", "849");
			graph.AddConnection ("849", "851");
			graph.AddConnection ("851", "853");
			graph.AddConnection ("852", "854");
			graph.AddConnection ("854", "855");
			graph.AddConnection ("855", "857");
			graph.AddConnection ("857", "859");
			graph.AddConnection ("859", "860");
			graph.AddConnection ("859", "861");
			graph.AddConnection ("860", "862");
			graph.AddConnection ("861", "863");
			graph.AddConnection ("863", "865");
			graph.AddConnection ("865", "867");
			graph.AddConnection ("867", "801");
			graph.AddConnection ("806", "806_838_862");
			graph.AddConnection ("838", "806_838_862");
			graph.AddConnection ("862", "806_838_862");

			Console.WriteLine ("CHECKPOINT 3");

		}
	}
}