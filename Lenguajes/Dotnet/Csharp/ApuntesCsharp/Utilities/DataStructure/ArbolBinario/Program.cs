using ArbolBinario.Clase;

BinaryTree<int>? arbolParaPrueba = CrearArbolConDatosPrueba();
List<int>? path5 = arbolParaPrueba.GetPathOfValue(5);
List<int>? path4 = arbolParaPrueba.GetPathOfValue(4);

for (int i = 0; i < (path4.Count < path5.Count ? path4.Count : path5.Count); i++)
{
    if (path4[i] != path5[i])
    {
        Console.WriteLine($"El superior en comun es {path4[i - 1]}");
        break;
    }
}

static BinaryTree<int> CrearArbolConDatosPrueba()
{
    BinaryTree<int>? arbol = new(1);
    // Agregar los hijos izquierdos
    arbol.AddLeftSoon(2);
    arbol.Left.AddLeftSoon(3);
    arbol.Left.AddRightSoon(4);
    arbol.Left.Left.AddLeftSoon(5);

    // Agregar los hijos Derechos
    arbol.AddRightSoon(6);
    arbol.Right.AddLeftSoon(7);
    arbol.Right.AddRightSoon(8);

    return arbol;
}
