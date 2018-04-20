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


##自環境のpython6.3で実行した結果

所要時間:0.6166858673095703[sec]

実行したコード

```
import pandas as pd
import numpy as np
import time


def multiply_to_int(x, y):
    return np.where(x > 0, (x * y + 0.0000001).astype(np.int), (x * y - 0.0000001).astype(np.int))

start = time.time()

df = pd.read_csv('i:\\test.csv')
df['z'] = multiply_to_int(df['x'].values, df['y'].values)
df_group = df[['a', 'z']].groupby('a').sum()
df_group['a'] = df_group.index
df_group[['a', 'z']].to_json('i:\\result.json', orient='records')

end = time.time()
print(f"所要時間:{end - start}[sec]")
```
