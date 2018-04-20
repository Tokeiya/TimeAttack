using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Optimized
{
	public struct Datum
	{
		private static ReadOnlySpan<char> Split(ref ReadOnlySpan<char> source)
		{
			int i;
			for (i = 0; i < source.Length; i++)
			{
				if(source[i]==',') break;
			}

			var ret = source.Slice(0, i);

			source = source.Slice(++i, source.Length - i);
			return ret;

		}

		private static void Skip(ref ReadOnlySpan<char> source)
		{
			int i;
			for (i = 0; i < source.Length; i++)
			{
				if (source[i] == ',') break;
			}

			source = source.Slice(++i, source.Length - i);

		}

		public static unsafe Datum CreateDatum(ReadOnlySpan<char> source)
		{
			var s = source;

			var a = Split(ref s);
			Skip(ref s);

			var x = double.Parse(Split(ref s), NumberStyles.AllowDecimalPoint);
			var y = double.Parse(s, NumberStyles.AllowDecimalPoint);

			var z = (int) (x > 0 ? x * y + 0.0000001 : x * y - 0.0000001);

			var ary = new byte[a.Length];

			for (int i = 0; i < ary.Length; i++)
			{
				ary[i] = (byte)a[i];
			}

			return new Datum(ary, z);
		}

		private Datum(byte[] a, int z)
		{
			A = a;
			Z = z;
		}

		public readonly byte[] A;
		public readonly int Z;
	}
}
