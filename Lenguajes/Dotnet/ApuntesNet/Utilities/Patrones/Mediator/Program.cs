using Mediator;

/**
 * Consiste en crear una entidad intermediaria que se encargue de gestionar la comunicación entre objetos.
 * En primer lugar definiremos una interfaz para exponer las operaciones que un intermediario puede realizar,
 * la cual llamaremos Mediator. Como es evidente debemos implementar dicha interfaz mediante una clase ConcreteMediator
 * para dotar a éste de funcionalidad.
 *
 *
 */

Component1? component1 = new();
Component2? component2 = new();
new ConcreteMediator(component1, component2);

Console.WriteLine("Client triggets operation A.");
component1.DoA();

Console.WriteLine();

Console.WriteLine("Client triggers operation D.");
component2.DoD();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
