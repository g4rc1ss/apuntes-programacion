using Caching.Distributed;
using Caching.Hybrid;
using Caching.Memory;

new MemoryCaching().MemoryCacheWithDI();

await new HybridMemory().HybridMemoryWithDiAsync();

await new DistributedMemory().DistributedMemoryWithDIAsync();
await new DistributedRedis().DistributedRedisAsync();


Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
