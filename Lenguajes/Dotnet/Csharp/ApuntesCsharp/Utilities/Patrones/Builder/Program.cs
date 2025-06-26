using Builder.Query;
using Builder.Query.Extensions;

PatronBuilder? claseImplementaBuilder1 = new();
PatronBuilder? claseImplementaBuilder2 = new();
PatronBuilder? claseImplementaBuilder3 = new();

string? query1 = claseImplementaBuilder1
    .Select("Id")
    .From("table")
    .Where("1 = 1")
    .OrderBy("Id")
    .Build();

string? query2 = claseImplementaBuilder2.From("table").Build();

string? query3 = claseImplementaBuilder3.Select("Hola").From("tableFrom").Build();

Console.WriteLine(query1);
Console.WriteLine(query2);
Console.WriteLine(query3);

Console.ReadKey();
