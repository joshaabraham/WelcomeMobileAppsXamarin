using System;
namespace MobileApps
{
	public static class AssemblyGlobal
	{
		public const string Company = "UXDivers";

		public const string ProductLine = "Grial UIKit";

		public const string Year = "2017";

		public const string Copyright = Company + " - " + Year;

#if DEBUG
		public const string Configuration = "Debug";
#elif RELEASE
		public const string Configuration = "Release";
#else
		public const string Configuration = "Unkown";
#endif
	}
}
