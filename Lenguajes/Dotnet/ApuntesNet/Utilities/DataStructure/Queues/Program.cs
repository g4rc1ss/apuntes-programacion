int[]? arrayElementos = [5, 2, 3, 4, 5];

Queues.Queue<int>? queue = new(arrayElementos);
queue.Enqueue(1);
int result = queue.Dequeue();

Console.WriteLine(result == 5);

List<int>? list = [.. queue];

Console.WriteLine(string.Join(", ", list));

Queues.Queue<int>? queue2 = new();
queue2.Enqueue(1);
queue2.Enqueue(2);
int valor = queue2.Dequeue();
Console.WriteLine(valor == 1);
queue2.Enqueue(5);
_ = queue2.ToList();

Console.WriteLine(string.Join(", ", queue2));
