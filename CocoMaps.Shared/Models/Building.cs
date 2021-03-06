﻿using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace CocoMaps.Shared
{

	public class Building
	{
		
		public string Code {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Campus {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}

		public Position Position {
			get;
			set;
		}

		public bool HasAtm {
			get;
			set;
		}

		public bool HasParkingLot {
			get;
			set;
		}

		public bool HasBikeRack {
			get;
			set;
		}

		public bool HasInfoKiosk {
			get;
			set;
		}

		public bool HasAccessibility {
			get;
			set;
		}

		public string ShapeCoords {
			get;
			set;
		}

		public List<Service> Services {
			get;
			set;
		}

		public List<Department> Departments {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[Building: Code = {0}, Name = {1}, Address = {2}]", Code, Name, Address);
		}
	}
}