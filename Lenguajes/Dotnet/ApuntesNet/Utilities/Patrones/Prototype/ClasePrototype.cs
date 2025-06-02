namespace Prototype;

public class ClasePrototype(string password) : ICloneable
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Age { get; set; }
    public DateTime FechaNacimiento { get; set; }

    public object Clone()
    {
        return new ClasePrototype(password)
        {
            Name = Name,
            Description = Description,
            Age = Age,
            FechaNacimiento = FechaNacimiento,
        };
    }

    public override string ToString()
    {
        return $"{Name} - {Description} - {Age} - {password}";
    }
}
