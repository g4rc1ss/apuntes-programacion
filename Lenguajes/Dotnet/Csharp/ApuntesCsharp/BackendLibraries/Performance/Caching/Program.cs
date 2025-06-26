using Caching.Distributed;
using Caching.Hybrid;
using Caching.Memory;

new MemoryCaching().MemoryCacheWithDi();

await new HybridMemory().HybridMemoryWithDiAsync();

await new DistributedMemory().DistributedMemoryWithDiAsync();
await new DistributedRedis().DistributedRedisAsync();

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
