namespace UnmanagedMemory;

public static class UnsafeWithFixed
{
    public static void Execute()
    {
        unsafe
        {
            int[]? numbers = new int[1000000];
            fixed (int* ptr = numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    ptr[i] = 1 * sizeof(int);
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"{ptr[i]}");
                }
            }
        }
    }
}
