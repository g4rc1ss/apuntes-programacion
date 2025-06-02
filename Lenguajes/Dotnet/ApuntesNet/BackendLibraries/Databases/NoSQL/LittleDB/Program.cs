using LiteDB;
using LittleDB;

using LiteDatabase? liteDb = new("Filename=./database.db;Password=1234");

ILiteCollection<User>? userCollection = liteDb.GetCollection<User>("Users");

User? user = new() { Username = "prueba", PhoneNumber = "748347384738" };
userCollection.Insert(user);

User? resultFindOne = userCollection.FindOne(x => x.Username == "prueba");
Console.WriteLine(resultFindOne.Username);

user.Username = "Prueba de modificacion";
userCollection.Update(user);

// Establecemos este campo como un indice para hacer la busqueda de forma mas optima
userCollection.EnsureIndex(x => x.Username);

User? resultQuery = userCollection
    .Query()
    .Where(x => x.Username == "Prueba de modificacion")
    .FirstOrDefault();

Console.WriteLine(resultQuery.Username);
