using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InteroperabilidadConAsync;

// Creamos el delegado que vamos a enviar a la DLL
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void Callback(int response);

public class ClaseInteractuaRust
{
    [DllImport("libcallback.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern void prueba_callback(Callback callback);

    public async Task EjecutarDllAsync(CancellationToken cancellationToken = default)
    {
        TaskCompletionSource<int>? taskCompletionSource = new(
            TaskCreationOptions.RunContinuationsAsynchronously
        );

        void Callback(int response)
        {
            if (!taskCompletionSource.TrySetResult(response))
            {
                taskCompletionSource.SetException(
                    new Exception("No se puede insertar el resultado")
                );
            }

            Console.WriteLine(response);
        }

        Console.WriteLine(
            $"Hilo de Csharp antes de llamar a la libreria {Thread.CurrentThread.ManagedThreadId}"
        );
        prueba_callback(Callback);

        await using (
            cancellationToken.UnsafeRegister(
                static (task, ct) => ((TaskCompletionSource)task!).TrySetCanceled(ct),
                taskCompletionSource
            )
        )
        {
            Stopwatch? stopwatch = Stopwatch.StartNew();
            await taskCompletionSource.Task;
            stopwatch.Stop();
            Console.WriteLine(
                $"Hilo de Csharp despues de esperar con await {Thread.CurrentThread.ManagedThreadId}"
            );

            Console.WriteLine($"Han pasado {stopwatch.ElapsedMilliseconds}");
        }
    }
}
