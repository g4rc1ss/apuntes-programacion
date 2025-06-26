using DeferredExecutionYield.ExplicitEnumerator.AsyncEnumerableClass;
using DeferredExecutionYield.ExplicitEnumerator.EnumerableClass;
using DeferredExecutionYield.YieldEnumerator;

IEnumerable<int>? yieldEnumerable = new YieldExecution().GetEnumerableWithYield();
IAsyncEnumerable<int>? asyncYield = new YieldExecution().GetAsyncEnumerableWithYieldAsync();

foreach (int item in yieldEnumerable) { }

await foreach (int item in asyncYield) { }

ExplicitEnumerable? enumerableExplicito = new();
ExplicitAsyncEnumerable? enumerableAsincronoExplicito = new();

foreach (int item in enumerableExplicito) { }

await foreach (int item in enumerableAsincronoExplicito) { }

Console.WriteLine("Teclee para cerrar la ventana...");
Console.Read();
