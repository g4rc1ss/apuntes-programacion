using Adapter;

Adaptar? adaptadar = new();
ITarget target = new PatronAdapter(adaptadar);

Console.WriteLine("El objeto de la clase Adaptar que nos viene, no es compatible con el cliente");
Console.WriteLine("Pero gracias a la clase PatronAdapter, conseguimos que lo sea");

Console.WriteLine(target.GetRequest());

Console.ReadKey();
