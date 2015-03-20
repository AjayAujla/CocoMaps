using System.Collections.Generic;

namespace CocoMaps.Indoor
{
	public class Indoor_H
	{

		static Indoor_H instance;

		public static Indoor_H getInstance {
			get {
				if (instance == null)
					instance = new Indoor_H ();
				return instance;
			}
		}

		public List<Vertex> Vertices = new List<Vertex> ();
		public List<Edge> Edges = new List<Edge> ();

		Indoor_H ()
		{
			//Vertex _ = new Vertex ("801", 0000000, 0000000);

			// Create Vertex, Add Vertex, Edge it, Repeat

			Vertex _801 = new Vertex ("801", 45.49734395, -73.57855484);
			Vertices.Add (_801);
			Vertex _803 = new Vertex ("803", 45.49729413, -73.57859373);
			Vertices.Add (_803);
			Edges.Add (new Edge (_801, _803));

			Vertex _805 = new Vertex ("805", 45.4972396, -73.57864469);
			Vertices.Add (_805);
			Edges.Add (new Edge (_803, _805));

			Vertex _807 = new Vertex ("807", 45.49718226, -73.57870102);
			Vertices.Add (_807);
			Edges.Add (new Edge (_805, _807));

			Vertex _806_807_811_ = new Vertex ("806_807_811", 45.49714184, -73.57874662);
			Vertices.Add (_806_807_811_);
			Edges.Add (new Edge (_807, _806_807_811_));

			Vertex _806 = new Vertex ("806", 45.49717474, -73.57881501);
			Vertices.Add (_806);
			Edges.Add (new Edge (_806, _806_807_811_));

			Vertex _811 = new Vertex ("811", 45.49708732, -73.57878819);
			Vertices.Add (_811);
			Edges.Add (new Edge (_806_807_811_, _811));

			Vertex _813 = new Vertex ("813", 45.49703749, -73.57883379);
			Vertices.Add (_813);
			Edges.Add (new Edge (_811, _813));

			Vertex _815 = new Vertex ("815", 45.49698673, -73.57888877);
			Vertices.Add (_815);
			Edges.Add (new Edge (_813, _815));

			Vertex _817 = new Vertex ("817", 45.49698673, -73.57888877);
			Vertices.Add (_817);
			Edges.Add (new Edge (_815, _817));

			Vertex _819 = new Vertex ("819", 45.49698673, -73.57888877);
			Vertices.Add (_819);
			Edges.Add (new Edge (_817, _819));

			Vertex _821 = new Vertex ("821", 45.49701963, -73.57897326);
			Vertices.Add (_821);
			Edges.Add (new Edge (_819, _821));

			Vertex _823 = new Vertex ("823", 45.49704877, -73.57903562);
			Vertices.Add (_823);
			Edges.Add (new Edge (_821, _823));

			Vertex _820_1 = new Vertex ("820_1", 45.49704877, -73.57903562);
			Vertices.Add (_820_1);
			Edges.Add (new Edge (_820_1, _821));
			Edges.Add (new Edge (_820_1, _823));

			Vertex _820_2 = new Vertex ("820_2", 45.49708779, -73.57911609);
			Vertices.Add (_820_2);
			Edges.Add (new Edge (_820_2, _823));

			Vertex _825 = new Vertex ("825", 45.49708779, -73.57911609);
			Vertices.Add (_825);
			Edges.Add (new Edge (_820_1, _825));
			Edges.Add (new Edge (_820_2, _825));
			Edges.Add (new Edge (_823, _825));

			Vertex _827 = new Vertex ("827", 45.49711834, -73.57918046);
			Vertices.Add (_827);
			Edges.Add (new Edge (_825, _827));

			Vertex _829 = new Vertex ("829", 45.49716158, -73.57927166);
			Vertices.Add (_829);
			Edges.Add (new Edge (_827, _829));

			Vertex _831 = new Vertex ("831", 45.49719824, -73.57934073);
			Vertices.Add (_831);
			Edges.Add (new Edge (_829, _831));

			Vertex _833 = new Vertex ("833", 45.49719824, -73.57934073);
			Vertices.Add (_833);
			Edges.Add (new Edge (_831, _833));

			Vertex _835 = new Vertex ("835", 45.49725464, -73.57927904);
			Vertices.Add (_835);
			Edges.Add (new Edge (_833, _835));

			Vertex _832 = new Vertex ("832", 45.49730212, -73.57923612);
			Vertices.Add (_832);
			Edges.Add (new Edge (_832, _835));

			Vertex _837 = new Vertex ("837", 45.49730212, -73.57923612);
			Vertices.Add (_837);
			Edges.Add (new Edge (_835, _837));

			Vertex _837_838_841_ = new Vertex ("_837_838_841_", 45.49735476, -73.57918583);
			Vertices.Add (_837_838_841_);
			Edges.Add (new Edge (_837, _837_838_841_));

			Vertex _841 = new Vertex ("_841", 45.49740223, -73.57913688);
			Vertices.Add (_841);
			Edges.Add (new Edge (_837_838_841_, _841));

			Vertex _843 = new Vertex ("_843", 45.4974544, -73.57908793);
			Vertices.Add (_843);
			Edges.Add (new Edge (_841, _843));

			Vertex _845 = new Vertex ("_845", 45.49750516, -73.579043);
			Vertices.Add (_845);
			Edges.Add (new Edge (_843, _845));

			Vertex _847 = new Vertex ("_847", 45.49754088, -73.57900947);
			Vertices.Add (_847);
			Edges.Add (new Edge (_845, _847));

			Vertex _849 = new Vertex ("_849", 45.4975611, -73.57899472);
			Vertices.Add (_849);
			Edges.Add (new Edge (_847, _849));

			Vertex _851 = new Vertex ("_851", 45.4975611, -73.57899472);
			Vertices.Add (_851);
			Edges.Add (new Edge (_849, _851));

			Vertex _853 = new Vertex ("_853", 45.49752208, -73.57891627);
			Vertices.Add (_853);
			Edges.Add (new Edge (_851, _853));

			Vertex _852 = new Vertex ("_852", 45.49750046, -73.57887);
			Vertices.Add (_852);
			Edges.Add (new Edge (_853, _852));

			Vertex _854 = new Vertex ("_854", 45.49750046, -73.57887);
			Vertices.Add (_854);
			Edges.Add (new Edge (_852, _854));

			Vertex _855 = new Vertex ("_855", 45.49748025, -73.57882842);
			Vertices.Add (_855);
			Edges.Add (new Edge (_854, _855));

			Vertex _857 = new Vertex ("_857", 45.49744453, -73.57875668);
			Vertices.Add (_857);
			Edges.Add (new Edge (_855, _857));

			Vertex _859 = new Vertex ("_859", 45.4974121, -73.57868828);
			Vertices.Add (_859);
			Edges.Add (new Edge (_857, _859));

			Vertex _860 = new Vertex ("_860", 45.49736322, -73.57873254);
			Vertices.Add (_860);
			Edges.Add (new Edge (_859, _860));

			Vertex _862 = new Vertex ("_862", 45.49730729, -73.57878819);
			Vertices.Add (_862);
			Edges.Add (new Edge (_860, _862));

			Vertex _861 = new Vertex ("_861", 45.49739001, -73.57863531);
			Vertices.Add (_861);
			Edges.Add (new Edge (_859, _861));

			Vertex _863 = new Vertex ("_863", 45.49734395, -73.57855484);
			Vertices.Add (_863);
			Edges.Add (new Edge (_861, _863));

			Vertex _865 = new Vertex ("_865", 45.49734395, -73.57855484);
			Vertices.Add (_865);
			Edges.Add (new Edge (_863, _865));

			Vertex _867 = new Vertex ("_867", 45.49734395, -73.57855484);
			Vertices.Add (_867);
			Edges.Add (new Edge (_865, _867));



			Vertex _838 = new Vertex ("_838", 45.49732562, -73.57911609);
			Vertices.Add (_838);
			Edges.Add (new Edge (_837_838_841_, _838));


			Vertex _806_838_862_ = new Vertex ("_806_838_862_", 45.49721046, -73.57888877);
			Vertices.Add (_806_838_862_);
			Edges.Add (new Edge (_806, _806_838_862_));
			Edges.Add (new Edge (_838, _806_838_862_));
			Edges.Add (new Edge (_862, _806_838_862_));


		}





	}
}