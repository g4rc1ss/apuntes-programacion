using Proxy;

Client? client = new();

// Ejecutamos con el codigo del usuario
Console.WriteLine("Client: Executing the client code with a real subject:");
RealSubject? realSubject = new();
client.ClientCode(realSubject);

Console.WriteLine();

// Intermediario que antes y despues de la ejecucion del codigo, realiza ciertas acciones.
// Es un Middleware en realidad
Console.WriteLine("Client: Executing the same client code with a proxy:");
PatronProxy? proxy = new(realSubject);
client.ClientCode(proxy);

Console.ReadKey();
