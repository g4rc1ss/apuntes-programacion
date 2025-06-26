namespace ArbolBinario.Clase;

internal class BinaryTree<T>(T value)
{
    public BinaryTree<T>? Left { get; private set; }
    public BinaryTree<T>? Right { get; private set; }

    public void AddLeftSoon(T value)
    {
        Left = new BinaryTree<T>(value);
    }

    public void AddRightSoon(T value)
    {
        Right = new BinaryTree<T>(value);
    }

    public T GetValue()
    {
        return value;
    }
}

internal static class BinaryTreeExtensions
{
    public static List<T> GetPathOfValue<T>(this BinaryTree<T> root, T valueToSearch)
    {
        List<T>? listaValor = [root.GetValue()];

        if (root.GetValue()!.Equals(valueToSearch))
        {
            return listaValor;
        }

        if (root.Left is not null)
        {
            List<T>? listaLeft = GetPathOfValue(root.Left, valueToSearch);
            if (listaLeft.Contains(valueToSearch))
            {
                listaValor.AddRange(listaLeft);
            }
        }

        if (root.Right is not null)
        {
            List<T>? listaRight = GetPathOfValue(root.Right, valueToSearch);
            if (listaRight.Contains(valueToSearch))
            {
                listaValor.AddRange(listaRight);
            }
        }

        return listaValor;
    }
}
