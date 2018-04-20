using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Optimized
{
	public class ByteArrayComp:IEqualityComparer<byte[]>
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct Integer
		{
			[FieldOffset(0)] public int Int;

			[FieldOffset(0)] public byte Byte0;

			[FieldOffset(1)] public byte Byte1;

			[FieldOffset(2)] public byte Byte2;

			[FieldOffset(3)] public byte Byte3;
		}

		public bool Equals(byte[] x, byte[] y)
		{
			var lx = x?.Length ?? -1;
			var ly = y?.Length ?? -1;

			if (lx != ly) return false;
			if (lx == -1) return true;

			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i]) return false;
			}

			return true;
		}

		public int GetHashCode(byte[] obj)
		{
			var hash=new Integer();

			for (int i = 0; i < obj.Length; i++)
			{
				switch (i%4)
				{
					case 0:
						hash.Byte0 ^= obj[i];
						break;

					case 1:
						hash.Byte1 ^= obj[i];
						break;

					case 2:
						hash.Byte2 ^= obj[i];
						break;

					case 3:
						hash.Byte3 ^= obj[i];
						break;
				}
			}

			return hash.Int;
		}
	}
}