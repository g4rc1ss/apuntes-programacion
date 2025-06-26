using System.Security.Cryptography;
using System.Text;

namespace HashTables;

public class HashTables<TKey, TValue>
{
    private int _size;
    private ObjectKeyValue[] _data;
    private int[] _hashIndex;

    public HashTables()
    {
        _data = new ObjectKeyValue[3];
        _hashIndex = [.. Enumerable.Range(0, 3).Select(x => -1)];
    }

    public void Add(TKey key, TValue value)
    {
        ArgumentNullException.ThrowIfNull(key);

        bool existsValue = TryGet(key).exists;
        if (existsValue)
        {
            throw new KeyNotFoundException("Key was not found");
        }

        // Verificamos el tamaño de los array
        if (_size == _data.Length)
        {
            Resize();
        }

        int hash = GetHashCode(key);
        uint indexHash = GetIndexHash(hash);
        int dataIndex = _hashIndex[indexHash];

        _data[_size].key = key;
        _data[_size].value = value;
        _data[_size].hashCode = (uint)hash;
        _data[_size].next = -1;

        if (dataIndex > -1)
        {
            ObjectKeyValue dataIndexValue = _data[dataIndex];
            while (true)
            {
                int next = dataIndexValue.next;

                if (next == -1 && dataIndexValue.hashCode != 0)
                {
                    _data[dataIndex].next = _size;
                    break;
                }

                if (dataIndexValue.hashCode == 0)
                {
                    _hashIndex[indexHash] = _size;
                    break;
                }

                dataIndexValue = _data[next];
            }
        }
        else
        {
            _hashIndex[indexHash] = _size;
        }

        _size++;
    }

    private void Resize()
    {
        Array.Resize(ref _data, _data.Length * 2);
        Array.Resize(ref _hashIndex, _hashIndex.Length * 2);
        RehashData();
    }

    private void RehashData()
    {
        ObjectKeyValue[]? copyData = new ObjectKeyValue[this._data.Length];
        Array.Copy(_data, copyData, copyData.Length);
        Array.Clear(_data);
        Array.Clear(_hashIndex);
        _hashIndex = [.. Enumerable.Range(0, _hashIndex.Length).Select(x => -1)];
        int oldSize = _size;
        _size = 0;

        for (int i = 0; i < oldSize; i++)
        {
            Add(copyData[i].key, copyData[i].value);
        }
    }

    public TValue Get(TKey key)
    {
        (TValue? value, _) = TryGet(key);
        return value;
    }

    private (TValue value, bool exists) TryGet(TKey key)
    {
        ArgumentNullException.ThrowIfNull(key);

        int hash = GetHashCode(key);
        uint indexHash = GetIndexHash(hash);
        int index = _hashIndex[indexHash];
        if (index == -1)
        {
            return default;
        }

        ObjectKeyValue objectKeyValue = _data[index];
        // Verificamos si la key existe
        while (true)
        {
            if ((uint)hash == objectKeyValue.hashCode)
            {
                return (objectKeyValue.value, true);
            }

            if (objectKeyValue.next == -1)
            {
                break;
            }

            if (objectKeyValue.next == 0 && objectKeyValue.hashCode == 0)
            {
                break;
            }

            objectKeyValue = _data[objectKeyValue.next];
        }

        return default;
    }

    private int GetHashCode(TKey key)
    {
        if (typeof(TKey).IsValueType)
        {
            return key.GetHashCode();
        }

        if (key is string stringKey)
        {
            using SHA256? sha256 = SHA256.Create();
            byte[]? hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringKey));
            return BitConverter.ToInt32(hash, 0);
        }

        return EqualityComparer<TKey>.Default.GetHashCode(key);
    }

    // Metodo copiado de la clase Dictionary
    private uint GetIndexHash(int hash)
    {
        return (uint)hash % (uint)_hashIndex.Length;
    }

    private struct ObjectKeyValue
    {
        public TKey key = default!;
        public TValue value = default!;
        public uint hashCode;
        public int next;

        public ObjectKeyValue()
        {
            hashCode = 0;
            next = -1;
        }
    }
}
