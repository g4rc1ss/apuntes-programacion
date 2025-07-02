using UnmanagedMemory;
using UnmanagedMemory.Marshalling;
using UnmanagedMemory.UnsafeContext;

MarshallWithClass.Execute();
MarshalWithStructs.Execute();
MarshalWithInt.Execute();

ArrayPoolShared.Execute();

UnsafeWithMarshallAndStructs.Execute();
UnsafeWithPointers.Execute();
UnsafeWithStackalloc.ExecuteWithPointers();
UnsafeWithStackalloc.ExecuteWithSpan();
UnsafeWithStackalloc.ExecuteWithMemory();
UnsafeWithFixed.Execute();
