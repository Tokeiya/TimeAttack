# TimeAttack

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
AMD Ryzen 7 1700X Eight-Core Processor, 1 CPU, 16 logical and 8 physical cores
Frequency=3314087 Hz, Resolution=301.7422 ns, Timer=TSC
.NET Core SDK=2.1.300-preview3-008627
  [Host]   : .NET Core 2.1.0-preview3-26411-06 (CoreCLR 4.6.26411.07, CoreFX 4.6.26411.06), 64bit RyuJIT
  ShortRun : .NET Core 2.1.0-preview3-26411-06 (CoreCLR 4.6.26411.07, CoreFX 4.6.26411.06), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|    Method |     Mean |      Error |    StdDev |
|---------- |---------:|-----------:|----------:|
| Optimized | 528.7 ms | 119.290 ms | 6.7401 ms |
