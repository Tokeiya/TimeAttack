using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Optimized
{
	[ShortRunJob]
	public class MyBench
	{
		[Benchmark]
		public int ReadAll()
		{
			int i;
			var accum = 0;
			var rdr = new LineReader(File.ReadAllBytes("I:\\test.csv"));
			for (i = 0;; i++)
			{
				var scr = rdr.ReadLine();
				if (scr.Length == 0) break;

				var d = Datum.CreateDatum(scr);
				accum += d.Z;
			}

			return accum;
		}

		[Benchmark]
		public int ReadList()
		{
			var ret = Loader.LoadAsList("I:\\test.csv");

			var accum = 0;
			foreach (var datum in ret) accum += datum.Z;

			return accum;
		}

		[Benchmark]
		public int ReadArray()
		{
			var ret = Loader.LoadAsArray("I:\\test.csv");

			var accum = 0;
			foreach (var datum in ret) accum += datum.Z;

			return accum;
		}

		[Benchmark]
		public void Optimized()
		{
			var ret = Loader.LoadAsArray("I:\\test.csv");

			var dict = new Dictionary<byte[], int>(new ByteArrayComp());

			var accum = new int[ret.Length];
			var idx = -1;


			foreach (var datum in ret)
				if (dict.TryGetValue(datum.A, out var i))
				{
					accum[i] += datum.Z;
				}
				else
				{
					dict.Add(datum.A, ++idx);
					accum[idx] += datum.Z;
				}

			Writer.Write("I:\\hoge.json", dict, accum);

		}
	}

	internal class Program
	{
		private static void Main(string[] args)
		{
			var conf = DefaultConfig.Instance
				.With(MarkdownExporter.GitHub)
				.With(Job.ShortRun);

			BenchmarkRunner.Run<MyBench>(conf);
		}
	}
}