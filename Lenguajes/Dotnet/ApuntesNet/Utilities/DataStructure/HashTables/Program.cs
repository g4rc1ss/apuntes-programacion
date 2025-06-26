using HashTables;

Dictionary<string, string>? dictionary = [];

if (true)
{
    dictionary.Add("0", "value1");
    dictionary.Add("1", "value1");
    dictionary.Add("2", "value1");
    dictionary.Add("Mundo3", "value1");
    dictionary.Add("Mundo4", "value1");
}

dictionary.TryGetValue("Mundo", out string? value);
Console.WriteLine(value);

HashTables<string, int>? hashTable = new();

for (int i = 0; i < 100; i++)
{
    hashTable.Add(i.ToString(), i);
}

hashTable.Get("50");
hashTable.Get("63");
hashTable.Get("30");
