namespace LinkedLists;

public class LinkedObjectList<TValue>
{
    private TValue? _value;
    private LinkedObjectList<TValue>? _nextNode;

    public LinkedObjectList() { }

    private LinkedObjectList(TValue newValue)
    {
        _value = newValue;
    }

    public void Add(TValue newValue)
    {
        if (_value == null)
        {
            _value = newValue;
            return;
        }

        if (_nextNode == null)
        {
            _nextNode = new LinkedObjectList<TValue>(newValue);
        }
        else
        {
            _nextNode.Add(newValue);
        }
    }

    public (TValue? value, LinkedObjectList<TValue>? nextNode) Get()
    {
        return (_value, _nextNode);
    }
}
