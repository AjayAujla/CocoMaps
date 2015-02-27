using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using CocoMaps.Models;
using Xamarin.Forms;
using System.Linq;

namespace CocoMaps.Shared
{
	/// <summary>
	/// CocoMaps placeholder.
	/// </summary>
	public static class CocoMapsApp
	{
		static Assembly _reflectionAssembly;
		internal static IDictionary<Type,Type> TypeMap;
		internal static readonly MethodInfo GetDependency;

		static CocoMapsApp ()
		{
			TypeMap = new Dictionary<Type, Type> {
				{ typeof(Location_MenuOption), typeof(Location_MenuOption) },
				{ typeof(Campus_MenuOption), typeof(Campus_MenuOption) },
				{ typeof(pInterest_MenuOption), typeof(pInterest_MenuOption) },
				{ typeof(bDirections_MenuOption), typeof(bDirections_MenuOption) },
				{ typeof(iDirections_MenuOption), typeof(iDirections_MenuOption) },
				{ typeof(Calendar_MenuOption), typeof(Calendar_MenuOption) },
				{ typeof(Settings_MenuOption), typeof(Settings_MenuOption) },
			};

			GetDependency = typeof(DependencyService)
				.GetRuntimeMethods ()
				.Single ((method) =>
					method.Name.Equals ("Get"));
		}

		public static void Init (Assembly assembly)
		{
			System.Threading.Interlocked.CompareExchange (ref _reflectionAssembly, assembly, null);
		}

		public static Stream LoadResource (String name)
		{
			return _reflectionAssembly.GetManifestResourceStream (name);
		}
	}
}