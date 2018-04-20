using System;

namespace Optimized
{
	public ref struct LineReader
	{
		private ReadOnlySpan<char> _source;

		public unsafe LineReader(byte[] source)
		{
			var buff = new char[source.Length];

			fixed (byte* scr = source)
			fixed (char* dest = buff)
			{
				for (var i = 0; i < source.Length; i++) dest[i] = (char) scr[i];
			}

			_source = new ReadOnlySpan<char>(buff, 9, source.Length - 9);
		}


		public ReadOnlySpan<char> ReadLine()
		{
			int i;

			for (i = 0; i < _source.Length; i++)
				if (_source[i] == '\r')
					break;

			if (i == 0) return default;

			var ret = _source.Slice(0, i);

			i += 2;
			_source = _source.Slice(i, _source.Length - i);

			return ret;
		}
	}
}