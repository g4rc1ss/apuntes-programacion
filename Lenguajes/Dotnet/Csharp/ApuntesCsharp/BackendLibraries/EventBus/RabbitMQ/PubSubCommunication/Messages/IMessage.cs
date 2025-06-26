namespace PubSubCommunication.Messages;

public interface IMessage
{
    public string MessageIdentifier { get; }
    public string Name { get; }
    public MessageDiagnosticTraces Traces { get; }
}
