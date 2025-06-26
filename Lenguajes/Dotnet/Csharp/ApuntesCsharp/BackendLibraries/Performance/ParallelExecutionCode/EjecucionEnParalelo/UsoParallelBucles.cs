namespace ParallelExecutionCode.EjecucionEnParalelo;

internal class UsoParallelBucles
{
    // Info en la teoria ubicada en BackEnd > Sintaxis > Teoria > 2_UsoAvanzado
    public void BucleFor()
    {
        Parallel.For(
            0,
            10000,
            (i, state) => Console.WriteLine($"LAMBDA  --  {i}, {state.IsStopped}")
        );
    }

    public void BucleForEach()
    {
        List<string>? listas = ["Hola", "Yo", "Me", "Llamo", "Ralph"];

        ParallelOptions? option = new() { MaxDegreeOfParallelism = 2 };

        Parallel.ForEach(
            listas,
            option,
            (linea, state) =>
            {
                if (state.IsStopped)
                {
                    state.Stop();
                    return;
                }
                Console.WriteLine($"ForEach LAMBDA  --  {linea}");
            }
        );
    }
}
