namespace ConfigurePermissionWithBitwise;

[Flags]
public enum PermissionWithBitWise
{
    None = 0, // 0b0000
    View = 1 << 0, // 0b0001
    Create = 1 << 1, // 0b0010
    Edit = 1 << 2, // 0b0100
    Delete = 1 << 3, // 0b1000,
    IsAdmin = 1 << 4, // 0b10000
}
