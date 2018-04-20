using System;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			Span<byte> buff = stackalloc byte[10];

			var idx = 10;

			var i = 114514;

			do
			{
				buff[--idx] = (byte) ((i % 10) + 0x30);

			} while ((i /= 10) != 0);

			var hoge = buff.Slice(idx, 10 - idx);




		}
	}
}
