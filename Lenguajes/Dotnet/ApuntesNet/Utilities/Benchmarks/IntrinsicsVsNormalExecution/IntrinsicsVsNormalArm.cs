using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using BenchmarkDotNet.Attributes;

namespace IntrinsicsVsNormalExecution;

[MemoryDiagnoser]
public class IntrinsicsVsNormalArm
{
    [Params(1, 10, 100, 1000, 100000, 1000000)]
    public int iterations;

    private int[]? paramA;
    private int[]? paramB;

    [GlobalSetup]
    public void Setup()
    {
        paramA = [.. Enumerable.Range(0, iterations)];
        paramB = [.. Enumerable.Range(0, iterations)];
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsAndFixed()
    {
        int len = paramA.Length;
        int[]? result = new int[len];

        fixed (
            int* paramAPtr = paramA,
                paramBPtr = paramB,
                resultPtr = result
        )
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            for (int i = 0; i < len; i += Vector128<int>.Count)
            {
                int* nextAPrt = i + paramAPtr;
                int* nextBPrt = i + paramBPtr;
                int* nextResultPtr = i + resultPtr;

                Vector128<int> vecA = Vector128.Load(nextAPrt);
                Vector128<int> vecB = Vector128.Load(nextBPrt);

                // Llamada al procesador
                Vector128<int> vecResult = AdvSimd.Add(vecA, vecB);

                vecResult.Store(nextResultPtr);
            }
        }
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsWithMarshal()
    {
        IntPtr pointerA = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        IntPtr pointerB = Marshal.AllocHGlobal(sizeof(int) * paramB.Length);
        IntPtr resultPointer = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        int len = paramA.Length;

        try
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            Marshal.Copy(paramA, 0, pointerA, len);
            Marshal.Copy(paramB, 0, pointerB, len);

            for (int i = 0; i < len; i += Vector128<int>.Count)
            {
                int* nextAPrt = i + (int*)pointerA;
                int* nextBPrt = i + (int*)pointerB;
                int* nextResultPtr = i + (int*)resultPointer;

                Vector128<int> vecA = Vector128.Load(nextAPrt);
                Vector128<int> vecB = Vector128.Load(nextBPrt);

                // Llamada al procesador
                Vector128<int> vecResult = AdvSimd.Add(vecA, vecB);

                vecResult.Store(nextResultPtr);
            }
        }
        finally
        {
#if DEBUG
            for (int i = 0; i < len; i++)
            {
                int* nextResultPtr = i + (int*)resultPointer;
                Console.WriteLine(*nextResultPtr);
            }
#endif

            Marshal.FreeHGlobal(pointerA);
            Marshal.FreeHGlobal(pointerB);
            Marshal.FreeHGlobal(resultPointer);
        }
    }

    [Benchmark]
    public unsafe void SumArraysWithIntrinsicsWithMarshalWithoutCopy()
    {
        IntPtr resultPointer = Marshal.AllocHGlobal(sizeof(int) * paramA.Length);
        int len = paramA.Length;
        int* resultPtr = (int*)resultPointer;

        try
        {
            if (!AdvSimd.IsSupported)
            {
                throw new PlatformNotSupportedException();
            }

            fixed (
                int* paramAPtr = paramA,
                    paramBPtr = paramB
            )
            {
                for (int i = 0; i < len; i += Vector128<int>.Count)
                {
                    int* nextAPrt = i + paramAPtr;
                    int* nextBPrt = i + paramBPtr;
                    int* nextResultPtr = i + resultPtr;

                    Vector128<int> vecA = Vector128.Load(nextAPrt);
                    Vector128<int> vecB = Vector128.Load(nextBPrt);

                    // Llamada al procesador
                    Vector128<int> vecResult = AdvSimd.Add(vecA, vecB);

                    vecResult.Store(nextResultPtr);
                }
            }
        }
        finally
        {
#if DEBUG
            for (int i = 0; i < len; i++)
            {
                int* nextResultPtr = i + (int*)resultPointer;
                Console.WriteLine(*nextResultPtr);
            }
#endif
            Marshal.FreeHGlobal(resultPointer);
        }
    }

    [Benchmark]
    public void SumArrays()
    {
        int[]? result = new int[paramA.Length];

        for (int i = 0; i < paramA.Length; i++)
        {
            result[i] = paramA[i] + paramB[i];
        }
    }
}
