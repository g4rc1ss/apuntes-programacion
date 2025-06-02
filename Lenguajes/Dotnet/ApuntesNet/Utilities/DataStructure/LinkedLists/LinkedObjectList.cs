namespace LinkedLists;

public class LinkedObjectList<TValue>
{
    private TValue? value;
    private LinkedObjectList<TValue>? nextNode;

    public LinkedObjectList() { }

    private LinkedObjectList(TValue newValue)
    {
        value = newValue;
    }

    public void Add(TValue newValue)
    {
        if (value == null)
        {
            value = newValue;
            return;
        }

        if (nextNode == null)
        {
            nextNode = new LinkedObjectList<TValue>(newValue);
        }
        else
        {
            nextNode.Add(newValue);
        }
    }

    public (TValue? value, LinkedObjectList<TValue>? nextNode) Get()
    {
        return (value, nextNode);
    }
}
