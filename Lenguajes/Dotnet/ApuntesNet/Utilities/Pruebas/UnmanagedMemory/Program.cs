using UnmanagedMemory;

MarshalWithUnsafe.Execute();
UnmanagedMemoryMarshal.Execute();

UnsafeWithPointers.Execute();

UnsafeWithStackalloc.ExecuteWithPointers();
UnsafeWithStackalloc.ExecuteWithSpan();
UnsafeWithStackalloc.ExecuteWithMemory();

UnsafeWithFixed.Execute();
