using System.Collections.Generic;
using System.IO;

namespace Optimized
{
	public static class Loader
	{
		public static List<Datum> LoadAsList(string path)
		{
			var rdr = new LineReader(File.ReadAllBytes(path));

			var ret = new List<Datum>();

			for (;;)
			{
				var piv = rdr.ReadLine();
				if (piv.IsEmpty) break;

				ret.Add(Datum.CreateDatum(piv));
			}

			return ret;
		}

		public static Datum[] LoadAsArray(string path)
		{
			var rdr = new LineReader(File.ReadAllBytes(path));

			var ret = new List<Datum>();

			for (;;)
			{
				var piv = rdr.ReadLine();
				if (piv.IsEmpty) break;

				ret.Add(Datum.CreateDatum(piv));
			}

			return ret.ToArray();
		}
	}
}