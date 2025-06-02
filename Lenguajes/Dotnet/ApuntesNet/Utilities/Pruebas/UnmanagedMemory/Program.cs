using UnmanagedMemory;

UnmanagedMemoryMarshal.Execute();

UnsafeWithPointers.Execute();

UnsafeWithStackalloc.ExecuteWithPointers();
UnsafeWithStackalloc.ExecuteWithSpan();
UnsafeWithStackalloc.ExecuteWithMemory();

UnsafeWithFixed.Execute();
