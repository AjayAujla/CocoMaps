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

		public string BuildingCode {
			get;
			set;
		}

		public Dictionary<string, Vertex> Vertices = new Dictionary<string, Vertex> ();


		// Codes prefixing numbers:
		// r_ : room
		// bm/w_ : bathroom men or women
		// e_ : elevator
		// s_ : stairs (normal or escalator)
		// i_ : intersection

		Indoor_H ()
		{

			BuildingCode = "H";

			Vertex _801 = new Vertex ("801", 45.49734395, -73.57855484);
			Vertices.Add (_801.id, _801);

			Vertex _803 = new Vertex ("803", 45.49729413, -73.57859373);
			Vertices.Add (_803.id, _803);

			_801.AdjacentVertices.Add (_803);
			_803.AdjacentVertices.Add (_801);

			Vertex _805 = new Vertex ("805", 45.4972396, -73.57864469);
			Vertices.Add (_805.id, _805);

			_803.AdjacentVertices.Add (_805);
			_805.AdjacentVertices.Add (_803);

			Vertex _807 = new Vertex ("807", 45.49718226, -73.57870102);
			Vertices.Add (_807.id, _807);

			_805.AdjacentVertices.Add (_807);
			_807.AdjacentVertices.Add (_805);

			Vertex _806_807_811_ = new Vertex ("806_807_811", 45.49714184, -73.57874662);
			Vertices.Add (_806_807_811_.id, _806_807_811_);

			_807.AdjacentVertices.Add (_806_807_811_);
			_806_807_811_.AdjacentVertices.Add (_807);

			Vertex _806 = new Vertex ("806", 45.49717474, -73.57881501);
			Vertices.Add (_806.id, _806);

			_806_807_811_.AdjacentVertices.Add (_806);
			_806.AdjacentVertices.Add (_806_807_811_);

			Vertex _811 = new Vertex ("811", 45.49708732, -73.57878819);
			Vertices.Add (_811.id, _811);

			_806_807_811_.AdjacentVertices.Add (_811);
			_811.AdjacentVertices.Add (_806_807_811_);

			Vertex _813 = new Vertex ("813", 45.49703749, -73.57883379);
			Vertices.Add (_813.id, _813);

			_811.AdjacentVertices.Add (_813);
			_813.AdjacentVertices.Add (_811);

			Vertex _815 = new Vertex ("815", 45.49698673, -73.57888877);
			Vertices.Add (_815.id, _815);

			_813.AdjacentVertices.Add (_815);
			_815.AdjacentVertices.Add (_813);

			Vertex _817 = new Vertex ("817", 45.49698673, -73.57888877);
			Vertices.Add (_817.id, _817);

			_815.AdjacentVertices.Add (_817);
			_817.AdjacentVertices.Add (_815);

			Vertex _819 = new Vertex ("819", 45.49698673, -73.57888877);
			Vertices.Add (_819.id, _819);

			_817.AdjacentVertices.Add (_819);
			_819.AdjacentVertices.Add (_817);

			Vertex _821 = new Vertex ("821", 45.49701963, -73.57897326);
			Vertices.Add (_821.id, _821);

			_819.AdjacentVertices.Add (_821);
			_821.AdjacentVertices.Add (_819);

			Vertex _823 = new Vertex ("823", 45.49704877, -73.57903562);
			Vertices.Add (_823.id, _823);

			_821.AdjacentVertices.Add (_823);
			_823.AdjacentVertices.Add (_821);

			Vertex _820_1 = new Vertex ("820_1", 45.49704877, -73.57903562);
			Vertices.Add (_820_1.id, _820_1);

			_820_1.AdjacentVertices.Add (_821);
			_820_1.AdjacentVertices.Add (_823);
			_821.AdjacentVertices.Add (_820_1);
			_823.AdjacentVertices.Add (_820_1);

			Vertex _820_2 = new Vertex ("820_2", 45.49708779, -73.57911609);
			Vertices.Add (_820_2.id, _820_2);

			_820_2.AdjacentVertices.Add (_823);
			_823.AdjacentVertices.Add (_820_2);

			Vertex _825 = new Vertex ("825", 45.49708779, -73.57911609);
			Vertices.Add (_825.id, _825);

			_820_1.AdjacentVertices.Add (_825);
			_825.AdjacentVertices.Add (_820_1);
			_820_2.AdjacentVertices.Add (_825);
			_825.AdjacentVertices.Add (_820_2);
			_823.AdjacentVertices.Add (_825);
			_825.AdjacentVertices.Add (_823);

			Vertex _827 = new Vertex ("827", 45.49711834, -73.57918046);
			Vertices.Add (_827.id, _827);

			_825.AdjacentVertices.Add (_827);
			_827.AdjacentVertices.Add (_825);

			Vertex _829 = new Vertex ("829", 45.49716158, -73.57927166);
			Vertices.Add (_829.id, _829);

			_827.AdjacentVertices.Add (_829);
			_829.AdjacentVertices.Add (_827);

			Vertex _831 = new Vertex ("831", 45.49719824, -73.57934073);
			Vertices.Add (_831.id, _831);

			_829.AdjacentVertices.Add (_831);
			_831.AdjacentVertices.Add (_829);

			Vertex _833 = new Vertex ("833", 45.49719824, -73.57934073);
			Vertices.Add (_833.id, _833);

			_831.AdjacentVertices.Add (_833);
			_833.AdjacentVertices.Add (_831);

			Vertex _835 = new Vertex ("835", 45.49725464, -73.57927904);
			Vertices.Add (_835.id, _835);

			_833.AdjacentVertices.Add (_835);
			_835.AdjacentVertices.Add (_833);

			Vertex _832 = new Vertex ("832", 45.49730212, -73.57923612);
			Vertices.Add (_832.id, _832);

			_832.AdjacentVertices.Add (_835);
			_835.AdjacentVertices.Add (_832);

			Vertex _837 = new Vertex ("837", 45.49730212, -73.57923612);
			Vertices.Add (_837.id, _837);

			_835.AdjacentVertices.Add (_837);
			_837.AdjacentVertices.Add (_835);

			Vertex _837_838_841_ = new Vertex ("_837_838_841_", 45.49735476, -73.57918583);
			Vertices.Add (_837_838_841_.id, _837_838_841_);

			_837.AdjacentVertices.Add (_837_838_841_);
			_837_838_841_.AdjacentVertices.Add (_837);

			Vertex _841 = new Vertex ("_841", 45.49740223, -73.57913688);
			Vertices.Add (_841.id, _841);

			_837_838_841_.AdjacentVertices.Add (_841);
			_841.AdjacentVertices.Add (_837_838_841_);

			Vertex _843 = new Vertex ("_843", 45.4974544, -73.57908793);
			Vertices.Add (_843.id, _843);

			_841.AdjacentVertices.Add (_843);
			_843.AdjacentVertices.Add (_841);

			Vertex _845 = new Vertex ("_845", 45.49750516, -73.579043);
			Vertices.Add (_845.id, _845);

			_843.AdjacentVertices.Add (_845);
			_845.AdjacentVertices.Add (_843);

			Vertex _847 = new Vertex ("_847", 45.49754088, -73.57900947);
			Vertices.Add (_847.id, _847);

			_845.AdjacentVertices.Add (_847);
			_847.AdjacentVertices.Add (_845);

			Vertex _849 = new Vertex ("_849", 45.4975611, -73.57899472);
			Vertices.Add (_849.id, _849);

			_847.AdjacentVertices.Add (_849);
			_849.AdjacentVertices.Add (_847);

			Vertex _851 = new Vertex ("_851", 45.4975611, -73.57899472);
			Vertices.Add (_851.id, _851);

			_849.AdjacentVertices.Add (_851);
			_851.AdjacentVertices.Add (_849);

			Vertex _853 = new Vertex ("_853", 45.49752208, -73.57891627);
			Vertices.Add (_853.id, _853);

			_851.AdjacentVertices.Add (_853);
			_853.AdjacentVertices.Add (_851);

			Vertex _852 = new Vertex ("_852", 45.49750046, -73.57887);
			Vertices.Add (_852.id, _852);

			_852.AdjacentVertices.Add (_853);
			_853.AdjacentVertices.Add (_852);

			Vertex _854 = new Vertex ("_854", 45.49750046, -73.57887);
			Vertices.Add (_854.id, _854);

			_852.AdjacentVertices.Add (_854);
			_854.AdjacentVertices.Add (_852);

			Vertex _855 = new Vertex ("_855", 45.49748025, -73.57882842);
			Vertices.Add (_855.id, _855);

			_854.AdjacentVertices.Add (_855);
			_855.AdjacentVertices.Add (_854);

			Vertex _857 = new Vertex ("_857", 45.49744453, -73.57875668);
			Vertices.Add (_857.id, _857);

			_855.AdjacentVertices.Add (_857);
			_857.AdjacentVertices.Add (_855);

			Vertex _859 = new Vertex ("_859", 45.4974121, -73.57868828);
			Vertices.Add (_859.id, _859);

			_857.AdjacentVertices.Add (_859);
			_859.AdjacentVertices.Add (_857);

			Vertex _860 = new Vertex ("_860", 45.49736322, -73.57873254);
			Vertices.Add (_860.id, _860);

			_859.AdjacentVertices.Add (_860);
			_860.AdjacentVertices.Add (_859);

			Vertex _862 = new Vertex ("_862", 45.49730729, -73.57878819);
			Vertices.Add (_862.id, _862);

			_860.AdjacentVertices.Add (_862);
			_862.AdjacentVertices.Add (_860);

			Vertex _861 = new Vertex ("_861", 45.49739001, -73.57863531);
			Vertices.Add (_861.id, _861);

			_859.AdjacentVertices.Add (_861);
			_861.AdjacentVertices.Add (_859);

			Vertex _863 = new Vertex ("_863", 45.49734395, -73.57855484);
			Vertices.Add (_863.id, _863);

			_861.AdjacentVertices.Add (_863);
			_863.AdjacentVertices.Add (_861);

			Vertex _865 = new Vertex ("_865", 45.49734395, -73.57855484);
			Vertices.Add (_865.id, _865);

			_863.AdjacentVertices.Add (_865);
			_865.AdjacentVertices.Add (_863);

			Vertex _867 = new Vertex ("_867", 45.49734395, -73.57855484);
			Vertices.Add (_867.id, _867);

			_865.AdjacentVertices.Add (_867);
			_867.AdjacentVertices.Add (_865);
			_867.AdjacentVertices.Add (_801);
			_801.AdjacentVertices.Add (_867);



			Vertex _838 = new Vertex ("_838", 45.49732562, -73.57911609);
			Vertices.Add (_838.id, _838);

			_837_838_841_.AdjacentVertices.Add (_838);
			_838.AdjacentVertices.Add (_837_838_841_);

			Vertex _806_838_862_ = new Vertex ("_806_838_862_", 45.49721046, -73.57888877);
			Vertices.Add (_806_838_862_.id, _806_838_862_);

			_806_838_862_.AdjacentVertices.Add (_806);
			_806_838_862_.AdjacentVertices.Add (_838);
			_806_838_862_.AdjacentVertices.Add (_862);

			_806.AdjacentVertices.Add (_806_838_862_);
			_838.AdjacentVertices.Add (_806_838_862_);
			_862.AdjacentVertices.Add (_806_838_862_);

		}

	}
}