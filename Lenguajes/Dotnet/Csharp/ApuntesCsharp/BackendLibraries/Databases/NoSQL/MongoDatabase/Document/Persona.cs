using MongoDB.Bson;

namespace MongoDatabase.Document;

internal class Persona
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public string? SubName { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
