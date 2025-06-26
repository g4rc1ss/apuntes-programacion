namespace ThreadsManagement.Hilos;

public static class ThreadsM
{
    public static Thread StartThread()
    {
        Thread thread = new(() =>
        {
            for (int x = 0; x < 1000; x++)
            {
                Console.WriteLine("hilo1");
            }
        });

        thread.Start();

        return thread;
    }

    public static void WaitThread(Thread thread)
    {
        thread.Join();
    }
}
