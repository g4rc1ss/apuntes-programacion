using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interoperability.Rust;

public class UseRustInterop
{
    public unsafe void Execute()
    {
        MyStruct myStruct = RustLibNative.CreateStruct(1, 200.3d);

        nint ptrVar = RustLibNative.CreateStructPtr(1, 300d);
        MyStruct structWithPointer = Unsafe.Read<MyStruct>(ptrVar.ToPointer());
        structWithPointer.a = 2;
        Unsafe.Write(ptrVar.ToPointer(), structWithPointer);

        RustLibNative.DeleteStructPtr(ptrVar);
    }
}

internal static partial class RustLibNative
{
    [LibraryImport("./Rust/libLibreriaRustInteropCsharp", EntryPoint = "create_struct")]
    internal static partial MyStruct CreateStruct(int a, double b);

    [LibraryImport("./Rust/libLibreriaRustInteropCsharp", EntryPoint = "create_struct_ptr")]
    internal static partial IntPtr CreateStructPtr(int a, double b);

    [LibraryImport("./Rust/libLibreriaRustInteropCsharp", EntryPoint = "destroy_struct_ptr")]
    internal static partial void DeleteStructPtr(nint ptr);
}

internal struct MyStruct
{
    internal int a;
    internal double b;
}
