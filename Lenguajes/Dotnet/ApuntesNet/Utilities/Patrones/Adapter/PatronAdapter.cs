namespace Adapter;

// The Adapter makes the Adaptee's interface compatible with the Target's
// interface.
internal class PatronAdapter(Adaptar adaptar) : ITarget
{
    public string GetRequest()
    {
        return $"This is '{adaptar.GetSpecificRequest()}'";
    }
}
