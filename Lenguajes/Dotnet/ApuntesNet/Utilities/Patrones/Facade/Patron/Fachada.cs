using Facade.CodigoComplejo;

namespace Facade.Patron;

public class Fachada
{
    protected Subsystem1 subsystem1;

    protected Subsystem2 subsystem2;

    public Fachada()
    {
        subsystem1 = new();
        subsystem2 = new();
    }

    // Esto ejecuta de forma invisible al usuario un proceso mas complejo de clases, etc.
    public string Operation()
    {
        string? result =
            $"Facade initializes subsystems:\n"
            + $"{subsystem1.Operation1()}"
            + $"{subsystem2.Operation1()}"
            + $"Facade orders subsystems to perform the action:\n"
            + $"{subsystem1.OperationN()}"
            + $"{subsystem2.OperationZ()}";
        return result;
    }
}
