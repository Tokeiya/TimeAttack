using System;
using System.Collections.Generic;
using System.IO;

namespace Optimized
{
	public static class Writer
	{
		public static void Write(string path, Dictionary<byte[], int> scr, int[] accum)
		{
			Span<byte> lb = stackalloc byte[1];
			lb[0] = (byte) '[';


			Span<byte> rb = stackalloc byte[1];
			rb[0] = (byte) ']';


			Span<byte> begin = stackalloc byte[6];
			begin[0] = (byte) '{';
			begin[1] = (byte) '"';
			begin[2] = (byte) 'a';
			begin[3] = (byte) '"';
			begin[4] = (byte) ':';
			begin[5] = (byte) '"';

			Span<byte> sum = stackalloc byte[8];
			sum[0] = (byte) '"';
			sum[1] = (byte) ',';
			sum[2] = (byte) '"';
			sum[3] = (byte) 's';
			sum[4] = (byte) 'u';
			sum[5] = (byte) 'm';
			sum[6] = (byte) '"';
			sum[7] = (byte) ':';


			Span<byte> end = stackalloc byte[2];
			end[0] = (byte) '}';
			end[1] = (byte) ',';

			Span<byte> buff = stackalloc byte[10];


			using (var str = new FileStream(path, FileMode.Create))
			{
				str.Write(lb);

				foreach (var elem in scr)
				{
					str.Write(begin);
					str.Write(elem.Key);
					str.Write(sum);

					var i = accum[elem.Value];
					var idx = 10;

					do
					{
						buff[--idx] = (byte) (i % 10 + 0x30);
					} while ((i /= 10) != 0);

					var num = buff.Slice(idx, 10 - idx);

					str.Write(num);
					str.Write(end);
				}

				str.SetLength(str.Length - 1);
				str.Write(rb);
			}
		}
	}

	public static class Loader
	{
		public static List<Datum> LoadAsList(string path)
		{
			var rdr = new LineReader(File.ReadAllBytes("I:\\test.csv"));

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
			var rdr = new LineReader(File.ReadAllBytes("I:\\test.csv"));

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