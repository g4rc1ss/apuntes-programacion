using UnmanagedMemory;

MarshalWithUnsafe.Execute();
UnmanagedMemoryMarshal.Execute();

ArrayPoolShared.Execute();

UnsafeWithPointers.Execute();

UnsafeWithStackalloc.ExecuteWithPointers();
UnsafeWithStackalloc.ExecuteWithSpan();
UnsafeWithStackalloc.ExecuteWithMemory();

UnsafeWithFixed.Execute();
