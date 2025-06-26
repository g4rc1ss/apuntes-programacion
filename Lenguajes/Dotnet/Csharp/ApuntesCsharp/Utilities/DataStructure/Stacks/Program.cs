using Stacks;

int[]? arrayElementos = [5, 2, 3, 4, 5];

StackCollection<int>? queue = new(arrayElementos);
queue.Push(1);
int result = queue.Pop();

Console.WriteLine(result == 1);

List<int>? list = [.. queue];

Console.WriteLine(string.Join(", ", list));

StackCollection<int>? queue2 = new();
queue2.Push(1);
queue2.Push(2);
int valor = queue2.Pop();
Console.WriteLine(valor == 2);
queue2.Push(5);
_ = queue2.ToList();

Console.WriteLine(string.Join(", ", queue2));
