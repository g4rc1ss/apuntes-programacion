using LinkedLists;

LinkedObjectList<string>? listaNueva = new();
listaNueva.Add("A");
listaNueva.Add("B");

LinkedObjectList<string>? deep = listaNueva;
while (true)
{
    (string? value, LinkedObjectList<string>? nextNode) = deep.Get();
    Console.WriteLine(value);

    if (nextNode == null)
    {
        break;
    }

    deep = nextNode;
}
